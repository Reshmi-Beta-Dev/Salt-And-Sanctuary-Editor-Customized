using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using ProjectTower.io;
using SheetEdit.TextureSheet;

namespace ProjectTower.texturesheet;

public class Textures
{
	public static long saveTick;

	public static XTexture[] tex;

	private static Dictionary<string, int> textures;

	public static ContentManager StreamingContent;

	public static object textureSemaphore;

	public static bool loading;

	public static int GetTextureIdx(string s)
	{
		if (!textures.ContainsKey(s))
		{
			return 0;
		}
		return textures[s];
	}

	public static int GetTextureIdxOrNegative(string s)
	{
		if (!textures.ContainsKey(s))
		{
			return -1;
		}
		return textures[s];
	}

	public static void Init(ContentManager Content)
	{
		StreamingContent = Content;
		textureSemaphore = new object();
		FileMgr.Open("texturesheet/master.zcm");
		int num = FileMgr.reader.ReadInt32();
		tex = new XTexture[num];
		textures = new Dictionary<string, int>();
		for (int i = 0; i < num; i++)
		{
			XTexture xTexture = new XTexture(FileMgr.reader, Content);
			textures.Add(xTexture.name, i);
			tex[i] = xTexture;
		}
	}
}
