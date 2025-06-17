using MapEdit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower.particles;
using ProjectTower.texturesheet;

namespace ProjectTower.map.entities;

public class BlinkPlatMgr
{
	public static float blinkPhase;

	public const float BLINK_MAX = 6f;

	public static int[] mainBlinkPhase;

	public static int[] quickBlinkPhase;

	public const int TOTAL_MAIN_BLINKS = 2;

	public const int TOTAL_QUICK_BLINKS = 6;

	public const int BLINK_OFF = 0;

	public const int BLINK_ON = 1;

	public const int BLINK_NEWLY_ON = 2;

	public const int TYPE_MAIN = 0;

	public const int TYPE_QUICK = 1;

	public static Vector2 glowTL;

	public static Vector2 glowBR;

	public static bool glowBrite;

	public static bool blueEtherRune;

	public static bool redBlockRune;

	public static void Init()
	{
		mainBlinkPhase = new int[2];
		quickBlinkPhase = new int[6];
	}

	public static void Update()
	{
		blinkPhase += Game1.frameTime * 1.5f;
		if ((double)blinkPhase >= 6.0)
		{
			blinkPhase -= 6f;
		}
		for (int i = 0; i < 2; i++)
		{
			if ((double)blinkPhase > (double)i * 3.0 && (double)blinkPhase < (double)(i + 1) * 3.0)
			{
				if (mainBlinkPhase[i] == 0)
				{
					mainBlinkPhase[i] = 2;
				}
			}
			else
			{
				mainBlinkPhase[i] = 0;
			}
		}
		for (int j = 0; j < 6; j++)
		{
			int num = (int)((double)blinkPhase + (double)j);
			if (num % 6 == 0 || (num + 1) % 6 == 0 || (num + 2) % 6 == 0)
			{
				if (quickBlinkPhase[j] == 0)
				{
					quickBlinkPhase[j] = 2;
				}
			}
			else
			{
				quickBlinkPhase[j] = 0;
			}
		}
		redBlockRune = false;
		blueEtherRune = false;
	}

	public static void DrawBlink(int x, int y, int type, int idx)
	{
		float num = 1f;
		float num2 = 1f;
		float num3 = 1f;
		float num4 = 0f;
		bool flag = false;
		switch (type)
		{
		case 0:
		{
			if (mainBlinkPhase[idx] == 0)
			{
				return;
			}
			if ((double)blinkPhase > (double)idx * 3.0 && (double)blinkPhase < (double)(idx + 1) * 3.0)
			{
				num4 = 1f - (blinkPhase - (float)idx * 3f);
				if ((double)num4 < 0.0)
				{
					num4 = 0f;
				}
			}
			if (mainBlinkPhase[idx] == 2)
			{
				flag = true;
			}
			float num7 = (float)((3.0 - (double)(blinkPhase - (float)idx * 3f)) / 3.0);
			num3 = 1f;
			num2 = (float)(0.600000023841858 + (double)num7 * 0.400000005960464);
			num = num7;
			num4 += 0.5f;
			if ((double)num7 < 0.100000001490116)
			{
				num3 *= num7 / 0.1f;
				num2 *= 0f;
				num *= 0f;
				num4 *= num7 / 0.1f;
			}
			break;
		}
		case 1:
		{
			if (quickBlinkPhase[idx] == 0)
			{
				return;
			}
			if ((int)((double)blinkPhase + 2.0) % 6 == (6 - idx) % 6)
			{
				num4 = (float)(1.0 - (((double)blinkPhase + 2.0) % 6.0 - (double)((6 - idx) % 6)));
			}
			float num5 = (float)((double)blinkPhase - (double)((6 - idx) % 6) + 2.0);
			if (quickBlinkPhase[idx] == 2)
			{
				flag = true;
			}
			while ((double)num5 > 6.0)
			{
				num5 -= 6f;
			}
			float num6 = (float)((3.0 - (double)num5) / 3.0);
			num3 = 1f;
			num2 = (float)(0.600000023841858 + (double)num6 * 0.400000005960464);
			num = num6;
			num4 += 0.5f;
			if ((double)num6 < 0.100000001490116)
			{
				num3 *= num6 / 0.1f;
				num2 *= 0f;
				num *= 0f;
				num4 *= num6 / 0.1f;
			}
			break;
		}
		}
		Vector2 vector = new Vector2((float)x * 64f, (float)y * 32f);
		Vector2 screenLoc = ScrollManager.GetScreenLoc(vector, 0);
		if (flag && (double)screenLoc.X > 0.0 && (double)screenLoc.Y > 0.0 && (double)screenLoc.X < (double)ScrollManager.screenSize.X && (double)screenLoc.Y < (double)ScrollManager.screenSize.Y)
		{
			if (!glowBrite)
			{
				glowTL = vector;
				glowBR = glowTL;
			}
			if ((double)vector.X < (double)glowTL.X)
			{
				glowTL.X = vector.X;
			}
			if ((double)vector.Y < (double)glowTL.Y)
			{
				glowTL.Y = vector.Y;
			}
			if ((double)vector.X > (double)glowBR.X)
			{
				glowBR.X = vector.X;
			}
			if ((double)vector.Y > (double)glowBR.Y)
			{
				glowBR.Y = vector.Y;
			}
			glowBrite = true;
		}
		Textures.tex[ParticleManager.spritesTexIdx].Draw(screenLoc, 125, new Vector2(1f, 1f) * ScrollManager.cannedDepth[0] * 0.5f, 0f, num, num2, num3, 1f);
		Textures.tex[ParticleManager.spritesTexIdx].Draw(screenLoc, 126, new Vector2(1f, Rand.GetRandomFloat(1f, 1.2f)) * ScrollManager.cannedDepth[0] * 0.5f, 0f, (float)((double)num * 2.0 + 0.5), (float)((double)num2 * 2.0 + 0.5), (float)((double)num3 * 2.0 + 0.5), num4);
		Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(vector + new Vector2(0f, (float)(y % 2) * 16f), 0), 0, new Vector2(5f, 0.5f) * ScrollManager.cannedDepth[0] * 0.5f, 0f, (float)((double)num * 2.0 + 0.5), (float)((double)num2 * 2.0 + 0.5), (float)((double)num3 * 2.0 + 0.5), num4 * 0.3f);
	}

	internal static void DrawRedBlock(int x, int y)
	{
		Vector2 vector = new Vector2((float)x * 64f, (float)y * 32f);
		Vector2 screenLoc = ScrollManager.GetScreenLoc(vector, 0);
		float num = 0.5f;
		float num2 = 0.1f;
		float num3 = 1f - GetRuneAlpha(vector);
		if (!redBlockRune)
		{
			num3 = 1f;
		}
		if ((double)num3 > 0.0)
		{
			num = 1f;
			num2 = 1f;
			SpriteTools.sprite.Draw(Game1.nullTex, screenLoc + new Vector2(32f, 0f) * ScrollManager.cannedDepth[0], new Rectangle(0, 0, 1, 1), new Color(1f, 0.9f, 0.8f, 0.5f * num3), 0f, new Vector2(0.5f, 0f), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
		}
		for (int i = 1; i < 3; i++)
		{
			Vector2 loc = screenLoc + ScrollManager.cannedDepth[0] * new Vector2((float)(64.0 * ((double)i / 3.0)), 16f);
			Game1.glowMgr.Add(1, loc, 0.75f * num2 * num3, 0.1f * num2 * num3, 0.1f * num2 * num3, ScrollManager.cannedDepth[0] * 1.5f, 0);
			Game1.textures["sprites"].Draw(loc, 41 + (x + i + y) % 10, new Vector2(1f, 1f) * ScrollManager.cannedDepth[0] * 0.85f, Game1.map.delta * ((float)i - 1.5f), 1f * num, 0.4f * num, 0.4f * num, 0.5f);
		}
		if (!((double)num3 <= 0.0))
		{
			Textures.tex[ParticleManager.spritesTexIdx].Draw(screenLoc, 125, new Vector2(1f, 1f) * ScrollManager.cannedDepth[0] * 0.5f, (float)(0.0 - (1.0 - (double)num3)), 1f, 0.5f, 0.5f, 1f * num3);
			Textures.tex[ParticleManager.spritesTexIdx].Draw(screenLoc + new Vector2(0f, 32f) * ScrollManager.cannedDepth[0], 125, new Vector2(1f, 1f) * ScrollManager.cannedDepth[0] * 0.5f, 1f - num3, 1f, 0.5f, 0.5f, 1f * num3);
		}
	}

	internal static float GetRuneAlpha(Vector2 rv)
	{
		return 1f;
	}

	internal static void DrawBlueEther(int x, int y)
	{
		blueEtherRune = true;
		Vector2 vector = new Vector2((float)x * 64f, (float)y * 32f);
		Vector2 screenLoc = ScrollManager.GetScreenLoc(vector, 0);
		float num = 0.5f;
		float num2 = 0.1f;
		float num3 = GetRuneAlpha(vector);
		if (!blueEtherRune)
		{
			num3 = 0f;
		}
		if (blueEtherRune)
		{
			num = 1f;
			num2 = 1f;
			SpriteTools.sprite.Draw(Game1.nullTex, screenLoc + new Vector2(32f, 0f) * ScrollManager.cannedDepth[0], new Rectangle(0, 0, 1, 1), new Color(0.8f, 0.9f, 1f, 0.5f * num3), 0f, new Vector2(0.5f, 0f), new Vector2(64f * num3, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
		}
		for (int i = 1; i < 3; i++)
		{
			Vector2 loc = screenLoc + ScrollManager.cannedDepth[0] * new Vector2((float)(64.0 * ((double)i / 3.0)), 16f);
			Game1.glowMgr.Add(1, loc, 0.1f * num2 * num3, 0.1f * num2 * num3, 0.75f * num2 * num3, ScrollManager.cannedDepth[0] * 1.5f, 0);
			Game1.textures["sprites"].Draw(loc, 41 + (x + i + y) % 10, new Vector2(1f, 1f) * ScrollManager.cannedDepth[0] * 0.85f, Game1.map.delta * ((float)i - 1.5f), 0.4f * num, 0.5f * num, 1f * num, 0.5f);
		}
		if (blueEtherRune)
		{
			Textures.tex[ParticleManager.spritesTexIdx].Draw(screenLoc, 125, new Vector2(1f, 1f) * ScrollManager.cannedDepth[0] * 0.5f, 1f - num3, 0.5f, 0.5f, 1f, 1f * num3);
			Textures.tex[ParticleManager.spritesTexIdx].Draw(screenLoc + new Vector2(0f, 32f) * ScrollManager.cannedDepth[0], 125, new Vector2(1f, 1f) * ScrollManager.cannedDepth[0] * 0.5f, (float)(0.0 - (1.0 - (double)num3)), 0.5f, 0.5f, 1f, 1f * num3);
		}
	}
}
