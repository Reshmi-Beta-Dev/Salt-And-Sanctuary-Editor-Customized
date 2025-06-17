using System.Collections.Generic;
using System.IO;
using MapEdit.glows;
using MapEdit.map.sequence;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower;
using ProjectTower.gamestate;
using ProjectTower.io;
using ProjectTower.map;
using ProjectTower.texturesheet;
using SheetEdit.TextureSheet;
using xCharEdit;

namespace MapEdit.map;

public class Map
{
	public struct Col
	{
		public int col;

		public int layer;

		internal void Read(BinaryReader reader)
		{
			col = reader.ReadByte();
			layer = reader.ReadByte();
		}

		internal void Write(BinaryWriter writer)
		{
			writer.Write((byte)col);
			writer.Write((byte)layer);
		}
	}

	public int xUnits = 1;

	public int yUnits = 1;

	public int background = -1;

	public Layer[] layer;

	public SequenceMgr sequenceMgr;

	public MapGrid mapGrid;

	public MapEditDraw mapEditDraw;

	public MapDraw mapDraw;

	public MapUpdate mapUpdate;

	public Col[,] col;

	public const int COL_NONE = 0;

	public const int COL_FULL = 1;

	public const int COL_RISE = 2;

	public const int COL_FALL = 3;

	public const int COL_SPIKES = 4;

	public const int COL_LEDGE = 5;

	public const int COL_LEDGE_RISE = 6;

	public const int COL_LEDGE_FALL = 7;

	public const int COL_TRAPDOOR_RISE = 8;

	public const int COL_TRAPDOOR_FALL = 9;

	public const int COL_LADDER_RIGHT = 10;

	public const int COL_LADDER_LEFT = 11;

	public const int COL_PLAT_TOP_LIMIT = 12;

	public const int COL_PLAT_BOTTOM_LIMIT = 13;

	public const int COL_OBELISK_LIMIT = 14;

	public const int COL_POISON = 15;

	public const int COL_PIPE_UP = 16;

	public const int COL_PIPE_DOWN = 17;

	public const int COL_PIPE_RIGHT = 18;

	public const int COL_PIPE_LEFT = 19;

	public const int COL_BLINK_MAIN_1 = 90;

	public const int COL_BLINK_MAIN_2 = 91;

	public const int COL_BLINK_QUICK_1 = 92;

	public const int COL_BLINK_QUICK_2 = 93;

	public const int COL_BLINK_QUICK_3 = 94;

	public const int COL_BLINK_QUICK_4 = 95;

	public const int COL_BLINK_QUICK_5 = 96;

	public const int COL_BLINK_QUICK_6 = 97;

	public const int COL_RED_BLOCK = 98;

	public const int COL_BLUE_ETHER = 99;

	public const int COL_ROT_WOOD_START_IDX = 100;

	public const int COL_ROT_WOOD_END_IDX = 1100;

	public const int COL_RED_EMPTY = 1101;

	public const int COL_BLUE_EMPTY = 1102;

	public const int LAYER_OUTSIDE = 0;

	public const int LAYER_DUNGEON = 1;

	public const int LAYER_SANCTUARY = 2;

	public const int LAYER_FORTRESS = 3;

	public const int LAYER_FOREST = 4;

	public const int LAYER_VILLAGE = 5;

	public const int LAYER_SHIP_IN = 6;

	public const int LAYER_SHIP_OUT = 7;

	public const int LAYER_DARK_CAVE = 8;

	public const int LAYER_RED_DUNGEON = 9;

	public const int LAYER_BLUE_CAVE = 10;

	public const int LAYER_SWAMP = 11;

	public const int LAYER_STORMY = 12;

	public const int LAYER_DOME = 13;

	public const int LAYER_RUINS = 14;

	public const int LAYER_LAKE = 15;

	public const int LAYER_DARKWOODS = 16;

	public const int LAYER_PYRAMID = 17;

	public const int LAYER_MINE = 18;

	public const int LAYER_LAB = 19;

	public const int LAYER_TOMB = 20;

	public const int LAYER_PALACE = 21;

	public const int LAYER_INNER_PALACE = 22;

	public const int LAYER_WELL = 23;

	public const int LAYER_INNER_DUNGEON = 24;

	public const int LAYER_RESCUED = 25;

	public const int LAYER_STARRY = 26;

	public const int TOTAL_LAYERS = 27;

	public const float CHAR_FALLING_PAIN = 360f;

	public const float CHAR_FALLING_MAJOR_PAIN = 720f;

	public const float CHAR_FALLING_NEAR_DEATH = 1080f;

	public const float CHAR_FALLING_DEATH = 1440f;

	public float delta;

	public float pDelta;

	public float brite;

	public float glowBrite;

	public const float FCELL = 64f;

	public const int ICELL = 64;

	public const int MAX_UNITS = 10;

	private int actorIdx;

	public bool camp;

	public void CopyFrom(Map map)
	{
		for (int i = 0; i < layer.Length; i++)
		{
			layer[i].CopyFrom(map.layer[i]);
		}
		xUnits = map.xUnits;
		yUnits = map.yUnits;
		col = new Col[xUnits, yUnits];
		for (int j = 0; j < xUnits; j++)
		{
			for (int k = 0; k < yUnits; k++)
			{
				col[j, k].col = map.col[j, k].col;
				col[j, k].layer = map.col[j, k].layer;
			}
		}
	}

	public void ResetLayers()
	{
		layer = new Layer[20];
		for (int i = 0; i < layer.Length; i++)
		{
			layer[i] = new Layer();
		}
		layer[0].depth = 20f;
		layer[1].depth = 12f;
		layer[2].depth = 8f;
		layer[3].depth = 4f;
		layer[4].depth = 2f;
		layer[5].depth = 1f;
		layer[6].depth = 1f;
		layer[7].depth = 0f;
		layer[8].depth = -1f;
		layer[9].depth = -2f;
		layer[10].depth = -4f;
		layer[11].depth = 12f;
		layer[12].depth = 8f;
		layer[13].depth = 4f;
		layer[14].depth = 2f;
		layer[15].depth = 1f;
		layer[16].depth = 1f;
		layer[17].depth = 0f;
		layer[18].depth = -1f;
		layer[19].depth = 1f;
		sequenceMgr = new SequenceMgr();
	}

	public Map()
	{
		mapGrid = new MapGrid();
		ResetLayers();
		col = new Col[200, 400];
		xUnits = 1;
		yUnits = 1;
		mapEditDraw = new MapEditDraw(this);
		mapDraw = new MapDraw(this);
		mapUpdate = new MapUpdate(this);
		brite = 1f;
	}

	public void SetCol(int x, int y, int c, int lr)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		if (x < 0)
		{
			num = -x;
			num3 = num;
			x = 0;
		}
		else if (x >= xUnits)
		{
			num3 = x + 1 - xUnits;
		}
		if (y < 0)
		{
			int i;
			for (i = 50; i < -y; i += 50)
			{
			}
			num2 = i;
			num4 = i;
			y += i;
		}
		else if (y >= yUnits)
		{
			num4 = y + 1 - yUnits;
		}
		if (num3 != 0 || num4 != 0)
		{
			sequenceMgr.MoveCols(num, num2);
			int num5 = xUnits;
			int num6 = yUnits;
			Col[,] array = new Col[xUnits, yUnits];
			for (int j = 0; j < xUnits; j++)
			{
				for (int k = 0; k < yUnits; k++)
				{
					array[j, k].col = col[j, k].col;
					array[j, k].layer = col[j, k].layer;
				}
			}
			xUnits += num3;
			yUnits += num4;
			col = new Col[xUnits, yUnits];
			for (int l = 0; l < num5; l++)
			{
				for (int m = 0; m < num6; m++)
				{
					col[l + num, m + num2].col = array[l, m].col;
					col[l + num, m + num2].layer = array[l, m].layer;
				}
			}
			for (int n = 0; n < layer.Length; n++)
			{
				foreach (Seg item in layer[n].seg)
				{
					item.loc += new Vector2((float)num * 64f, (float)((double)num2 * 64.0 * 0.5));
				}
			}
		}
		if (c > -1)
		{
			col[x, y].col = c;
		}
		if (lr > -1)
		{
			col[x, y].layer = lr;
		}
		ScrollManager.scroll += new Vector2((float)num * 64f, (float)((double)num2 * 64.0 * 0.5));
	}

	public void RefreshDepths()
	{
		for (int i = 0; i < 20; i++)
		{
			layer[i].RefreshDepths();
		}
	}

	public void Draw(int startLayer, int endLayer, GlowMgr glowMgr, Effect effect, float alpha)
	{
		mapDraw.additive = false;
		actorIdx = 0;
		int num = -1;
		if (mapGrid.needsUpdate)
		{
			mapGrid.Create(this);
		}
		int num2 = (int)((double)ScrollManager.scroll.X / 3200.0);
		int num3 = (int)((double)ScrollManager.scroll.Y / 1600.0);
		for (int i = startLayer; i < endLayer; i++)
		{
			float size = ScrollManager.GetSize(this.layer[i].depth);
			int additiveSegIdx = mapDraw.ResetAdditiveSegs(i);
			mapDraw.totalNoParchmentSegs = 0;
			Layer layer = this.layer[i];
			float num4 = brite;
			Color color = new Color(num4, num4, num4, 1f);
			for (int j = num2 - 1; j < num2 + 2; j++)
			{
				for (int k = num3 - 1; k < num3 + 2; k++)
				{
					num = -1;
					if (j < 0 || k < 0 || j >= mapGrid.tX || k >= mapGrid.tY)
					{
						continue;
					}
					for (int l = 0; l < mapGrid.chunk[j, k].layer[i].Length; l++)
					{
						Seg seg = layer.seg[mapGrid.chunk[j, k].layer[i][l]];
						if (seg == null)
						{
							continue;
						}
						XTexture xTexture = Game1.textures[seg.texture];
						if (xTexture.texture == null)
						{
							xTexture.texture = ContentRig.LoadTextureFromFile("\\gfx\\" + xTexture.name + ".png");
						}
						XSprite xSprite = xTexture.cell[(seg.idx < xTexture.cell.Length) ? seg.idx : 0];
						if (seg.idx >= xTexture.cell.Length)
						{
							seg.idx = xTexture.cell.Length - 1;
						}
						Vector2 scaling = seg.scaling;
						color = new Color(num4, num4, num4, 1f);
						bool flag = false;
						if (xTexture.type == 3)
						{
							try
							{
								Game1.actorMgr.actor[actorIdx].Draw(Game1.textures[Game1.actorMgr.actor[actorIdx].mDef.texture], 1f);
							}
							catch
							{
							}
							actorIdx++;
							flag = true;
						}
						if (GetHideBossCell(xSprite))
						{
							flag = true;
						}
						if (flag)
						{
							continue;
						}
						Vector2 screenLoc = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
						float r = seg.rotation;
						Vector2 size2 = scaling * size;
						float num5 = (float)(((xSprite.srcRect.Width > xSprite.srcRect.Height) ? ((double)xSprite.srcRect.Width) : ((double)xSprite.srcRect.Height)) * (((double)size2.X > (double)size2.Y) ? ((double)size2.X) : ((double)size2.Y)));
						float num6 = 0f;
						bool flag2 = false;
						if (xSprite.flags == 32)
						{
							num6 = -800f;
						}
						if (!seg.hasVisRect && (double)screenLoc.X > 0.0 - (double)num5 && (double)screenLoc.Y > (double)num6 - (double)num5 && (double)screenLoc.X < (double)ScrollManager.screenSize.X + (double)num5 && (double)screenLoc.Y < (double)ScrollManager.screenSize.Y + (double)num5)
						{
							flag2 = true;
						}
						if (flag2)
						{
							if (seg.texture == "smashables")
							{
								screenLoc = ScrollManager.GetScreenLoc(new Vector2(seg.loc.X, (float)((double)(int)((double)seg.loc.Y / 32.0) * 32.0 - 8.0)), seg.depth);
								r = 0f;
								SpriteTools.End();
								SpriteTools.BeginAlpha();
							}
							num = mapDraw.Draw(xSprite, seg, xTexture, additiveSegIdx, color, screenLoc, r, size2, effect, glowMgr, scaling, alpha, i, num, l, j, k, num2, num3);
							if (seg.texture == "smashables")
							{
								SpriteTools.End();
								SpriteTools.BeginPMAlpha();
								num = -1;
							}
						}
						if (glowMgr != null)
						{
							mapUpdate.AddGlowsToDrawList(xTexture, seg, glowMgr, layer);
						}
					}
				}
			}
			if (mapDraw.totalNoParchmentSegs > 0)
			{
				SpriteTools.End();
				int pLayer = -1;
				int num7 = (int)((double)ScrollManager.scroll.X / 64.0);
				int num8 = (int)((double)ScrollManager.scroll.Y / 32.0);
				if (num7 >= 0 && num8 >= 0 && num7 < xUnits && num8 < yUnits)
				{
					pLayer = col[num7, num8].layer;
				}
				mapDraw.SetBloomTint(effect, i, pLayer, pLayer, 1f, 1f);
				effect.Parameters["a"].SetValue(alpha);
				SpriteTools.BeginPMAlpha(effect);
				mapDraw.DrawNoParchmentSegs(this.layer[i], glowMgr);
				mapDraw.totalNoParchmentSegs = 0;
				num = -1;
			}
			int num9 = -1;
			int num10 = (int)((double)ScrollManager.scroll.X / 64.0);
			int num11 = (int)((double)ScrollManager.scroll.Y / 32.0);
			if (num10 >= 0 && num11 >= 0 && num10 < xUnits && num11 < yUnits)
			{
				num9 = col[num10, num11].layer;
			}
			mapDraw.additive = mapDraw.CheckAdditiveSegDraw(additiveSegIdx, this.layer, i, num9, num9, 1f, glowMgr);
			_ = 17;
		}
		if (mapDraw.additive || num != -1)
		{
			SpriteTools.End();
			SpriteTools.BeginPMAlpha();
		}
	}

	private bool GetHideBossCell(XSprite cell)
	{
		if (Game1.hideBossBounds)
		{
			int flags = cell.flags;
			if (flags == 16 || (uint)(flags - 36) <= 16u)
			{
				return true;
			}
		}
		return false;
	}

	private bool GetNoDraw(XTexture texture, Seg seg, int layer)
	{
		switch (texture.type)
		{
		case 2:
			switch (texture.GetCell(seg.idx).flags)
			{
			case 1:
			case 2:
			case 3:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 27:
			case 28:
			case 29:
			case 30:
			case 33:
			case 36:
			case 37:
			case 38:
			case 39:
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 63:
			case 75:
			case 76:
			case 77:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 88:
			case 90:
			case 93:
				return true;
			}
			break;
		case 3:
			return true;
		}
		return false;
	}

	private bool GetMapNoDraw(XTexture texture, Seg seg, int layer)
	{
		return false;
	}

	public void Write(string path, Dictionary<string, XTexture> textures)
	{
		BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.Write));
		binaryWriter.Write(xUnits);
		binaryWriter.Write(yUnits);
		for (int i = 0; i < layer.Length; i++)
		{
			if (i == 19)
			{
				layer[i].WriteEntities(binaryWriter);
			}
			else
			{
				layer[i].Write(binaryWriter, textures);
			}
		}
		for (int j = 0; j < xUnits; j++)
		{
			int num = 0;
			for (int k = 0; k < yUnits; k++)
			{
				if (k > num && col[j, k].col != col[j, num].col)
				{
					binaryWriter.Write(k - num);
					binaryWriter.Write((byte)col[j, num].col);
					num = k;
				}
			}
			binaryWriter.Write(yUnits - num);
			binaryWriter.Write((byte)col[j, num].col);
			binaryWriter.Write(-1);
		}
		for (int l = 0; l < xUnits; l++)
		{
			int num2 = 0;
			for (int m = 0; m < yUnits; m++)
			{
				if (m > num2 && col[l, m].layer != col[l, num2].layer)
				{
					binaryWriter.Write(m - num2);
					binaryWriter.Write((byte)col[l, num2].layer);
					num2 = m;
				}
			}
			binaryWriter.Write(yUnits - num2);
			binaryWriter.Write((byte)col[l, num2].layer);
			binaryWriter.Write(-1);
		}
		Game1.map.sequenceMgr.Write(binaryWriter);
		binaryWriter.Close();
		GameConsole.WriteLine("Saved: " + path);
	}

	public bool TestCol(Vector3 loc)
	{
		int num = (int)((double)loc.X / 128.0);
		int num2 = (int)((double)loc.Y / 128.0);
		if (num >= 0 && num2 >= 0 && num < xUnits * 10 && num2 < 10)
		{
			return col[num, num2].col == 1;
		}
		return true;
	}

	public void Read(string path)
	{
		FileMgr.Open(path);
		ResetLayers();
		xUnits = FileMgr.reader.ReadInt32();
		yUnits = FileMgr.reader.ReadInt32();
		col = new Col[xUnits, yUnits];
		for (int i = 0; i < layer.Length; i++)
		{
			if (i == 19)
			{
				layer[i].ReadEntities(FileMgr.reader);
			}
			else
			{
				layer[i].Read(FileMgr.reader);
			}
		}
		for (int j = 0; j < xUnits; j++)
		{
			int num = 0;
			while (true)
			{
				int num2 = FileMgr.reader.ReadInt32();
				if (num2 == -1)
				{
					break;
				}
				int num3 = FileMgr.reader.ReadByte();
				for (int k = 0; k < num2; k++)
				{
					col[j, num].col = num3;
					num++;
				}
			}
		}
		for (int l = 0; l < xUnits; l++)
		{
			int num4 = 0;
			while (true)
			{
				int num5 = FileMgr.reader.ReadInt32();
				if (num5 == -1)
				{
					break;
				}
				int num6 = FileMgr.reader.ReadByte();
				for (int m = 0; m < num5; m++)
				{
					col[l, num4].layer = num6;
					num4++;
				}
			}
		}
		sequenceMgr.Read(FileMgr.reader);
		FileMgr.Close();
		RefreshDepths();
		mapGrid.needsUpdate = true;
	}

	internal void DrawSeg(Dictionary<string, XTexture> textures, int idx, float brite)
	{
		Seg seg = layer[15].seg[idx];
		float num = 1f;
		XTexture xTexture = Textures.tex[seg.textureIdx];
		XSprite cell = xTexture.GetCell(seg.idx);
		SpriteTools.sprite.Draw(xTexture.texture, ScrollManager.GetScreenLoc(seg.loc, seg.depth), cell.srcRect, new Color(brite, brite, brite, 1f), seg.rotation, cell.origin - new Vector2(cell.srcRect.X, cell.srcRect.Y), seg.scaling * ScrollManager.GetSize(seg.depth) * num, SpriteEffects.None, 1f);
	}

	internal void Reset()
	{
	}
}
