using System.Linq;
using LootEdit;
using LootEdit.loot;
using MapEdit;
using MapEdit.map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower.sanctuary;
using SheetEdit.TextureSheet;
using xCharEdit;

namespace ProjectTower.map;

public class MapEditDraw
{
	private Map map;

	public MapEditDraw(Map map)
	{
		this.map = map;
	}

	public void DrawLayers()
	{
		Vector2 realLoc = ScrollManager.GetRealLoc(default(Vector2), 0f);
		Vector2 realLoc2 = ScrollManager.GetRealLoc(ScrollManager.screenSize, 0f);
		int num = (int)((double)realLoc.X / 64.0) - 1;
		int num2 = (int)((double)realLoc2.X / 64.0) + 2;
		int num3 = (int)((double)realLoc.Y / 32.0) - 1;
		int num4 = (int)((double)realLoc2.Y / 32.0) + 2;
		for (int i = num; i < num2; i++)
		{
			for (int j = num3; j < num4; j++)
			{
				if (i < 0 || j < 0 || i >= map.xUnits || j >= map.yUnits || map.col[i, j].layer == 0)
				{
					continue;
				}
				Vector2 screenLoc = ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0);
				if ((double)screenLoc.X > -100.0 && (double)screenLoc.Y > -100.0 && (double)screenLoc.X < (double)ScrollManager.screenSize.X && (double)screenLoc.Y < (double)ScrollManager.screenSize.Y)
				{
					switch (map.col[i, j].layer)
					{
					case 1:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0.5f, 0f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 2:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 0.5f, 1f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 3:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.5f, 0.5f, 0.5f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 4:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0.5f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 5:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.4f, 0.8f, 0.5f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 6:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 0.5f, 1f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 7:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 1f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 8:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.25f, 0.25f, 0.5f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 9:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.5f, 0.35f, 0.05f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 10:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.05f, 0.35f, 0.5f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 11:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.5f, 0.5f, 0.05f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 12:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.05f, 0.05f, 0.15f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 13:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.35f, 0.35f, 0.5f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 14:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.6f, 0.6f, 0f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 15:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.2f, 0.5f, 0.5f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 16:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 0.5f, 0.2f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 17:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 0.6f, 0.6f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 18:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 0.5f, 0f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 19:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 0.65f, 0f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 20:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.3f, 0.3f, 0.3f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 21:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.3f, 0.3f, 0.6f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 22:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.6f, 0.5f, 0.5f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 23:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.65f, 0.65f, 0.65f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 24:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.8f, 0.5f, 0f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 25:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.8f, 0.9f, 1f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 26:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.6f, 0.7f, 1f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					}
				}
			}
		}
	}

	public void DrawColForWorldMap()
	{
		Vector2 realLoc = ScrollManager.GetRealLoc(default(Vector2), 0f);
		Vector2 realLoc2 = ScrollManager.GetRealLoc(ScrollManager.screenSize, 0f);
		int num = (int)((double)realLoc.X / 64.0) - 1;
		int num2 = (int)((double)realLoc2.X / 64.0) + 2;
		int num3 = (int)((double)realLoc.Y / 32.0) - 1;
		int num4 = (int)((double)realLoc2.Y / 32.0) + 2;
		for (int i = num; i < num2; i++)
		{
			for (int j = num3; j < num4; j++)
			{
				if (i >= 0 && j >= 0 && i < map.xUnits && j < map.yUnits && map.col[i, j].col != 0)
				{
					switch (map.col[i, j].col)
					{
					case 1:
					case 2:
					case 3:
					case 5:
					case 6:
					case 7:
					case 10:
					case 11:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 1f, 1f, Rand.GetRandomFloat(0f, 0.3f)), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0] * 3f, SpriteEffects.None, 1f);
						break;
					}
				}
			}
		}
	}

	public void DrawCol()
	{
		foreach (Seg item in map.layer[15].seg)
		{
			bool flag = false;
			if (Game1.textures[item.texture].cell[item.idx].flags == 11)
			{
				flag = true;
			}
			if (!flag)
			{
				continue;
			}
			Sanctuary sanctuary = new Sanctuary(item, 0);
			int num = (int)((double)item.loc.X / 64.0);
			int num2 = (int)((double)item.loc.Y / 32.0);
			int num3 = 12;
			int num4 = 12;
			int num5 = 2;
			bool flag2 = false;
			if (item.strFlag != null && item.strFlag.Contains("shrine"))
			{
				num3 = 5;
				num4 = 10;
				flag2 = true;
			}
			sanctuary.creed = 3;
			sanctuary.shrine = flag2;
			sanctuary.claimFrame = 0.5f;
			for (int i = num - num3; i <= num + num3; i++)
			{
				for (int j = num2 - num4; j <= num2 + num5; j++)
				{
					if (i >= num - 1 && i <= num + 1 && j >= num2 - 2 && j <= num2 + 1)
					{
						continue;
					}
					if ((i == num - 12 && j == num2 + 1) || (i == num - 11 && j == num2 + 2))
					{
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 1f, 0f, 0.25f), 0.47f, default(Vector2), new Vector2(64f, 3f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
					}
					else if ((i == num + 12 && j == num2 + 1) || (i == num + 11 && j == num2 + 2))
					{
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)((float)j + 1f) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 1f, 0f, 0.25f), -0.47f, default(Vector2), new Vector2(64f, 3f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
					}
					else if ((i != num - 12 || j != num2 + 2) && (i != num + 12 || j != num2 + 2))
					{
						float r = 1f;
						if (i == num && j == num2)
						{
							r = 0f;
						}
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)i * 64f, (float)((double)j * 64.0 * 0.5 + 16.0)), 0), new Rectangle(0, 0, 1, 1), new Color(r, 1f, 0f, 0.25f), 0f, default(Vector2), new Vector2(64f, 3f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)((double)i * 64.0 + 32.0), (float)((double)j * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(r, 1f, 0f, 0.25f), 0f, default(Vector2), new Vector2(3f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
					}
				}
			}
			Vector2 loc = new Vector2((float)((double)num * 64.0 + 32.0), (float)((double)num2 * 64.0 * 0.5 + 6.40000009536743));
			XTexture xTexture = Game1.textures["consumables"];
			if (xTexture.texture == null)
			{
				xTexture.texture = ContentRig.LoadTextureFromFile("\\gfx\\consumables.png");
			}
			if (flag2)
			{
				xTexture.Draw(ScrollManager.GetScreenLoc(loc, 0), 71, new Vector2(1f, 1f) * 0.5f * ScrollManager.cannedDepth[0], 0f, 1f, 1f, 1f, 0.5f);
			}
			else
			{
				xTexture.Draw(ScrollManager.GetScreenLoc(loc, 0), 9, new Vector2(1f, 1f) * 0.5f * ScrollManager.cannedDepth[0], 0f, 1f, 1f, 1f, 0.5f);
			}
		}
		if (Game1.selLayer == 20)
		{
			Vector2 realLoc = ScrollManager.GetRealLoc(Game1.MVec(), 1f);
			int num6 = (int)((double)realLoc.X / 64.0);
			int num7 = (int)((double)realLoc.Y / 32.0);
			bool flag3 = false;
			float num8 = 0f;
			if (num7 > 0 && num7 < map.yUnits - 2 && num6 > 0 && num6 < map.xUnits - 1 && map.col[num6, num7].col == 0 && map.col[num6, num7 + 1].col != 0)
			{
				for (int k = num6 - 1; k <= num6 + 1; k += 2)
				{
					int num9 = 0;
					for (int l = num7; l < map.yUnits; l++)
					{
						bool flag4 = false;
						if (map.col[k, l].col == 0)
						{
							num9++;
						}
						else
						{
							flag4 = true;
						}
						if (flag4)
						{
							break;
						}
					}
					if ((double)(num9 - 1) * 32.0 >= 1440.0)
					{
						flag3 = true;
					}
					float num10 = (float)(num9 - 1) * 32f;
					if ((double)num10 > (double)num8)
					{
						num8 = num10;
					}
				}
				SpriteTools.sprite.DrawString(Game1.arial, num8.ToString(), ScrollManager.GetScreenLoc(new Vector2((float)(((double)num6 + 0.5) * 64.0), (float)((double)(num7 + 1) * 64.0 * 0.5)), 1f), new Color(1f, 1f, 1f, 1f), 0f, default(Vector2), 1f, SpriteEffects.None, 1f);
				if (flag3)
				{
					SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)(((double)num6 + 0.5) * 64.0), (float)((double)(num7 + 1) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 0f, 0.5f), -0.8f, new Vector2(0f, 0.5f), new Vector2(51.2f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
					SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)(((double)num6 + 0.5) * 64.0), (float)((double)(num7 + 1) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 0f, 0.5f), 3.941593f, new Vector2(0f, 0.5f), new Vector2(51.2f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
				}
			}
		}
		Vector2 realLoc2 = ScrollManager.GetRealLoc(default(Vector2), 0f);
		Vector2 realLoc3 = ScrollManager.GetRealLoc(ScrollManager.screenSize, 0f);
		int num11 = (int)((double)realLoc2.X / 64.0) - 1;
		int num12 = (int)((double)realLoc3.X / 64.0) + 2;
		int num13 = (int)((double)realLoc2.Y / 32.0) - 1;
		int num14 = (int)((double)realLoc3.Y / 32.0) + 2;
		for (int m = num11; m < num12; m++)
		{
			for (int n = num13; n < num14; n++)
			{
				if (m >= 0 && n >= 0 && m < map.xUnits && n < map.yUnits && map.col[m, n].col != 0)
				{
					switch (map.col[m, n].col)
					{
					case 2:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)(n + 1) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 0f, 0.5f), -0.47f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 3:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 0f, 0.5f), 0.47f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 4:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.25f) * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 1f, 0.5f), 0f, default(Vector2), new Vector2(5f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.75f) * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 1f, 0.5f), 0f, default(Vector2), new Vector2(5f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.5f) * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 1f, 0.5f), 0f, default(Vector2), new Vector2(5f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 5:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 6:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)(n + 1) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), -0.47f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 7:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0.47f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 8:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)(n + 1) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), -0.47f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 9:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0.47f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 10:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)((double)m * 64.0 + 64.0), (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0f, default(Vector2), new Vector2(1f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.5f) * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0f, default(Vector2), new Vector2(32f, 1f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 11:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0f, default(Vector2), new Vector2(1f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0f, default(Vector2), new Vector2(32f, 1f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 12:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.1f, 0f, 1f, 0.5f), 0f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.5f) * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.1f, 0f, 1f, 0.5f), 0f, default(Vector2), new Vector2(1f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 13:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)((float)n + 1f) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.1f, 0f, 1f, 0.5f), 0f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.5f) * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.1f, 0f, 1f, 0.5f), 0f, default(Vector2), new Vector2(1f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 14:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)((float)n + 0.5f) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 1f, 0.5f), 0f, default(Vector2), new Vector2(64f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.5f) * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 1f, 0.5f), 0f, default(Vector2), new Vector2(5f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 15:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0.1f, 0.6f, 0f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 16:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.5f) * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0.8f, default(Vector2), new Vector2(51.2f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.5f) * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 2.341593f, default(Vector2), new Vector2(51.2f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 17:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.5f) * 64f, (float)((double)(n + 1) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), -0.8f, default(Vector2), new Vector2(51.2f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2(((float)m + 0.5f) * 64f, (float)((double)(n + 1) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 3.941593f, default(Vector2), new Vector2(51.2f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 18:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)(m + 1) * 64f, (float)(((double)n + 0.5) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 2.791593f, default(Vector2), new Vector2(51.2f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)(m + 1) * 64f, (float)(((double)n + 0.5) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 3.491593f, default(Vector2), new Vector2(51.2f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					case 19:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)(((double)n + 0.5) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), 0.35f, default(Vector2), new Vector2(51.2f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)(((double)n + 0.5) * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(0f, 1f, 0f, 0.5f), -0.35f, default(Vector2), new Vector2(51.2f, 6.4f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					default:
						SpriteTools.sprite.Draw(Game1.nullTex, ScrollManager.GetScreenLoc(new Vector2((float)m * 64f, (float)((double)n * 64.0 * 0.5)), 0), new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 0f, 0.5f), 0f, default(Vector2), new Vector2(64f, 32f) * ScrollManager.cannedDepth[0], SpriteEffects.None, 1f);
						break;
					}
				}
			}
		}
	}

	public void DrawChests(SpriteFont arial)
	{
		Layer layer = map.layer[19];
		for (int i = 0; i < layer.seg.Count; i++)
		{
			Seg seg = layer.seg[i];
			if (seg == null)
			{
				continue;
			}
			Vector2 screenLoc = ScrollManager.GetScreenLoc(seg.loc, 0);
			if (!((double)screenLoc.X > 0.0) || !((double)screenLoc.Y > 0.0) || !((double)screenLoc.X < (double)ScrollManager.screenSize.X) || !((double)screenLoc.Y < (double)ScrollManager.screenSize.Y) || seg.strFlag == null)
			{
				continue;
			}
			string[] array = seg.strFlag.Split('\n');
			int num = 0;
			for (int j = 0; j < array.Length; j++)
			{
				string[] array2 = array[j].Split(' ');
				bool flag = false;
				for (int k = 0; k < array2.Length; k++)
				{
					if (array2[k] == "chest" || array2[k] == "drops" || array2[k] == "drop")
					{
						flag = true;
					}
					else
					{
						if (!flag)
						{
							continue;
						}
						float num2 = 0f;
						string text = array2[k];
						if (text.Contains('\r'))
						{
							text = text.Split('\r')[0];
						}
						if (text.Contains('/'))
						{
							text = text.Split('/')[0];
						}
						bool flag2 = true;
						Color color = new Color(1f, 0f, 0f, 1f);
						for (int l = 0; l < LootCatalog.category.Length; l++)
						{
							for (int m = 0; m < LootCatalog.category[l].loot.Count; m++)
							{
								if (LootCatalog.category[l].loot[m].name == text)
								{
									LootDef lootDef = LootCatalog.category[l].loot[m];
									color = new Color(1f, 1f, 1f, 1f);
									switch (l)
									{
									case 0:
										num2 = lootDef.values[5];
										color = new Color(1f, 0.5f, 0f, 1f);
										flag2 = Game1.filter == 0 || Game1.filter == 5;
										break;
									case 1:
										num2 = lootDef.values[9];
										color = new Color(0.5f, 0.5f, 1f, 1f);
										flag2 = Game1.filter == 0 || Game1.filter == 6;
										break;
									case 2:
										num2 = lootDef.values[8];
										color = new Color(1f, 1f, 0f, 1f);
										flag2 = Game1.filter == 0 || Game1.filter == 4;
										break;
									case 3:
										color = new Color(1f, 1f, 0.5f, 1f);
										flag2 = ((lootDef.type == 0) ? (Game1.filter == 0 || Game1.filter == 1) : (Game1.filter == 0 || Game1.filter == 2));
										break;
									case 4:
										color = new Color(0f, 1f, 0f, 1f);
										flag2 = Game1.filter == 0;
										text = array2[k];
										break;
									case 5:
										color = new Color(1f, 0f, 1f, 1f);
										flag2 = Game1.filter == 0 || Game1.filter == 3;
										break;
									case 6:
										color = new Color(1f, 0f, 0.5f, 1f);
										flag2 = Game1.filter == 0;
										break;
									case 7:
										color = new Color(0f, 1f, 1f, 1f);
										flag2 = Game1.filter == 0 || Game1.filter == 7;
										text = array2[k];
										break;
									}
								}
							}
						}
						if (flag2)
						{
							if ((double)num2 > 0.0)
							{
								text = text + ":" + num2;
							}
							SpriteTools.sprite.DrawString(arial, text, ScrollManager.GetScreenLoc(seg.loc, 0) + new Vector2(arial.MeasureString(text).X * -0.5f, (float)num * 30f), color);
							num++;
						}
						flag = false;
					}
				}
			}
		}
	}
}
