using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using ProjectTower.texturesheet;
using SheetEdit.TextureSheet;

namespace MapEdit.map;

public class Seg
{
	public Vector2 loc;

	public int idx;

	public string texture;

	public int textureIdx;

	public float rotation;

	public Vector2 scaling;

	public bool hasVisRect;

	public Vector2 visTL;

	public Vector2 visBR;

	public int intFlag;

	public string strFlag;

	public float depth;

	internal void CopyFrom(Seg seg)
	{
		if (seg == null)
		{
			return;
		}
		try
		{
			loc = seg.loc;
			idx = seg.idx;
			texture = seg.texture;
			rotation = seg.rotation;
			scaling = seg.scaling;
			intFlag = seg.intFlag;
			strFlag = seg.strFlag;
		}
		catch
		{
		}
	}

	internal void UpdateVisRect(int layer)
	{
		XSprite cell = Textures.tex[textureIdx].GetCell(idx);
		Vector2 vector = new Vector2((float)Math.Cos(rotation) * ((float)cell.srcRect.Right - cell.origin.X) * scaling.X, (float)Math.Sin(rotation) * ((float)cell.srcRect.Right - cell.origin.X) * scaling.X);
		Vector2 vector2 = new Vector2((float)Math.Cos((double)rotation + 1.57000005245209) * ((float)cell.srcRect.Bottom - cell.origin.Y) * scaling.Y, (float)Math.Sin((double)rotation + 1.57000005245209) * ((float)cell.srcRect.Bottom - cell.origin.Y) * scaling.Y);
		Vector2 vector3 = new Vector2((float)Math.Cos(rotation) * (cell.origin.X - (float)cell.srcRect.X) * scaling.X, (float)Math.Sin(rotation) * (cell.origin.X - (float)cell.srcRect.X) * scaling.X);
		Vector2 vector4 = new Vector2((float)Math.Cos((double)rotation + 1.57000005245209) * (cell.origin.Y - (float)cell.srcRect.Y) * scaling.Y, (float)Math.Sin((double)rotation + 1.57000005245209) * (cell.origin.Y - (float)cell.srcRect.Y) * scaling.Y);
		Vector2 vector5 = -vector3 - vector4;
		Vector2 vector6 = vector - vector4;
		Vector2 vector7 = -vector3 + vector2;
		Vector2 vector8 = vector + vector2;
		Vector2 vector9 = default(Vector2);
		Vector2 vector10 = default(Vector2);
		if ((double)vector6.X < (double)vector9.X)
		{
			vector9.X = vector6.X;
		}
		if ((double)vector6.Y < (double)vector9.Y)
		{
			vector9.Y = vector6.Y;
		}
		if ((double)vector7.X < (double)vector9.X)
		{
			vector9.X = vector7.X;
		}
		if ((double)vector7.Y < (double)vector9.Y)
		{
			vector9.Y = vector7.Y;
		}
		if ((double)vector8.X < (double)vector9.X)
		{
			vector9.X = vector8.X;
		}
		if ((double)vector8.Y < (double)vector9.Y)
		{
			vector9.Y = vector8.Y;
		}
		if ((double)vector5.X < (double)vector9.X)
		{
			vector9.X = vector5.X;
		}
		if ((double)vector5.Y < (double)vector9.Y)
		{
			vector9.Y = vector5.Y;
		}
		if ((double)vector6.X > (double)vector10.X)
		{
			vector10.X = vector6.X;
		}
		if ((double)vector6.Y > (double)vector10.Y)
		{
			vector10.Y = vector6.Y;
		}
		if ((double)vector7.X > (double)vector10.X)
		{
			vector10.X = vector7.X;
		}
		if ((double)vector7.Y > (double)vector10.Y)
		{
			vector10.Y = vector7.Y;
		}
		if ((double)vector8.X > (double)vector10.X)
		{
			vector10.X = vector8.X;
		}
		if ((double)vector8.Y > (double)vector10.Y)
		{
			vector10.Y = vector8.Y;
		}
		if ((double)vector5.X > (double)vector10.X)
		{
			vector10.X = vector5.X;
		}
		if ((double)vector5.Y > (double)vector10.Y)
		{
			vector10.Y = vector5.Y;
		}
		visTL = vector9;
		visBR = vector10;
		hasVisRect = true;
	}

	internal void Read(BinaryReader reader)
	{
		idx = reader.ReadInt32();
		loc = new Vector2(reader.ReadSingle(), reader.ReadSingle());
		rotation = reader.ReadSingle();
		scaling = new Vector2(reader.ReadSingle(), reader.ReadSingle());
		texture = reader.ReadString();
		hasVisRect = false;
		XTexture xTexture = Game1.textures[texture];
		if (xTexture.type == 3)
		{
			strFlag = reader.ReadString();
			intFlag = reader.ReadInt32();
		}
		if (xTexture.type != 2)
		{
			return;
		}
		XSprite originalCell = xTexture.GetOriginalCell(idx);
		switch (originalCell.flags)
		{
		case 9:
		case 10:
		case 11:
		case 13:
		case 14:
		case 15:
		case 22:
		case 29:
		case 30:
		{
			string text = reader.ReadString();
			strFlag = ((!(text == "")) ? text : null);
			intFlag = reader.ReadInt32();
			if (originalCell.flags == 22)
			{
				intFlag = -1;
			}
			break;
		}
		}
	}

	internal void Write(BinaryWriter writer, Dictionary<string, XTexture> t)
	{
		writer.Write(idx);
		writer.Write(loc.X);
		writer.Write(loc.Y);
		writer.Write(rotation);
		writer.Write(scaling.X);
		writer.Write(scaling.Y);
		writer.Write(texture);
		if (t[texture].type == 3)
		{
			if (strFlag == null)
			{
				writer.Write("");
			}
			else
			{
				writer.Write(strFlag);
			}
			writer.Write(intFlag);
		}
		if (t[texture].type == 2)
		{
			switch (t[texture].cell[idx].flags)
			{
			case 9:
			case 10:
			case 11:
			case 13:
			case 14:
			case 15:
			case 22:
			case 29:
			case 30:
				writer.Write((strFlag != null) ? strFlag : "");
				writer.Write(intFlag);
				break;
			}
		}
	}

	internal void WriteEntity(BinaryWriter writer)
	{
		writer.Write(idx);
		writer.Write(loc.X);
		writer.Write(loc.Y);
		writer.Write(intFlag);
		writer.Write(texture);
		writer.Write((strFlag != null) ? strFlag : "");
	}

	internal void ReadEntity(BinaryReader reader)
	{
		idx = reader.ReadInt32();
		loc = new Vector2(reader.ReadSingle(), reader.ReadSingle());
		intFlag = reader.ReadInt32();
		texture = reader.ReadString();
		strFlag = reader.ReadString();
	}
}
