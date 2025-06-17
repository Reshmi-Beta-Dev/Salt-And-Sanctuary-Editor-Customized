using MapEdit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectTower.director;

public class BloomDraw
{
	private static RenderTarget2D bloomTarg;

	private static Effect bloomEffect;

	public static bool canDraw;

	private static float alpha;

	public static bool active;

	public static void Init(GraphicsDevice gd, ContentManager Content)
	{
		bloomTarg = new RenderTarget2D(gd, 512, 512);
		bloomEffect = Content.Load<Effect>("fx/bloom");
		active = true;
	}

	public static void Prepare(GraphicsDevice gd, RenderTarget2D mainTarg)
	{
		gd.SetRenderTarget(bloomTarg);
		bloomEffect.Parameters["v"].SetValue(0.0125f);
		bloomEffect.Parameters["a"].SetValue(1f);
		bloomEffect.Parameters["sat"].SetValue(1f);
		SpriteTools.BeginAlpha(bloomEffect);
		SpriteTools.sprite.Draw(mainTarg, new Rectangle(0, 0, bloomTarg.Width, bloomTarg.Height), Color.White);
		SpriteTools.End();
	}

	public static void Update()
	{
		if (canDraw)
		{
			if (active)
			{
				alpha = 1f;
				if (!((double)alpha <= 1.0))
				{
					alpha = 1f;
				}
			}
			else
			{
				alpha = 0f;
			}
		}
		else
		{
			alpha = 0f;
		}
	}

	public static void Draw()
	{
		if (!canDraw)
		{
			canDraw = true;
			alpha = 0f;
			return;
		}
		alpha = 1f;
		SpriteTools.BeginAdditive();
		SpriteTools.sprite.Draw(bloomTarg, new Rectangle(0, 0, (int)ScrollManager.screenSize.X, (int)ScrollManager.screenSize.Y), new Color(1f, 1f, 1f, 0.25f));
		SpriteTools.End();
	}
}
