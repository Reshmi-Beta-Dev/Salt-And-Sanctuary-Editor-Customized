using MapEdit;
using MapEdit.map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectTower.director;

public class Water
{
	public static float waterLev;

	public static Effect waterEffect;

	private static Texture2D waterTex;

	private static float waterDelta;

	private static float waterTheta;

	private static RenderTarget2D waterTarg;

	private static GraphicsDevice dev;

	private static Matrix MatrixTransform;

	private static bool hasMatrix;

	public static void Init(GraphicsDevice _dev, ContentManager Content)
	{
		waterEffect = Content.Load<Effect>("fx/water");
		dev = _dev;
		waterTex = Content.Load<Texture2D>("gfx/water");
		waterLev = 3500f;
	}

	public static void CreateTarg(GraphicsDevice dev)
	{
		waterTarg = new RenderTarget2D(dev, (int)ScrollManager.screenSize.X / 2, (int)ScrollManager.screenSize.Y / 2);
	}

	public static void Update(Layer layer)
	{
		for (int i = 0; i < layer.seg.Count; i++)
		{
			if (Game1.textures[layer.seg[i].texture].cell[layer.seg[i].idx].flags == 12)
			{
				waterLev = layer.seg[i].loc.Y;
			}
		}
		waterLev = -1f;
	}

	public static void Prepare(RenderTarget2D mainTarg)
	{
		if (!((double)waterLev <= -1.0))
		{
			dev.SamplerStates[1] = SamplerState.LinearWrap;
			dev.SetRenderTarget(waterTarg);
			dev.Clear(new Color(0f, 0f, 0f, 0f));
			Rectangle value = new Rectangle(0, 0, (int)ScrollManager.screenSize.X, (int)ScrollManager.screenSize.Y);
			Rectangle destinationRectangle = new Rectangle
			{
				X = 0,
				Y = 0,
				Width = waterTarg.Width,
				Height = waterTarg.Height
			};
			float value2 = ScrollManager.GetScreenLoc(new Vector2(0f, waterLev), 0).Y / ScrollManager.screenSize.Y;
			dev.Textures[0] = mainTarg;
			dev.Textures[1] = waterTex;
			if (waterEffect != null)
			{
				waterEffect.Parameters["horizon"].SetValue(value2);
				waterEffect.Parameters["delta"].SetValue(6.28f - waterDelta);
				waterEffect.Parameters["theta"].SetValue(6.28f - waterTheta);
				SpriteTools.BeginOpaque(waterEffect);
			}
			else
			{
				SpriteTools.BeginAlpha();
			}
			SpriteTools.sprite.Draw(mainTarg, destinationRectangle, value, Color.White, 0f, default(Vector2), SpriteEffects.None, 0f);
			SpriteTools.End();
			dev.Textures[1] = null;
		}
	}

	public static void Draw()
	{
		if (!((double)waterLev <= -1.0))
		{
			SpriteTools.BeginAlpha();
			SpriteTools.sprite.Draw(waterTarg, new Vector2(0f, ScrollManager.GetScreenLoc(new Vector2(0f, waterLev), 0).Y), new Rectangle(0, 0, waterTarg.Width, waterTarg.Height), Color.White, 0f, default(Vector2), new Vector2(ScrollManager.screenSize.X / (float)waterTarg.Width, ScrollManager.screenSize.Y / (float)waterTarg.Height), SpriteEffects.None, 0f);
			SpriteTools.End();
		}
	}
}
