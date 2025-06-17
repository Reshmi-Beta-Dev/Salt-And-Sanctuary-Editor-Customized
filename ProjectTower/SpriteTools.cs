using Microsoft.Xna.Framework.Graphics;

namespace ProjectTower;

public class SpriteTools
{
	public static SpriteBatch sprite;

	private static BlendState blendSubtract;

	private static BlendState blendAlphaAdd;

	public static void Init(GraphicsDevice dev)
	{
		sprite = new SpriteBatch(dev);
		blendSubtract = new BlendState();
		blendSubtract.ColorSourceBlend = Blend.SourceAlpha;
		blendSubtract.ColorDestinationBlend = Blend.One;
		blendSubtract.ColorBlendFunction = BlendFunction.ReverseSubtract;
		blendSubtract.AlphaSourceBlend = Blend.SourceAlpha;
		blendSubtract.AlphaDestinationBlend = Blend.One;
		blendSubtract.AlphaBlendFunction = BlendFunction.ReverseSubtract;
		blendAlphaAdd = new BlendState();
		blendAlphaAdd.ColorSourceBlend = Blend.SourceAlpha;
		blendAlphaAdd.ColorDestinationBlend = Blend.InverseSourceAlpha;
		blendAlphaAdd.ColorBlendFunction = BlendFunction.Add;
		blendAlphaAdd.AlphaSourceBlend = Blend.SourceAlpha;
		blendAlphaAdd.AlphaDestinationBlend = Blend.One;
		blendAlphaAdd.AlphaBlendFunction = BlendFunction.Add;
	}

	public static void BeginOpaque()
	{
		sprite.Begin(SpriteSortMode.Deferred, BlendState.Opaque);
	}

	public static void BeginAlpha()
	{
		sprite.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
	}

	public static void BeginPixelAlpha()
	{
		sprite.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null);
	}

	public static void BeginAlphaAdd()
	{
		blendAlphaAdd = new BlendState();
		blendAlphaAdd.ColorSourceBlend = Blend.SourceAlpha;
		blendAlphaAdd.ColorDestinationBlend = Blend.InverseSourceAlpha;
		blendAlphaAdd.ColorBlendFunction = BlendFunction.Add;
		blendAlphaAdd.AlphaSourceBlend = Blend.SourceAlpha;
		blendAlphaAdd.AlphaDestinationBlend = Blend.InverseSourceAlpha;
		blendAlphaAdd.AlphaBlendFunction = BlendFunction.Add;
		sprite.Begin(SpriteSortMode.Deferred, blendAlphaAdd);
	}

	public static void BeginPMAlpha()
	{
		sprite.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
	}

	public static void BeginAdditive()
	{
		sprite.Begin(SpriteSortMode.Deferred, BlendState.Additive);
	}

	public static void BeginSubtractive()
	{
		sprite.Begin(SpriteSortMode.Deferred, blendSubtract);
	}

	public static void BeginSubtractive(Effect effect)
	{
		sprite.Begin(SpriteSortMode.Deferred, blendSubtract, null, null, null, effect);
	}

	public static void BeginWrappedSubtractive(Effect effect)
	{
		sprite.Begin(SpriteSortMode.Deferred, blendSubtract, SamplerState.AnisotropicWrap, null, null, effect);
	}

	public static void BeginAlpha(Effect effect)
	{
		sprite.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, effect);
	}

	public static void BeginAdditive(Effect effect)
	{
		sprite.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, effect);
	}

	public static void BeginOpaque(Effect effect)
	{
		sprite.Begin(SpriteSortMode.Deferred, BlendState.Opaque, null, null, null, effect);
	}

	public static void BeginPMAlpha(Effect effect)
	{
		sprite.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, effect);
	}

	public static void End()
	{
		sprite.End();
	}
}
