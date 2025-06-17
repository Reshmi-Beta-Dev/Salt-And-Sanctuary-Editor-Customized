using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower;
using SheetEdit.TextureSheet;

namespace MapEdit.glows;

public class GlowList
{
	private Glow[] glow;

	public int totalGlows;

	public int idx;

	private int listGlows;

	public GlowList(int idx)
	{
		this.idx = idx;
		glow = new Glow[128];
		for (int i = 0; i < glow.Length; i++)
		{
			glow[i] = new Glow();
		}
	}

	public void AddGlow(Vector2 loc, float r, float g, float b, float size, int type)
	{
		float num = 200f;
		float num2 = 0f;
		if (!((double)loc.X + (double)num2 < 0.0) && !((double)loc.Y + (double)num2 < 0.0) && !((double)loc.X - (double)num2 > (double)ScrollManager.screenSize.X) && !((double)loc.Y - (double)num2 > (double)ScrollManager.screenSize.Y))
		{
			float num3 = 1f;
			if ((double)loc.X < 0.0 - (double)num)
			{
				num3 *= (float)(1.0 - (0.0 - (double)loc.X - (double)num) / (double)num2);
			}
			if ((double)loc.Y < 0.0 - (double)num)
			{
				num3 *= (float)(1.0 - (0.0 - (double)loc.Y - (double)num) / (double)num2);
			}
			if ((double)loc.X > (double)ScrollManager.screenSize.X + (double)num)
			{
				num3 *= (float)(1.0 - ((double)loc.X - ((double)ScrollManager.screenSize.X + (double)num)) / (double)num2);
			}
			if ((double)loc.Y > (double)ScrollManager.screenSize.Y + (double)num)
			{
				num3 *= (float)(1.0 - ((double)loc.Y - ((double)ScrollManager.screenSize.Y + (double)num)) / (double)num2);
			}
			if (totalGlows < glow.Length)
			{
				glow[totalGlows].Init(loc, r, g, b, size * num3, type);
				totalGlows++;
			}
		}
	}

	public void Draw(XTexture xt)
	{
		for (int i = 0; i < totalGlows; i++)
		{
			glow[i].Draw(xt, idx);
		}
	}

	internal void DrawList()
	{
		int num = 28;
		for (int i = 0; i < listGlows; i++)
		{
			SpriteTools.sprite.DrawString(Game1.arial, glow[i].loc.ToString(), new Vector2((float)(i / num) * 200f, (float)(i % num) * 24f), Color.White, 0f, default(Vector2), 0.9f, SpriteEffects.None, 1f);
		}
	}

	internal void Clear()
	{
		listGlows = totalGlows;
		totalGlows = 0;
	}

	internal void DrawForLightMode(XTexture xt)
	{
		for (int i = 0; i < totalGlows; i++)
		{
			glow[i].DrawForLightMode(xt, idx);
		}
	}
}
