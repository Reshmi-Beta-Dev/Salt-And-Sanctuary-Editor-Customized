using MapEdit;
using MapEdit.map;
using Microsoft.Xna.Framework;
using ProjectTower.particles;
using ProjectTower.texturesheet;

namespace ProjectTower.map.entities;

public class RotWood
{
	public int ID;

	public Vector2 loc;

	public int x;

	public int y;

	public int layerIdx;

	public float progFrame;

	public float standingFrame;

	public const int PHASE_INTACT = 0;

	public const int PHASE_SHAKY = 1;

	public const int PHASE_DESTROYED = 2;

	public int phase;

	public RotWood(int ID)
	{
		this.ID = ID;
		phase = 0;
	}

	public void Update()
	{
		switch (phase)
		{
		case 0:
			if (!((double)standingFrame <= 0.0))
			{
				phase = 1;
				progFrame = 0f;
			}
			break;
		case 1:
			if ((double)standingFrame > 0.0)
			{
				standingFrame -= Game1.frameTime;
				progFrame += Game1.frameTime;
				if (!((double)progFrame <= 1.0))
				{
					phase = 2;
					progFrame = 0f;
				}
			}
			else
			{
				phase = 0;
			}
			break;
		case 2:
			progFrame += Game1.frameTime;
			if (!((double)progFrame <= 10.0))
			{
				phase = 0;
				progFrame = 0f;
				standingFrame = 0f;
			}
			break;
		}
	}

	public void Draw(float alpha)
	{
		Vector2 screenLoc = ScrollManager.GetScreenLoc(loc, 0);
		if (!((double)screenLoc.X <= -100.0) && !((double)screenLoc.X >= (double)ScrollManager.screenSize.X) && !((double)screenLoc.Y <= -100.0) && !((double)screenLoc.Y >= (double)ScrollManager.screenSize.Y))
		{
			Draw(x, y, phase, progFrame, alpha);
		}
	}

	public static void Draw(int x, int y, int phase, float rotFrame, float alpha)
	{
		float num = 1f;
		if (phase == 2)
		{
			if ((double)rotFrame < 9.5)
			{
				return;
			}
			float num2 = (float)(((double)rotFrame - 9.5) * 2.0);
			alpha *= num2;
			num = num2;
		}
		for (int i = 0; i < 5; i++)
		{
			int idx = 108 + i;
			float rotation = 0f;
			if (phase == 1)
			{
				rotation = Rand.GetRandomFloat(-1f, 1f) * 0.1f;
			}
			Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(new Vector2((float)((double)x * 64.0 + 32.0), (float)((double)y * 32.0 - 8.0 + (double)i * 6.0)), 0), idx, new Vector2(0.55f, num) * ScrollManager.cannedDepth[0], rotation, 1f, 1f, 1f, alpha);
		}
	}

	internal void Init(Seg seg, Map map, int layerIdx)
	{
		this.layerIdx = layerIdx;
		loc = seg.loc;
		x = (int)((double)loc.X / 64.0);
		y = (int)((double)loc.Y / 32.0);
		progFrame = 0f;
		map.col[x, y].col = ID + 100;
		phase = 0;
	}
}
