using MapEdit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower.particles;

namespace ProjectTower.director;

public class RefractDraw
{
	private static GraphicsDevice GraphicsDevice;

	private static RenderTarget2D refractTarg;

	private static Effect refractEffect;

	public static void Init(GraphicsDevice gd, ContentManager Content)
	{
		GraphicsDevice = gd;
		refractEffect = Content.Load<Effect>("fx/refract");
	}

	public static void CreateTarg(GraphicsDevice GraphicsDevice)
	{
		refractTarg = new RenderTarget2D(GraphicsDevice, (int)ScrollManager.screenSize.X, (int)ScrollManager.screenSize.Y);
	}

	internal static void Draw(RenderTarget2D auxTarg, RenderTarget2D backTarg)
	{
		GraphicsDevice.SetRenderTarget(refractTarg);
		GraphicsDevice.Clear(new Color(0f, 0f, 0f, 1f));
		SpriteTools.BeginAdditive();
		ParticleManager.Draw(6);
		SpriteTools.End();
		GraphicsDevice.SetRenderTarget(auxTarg);
		GraphicsDevice.Textures[1] = refractTarg;
		SpriteTools.BeginOpaque(refractEffect);
		SpriteTools.sprite.Draw(backTarg, new Rectangle(0, 0, (int)ScrollManager.screenSize.X, (int)ScrollManager.screenSize.Y), Color.White);
		SpriteTools.End();
		GraphicsDevice.Textures[1] = null;
	}
}
