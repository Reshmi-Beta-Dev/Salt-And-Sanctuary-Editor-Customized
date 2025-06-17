using System;
using MapEdit;
using MapEdit.glows;
using MapEdit.map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower.gamestate;
using ProjectTower.map.entities;
using ProjectTower.particles;
using ProjectTower.texturesheet;
using SheetEdit.TextureSheet;
using xCharEdit;

namespace ProjectTower.map;

public class MapDraw
{
	public class AdditveSegStruct
	{
		public const int MAX_ADDITIVE_SEGS = 256;

		public int[] additiveSegs;

		public int totalAdditiveSegs;

		public AdditveSegStruct()
		{
			additiveSegs = new int[256];
		}
	}

	public AdditveSegStruct[] additiveSegs = new AdditveSegStruct[5];

	private const int ADDITIVE_SEG_ANY = 0;

	private const int ADDITIVE_SEG_I_BACK = 1;

	private const int ADDITIVE_SEG_I_MID = 2;

	private const int ADDITIVE_SEG_O_BACK = 3;

	private const int ADDITIVE_SEG_O_MID = 4;

	private const int ADDITIVE_SEG_TOTAL = 5;

	private int[] noParchmentSegs;

	public int totalNoParchmentSegs;

	private const int MAX_NO_PARCHMENT_SEGS = 256;

	public bool additive;

	private Map map;

	public MapDraw(Map map)
	{
		this.map = map;
		additiveSegs = new AdditveSegStruct[5];
		for (int i = 0; i < additiveSegs.Length; i++)
		{
			additiveSegs[i] = new AdditveSegStruct();
		}
		noParchmentSegs = new int[256];
	}

	public int Draw(XSprite cell, Seg seg, XTexture xTex, int additiveSegIdx, Color c, Vector2 loc, float r, Vector2 size, Effect effect, GlowMgr glowMgr, Vector2 scale, float alpha, int l, int ld, int i, int tX, int tY, int sX, int sY)
	{
		try
		{
			if (CheckIsDelayedDraw(cell, additiveSegIdx, tX, tY, l, i, loc, c, r, scale, xTex, seg))
			{
				return ld;
			}
			_ = additive;
			r = PreCellDraw(cell, l, ld, scale, seg, loc, r);
			if (l != ld)
			{
				ld = l;
				if (additive)
				{
					additive = false;
				}
				ResetLayerTintEffect(effect, l, alpha, sX, sY, tX, tY);
			}
			SpriteTools.sprite.Draw(xTex.texture, loc, cell.srcRect, c, r, cell.origin - new Vector2(cell.srcRect.X, cell.srcRect.Y), size, SpriteEffects.None, 0f);
			PostCellDraw(cell, seg, glowMgr, xTex, loc, scale, r);
		}
		catch (Exception ex)
		{
			GameConsole.WriteLine("*** Map draw error! ***");
			GameConsole.WriteLine("Layer: " + l + " seg: " + map.mapGrid.chunk[tX, tY].layer[l][i]);
			GameConsole.WriteLine(ex.StackTrace);
			GameConsole.WriteLine(ex.Message);
		}
		return ld;
	}

	public void CopyLayerEffect(Effect dest, Effect src)
	{
		dest.Parameters["r"].SetValue(src.Parameters["r"].GetValueSingle());
		dest.Parameters["g"].SetValue(src.Parameters["g"].GetValueSingle());
		dest.Parameters["b"].SetValue(src.Parameters["b"].GetValueSingle());
		dest.Parameters["tint"].SetValue(src.Parameters["tint"].GetValueSingle());
		dest.Parameters["sat"].SetValue(src.Parameters["sat"].GetValueSingle());
		dest.Parameters["gamma"].SetValue(src.Parameters["gamma"].GetValueSingle());
	}

	public void ResetLayerTintEffect(Effect effect, int l, float alpha, int sX, int sY, int tX, int tY)
	{
		SpriteTools.End();
		if (effect != null)
		{
			int num = -1;
			int num2 = (int)((double)ScrollManager.scroll.X / 64.0);
			int num3 = (int)((double)ScrollManager.scroll.Y / 32.0);
			if (num2 >= 0 && num3 >= 0 && num2 < map.xUnits && num3 < map.yUnits)
			{
				num = map.col[num2, num3].layer;
			}
			SetBloomTint(effect, l, num, num, 1f, 1f);
			effect.Parameters["a"].SetValue(alpha);
			SetMapEditTintEffects(sX, sY, tX, tY, effect, l);
			SpriteTools.BeginPMAlpha(effect);
		}
		else
		{
			SpriteTools.BeginAlpha();
		}
	}

	private void SetMapEditTintEffects(int sX, int sY, int tX, int tY, Effect effect, int l)
	{
		if (Game1.showMapGrid && (sX != tX || sY != tY))
		{
			effect.Parameters["r"].SetValue(1f);
			effect.Parameters["g"].SetValue(0f);
			effect.Parameters["b"].SetValue(0f);
			effect.Parameters["tint"].SetValue(0.5f);
		}
		if (Game1.highlightLayer)
		{
			if (Game1.selLayer > l)
			{
				effect.Parameters["r"].SetValue(1f);
				effect.Parameters["g"].SetValue(0f);
				effect.Parameters["b"].SetValue(0f);
				effect.Parameters["tint"].SetValue(0.5f);
			}
			else if (Game1.selLayer < l)
			{
				effect.Parameters["r"].SetValue(0f);
				effect.Parameters["g"].SetValue(1f);
				effect.Parameters["b"].SetValue(0f);
				effect.Parameters["tint"].SetValue(0.5f);
			}
			else if (Game1.selLayer == l)
			{
				effect.Parameters["r"].SetValue(1f);
				effect.Parameters["g"].SetValue(1f);
				effect.Parameters["b"].SetValue(0f);
				effect.Parameters["tint"].SetValue(0.5f);
			}
		}
	}

	private void PostCellDraw(XSprite cell, Seg seg, GlowMgr glowMgr, XTexture xTex, Vector2 loc, Vector2 scale, float r)
	{
		switch (cell.flags)
		{
		case 9:
		{
			if (cell.flags != 9)
			{
				break;
			}
			int num = (int)((double)seg.loc.X / 64.0);
			int num2 = (int)((double)seg.loc.Y / 32.0);
			if (num > 0 && num2 > 0 && num < map.xUnits && num2 < map.yUnits)
			{
				int col = map.col[num, num2].col;
				if ((uint)(col - 12) <= 1u)
				{
					SpriteTools.sprite.Draw(xTex.texture, loc, cell.srcRect, new Color(0f, 1f, 0f, 1f), r, cell.origin - new Vector2(cell.srcRect.X, cell.srcRect.Y), scale * ScrollManager.GetSize(seg.depth) * 0.25f, SpriteEffects.None, 1f);
				}
			}
			break;
		}
		case 22:
			DrawBossCandles(seg, glowMgr);
			break;
		case 28:
			RotWood.Draw((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0), 0, 0f, 0f);
			break;
		}
	}

	private bool CheckIsDelayedDraw(XSprite cell, int additiveSegIdx, int tX, int tY, int l, int i, Vector2 loc, Color c, float r, Vector2 scale, XTexture xTex, Seg seg)
	{
		switch (cell.flags)
		{
		case 8:
		case 21:
		case 25:
		case 26:
		case 53:
		case 54:
		case 55:
		case 56:
		case 57:
		case 58:
		case 59:
		case 60:
		case 65:
		case 78:
		case 79:
		case 87:
		case 89:
			AddAdditiveDraw(additiveSegIdx, tX, tY, l, i);
			return true;
		case 20:
		case 32:
			AddNoParchmentDraw(tX, tY, l, i);
			return true;
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
			SpriteTools.sprite.Draw(xTex.texture, loc, cell.srcRect, c, r, new Vector2(cell.srcRect.Width, cell.srcRect.Height) / 2f, scale * ScrollManager.GetSize(seg.depth), SpriteEffects.None, 1f);
			return true;
		case 91:
			AddNoParchmentDraw(tX, tY, l, i);
			AddAdditiveDraw(additiveSegIdx, tX, tY, l, i);
			return true;
		default:
			return false;
		}
	}

	private float PreCellDraw(XSprite cell, int l, int ld, Vector2 scale, Seg seg, Vector2 loc, float r)
	{
		switch (cell.flags)
		{
		case 5:
			r += (float)Math.Cos((double)map.delta * 2.0 + (double)seg.loc.X + (double)seg.loc.Y) * 0.1f;
			break;
		case 19:
			r += (float)Math.Cos((double)map.delta * 2.5 + (double)seg.loc.X + (double)seg.loc.Y) * 0.1f;
			break;
		case 34:
			r += (float)Math.Cos((double)map.delta * 2.0 + (double)seg.loc.X + (double)seg.loc.Y) * 0.1f;
			break;
		case 35:
			r += (float)Math.Cos((double)map.delta * 0.5 + (double)seg.loc.X + (double)seg.loc.Y) * 0.05f;
			break;
		case 61:
			r += (float)Math.Cos((double)map.delta * 1.0 + (double)seg.loc.X + (double)seg.loc.Y) * 0.015f;
			break;
		case 62:
			r += (float)Math.Cos((double)map.delta * 1.0 + (double)seg.loc.X + (double)seg.loc.Y) * 0.015f;
			break;
		case 66:
		case 67:
		case 68:
		{
			if (l != ld)
			{
				break;
			}
			float num2 = 34f;
			float num3 = 472f;
			switch (cell.flags)
			{
			case 66:
				num2 = 34f;
				num3 = 472f;
				break;
			case 67:
				num2 = 58f;
				num3 = 379f;
				break;
			case 68:
				num2 = 112f;
				num3 = 218f;
				break;
			}
			float x = num2 * scale.X;
			float num4 = num3 * scale.Y;
			float num5 = (float)Math.Cos((double)seg.rotation + 1.57079637050629);
			float num6 = (float)Math.Sin((double)seg.rotation + 1.57079637050629);
			for (int j = 0; j < 4; j++)
			{
				float num7 = (float)((double)map.delta / 6.28318548202515 * 2.0 + (double)seg.loc.X + (double)j / 4.0);
				float num8 = num7 - (float)(int)num7;
				XTexture xTexture = Game1.textures["sprites"];
				float num9 = 1f;
				if ((double)num8 < 0.400000005960464)
				{
					num9 *= num8 / 0.4f;
				}
				if ((double)num8 > 0.600000023841858)
				{
					num9 *= (float)((1.0 - (double)num8) / 0.400000005960464);
				}
				float num10 = num9 * 1.5f;
				Vector2 screenLoc = ScrollManager.GetScreenLoc(seg.loc + new Vector2(num5 * (num8 - 0.5f) * num4, num6 * (num8 - 0.5f) * num4), seg.depth);
				int idx = 138 + j;
				Vector2 scale2 = ScrollManager.GetSize(seg.depth) * 0.0065f * new Vector2(x, num10 * num4);
				double num11 = seg.rotation;
				xTexture.Draw(screenLoc, idx, scale2, (float)num11, 1f, 1f, 1f, 1f);
			}
			break;
		}
		case 71:
		case 72:
		case 73:
		{
			float num = 100f;
			switch (cell.flags)
			{
			case 71:
				num = 430f;
				break;
			case 72:
				num = 256f;
				break;
			case 73:
				num = 180f;
				break;
			}
			for (int i = 0; i < 4; i++)
			{
				Game1.textures["sprites"].Draw(loc, 138 + i, scale * ScrollManager.GetSize(seg.depth) * num * 0.0065f, (float)((double)map.delta * 2.0 * ((double)i - 1.5) * 0.200000002980232) + seg.loc.X, 1f, 1f, 1f, 1f);
			}
			break;
		}
		}
		return r;
	}

	private void AddNoParchmentDraw(int tX, int tY, int l, int i)
	{
		if (totalNoParchmentSegs < 256)
		{
			noParchmentSegs[totalNoParchmentSegs] = map.mapGrid.chunk[tX, tY].layer[l][i];
			totalNoParchmentSegs++;
		}
	}

	private void AddAdditiveDraw(int additiveSegIdx, int tX, int tY, int l, int i)
	{
		if (additiveSegs[additiveSegIdx].totalAdditiveSegs < 256)
		{
			additiveSegs[additiveSegIdx].additiveSegs[additiveSegs[additiveSegIdx].totalAdditiveSegs] = map.mapGrid.chunk[tX, tY].layer[l][i];
			additiveSegs[additiveSegIdx].totalAdditiveSegs++;
		}
	}

	public void SetBloomTint(Effect bloomTintEffect, int l, int layer, int pLayer, float layerProg, float detailFac)
	{
		LayerTintCatalog.SetBloomTint(bloomTintEffect, l, layer, pLayer, layerProg, detailFac);
	}

	private void DrawBossCandles(Seg seg, GlowMgr glowMgr)
	{
		float num = 0f;
		for (int i = 0; i < 9; i++)
		{
			float num2 = 0f;
			float num3 = (float)i / 9f;
			float num4 = ((float)i + 1f) / 9f;
			if ((double)num > (double)num4)
			{
				num2 = 1f;
			}
			else if ((double)num > (double)num3 && (double)num <= (double)num4)
			{
				num2 = (float)(((double)num - (double)num3) / ((double)num4 - (double)num3));
			}
			if ((double)num2 > 0.0)
			{
				Vector2 screenLoc = ScrollManager.GetScreenLoc(seg.loc + new Vector2(-40f, -150f) + new Vector2(10.2f * (float)i, (float)(0.0 - ((i % 2 == 1) ? 10.0 : 0.0))), 0);
				glowMgr.Add(1, screenLoc, num2, num2, num2, Rand.GetRandomFloat(0.1f, 0.15f) * ScrollManager.cannedDepth[0], 0);
				glowMgr.Add(1, screenLoc, num2, 0f, 0f, Rand.GetRandomFloat(0.2f, 0.25f) * ScrollManager.cannedDepth[0], 0);
				glowMgr.Add(1, screenLoc, num2 * 0.1f, 0f, 0f, Rand.GetRandomFloat(1f, 1.05f) * ScrollManager.cannedDepth[0], 0);
				if (i % 3 == 0)
				{
					glowMgr.Add(0, screenLoc, num2 * 0.5f, num2 * 0.3f, num2 * 0.1f, num2 * 5f * ScrollManager.cannedDepth[0], 0);
				}
			}
		}
	}

	public void DrawNoParchmentSegs(Layer layer, GlowMgr glowMgr)
	{
		float brite = map.brite;
		Color color = new Color(brite, brite, brite, 1f);
		for (int i = 0; i < totalNoParchmentSegs; i++)
		{
			Seg seg = layer.seg[noParchmentSegs[i]];
			float size = ScrollManager.GetSize(seg.depth);
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
			Vector2 screenLoc = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
			float num = seg.rotation;
			Vector2 vector = scaling * size;
			bool flag = true;
			switch (xSprite.flags)
			{
			case 20:
			{
				Vector2 loc = seg.loc;
				float num7 = (float)((double)map.delta + (double)seg.loc.X * 0.100000001490116 + (double)seg.loc.Y * 0.100000001490116);
				Vector2 vector2 = new Vector2((float)Math.Cos(num7), (float)Math.Sin(num7));
				Vector2 loc2 = loc + vector2 * new Vector2(-400f, 100f);
				if ((double)vector2.Y > 0.0)
				{
					loc2.Y += vector2.Y * 100f;
				}
				screenLoc = ScrollManager.GetScreenLoc(loc2, seg.depth);
				num += (float)Math.Cos((double)map.delta * 3.0 + (double)seg.loc.X + (double)seg.loc.Y) * 0.05f;
				break;
			}
			case 32:
			{
				num = map.delta + 0f;
				XSprite cell = xTexture.GetCell(seg.idx + 2);
				float num4 = (float)((double)map.delta / 6.28318548202515 * 20.0);
				float num5 = num4 - (float)(int)num4;
				float num6 = 236f;
				for (int k = 1; k < 11; k++)
				{
					SpriteTools.sprite.Draw(xTexture.texture, ScrollManager.GetScreenLoc(seg.loc + new Vector2(0f - num6, (float)((double)k * 100.0 - (double)num5 * 100.0)), seg.depth), cell.srcRect, color, 0f, cell.origin - new Vector2(cell.srcRect.X, cell.srcRect.Y), new Vector2(1f, 0.9f) * ScrollManager.GetSize(seg.depth), SpriteEffects.None, 0f);
					SpriteTools.sprite.Draw(xTexture.texture, ScrollManager.GetScreenLoc(seg.loc + new Vector2(num6, (float)((double)(k - 1) * 100.0 + (double)num5 * 100.0)), seg.depth), cell.srcRect, color, 0f, cell.origin - new Vector2(cell.srcRect.X, cell.srcRect.Y), new Vector2(1f, 0.9f) * ScrollManager.GetSize(seg.depth), SpriteEffects.None, 0f);
				}
				break;
			}
			case 91:
			{
				for (int j = 0; j < 10; j++)
				{
					float num2 = map.delta / 62.83186f * 1f + (float)j / 10f;
					float num3 = num2 - (float)(int)num2 - 0.5f;
					screenLoc = ScrollManager.GetScreenLoc(seg.loc + new Vector2(num3 * 9000f, 0f), seg.depth);
					Vector2 scale = vector;
					scale.Y += (float)(Math.Cos((double)seg.loc.X + ((double)num3 * 2.0 + 1.0) * 6.28318548202515 * 10.0 + (double)j * 3.70000004768372) * 0.100000001490116) * size;
					if ((double)screenLoc.X > -380.0 && (double)screenLoc.X < (double)ScrollManager.screenSize.X + 380.0)
					{
						SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, new Color(1f, 1f, 1f, 1f), num, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), scale, SpriteEffects.None, 0f);
					}
				}
				flag = false;
				break;
			}
			}
			if (flag)
			{
				SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, color, num, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), vector, SpriteEffects.None, 0f);
			}
			switch (xSprite.flags)
			{
			case 20:
			{
				XSprite cell2 = xTexture.GetCell(seg.idx + 1);
				Vector2 loc3 = seg.loc;
				float num8 = (float)((double)map.delta + (double)seg.loc.X * 0.100000001490116 + (double)seg.loc.Y * 0.100000001490116);
				Vector2 vector3 = new Vector2((float)Math.Cos(num8), (float)Math.Sin(num8));
				Vector2 loc4 = loc3 + vector3 * new Vector2(-400f, 100f);
				if ((double)vector3.Y > 0.0)
				{
					loc4.Y += vector3.Y * 100f;
				}
				loc4.X += (float)((double)vector3.X * 100.0 - 200.0) * scaling.X;
				if ((double)vector3.X > 0.0)
				{
					scaling.X -= vector3.X / 2f;
				}
				Vector2 screenLoc2 = ScrollManager.GetScreenLoc(loc4, seg.depth);
				float rotation = num - 0.5f;
				SpriteTools.sprite.Draw(xTexture.texture, screenLoc2, cell2.srcRect, color, rotation, cell2.origin - new Vector2(cell2.srcRect.X, cell2.srcRect.Y), vector, SpriteEffects.None, 0f);
				break;
			}
			case 32:
				SpriteTools.sprite.Draw(xTexture.texture, ScrollManager.GetScreenLoc(seg.loc + new Vector2(0f, 1000f), seg.depth), xSprite.srcRect, color, num, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), vector, SpriteEffects.None, 0f);
				break;
			}
		}
	}

	public int GetAdditiveSegLayerFromLayer(int layer)
	{
		return layer switch
		{
			4 => 3, 
			5 => 4, 
			14 => 1, 
			15 => 2, 
			_ => 0, 
		};
	}

	private void DrawAdditiveSegs(int l, Layer layer, int curLayer, int prevLayer, float layerProg, GlowMgr glowMgr, int additiveLayerIdx)
	{
		float brite = map.brite;
		for (int i = 0; i < additiveSegs[additiveLayerIdx].totalAdditiveSegs; i++)
		{
			Color color = new Color(brite, brite, brite, 1f);
			Seg seg = layer.seg[additiveSegs[additiveLayerIdx].additiveSegs[i]];
			float size = ScrollManager.GetSize(seg.depth);
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
			Vector2 screenLoc = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
			float rotation = seg.rotation;
			Vector2 vector = scaling * size;
			switch (xSprite.flags)
			{
			case 8:
			{
				float num13 = (float)((double)map.delta / 6.28318548202515 + (double)seg.loc.X / 16.0);
				float num14 = num13 - (float)(int)num13;
				screenLoc.X += num14 * 100f * ScrollManager.cannedDepth[0];
				color = (((double)num14 >= 0.5) ? (new Color(1f, 1f, 1f, 1f) * (1f - num14) * 2.72f) : (new Color(1f, 1f, 1f, 1f) * num14 * 2.72f));
				float rotation2 = rotation + num14 * 0.25f;
				SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, color, rotation2, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), vector, SpriteEffects.None, 1f);
				break;
			}
			case 21:
			{
				Vector2 loc = seg.loc;
				float num7 = (float)((double)map.delta + (double)seg.loc.X * 0.100000001490116 + (double)seg.loc.Y * 0.100000001490116);
				float num8 = (float)((double)map.delta + (double)seg.loc.X * 0.100000001490116 + (double)seg.loc.Y * 0.100000001490116);
				float num9 = num7 / 3.141593f * 3f;
				float num10 = num9 - (float)(int)num9;
				float num11 = seg.rotation + (float)Math.Cos((double)num8 + (double)seg.loc.X + (double)seg.loc.Y) * 0.05f;
				Vector2 vector2 = new Vector2((float)Math.Cos((double)num11 + 1.57079637050629), (float)Math.Sin((double)num11 + 1.57079637050629)) * num10 * 2000f;
				Vector2 screenLoc4 = ScrollManager.GetScreenLoc(loc + vector2, seg.depth);
				float num12 = (((double)num10 < 0.5) ? (num10 * 1.2f) : ((float)((1.0 - (double)num10) * 1.20000004768372))) * brite;
				color = new Color(num12, num12, num12, 1f);
				SpriteTools.sprite.Draw(xTexture.texture, screenLoc4, xSprite.srcRect, color, num11, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), vector, SpriteEffects.None, 1f);
				break;
			}
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
			case 58:
			case 59:
			case 60:
				SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, color, rotation, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), scaling * ScrollManager.GetSize(seg.depth), SpriteEffects.None, 1f);
				switch (xSprite.flags)
				{
				case 53:
					BlinkPlatMgr.DrawBlink((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0), 0, 0);
					break;
				case 54:
					BlinkPlatMgr.DrawBlink((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0), 0, 1);
					break;
				case 55:
					BlinkPlatMgr.DrawBlink((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0), 1, 0);
					break;
				case 56:
					BlinkPlatMgr.DrawBlink((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0), 1, 1);
					break;
				case 57:
					BlinkPlatMgr.DrawBlink((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0), 1, 2);
					break;
				case 58:
					BlinkPlatMgr.DrawBlink((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0), 1, 3);
					break;
				case 59:
					BlinkPlatMgr.DrawBlink((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0), 1, 4);
					break;
				case 60:
					BlinkPlatMgr.DrawBlink((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0), 1, 5);
					break;
				}
				break;
			case 65:
			case 89:
			{
				_ = ScrollManager.candleAlpha;
				if (xSprite.flags == 89)
				{
					glowMgr.Add(0, screenLoc, 0.3f, 0.3f, 0.3f, 4f * ScrollManager.GetSize(seg.depth), 0);
				}
				float num15 = 1f;
				if ((double)num15 > 0.0)
				{
					SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, new Color(1f, 1f, 1f, 1f) * 0.45f * num15, rotation, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), vector, SpriteEffects.None, 1f);
					SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, new Color(1f, 1f, 1f, 1f) * Rand.GetRandomFloat(0.5f, 0.7f) * num15, rotation, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), vector * Rand.GetRandomVec2(1f, 1f, 1f, 1.09f), SpriteEffects.None, 1f);
					glowMgr.Add(1, ScrollManager.GetScreenLoc(seg.loc + new Vector2(0f, Rand.GetRandomFloat(-35f, -30f)), seg.depth), 0.05f, 0.04f, 0.02f, Rand.GetRandomFloat(2.4f, 2.5f) * num15 * ScrollManager.GetSize(seg.depth), 1);
				}
				break;
			}
			case 78:
			case 79:
				SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, color, rotation, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), scaling * ScrollManager.GetSize(seg.depth), SpriteEffects.None, 1f);
				if (xSprite.flags == 79)
				{
					BlinkPlatMgr.DrawBlueEther((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0));
				}
				else
				{
					BlinkPlatMgr.DrawRedBlock((int)((double)seg.loc.X / 64.0), (int)((double)seg.loc.Y / 32.0));
				}
				break;
			case 87:
				SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, new Color(1f, 1f, 1f, 1f) * 0.45f, rotation, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), vector, SpriteEffects.None, 1f);
				SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, new Color(1f, 1f, 1f, 1f) * Rand.GetRandomFloat(0.5f, 0.7f), rotation, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), vector * Rand.GetRandomVec2(1f, 1f, 1f, 1.09f), SpriteEffects.None, 1f);
				break;
			case 91:
			{
				for (int j = 0; j < 10; j++)
				{
					float num = map.delta / 62.83186f * 1f + (float)j / 10f;
					float num2 = num - (float)(int)num - 0.5f;
					float num3 = -5000f;
					if (j % 2 == 0)
					{
						num3 = 3000f;
					}
					Vector2 screenLoc2 = ScrollManager.GetScreenLoc(seg.loc + new Vector2(num2 * num3, 0f), seg.depth);
					Vector2 scale = vector * 0.5f;
					scale.Y += (float)(Math.Cos((double)seg.loc.X + ((double)num2 * 2.0 + 1.0) * 6.28318548202515 * 10.0 + (double)j * 3.70000004768372) * 0.100000001490116) * size;
					XSprite originalCell = xTexture.GetOriginalCell(1);
					float num4 = (float)Math.Sin((double)seg.loc.X + ((double)num2 * 2.0 + 1.0) * 6.28318548202515 * 10.0 + (double)j * 3.70000004768372) * 0.35f;
					if ((double)screenLoc2.X > -380.0 && (double)screenLoc2.X < (double)ScrollManager.screenSize.X + 380.0 && (double)num4 > 0.0)
					{
						SpriteTools.sprite.Draw(xTexture.texture, screenLoc2, originalCell.srcRect, new Color(num4, num4, num4, 1f), rotation + ((j % 2 == 0) ? 3.141593f : 0f), originalCell.origin - new Vector2(originalCell.srcRect.X, originalCell.srcRect.Y), scale, SpriteEffects.None, 0f);
					}
					for (int k = 0; k < 4; k++)
					{
						Vector2 screenLoc3 = ScrollManager.GetScreenLoc(seg.loc + new Vector2((float)Math.Cos((double)k + (double)map.delta), (float)Math.Sin((double)k + (double)map.delta)) * new Vector2(200f, 50f) + new Vector2(num2 * 4000f, 0f), seg.depth);
						float num5 = (float)((Math.Sin((double)seg.loc.X + ((double)num2 * 2.0 + 1.0) * 6.28318548202515 * 10.0 + (double)j * 4.69999980926514 + (double)k) - 0.899999976158142) * 10.0);
						if ((double)screenLoc3.X > 0.0 && (double)screenLoc3.X < (double)ScrollManager.screenSize.X && (double)num5 > 0.0)
						{
							float num6 = num5 * 0.05f;
							Textures.tex[ParticleManager.spritesTexIdx].Draw(screenLoc3, 0, new Vector2(1f, 0.2f) * size * 2f, 0f, num6, num6, num6, 1f);
						}
					}
				}
				break;
			}
			default:
				SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, color, rotation, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), vector, SpriteEffects.None, 1f);
				break;
			}
		}
	}

	internal bool CheckAdditiveSegDraw(int additiveSegIdx, Layer[] layer, int l, int curLayer, int prevLayer, float layerProg, GlowMgr glowMgr)
	{
		bool result = false;
		if (additiveSegs[additiveSegIdx].totalAdditiveSegs > 0)
		{
			SpriteTools.End();
			SpriteTools.BeginAdditive();
			result = true;
			DrawAdditiveSegs(l, layer[l], curLayer, prevLayer, layerProg, glowMgr, additiveSegIdx);
			additiveSegs[additiveSegIdx].totalAdditiveSegs = 0;
		}
		return result;
	}

	internal int ResetAdditiveSegs(int l)
	{
		int additiveSegLayerFromLayer = GetAdditiveSegLayerFromLayer(l);
		additiveSegs[additiveSegLayerFromLayer].totalAdditiveSegs = 0;
		return additiveSegLayerFromLayer;
	}
}
