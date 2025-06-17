using System;
using MapEdit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectTower.director.bloom;

public class BloomComponent
{
	public enum IntermediateBuffer
	{
		PreBloom,
		BlurredHorizontally,
		BlurredBothWays,
		FinalResult
	}

	private static IntermediateBuffer showBuffer = IntermediateBuffer.FinalResult;

	private static GraphicsDevice dev;

	private static Effect bloomExtractEffect;

	private static Effect bloomCombineEffect;

	private static Effect gaussianBlurEffect;

	private static RenderTarget2D renderTarget1;

	private static RenderTarget2D renderTarget2;

	public static float baseSat;

	public static float bloomBase;

	public static float bloomIntensity;

	public static float bloomSat;

	public static float bloomThreshhold;

	public static float bloomVignette;

	public static float floorValue;

	public static float lightRed;

	public static float lightThresh;

	public static float lightBlue;

	public static float lightFac;

	public static float lightDesat;

	public static float darkBlur;

	public IntermediateBuffer ShowBuffer
	{
		get
		{
			return showBuffer;
		}
		set
		{
			showBuffer = value;
		}
	}

	public static void Init(GraphicsDevice _dev, ContentManager Content)
	{
		dev = _dev;
		bloomExtractEffect = Content.Load<Effect>("fx/bloom/BloomExtract");
		bloomCombineEffect = Content.Load<Effect>("fx/bloom/BloomCombine");
		gaussianBlurEffect = Content.Load<Effect>("fx/bloom/GaussianBlur");
	}

	public static void CreateTargs(GraphicsDevice dev)
	{
		renderTarget1 = new RenderTarget2D(dev, (int)ScrollManager.screenSize.X / 2, (int)ScrollManager.screenSize.Y / 2);
		renderTarget2 = new RenderTarget2D(dev, (int)ScrollManager.screenSize.X / 2, (int)ScrollManager.screenSize.Y / 2);
	}

	public static void Draw(RenderTarget2D goalTarg, RenderTarget2D sceneRenderTarget, RenderTarget2D lightTarget)
	{
		dev.SamplerStates[1] = SamplerState.LinearClamp;
		bloomExtractEffect.Parameters["BloomThreshold"].SetValue(bloomThreshhold);
		DrawFullscreenQuad(sceneRenderTarget, renderTarget1, bloomExtractEffect, IntermediateBuffer.PreBloom);
		SetBlurEffectParameters(1f / (float)renderTarget1.Width, 0f);
		DrawFullscreenQuad(renderTarget1, renderTarget2, gaussianBlurEffect, IntermediateBuffer.BlurredHorizontally);
		SetBlurEffectParameters(0f, 1f / (float)renderTarget1.Height);
		DrawFullscreenQuad(renderTarget2, renderTarget1, gaussianBlurEffect, IntermediateBuffer.BlurredBothWays);
		dev.SetRenderTarget(goalTarg);
		EffectParameterCollection parameters = bloomCombineEffect.Parameters;
		parameters["BloomIntensity"].SetValue(bloomIntensity);
		parameters["BaseIntensity"].SetValue(bloomBase);
		parameters["BloomSaturation"].SetValue(bloomSat);
		parameters["BaseSaturation"].SetValue(baseSat);
		parameters["BloomVignette"].SetValue(bloomVignette);
		parameters["floorVal"].SetValue(floorValue);
		parameters["lightFac"].SetValue(lightFac);
		parameters["lightBlue"].SetValue(lightBlue);
		parameters["lightRed"].SetValue(lightRed);
		parameters["lightThresh"].SetValue(lightThresh);
		parameters["lightDesat"].SetValue(lightDesat);
		parameters["darkBlur"].SetValue(darkBlur);
		dev.Textures[1] = sceneRenderTarget;
		dev.Textures[2] = lightTarget;
		Viewport viewport = dev.Viewport;
		SpriteTools.sprite.Begin(SpriteSortMode.Deferred, BlendState.Opaque, null, null, null, bloomCombineEffect);
		SpriteTools.sprite.Draw(renderTarget1, new Rectangle(0, 0, viewport.Width, viewport.Height), Color.White);
		SpriteTools.sprite.End();
		dev.Textures[1] = null;
		dev.Textures[2] = null;
	}

	private static void DrawFullscreenQuad(Texture2D texture, RenderTarget2D renderTarget, Effect effect, IntermediateBuffer currentBuffer)
	{
		dev.SetRenderTarget(renderTarget);
		DrawFullscreenQuad(texture, renderTarget.Width, renderTarget.Height, effect, currentBuffer);
	}

	private static void DrawFullscreenQuad(Texture2D texture, int width, int height, Effect effect, IntermediateBuffer currentBuffer)
	{
		if (showBuffer < currentBuffer)
		{
			effect = null;
		}
		SpriteTools.sprite.Begin(SpriteSortMode.Deferred, BlendState.Opaque, null, null, null, effect);
		SpriteTools.sprite.Draw(texture, new Rectangle(0, 0, width, height), Color.White);
		SpriteTools.sprite.End();
	}

	public static void DrawTargets()
	{
		SpriteTools.sprite.Draw(renderTarget2, new Rectangle(0, 0, renderTarget2.Width, renderTarget2.Height), new Color(1f, 1f, 1f, 1f));
	}

	private static void SetBlurEffectParameters(float dx, float dy)
	{
		EffectParameter effectParameter = gaussianBlurEffect.Parameters["SampleWeights"];
		EffectParameter effectParameter2 = gaussianBlurEffect.Parameters["SampleOffsets"];
		int count = effectParameter.Elements.Count;
		float[] array = new float[count];
		Vector2[] array2 = new Vector2[count];
		array[0] = ComputeGaussian(0f);
		array2[0] = new Vector2(0f);
		float num = array[0];
		for (int i = 0; i < count / 2; i++)
		{
			num += (array[i * 2 + 2] = (array[i * 2 + 1] = ComputeGaussian(i + 1))) * 2f;
			float num2 = (float)(i * 2) + 1.5f;
			array2[i * 2 + 2] = -(array2[i * 2 + 1] = new Vector2(dx, dy) * num2);
		}
		for (int j = 0; j < array.Length; j++)
		{
			array[j] /= num;
		}
		effectParameter.SetValue(array);
		effectParameter2.SetValue(array2);
	}

	private static float ComputeGaussian(float n)
	{
		float num = 4f;
		return (float)(1.0 / Math.Sqrt(Math.PI * 2.0 * (double)num) * Math.Exp((0.0 - (double)n * (double)n) / (2.0 * (double)num * (double)num)));
	}
}
