using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower;
using ProjectTower.io;

namespace SheetEdit.TextureSheet;

public class XTexture
{
	public string name = "";

	public int ugcPackageIdx = -1;

	public int ugcSheetIdx = -1;

	public XSprite[] cell;

	public Texture2D texture;

	public const int TYPE_NORMAL = 0;

	public const int TYPE_CLOTHES = 1;

	public const int TYPE_MAP = 2;

	public const int TYPE_CHARACTER = 3;

	public const int TYPE_CHAR = 4;

	public const int TYPE_CHAR_VAR = 5;

	public const int MAX_CELLS = 128;

	public const string VERSION_TREE = "Tree 1.0";

	public bool needsUnload;

	public int type;

	public XTexture()
	{
		cell = new XSprite[128];
		type = 0;
	}

	public XTexture(Texture2D t, string[] chars)
	{
		texture = t;
		cell = new XSprite[chars.Length];
		type = 3;
		for (int i = 0; i < chars.Length; i++)
		{
			cell[i] = new XSprite();
			XSprite xSprite = cell[i];
			xSprite.name = chars[i];
			xSprite.srcRect = new Rectangle(0, 0, 200, 400);
			xSprite.origin = new Vector2((float)xSprite.srcRect.Width / 2f, (float)xSprite.srcRect.Height - 20f);
		}
	}

	public XTexture(ContentManager Content, string path)
	{
		texture = Content.Load<Texture2D>(path);
		Read(path + ".zsx");
	}

	public XTexture(ContentManager Content, string filePath, string texPath)
	{
		texture = Content.Load<Texture2D>(texPath);
		Read(filePath);
	}

	public XTexture(ContentManager Content, string filePath, Texture2D texture)
	{
		this.texture = texture;
		Read(filePath);
	}

	public void Read(string path)
	{
		FileMgr.Open(path);
		ReadData(FileMgr.reader);
		FileMgr.Close();
	}

	public void ReadData(BinaryReader reader)
	{
		type = reader.ReadInt32();
		int num = reader.ReadInt32();
		cell = new XSprite[num];
		for (int i = 0; i < num; i++)
		{
			if (reader.ReadBoolean())
			{
				cell[i] = new XSprite();
				XSprite xSprite = cell[i];
				xSprite.name = reader.ReadString();
				xSprite.srcRect = new Rectangle(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
				xSprite.origin = new Vector2(reader.ReadSingle(), reader.ReadSingle());
				switch (type)
				{
				case 1:
					xSprite.char_ref = reader.ReadInt32();
					xSprite.flags = reader.ReadInt32();
					break;
				case 2:
					xSprite.flags = reader.ReadInt32();
					break;
				case 4:
					xSprite.flags = reader.ReadInt32();
					break;
				}
			}
		}
	}

	public Rectangle GetSpriteRect(int idx)
	{
		if (idx >= cell.Length || cell[idx] == null)
		{
			return default(Rectangle);
		}
		return cell[idx].srcRect;
	}

	public string GetSpriteName(int idx)
	{
		if (idx >= cell.Length || cell[idx] == null)
		{
			return "";
		}
		return cell[idx].name;
	}

	public Vector2 GetSpriteOrigin(int idx)
	{
		if (idx >= cell.Length || cell[idx] == null)
		{
			return default(Vector2);
		}
		return cell[idx].origin;
	}

	public void SetSpriteRect(int idx, Rectangle rect)
	{
		if (idx < cell.Length)
		{
			if (cell[idx] == null)
			{
				cell[idx] = new XSprite();
			}
			cell[idx].srcRect = rect;
		}
	}

	public void SetSpriteOrigin(int idx, Vector2 origin)
	{
		if (idx < cell.Length)
		{
			if (cell[idx] == null)
			{
				cell[idx] = new XSprite();
			}
			cell[idx].origin = origin;
		}
	}

	public virtual void Draw(Vector2 loc, int idx, Vector2 scale, float rotation, float r, float g, float b, float a)
	{
		if (idx < 0 || idx >= cell.Length || texture == null || texture == null)
		{
			return;
		}
		XSprite xSprite = GetCell(idx);
		if (xSprite != null)
		{
			if (float.IsNaN(rotation))
			{
				rotation = 0f;
			}
			SpriteTools.sprite.Draw(texture, loc, xSprite.srcRect, new Color(r, g, b, a), rotation, xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y), scale, SpriteEffects.None, 0f);
		}
	}

	public XSprite GetCell(int idx)
	{
		if (idx < cell.Length && idx >= 0)
		{
			return cell[idx];
		}
		return cell[0];
	}

	public XSprite GetOriginalCell(int idx)
	{
		return cell[idx];
	}

	public int GetCellCount()
	{
		return cell.Length;
	}

	public int GetOriginalCellCount()
	{
		return cell.Length;
	}

	public virtual void DrawFlipped(Vector2 loc, int idx, Vector2 scale, float rotation, float r, float g, float b, float a)
	{
		XSprite xSprite = GetCell(idx);
		try
		{
			if (float.IsNaN(rotation))
			{
				rotation = 0f;
			}
			float num = scale.X;
			if ((double)scale.Y > (double)scale.X)
			{
				num = scale.Y;
			}
			Vector2 vector = (xSprite.origin - new Vector2(xSprite.srcRect.Left, xSprite.srcRect.Top)) * num * 1.4f;
			Vector2 vector2 = (new Vector2(xSprite.srcRect.Right, xSprite.srcRect.Bottom) - xSprite.origin) * num * 1.4f;
			if ((double)vector2.X > (double)vector.X)
			{
				vector.X = vector2.X;
			}
			if ((double)vector2.Y > (double)vector.Y)
			{
				vector.Y = vector2.Y;
			}
			if (!((double)loc.X + (double)vector.X < 0.0) && !((double)loc.Y + (double)vector.Y < 0.0))
			{
				Vector2 origin = xSprite.origin - new Vector2(xSprite.srcRect.X, xSprite.srcRect.Y);
				origin.X = (float)xSprite.srcRect.Width - origin.X;
				SpriteTools.sprite.Draw(texture, loc, xSprite.srcRect, new Color(r, g, b, a), rotation, origin, scale, SpriteEffects.FlipHorizontally, 0f);
			}
		}
		catch
		{
		}
	}

	public XTexture(BinaryReader reader, ContentManager Content)
	{
		name = reader.ReadString();
		ReadData(reader);
		texture = Content.Load<Texture2D>("gfx/" + name);
	}

	public XTexture(string name, BinaryReader reader, Texture2D tex)
	{
		this.name = name;
		ReadData(reader);
		texture = tex;
	}

	public Texture2D GetTexture()
	{
		return texture;
	}
}
