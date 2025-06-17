using Microsoft.Xna.Framework;
using SheetEdit.TextureSheet;

namespace MapEdit.glows;

public class Glow
{
	public Vector2 loc;

	private float r;

	private float g;

	private float b;

	private float size;

	private int type;

	public const int TYPE_NORMAL = 0;

	public const int TYPE_WARM = 1;

	internal void Init(Vector2 loc, float r, float g, float b, float size, int type)
	{
		this.loc = loc;
		this.r = r;
		this.g = g;
		this.b = b;
		this.size = size;
		this.type = type;
	}

	internal void Draw(XTexture xt, int type)
	{
		int idx = 144;
		float num = 0.6f;
		if (this.type == 1)
		{
			idx = 166;
			num = 0.8f;
			g = r * 0.9f;
			b = r * 0.9f;
		}
		xt.Draw(loc, idx, size * new Vector2(1f, 1f) * num, 0f, r, g, b, 1f);
	}

	internal void DrawForLightMode(XTexture xt, int idx)
	{
		xt.Draw(loc, 144, size * new Vector2(1f, 1f) * 0.6f, 0f, r, g, b, 1f);
	}
}
