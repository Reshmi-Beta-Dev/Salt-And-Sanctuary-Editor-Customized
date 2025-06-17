using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower;
using SheetEdit.TextureSheet;

namespace MapEdit.map.sequence;

public class Change
{
	public string name;

	private SequenceLayer[] originalLayer;

	private SequenceLayer[] changeLayer;

	private int[,] originalCol;

	private int[,] changeCol;

	private int colX;

	private int colY;

	private List<string> script;

	public void Write(BinaryWriter writer)
	{
		writer.Write(name);
		for (int i = 0; i < originalLayer.Length; i++)
		{
			if (originalLayer[i] == null)
			{
				writer.Write(value: false);
				continue;
			}
			writer.Write(value: true);
			originalLayer[i].Write(writer);
		}
		for (int j = 0; j < changeLayer.Length; j++)
		{
			if (changeLayer[j] == null)
			{
				writer.Write(value: false);
				continue;
			}
			writer.Write(value: true);
			changeLayer[j].Write(writer);
		}
		writer.Write(colX);
		writer.Write(colY);
		writer.Write(originalCol.GetUpperBound(0) + 1);
		writer.Write(originalCol.GetUpperBound(1) + 1);
		for (int k = 0; k < originalCol.GetUpperBound(0) + 1; k++)
		{
			for (int l = 0; l < originalCol.GetUpperBound(1) + 1; l++)
			{
				writer.Write(originalCol[k, l]);
			}
		}
		writer.Write(changeCol.GetUpperBound(0) + 1);
		writer.Write(changeCol.GetUpperBound(1) + 1);
		for (int m = 0; m < changeCol.GetUpperBound(0) + 1; m++)
		{
			for (int n = 0; n < changeCol.GetUpperBound(1) + 1; n++)
			{
				writer.Write(changeCol[m, n]);
			}
		}
		writer.Write(script.Count);
		foreach (string item in script)
		{
			writer.Write(item);
		}
	}

	public void Read(BinaryReader reader)
	{
		name = reader.ReadString();
		originalLayer = new SequenceLayer[20];
		changeLayer = new SequenceLayer[20];
		for (int i = 0; i < originalLayer.Length; i++)
		{
			if (reader.ReadBoolean())
			{
				originalLayer[i].Read(reader);
			}
		}
		for (int j = 0; j < changeLayer.Length; j++)
		{
			if (reader.ReadBoolean())
			{
				changeLayer[j].Read(reader);
			}
		}
		colX = reader.ReadInt32();
		colY = reader.ReadInt32();
		originalCol = new int[reader.ReadInt32(), reader.ReadInt32()];
		for (int k = 0; k < originalCol.GetUpperBound(0) + 1; k++)
		{
			for (int l = 0; l < originalCol.GetUpperBound(1) + 1; l++)
			{
				originalCol[k, l] = reader.ReadInt32();
			}
		}
		changeCol = new int[reader.ReadInt32(), reader.ReadInt32()];
		for (int m = 0; m < changeCol.GetUpperBound(0) + 1; m++)
		{
			for (int n = 0; n < changeCol.GetUpperBound(1) + 1; n++)
			{
				changeCol[m, n] = reader.ReadInt32();
			}
		}
		int num = reader.ReadInt32();
		script = new List<string>();
		for (int num2 = 0; num2 < num; num2++)
		{
			script.Add(reader.ReadString());
		}
	}

	public void Set(Map changeMap, Map originalMap)
	{
		originalLayer = new SequenceLayer[20];
		changeLayer = new SequenceLayer[20];
		List<Point> list = new List<Point>();
		List<Point> list2 = new List<Point>();
		for (int i = 0; i < originalMap.layer.Length; i++)
		{
			Layer layer = originalMap.layer[i];
			for (int j = 0; j < layer.seg.Count; j++)
			{
				Seg seg = layer.seg[j];
				if (seg != null)
				{
					Seg seg2 = changeMap.layer[i].seg[j];
					if (seg2 != null && ((double)seg.loc.X != (double)seg2.loc.X || (double)seg.loc.Y != (double)seg2.loc.Y || (double)seg.rotation != (double)seg2.rotation || (double)seg.scaling.X != (double)seg2.scaling.X || (double)seg.scaling.Y != (double)seg2.scaling.Y))
					{
						list.Add(new Point(i, j));
					}
				}
			}
		}
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		for (int k = 0; k < originalMap.xUnits; k++)
		{
			for (int l = 0; l < originalMap.yUnits; l++)
			{
				if (originalMap.col[k, l].col != changeMap.col[k, l].col)
				{
					list2.Add(new Point(k, l));
					if (num == -1 || k < num)
					{
						num = k;
					}
					if (num2 == -1 || l < num2)
					{
						num2 = l;
					}
					if (num3 == -1 || k > num3)
					{
						num3 = k;
					}
					if (num4 == -1 || l > num4)
					{
						num4 = l;
					}
				}
			}
		}
		colX = num;
		colY = num2;
		originalCol = new int[num3 - num + 1, num4 - num2 + 1];
		changeCol = new int[num3 - num + 1, num4 - num2 + 1];
		foreach (Point item in list2)
		{
			originalCol[item.X - colX, item.Y - colY] = originalMap.col[item.X, item.Y].col;
			changeCol[item.X - colX, item.Y - colY] = changeMap.col[item.X, item.Y].col;
			Console.WriteLine("Col change: " + item.ToString() + ": " + originalMap.col[item.X, item.Y].col + " -> " + changeMap.col[item.X, item.Y].col);
		}
		foreach (Point item2 in list)
		{
			int x = item2.X;
			SequenceSeg sequenceSeg = new SequenceSeg(originalMap.layer[x].seg[item2.Y], item2.Y);
			SequenceSeg sequenceSeg2 = new SequenceSeg(changeMap.layer[x].seg[item2.Y], item2.Y);
			if (originalLayer[x] == null)
			{
				originalLayer[x] = new SequenceLayer();
			}
			if (changeLayer[x] == null)
			{
				changeLayer[x] = new SequenceLayer();
			}
			originalLayer[x].seg.Add(sequenceSeg);
			changeLayer[x].seg.Add(sequenceSeg2);
			Console.WriteLine("Seg change: " + sequenceSeg.loc.ToString() + " -> " + sequenceSeg2.loc.ToString());
		}
	}

	public Dictionary<int, List<int>> GetAffectedSegs(int ID, Dictionary<int, List<int>> rSegs)
	{
		if (originalLayer != null)
		{
			for (int i = 0; i < originalLayer.Length; i++)
			{
				if (originalLayer[i] == null)
				{
					continue;
				}
				for (int j = 0; j < originalLayer[i].seg.Count; j++)
				{
					SequenceSeg sequenceSeg = originalLayer[i].seg[j];
					if (!rSegs.ContainsKey(i))
					{
						rSegs.Add(i, new List<int>());
					}
					rSegs[i].Add(sequenceSeg.ID);
				}
			}
		}
		return rSegs;
	}

	internal void MoveCols(int mx, int my)
	{
		colX += mx;
		colY += my;
		for (int i = 0; i < originalLayer.Length; i++)
		{
			if (originalLayer[i] == null)
			{
				continue;
			}
			foreach (SequenceSeg item in originalLayer[i].seg)
			{
				item.loc += new Vector2((float)mx * 64f, (float)((double)my * 64.0 * 0.5));
			}
		}
		for (int j = 0; j < changeLayer.Length; j++)
		{
			if (changeLayer[j] == null)
			{
				continue;
			}
			foreach (SequenceSeg item2 in changeLayer[j].seg)
			{
				item2.loc += new Vector2((float)mx * 64f, (float)((double)my * 64.0 * 0.5));
			}
		}
	}

	internal void Draw()
	{
		if (changeLayer != null)
		{
			try
			{
				for (int i = 0; i < changeLayer.Length; i++)
				{
					if (changeLayer[i] == null)
					{
						continue;
					}
					foreach (SequenceSeg item in changeLayer[i].seg)
					{
						Seg seg = Game1.map.layer[i].seg[item.ID];
						XTexture xTexture = Game1.textures[seg.texture];
						if (xTexture.texture != null)
						{
							XSprite xSprite = xTexture.cell[seg.idx];
							Vector2 screenLoc = ScrollManager.GetScreenLoc(item.loc, seg.depth);
							float rotation = item.rotation;
							Vector2 scaling = item.scaling;
							SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, new Color(1f, 0f, 0f, 1f), rotation, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), scaling * ScrollManager.GetSize(seg.depth), SpriteEffects.None, 1f);
						}
					}
				}
				for (int j = 0; j < originalLayer.Length; j++)
				{
					if (originalLayer[j] == null)
					{
						continue;
					}
					foreach (SequenceSeg item2 in originalLayer[j].seg)
					{
						Seg seg2 = Game1.map.layer[j].seg[item2.ID];
						XTexture xTexture2 = Game1.textures[seg2.texture];
						if (xTexture2.texture != null)
						{
							XSprite xSprite2 = xTexture2.cell[seg2.idx];
							Vector2 screenLoc2 = ScrollManager.GetScreenLoc(item2.loc, seg2.depth);
							float rotation2 = item2.rotation;
							Vector2 scaling2 = item2.scaling;
							SpriteTools.sprite.Draw(xTexture2.texture, screenLoc2, xSprite2.srcRect, new Color(0f, 1f, 0f, 1f), rotation2, xSprite2.origin - new Vector2(xSprite2.srcRect.X, xSprite2.srcRect.Y), scaling2 * ScrollManager.GetSize(seg2.depth), SpriteEffects.None, 1f);
						}
					}
				}
			}
			catch
			{
			}
		}
		if (originalCol == null)
		{
			return;
		}
		for (int k = 0; k < originalCol.GetUpperBound(0) + 1; k++)
		{
			for (int l = 0; l < originalCol.GetUpperBound(1) + 1; l++)
			{
				_ = originalCol[k, l];
				if (changeCol[k, l] == 0)
				{
					Vector2 screenLoc3 = ScrollManager.GetScreenLoc(new Vector2((float)(((double)(k + colX) + 0.5) * 64.0), (float)(((double)(l + colY) + 0.5) * 64.0 * 0.5)), 0);
					Vector2 scale = new Vector2(60f, 2f) * ScrollManager.GetSize(0f);
					float num = 0.5f;
					SpriteTools.sprite.Draw(Game1.nullTex, screenLoc3, new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 0f, 0.5f), num, new Vector2(0.5f, 0.5f), scale, SpriteEffects.None, 1f);
					SpriteTools.sprite.Draw(Game1.nullTex, screenLoc3, new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 0f, 0.5f), 0f - num, new Vector2(0.5f, 0.5f), scale, SpriteEffects.None, 1f);
				}
			}
		}
	}

	internal void Swap(int selLayer, int i, int j)
	{
		if (changeLayer[selLayer] == null || originalLayer[selLayer] == null)
		{
			return;
		}
		foreach (SequenceSeg item in originalLayer[selLayer].seg)
		{
			if (item.ID == i)
			{
				item.ID = j;
			}
			else if (item.ID == j)
			{
				item.ID = i;
			}
		}
		foreach (SequenceSeg item2 in changeLayer[selLayer].seg)
		{
			if (item2.ID == i)
			{
				item2.ID = j;
			}
			else if (item2.ID == j)
			{
				item2.ID = i;
			}
		}
	}
}
