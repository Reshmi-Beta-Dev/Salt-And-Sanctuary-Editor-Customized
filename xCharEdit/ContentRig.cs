using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace xCharEdit;

public class ContentRig
{
	private static ContentManager Content;

	public static string basePath;

	public static void Init(ContentManager _Content)
	{
		basePath = Directory.GetCurrentDirectory();
		Content = _Content;
	}

	public static Texture2D LoadTextureFromFile(string path)
	{
		return Content.Load<Texture2D>("gfx/" + Path.GetFileNameWithoutExtension(path));
	}

	public static Texture2D LoadPMATextureFromFile(string path)
	{
		return Content.Load<Texture2D>("gfx/" + Path.GetFileNameWithoutExtension(path));
	}
}
