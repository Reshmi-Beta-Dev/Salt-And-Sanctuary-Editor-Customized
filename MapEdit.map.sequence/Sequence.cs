using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower;
using SheetEdit.TextureSheet;

namespace MapEdit.map.sequence;

public class Sequence
{
	public class SequenceState
	{
		public SequenceLayer[] layer;

		public int[,] col;

		public int colX;

		public int colY;
	}

	public float duration = 2f;

	public string name;

	private List<SequenceState> states;

	public int editNode;

	public List<string> script;

	public const int STATE_OFF = 0;

	public const int STATE_ON = 1;

	public const int STATE_ACTIVATING = 2;

	public const int STATE_DEACTIVATING = 3;

	public int playState;

	public int playNode;

	public float playFrame;

	public int sequenceType;

	public const int SEQ_NONE = 0;

	public const int SEQ_WOOD_DOOR = 1;

	public const int SEQ_LADDER = 2;

	public const int SEQ_STONE_DOOR = 3;

	public Vector2 center;

	public bool taper;

	public void Activate()
	{
		playState = 2;
	}

	public void Deactivate()
	{
		playState = 3;
	}

	public void Toggle()
	{
		switch (playState)
		{
		case 0:
			playState = 2;
			playFrame = 0f;
			break;
		case 1:
			playState = 3;
			playFrame = duration;
			break;
		case 2:
			playState = 3;
			break;
		case 3:
			playState = 2;
			break;
		}
	}

	public void SetCols(Map map, bool next)
	{
		int index = playNode * 2 + (next ? 1 : 0);
		for (int i = 0; i < states[index].col.GetUpperBound(0) + 1; i++)
		{
			for (int j = 0; j < states[index].col.GetUpperBound(1) + 1; j++)
			{
				if (states[index].col[i, j] != -1)
				{
					map.col[states[index].colX + i, states[index].colY + j].col = states[index].col[i, j];
				}
			}
		}
	}

	public void Write(BinaryWriter writer)
	{
		writer.Write(name);
		writer.Write(states.Count);
		for (int i = 0; i < states.Count; i++)
		{
			for (int j = 0; j < states[i].layer.Length; j++)
			{
				if (states[i].layer[j] == null)
				{
					writer.Write(value: false);
					continue;
				}
				writer.Write(value: true);
				states[i].layer[j].Write(writer);
			}
			writer.Write(states[i].colX);
			writer.Write(states[i].colY);
			writer.Write(states[i].col.GetUpperBound(0) + 1);
			writer.Write(states[i].col.GetUpperBound(1) + 1);
			for (int k = 0; k < states[i].col.GetUpperBound(0) + 1; k++)
			{
				for (int l = 0; l < states[i].col.GetUpperBound(1) + 1; l++)
				{
					writer.Write(states[i].col[k, l]);
				}
			}
		}
		if (script == null)
		{
			writer.Write(0);
			return;
		}
		writer.Write(script.Count);
		foreach (string item in script)
		{
			writer.Write(item);
		}
	}

	public void Reset()
	{
		playState = 0;
		playNode = 0;
		playFrame = 0f;
	}

	public void Read(BinaryReader reader)
	{
		name = reader.ReadString();
		int num = reader.ReadInt32();
		states = new List<SequenceState>();
		for (int i = 0; i < num; i++)
		{
			states.Add(new SequenceState());
		}
		for (int j = 0; j < num; j++)
		{
			states[j].layer = new SequenceLayer[20];
			for (int k = 0; k < states[j].layer.Length; k++)
			{
				if (reader.ReadBoolean())
				{
					states[j].layer[k] = new SequenceLayer();
					states[j].layer[k].Read(reader);
				}
			}
			states[j].colX = reader.ReadInt32();
			states[j].colY = reader.ReadInt32();
			states[j].col = new int[reader.ReadInt32(), reader.ReadInt32()];
			for (int l = 0; l < states[j].col.GetUpperBound(0) + 1; l++)
			{
				for (int m = 0; m < states[j].col.GetUpperBound(1) + 1; m++)
				{
					states[j].col[l, m] = reader.ReadInt32();
				}
			}
		}
		int num2 = reader.ReadInt32();
		script = new List<string>();
		for (int n = 0; n < num2; n++)
		{
			script.Add(reader.ReadString());
		}
	}

	public void Set(Map changeMap, Map originalMap)
	{
		if (states == null)
		{
			states = new List<SequenceState>();
		}
		while (states.Count < (editNode + 1) * 2)
		{
			states.Add(new SequenceState());
		}
		states[editNode * 2].layer = new SequenceLayer[20];
		states[editNode * 2 + 1].layer = new SequenceLayer[20];
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
		states[editNode * 2].colX = num;
		states[editNode * 2].colY = num2;
		states[editNode * 2 + 1].colX = num;
		states[editNode * 2 + 1].colY = num2;
		states[editNode * 2].col = new int[num3 - num + 1, num4 - num2 + 1];
		states[editNode * 2 + 1].col = new int[num3 - num + 1, num4 - num2 + 1];
		for (int m = 0; m < states[editNode * 2].col.GetUpperBound(0) + 1; m++)
		{
			for (int n = 0; n < states[editNode * 2].col.GetUpperBound(1) + 1; n++)
			{
				states[editNode * 2].col[m, n] = -1;
				states[editNode * 2 + 1].col[m, n] = -1;
			}
		}
		foreach (Point item in list2)
		{
			states[editNode * 2].col[item.X - num, item.Y - num2] = originalMap.col[item.X, item.Y].col;
			states[editNode * 2 + 1].col[item.X - num, item.Y - num2] = changeMap.col[item.X, item.Y].col;
			Console.WriteLine("Col change: " + item.ToString() + ": " + originalMap.col[item.X, item.Y].col + " -> " + changeMap.col[item.X, item.Y].col);
		}
		foreach (Point item2 in list)
		{
			int x = item2.X;
			SequenceSeg sequenceSeg = new SequenceSeg(originalMap.layer[x].seg[item2.Y], item2.Y);
			SequenceSeg sequenceSeg2 = new SequenceSeg(changeMap.layer[x].seg[item2.Y], item2.Y);
			if (states[editNode * 2].layer[x] == null)
			{
				states[editNode * 2].layer[x] = new SequenceLayer();
			}
			if (states[editNode * 2 + 1].layer[x] == null)
			{
				states[editNode * 2 + 1].layer[x] = new SequenceLayer();
			}
			states[editNode * 2].layer[x].seg.Add(sequenceSeg);
			states[editNode * 2 + 1].layer[x].seg.Add(sequenceSeg2);
			Console.WriteLine("Seg change: " + sequenceSeg.loc.ToString() + " -> " + sequenceSeg2.loc.ToString());
		}
	}

	public Dictionary<int, List<int>> GetAffectedSegs(int ID, Dictionary<int, List<int>> rSegs)
	{
		if (states == null)
		{
			return new Dictionary<int, List<int>>();
		}
		for (int i = 0; i < states.Count; i++)
		{
			if (states[i].layer == null)
			{
				continue;
			}
			for (int j = 0; j < states[i].layer.Length; j++)
			{
				if (states[i].layer[j] == null)
				{
					continue;
				}
				for (int k = 0; k < states[i].layer[j].seg.Count; k++)
				{
					SequenceSeg sequenceSeg = states[i].layer[j].seg[k];
					if (!rSegs.ContainsKey(j))
					{
						rSegs.Add(j, new List<int>());
					}
					rSegs[j].Add(sequenceSeg.ID);
				}
			}
		}
		return rSegs;
	}

	internal void MoveCols(int mx, int my)
	{
		if (states == null)
		{
			return;
		}
		for (int i = 0; i < states.Count; i++)
		{
			states[i].colX += mx;
			states[i].colY += my;
			for (int j = 0; j < states[i].layer.Length; j++)
			{
				if (states[i].layer[j] == null)
				{
					continue;
				}
				foreach (SequenceSeg item in states[i].layer[j].seg)
				{
					item.loc += new Vector2((float)mx * 64f, (float)((double)my * 64.0 * 0.5));
				}
			}
		}
	}

	internal void Draw()
	{
		if (states == null)
		{
			return;
		}
		for (int i = 0; i < states.Count; i++)
		{
			if (states[i].layer != null)
			{
				try
				{
					for (int j = 0; j < states[i].layer.Length; j++)
					{
						if (states[i].layer[j] == null)
						{
							continue;
						}
						foreach (SequenceSeg item in states[i].layer[j].seg)
						{
							Seg seg = Game1.map.layer[j].seg[item.ID];
							XTexture xTexture = Game1.textures[seg.texture];
							if (xTexture.texture != null)
							{
								XSprite xSprite = xTexture.cell[seg.idx];
								Vector2 screenLoc = ScrollManager.GetScreenLoc(item.loc, seg.depth);
								float rotation = item.rotation;
								Vector2 scaling = item.scaling;
								SpriteTools.sprite.Draw(xTexture.texture, screenLoc, xSprite.srcRect, (i % 2 == 0) ? new Color(0f, 1f, 0f, 1f) : new Color(1f, 0f, 0f, 1f), rotation, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), scaling * ScrollManager.GetSize(seg.depth), SpriteEffects.None, 1f);
							}
						}
					}
				}
				catch
				{
				}
			}
			if (i <= 0 || states[i].col == null)
			{
				continue;
			}
			for (int k = 0; k < states[i].col.GetUpperBound(0) + 1; k++)
			{
				for (int l = 0; l < states[i].col.GetUpperBound(1) + 1; l++)
				{
					if (states[i].col[k, l] == 0)
					{
						Vector2 screenLoc2 = ScrollManager.GetScreenLoc(new Vector2((float)(((double)(k + states[i].colX) + 0.5) * 64.0), (float)(((double)(l + states[i].colY) + 0.5) * 64.0 * 0.5)), 0);
						Vector2 scale = new Vector2(60f, 2f) * ScrollManager.GetSize(0f);
						float num = 0.5f;
						SpriteTools.sprite.Draw(Game1.nullTex, screenLoc2, new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 0f, 0.5f), num, new Vector2(0.5f, 0.5f), scale, SpriteEffects.None, 1f);
						SpriteTools.sprite.Draw(Game1.nullTex, screenLoc2, new Rectangle(0, 0, 1, 1), new Color(1f, 0f, 0f, 0.5f), 0f - num, new Vector2(0.5f, 0.5f), scale, SpriteEffects.None, 1f);
					}
				}
			}
		}
	}

	internal void Delete(int selLayer, int i)
	{
		if (states == null)
		{
			return;
		}
		for (int j = 0; j < states.Count; j++)
		{
			if (states[j].layer[selLayer] == null)
			{
				continue;
			}
			bool flag = false;
			foreach (SequenceSeg item in states[j].layer[selLayer].seg)
			{
				if (item.ID == i)
				{
					item.ID = -1;
					flag = true;
				}
				else if (item.ID > i)
				{
					item.ID--;
				}
			}
			if (!flag)
			{
				continue;
			}
			foreach (SequenceSeg item2 in states[j].layer[selLayer].seg)
			{
				if (item2.ID == -1)
				{
					states[j].layer[selLayer].seg.Remove(item2);
					break;
				}
			}
		}
	}

	internal void Swap(int selLayer, int i, int j)
	{
		if (states == null)
		{
			return;
		}
		for (int k = 0; k < states.Count; k++)
		{
			if (states[k].layer[selLayer] == null)
			{
				continue;
			}
			foreach (SequenceSeg item in states[k].layer[selLayer].seg)
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
		}
	}

	internal void InitRecord()
	{
		editNode = 0;
		states = new List<SequenceState>();
	}
}
