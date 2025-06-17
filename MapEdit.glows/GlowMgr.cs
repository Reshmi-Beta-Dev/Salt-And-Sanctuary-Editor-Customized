using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower;
using SheetEdit.TextureSheet;

namespace MapEdit.glows;

public class GlowMgr
{
	public GlowList[] list = new GlowList[2]
	{
		new GlowList(0),
		new GlowList(1)
	};

	public float lightFac = 1f;

	public const int GLOW_LIGHTMAP = 0;

	public const int GLOW_NORMAL = 1;

	public float alpha;

	public Effect lightEffect;

	public Texture2D cloudsTex;

	public const int TOTAL_ADDS = 3;

	public float greenLanternFrame;

	public float greenLanternAlpha;

	private Vector2[] addVec;

	public GlowMgr(ContentManager Content)
	{
		lightEffect = Content.Load<Effect>("fx/lightmap");
		cloudsTex = Content.Load<Texture2D>("gfx/waterstain");
		addVec = new Vector2[3];
	}

	public void Draw(XTexture xt)
	{
		list[1].Draw(xt);
	}

	internal void Add(int type, Vector2 loc, float r, float g, float b, float size, int glowType)
	{
		list[type].AddGlow(loc, r, g, b, size, glowType);
	}

	internal void Draw(XTexture xt, int idx)
	{
		list[idx].Draw(xt);
	}

	internal void Clear()
	{
		list[1].Clear();
	}

	internal void Prepare(XTexture xt, RenderTarget2D lightTarg)
	{
		GraphicsDevice graphicsDevice = lightTarg.GraphicsDevice;
		graphicsDevice.SetRenderTarget(lightTarg);
		graphicsDevice.Clear(new Color(1f, 1f, 1f, 1f));
		SpriteTools.BeginSubtractive();
		list[0].DrawForLightMode(xt);
		SpriteTools.End();
		list[0].Clear();
	}

	internal void Update()
	{
		if ((double)greenLanternFrame > 0.0)
		{
			greenLanternFrame -= Game1.frameTime;
			if ((double)greenLanternAlpha < 1.0)
			{
				greenLanternAlpha += Game1.frameTime;
				if ((double)greenLanternAlpha > 1.0)
				{
					greenLanternAlpha = 1f;
				}
			}
		}
		else if ((double)greenLanternAlpha > 0.0)
		{
			greenLanternAlpha -= Game1.frameTime;
			if ((double)greenLanternAlpha < 0.0)
			{
				greenLanternAlpha = 0f;
			}
		}
		addVec[0].X += Game1.frameTime * 6f;
		addVec[0].Y += Game1.frameTime * 4f;
		addVec[1].X += Game1.frameTime * -3.5f;
		addVec[1].Y += Game1.frameTime * -7f;
		addVec[2].X += Game1.frameTime * -6f;
		addVec[2].Y += Game1.frameTime * -2.5f;
		float num = 512f;
		for (int i = 0; i < addVec.Length; i++)
		{
			if ((double)addVec[i].X >= (double)num)
			{
				addVec[i].X -= num;
			}
			if ((double)addVec[i].X < 0.0)
			{
				addVec[i].X += num;
			}
			if ((double)addVec[i].Y >= (double)num)
			{
				addVec[i].Y -= num;
			}
			if ((double)addVec[i].Y < 0.0)
			{
				addVec[i].Y += num;
			}
		}
	}

	internal void Draw(RenderTarget2D lightTarg)
	{
		lightEffect.Parameters["alpha"].SetValue(alpha);
		_ = ScrollManager.scroll;
		Vector2 realLoc = ScrollManager.GetRealLoc(new Vector2(0f, 0f), 2f);
		Vector2 realLoc2 = ScrollManager.GetRealLoc(ScrollManager.screenSize, 2f);
		Vector2 realLoc3 = ScrollManager.GetRealLoc(new Vector2(0f, 0f), 5f);
		ScrollManager.GetRealLoc(ScrollManager.screenSize, 5f);
		Vector2 realLoc4 = ScrollManager.GetRealLoc(new Vector2(0f, 0f), 11f);
		ScrollManager.GetRealLoc(ScrollManager.screenSize, 11f);
		lightEffect.Parameters["scroll"].SetValue(realLoc + addVec[0]);
		lightEffect.Parameters["scroll2"].SetValue(realLoc3 + addVec[1]);
		lightEffect.Parameters["scroll3"].SetValue(realLoc4 + addVec[2]);
		lightEffect.Parameters["scrollDif"].SetValue(realLoc2 - realLoc);
		lightEffect.Parameters["lightFac"].SetValue(lightFac);
		SpriteTools.sprite.GraphicsDevice.Textures[1] = cloudsTex;
		SpriteTools.BeginSubtractive(lightEffect);
		SpriteTools.sprite.Draw(lightTarg, new Rectangle(0, 0, (int)ScrollManager.screenSize.X, (int)ScrollManager.screenSize.Y), new Color(1f, 1f, 1f, alpha));
		SpriteTools.End();
		SpriteTools.sprite.GraphicsDevice.Textures[1] = null;
	}

	internal void DrawList()
	{
		list[1].DrawList();
	}
}
