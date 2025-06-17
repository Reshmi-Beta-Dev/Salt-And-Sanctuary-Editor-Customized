using MapEdit;
using Microsoft.Xna.Framework;
using ProjectTower.texturesheet;
using SheetEdit.TextureSheet;

namespace ProjectTower.particles.env;

public class DotsMgr
{
	private struct Dot
	{
		public Vector2 loc;

		private Vector2 traj;

		private int depth;

		private float size;

		public float frame;

		private float r;

		private float g;

		private float b;

		internal void Init()
		{
			switch (Rand.GetRandomInt(0, 3))
			{
			case 0:
				depth = 0;
				size = 0.025f;
				break;
			case 1:
				depth = 2;
				size = 0.05f;
				break;
			case 2:
				depth = 7;
				size = 0.25f;
				break;
			}
			size *= Rand.GetRandomFloat(0.9f, 1.5f);
			r = 1f;
			g = r * 0.9f;
			b = r * 0.8f;
			float num = ScrollManager.cannedDepth[depth];
			if ((double)num == 0.0)
			{
				num = 1f;
			}
			loc.X = ScrollManager.scroll.X + Rand.GetRandomFloat((float)((0.0 - (double)ScrollManager.screenSize.X) / 2.0), ScrollManager.screenSize.X / 2f) / num;
			loc.Y = ScrollManager.scroll.Y + Rand.GetRandomFloat((float)((0.0 - (double)ScrollManager.screenSize.Y) / 2.0), ScrollManager.screenSize.Y / 2f) / num;
			traj = Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 50f;
			frame = 2f;
		}

		internal void Update(float frameTime)
		{
			double num = frame;
			frame -= frameTime * 0.5f;
			loc += traj * frameTime;
			if ((int)(num * 10.0) != (int)((double)frame * 10.0))
			{
				traj += Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 10f;
			}
			if ((double)frame < 0.0)
			{
				Init();
			}
			float num2 = ScrollManager.cannedDepth[depth];
			if ((double)num2 == 0.0)
			{
				num2 = 1f;
			}
			if ((double)loc.X < (double)ScrollManager.scroll.X - (double)ScrollManager.screenSize.X / 2.0 / (double)num2)
			{
				loc.X += ScrollManager.screenSize.X / num2;
			}
			if (!((double)loc.X <= (double)ScrollManager.scroll.X + (double)ScrollManager.screenSize.X / 2.0 / (double)num2))
			{
				loc.X -= ScrollManager.screenSize.X / num2;
			}
		}

		internal void Draw(float alpha)
		{
			XTexture xTexture = Game1.textures["sprites"];
			switch (depth)
			{
			case 0:
				alpha *= 1f;
				break;
			case 2:
				alpha *= 0.5f;
				break;
			case 7:
				alpha *= 0.095f;
				break;
			}
			xTexture.Draw(ScrollManager.GetScreenLoc(loc, depth), 169, new Vector2(1f, 1f) * size * ScrollManager.cannedDepth[depth], frame, r, g, b, alpha * (((double)frame > 1.0) ? (2f - frame) : frame));
		}
	}

	private struct Snowflake
	{
		public Vector2 loc;

		private Vector2 traj;

		private int depth;

		public float frame;

		private float rDir;

		private float rotation;

		private float size;

		private int idx;

		private bool fore;

		internal void Init(bool fore)
		{
			this.fore = fore;
			depth = (fore ? (1 + Rand.GetRandomInt(0, 4)) : (3 + Rand.GetRandomInt(0, 3)));
			idx = Rand.GetRandomInt(92, 96);
			float num = ScrollManager.cannedDepth[depth];
			if ((double)num == 0.0)
			{
				num = 1f;
			}
			rDir = Rand.GetRandomFloat(-1f, 1f) * 10f;
			rotation = Rand.GetRandomFloat(0f, 6.283185f);
			size = Rand.GetRandomFloat(0.1f, 0.8f);
			loc.X = ScrollManager.scroll.X + Rand.GetRandomFloat((float)((0.0 - (double)ScrollManager.screenSize.X) / 2.0), ScrollManager.screenSize.X / 2f) / num;
			loc.Y = ScrollManager.scroll.Y + Rand.GetRandomFloat((float)((0.0 - (double)ScrollManager.screenSize.Y) / 2.0), ScrollManager.screenSize.Y / 2f) / num;
			traj = Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 50f;
			frame = 2f;
		}

		internal void Update(float frameTime)
		{
			double num = frame;
			frame -= frameTime * 0.5f;
			loc += traj * frameTime;
			if ((int)(num * 10.0) != (int)((double)frame * 10.0))
			{
				traj += Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 10f;
			}
			if ((double)traj.Y < 180.0)
			{
				traj.Y += Game1.frameTime * 100f;
			}
			rotation += Game1.frameTime * rDir;
			if ((double)frame < 0.0)
			{
				Init(fore);
			}
			float num2 = ScrollManager.cannedDepth[depth];
			if ((double)num2 == 0.0)
			{
				num2 = 1f;
			}
			if ((double)num2 > 2.0)
			{
				num2 = 2f;
			}
			if ((double)loc.X < (double)ScrollManager.scroll.X - (double)ScrollManager.screenSize.X / 2.0 / (double)num2)
			{
				loc.X += ScrollManager.screenSize.X / num2;
			}
			if ((double)loc.X > (double)ScrollManager.scroll.X + (double)ScrollManager.screenSize.X / 2.0 / (double)num2)
			{
				loc.X -= ScrollManager.screenSize.X / num2;
			}
			if ((double)loc.Y < (double)ScrollManager.scroll.Y - (double)ScrollManager.screenSize.Y / 2.0 / (double)num2)
			{
				loc.Y += ScrollManager.screenSize.Y / num2;
			}
			if (!((double)loc.Y <= (double)ScrollManager.scroll.Y + (double)ScrollManager.screenSize.Y / 2.0 / (double)num2))
			{
				loc.Y -= ScrollManager.screenSize.Y / num2;
			}
		}

		internal void Draw(float alpha)
		{
			XTexture xTexture = Game1.textures["sprites"];
			float num = (float)((double)(idx % 3) / 4.0 + 0.349999994039536);
			float num2 = 0.8f;
			Vector2 screenLoc = ScrollManager.GetScreenLoc(loc, depth);
			int num3 = idx;
			Vector2 scale = new Vector2(1f, 1f) * size * ScrollManager.cannedDepth[depth];
			double num4 = rotation;
			double num5 = num;
			double num6 = num;
			double num7 = num;
			double num8 = (double)alpha * (((double)frame > 1.0) ? (2.0 - (double)frame) : ((double)frame)) * (double)num2;
			xTexture.Draw(screenLoc, num3, scale, (float)num4, (float)num5, (float)num6, (float)num7, (float)num8);
		}
	}

	private struct Leaf
	{
		public Vector2 loc;

		private Vector2 traj;

		private int depth;

		public float frame;

		private float rDir;

		private float rotation;

		private float size;

		private int idx;

		private bool fore;

		internal void Init(bool fore)
		{
			this.fore = fore;
			depth = (fore ? (1 + Rand.GetRandomInt(0, 4)) : (3 + Rand.GetRandomInt(0, 3)));
			idx = Rand.GetRandomInt(101, 106);
			float num = ScrollManager.cannedDepth[depth];
			if ((double)num == 0.0)
			{
				num = 1f;
			}
			if ((double)num > 2.0)
			{
				num = 2f;
			}
			rDir = Rand.GetRandomFloat(-1f, 1f) * 10f;
			rotation = Rand.GetRandomFloat(0f, 6.283185f);
			size = Rand.GetRandomFloat(0.1f, 0.8f);
			loc.X = ScrollManager.scroll.X + Rand.GetRandomFloat((float)((0.0 - (double)ScrollManager.screenSize.X) / 2.0), ScrollManager.screenSize.X / 2f) / num;
			loc.Y = ScrollManager.scroll.Y + Rand.GetRandomFloat((float)((0.0 - (double)ScrollManager.screenSize.Y) / 2.0), ScrollManager.screenSize.Y / 2f) / num;
			traj = Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 50f;
			frame = 2f;
		}

		internal void Update(float frameTime)
		{
			double num = frame;
			frame -= frameTime * 0.5f;
			loc += traj * frameTime;
			if ((int)(num * 10.0) != (int)((double)frame * 10.0))
			{
				traj += Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 10f;
			}
			if ((double)traj.Y < 180.0)
			{
				traj.Y += Game1.frameTime * 100f;
			}
			rotation += Game1.frameTime * rDir;
			if ((double)frame < 0.0)
			{
				Init(fore);
			}
			float num2 = ScrollManager.cannedDepth[depth];
			if ((double)num2 == 0.0)
			{
				num2 = 1f;
			}
			if ((double)num2 > 2.0)
			{
				num2 = 2f;
			}
			if ((double)loc.X < (double)ScrollManager.scroll.X - (double)ScrollManager.screenSize.X / 2.0 / (double)num2)
			{
				loc.X += ScrollManager.screenSize.X / num2;
			}
			if ((double)loc.X > (double)ScrollManager.scroll.X + (double)ScrollManager.screenSize.X / 2.0 / (double)num2)
			{
				loc.X -= ScrollManager.screenSize.X / num2;
			}
			if ((double)loc.Y < (double)ScrollManager.scroll.Y - (double)ScrollManager.screenSize.Y / 2.0 / (double)num2)
			{
				loc.Y += ScrollManager.screenSize.Y / num2;
			}
			if (!((double)loc.Y <= (double)ScrollManager.scroll.Y + (double)ScrollManager.screenSize.Y / 2.0 / (double)num2))
			{
				loc.Y -= ScrollManager.screenSize.Y / num2;
			}
		}

		internal void Draw(float alpha)
		{
			XTexture xTexture = Game1.textures["sprites"];
			float num = frame - (float)(int)frame;
			float num2 = 1f;
			float num3;
			if ((double)num > 0.5)
			{
				num2 = 0.5f;
				num3 = (float)((1.0 - (double)num) * 2.0);
			}
			else
			{
				num3 = num * 2f;
			}
			float y = (float)((((double)num3 > 0.5) ? (1.0 - (double)num3) : ((double)num3)) * 2.0);
			Vector2 screenLoc = ScrollManager.GetScreenLoc(loc, depth);
			int num4 = idx;
			Vector2 scale = new Vector2(1f, y) * size * ScrollManager.cannedDepth[depth];
			double num5 = rotation;
			double num6 = num2;
			double num7 = num2;
			double num8 = num2;
			double num9 = (double)alpha * (((double)frame > 1.0) ? (2.0 - (double)frame) : ((double)frame)) * 0.800000011920929;
			xTexture.Draw(screenLoc, num4, scale, (float)num5, (float)num6, (float)num7, (float)num8, (float)num9);
		}
	}

	private struct Raindrop
	{
		public Vector2 loc;

		private Vector2 traj;

		private int depth;

		public float frame;

		private float size;

		private int idx;

		private bool fore;

		internal void Init(bool fore)
		{
			this.fore = fore;
			depth = (fore ? (1 + Rand.GetRandomInt(0, 4)) : (3 + Rand.GetRandomInt(0, 3)));
			idx = Rand.GetRandomInt(92, 96);
			float num = ScrollManager.cannedDepth[depth];
			if ((double)num == 0.0)
			{
				num = 1f;
			}
			size = Rand.GetRandomFloat(0.5f, 2f);
			loc.X = ScrollManager.scroll.X + Rand.GetRandomFloat((float)((0.0 - (double)ScrollManager.screenSize.X) / 2.0), ScrollManager.screenSize.X / 2f) / num;
			loc.Y = ScrollManager.scroll.Y + Rand.GetRandomFloat((float)((0.0 - (double)ScrollManager.screenSize.Y) / 2.0), ScrollManager.screenSize.Y / 2f) / num;
			traj = Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 50f;
			traj.Y = 1500f;
			frame = 2f;
		}

		internal void Update(float frameTime)
		{
			frame -= frameTime * 0.5f;
			loc += traj * frameTime;
			if ((double)frame < 0.0)
			{
				Init(fore);
			}
			float num = ScrollManager.cannedDepth[depth];
			if ((double)num == 0.0)
			{
				num = 1f;
			}
			if ((double)num > 2.0)
			{
				num = 2f;
			}
			if ((double)loc.X < (double)ScrollManager.scroll.X - (double)ScrollManager.screenSize.X / 2.0 / (double)num)
			{
				loc.X += ScrollManager.screenSize.X / num;
			}
			if ((double)loc.X > (double)ScrollManager.scroll.X + (double)ScrollManager.screenSize.X / 2.0 / (double)num)
			{
				loc.X -= ScrollManager.screenSize.X / num;
			}
			if ((double)loc.Y < (double)ScrollManager.scroll.Y - (double)ScrollManager.screenSize.Y / 2.0 / (double)num)
			{
				loc.Y += ScrollManager.screenSize.Y / num;
			}
			if (!((double)loc.Y <= (double)ScrollManager.scroll.Y + (double)ScrollManager.screenSize.Y / 2.0 / (double)num))
			{
				loc.Y -= ScrollManager.screenSize.Y / num;
				loc.X = Rand.GetRandomFloat(ScrollManager.scroll.X - ScrollManager.screenSize.X / 2f / num, ScrollManager.scroll.X + ScrollManager.screenSize.X / 2f / num);
			}
		}

		internal void Draw(float alpha)
		{
			Game1.textures["sprites"].Draw(ScrollManager.GetScreenLoc(loc, depth), idx, new Vector2(0.1f, 1.5f) * size * ScrollManager.cannedDepth[depth], 0f, 1f, 1f, 1f, (float)((double)alpha * (((double)frame > 1.0) ? (2.0 - (double)frame) : ((double)frame)) * 0.25));
		}
	}

	public float snowAlpha;

	public float dotsAlpha;

	public float rainAlpha;

	public float leavesAlpha;

	private const int TOTAL_DOTS = 64;

	private const int TOTAL_BACK_FLAKES = 240;

	private const int TOTAL_FORE_FLAKES = 96;

	private const int TOTAL_BACK_RAIN = 128;

	private const int TOTAL_FORE_RAIN = 64;

	private const int TOTAL_BACK_LEAVES = 160;

	private const int TOTAL_FORE_LEAVES = 32;

	private float starFrame;

	private float starLife;

	private Vector2 starVec;

	private float starRotation;

	private Dot[] dot;

	private Snowflake[] foreFlake;

	private Snowflake[] backFlake;

	private Raindrop[] foreRain;

	private Raindrop[] backRain;

	private Leaf[] foreLeaf;

	private Leaf[] backLeaf;

	public bool isInited;

	public DotsMgr()
	{
		dot = new Dot[64];
		foreFlake = new Snowflake[96];
		backFlake = new Snowflake[240];
		foreRain = new Raindrop[64];
		backRain = new Raindrop[128];
		foreLeaf = new Leaf[32];
		backLeaf = new Leaf[160];
	}

	public void Update(float frameTime)
	{
		if (!isInited)
		{
			for (int i = 0; i < foreFlake.Length; i++)
			{
				foreFlake[i].Init(fore: true);
				foreFlake[i].frame = Rand.GetRandomFloat(0f, 2f);
			}
			for (int j = 0; j < backFlake.Length; j++)
			{
				backFlake[j].Init(fore: false);
				backFlake[j].frame = Rand.GetRandomFloat(0f, 2f);
			}
			for (int k = 0; k < foreLeaf.Length; k++)
			{
				foreLeaf[k].Init(fore: true);
				foreLeaf[k].frame = Rand.GetRandomFloat(0f, 2f);
			}
			for (int l = 0; l < backLeaf.Length; l++)
			{
				backLeaf[l].Init(fore: false);
				backLeaf[l].frame = Rand.GetRandomFloat(0f, 2f);
			}
			for (int m = 0; m < foreRain.Length; m++)
			{
				foreRain[m].Init(fore: true);
				foreRain[m].frame = Rand.GetRandomFloat(0f, 2f);
			}
			for (int n = 0; n < backRain.Length; n++)
			{
				backRain[n].Init(fore: false);
				backRain[n].frame = Rand.GetRandomFloat(0f, 2f);
			}
			for (int num = 0; num < dot.Length; num++)
			{
				dot[num].Init();
				dot[num].frame = Rand.GetRandomFloat(0f, 2f);
			}
			isInited = true;
		}
		if ((double)dotsAlpha > 0.0)
		{
			for (int num2 = 0; num2 < dot.Length; num2++)
			{
				dot[num2].Update(frameTime);
			}
		}
		if ((double)snowAlpha > 0.0)
		{
			for (int num3 = 0; num3 < backFlake.Length; num3++)
			{
				backFlake[num3].Update(frameTime);
			}
			for (int num4 = 0; num4 < foreFlake.Length; num4++)
			{
				foreFlake[num4].Update(frameTime);
			}
		}
		if ((double)rainAlpha > 0.0)
		{
			for (int num5 = 0; num5 < backRain.Length; num5++)
			{
				backRain[num5].Update(frameTime);
			}
			for (int num6 = 0; num6 < foreRain.Length; num6++)
			{
				foreRain[num6].Update(frameTime);
			}
		}
		if (!((double)leavesAlpha <= 0.0))
		{
			for (int num7 = 0; num7 < backLeaf.Length; num7++)
			{
				backLeaf[num7].Update(frameTime);
			}
			for (int num8 = 0; num8 < foreLeaf.Length; num8++)
			{
				foreLeaf[num8].Update(frameTime);
			}
		}
	}

	public void DrawFore()
	{
		if ((double)dotsAlpha > 0.0)
		{
			for (int i = 0; i < dot.Length; i++)
			{
				dot[i].Draw(dotsAlpha);
			}
		}
		if ((double)snowAlpha > 0.0)
		{
			for (int j = 0; j < foreFlake.Length; j++)
			{
				foreFlake[j].Draw(snowAlpha);
			}
		}
		if ((double)rainAlpha > 0.0)
		{
			for (int k = 0; k < foreRain.Length; k++)
			{
				foreRain[k].Draw(rainAlpha);
			}
		}
		if (!((double)leavesAlpha <= 0.0))
		{
			for (int l = 0; l < foreLeaf.Length; l++)
			{
				foreLeaf[l].Draw(leavesAlpha);
			}
		}
	}

	public void DrawBack()
	{
		if ((double)snowAlpha > 0.0)
		{
			for (int i = 0; i < backFlake.Length; i++)
			{
				backFlake[i].Draw(snowAlpha);
			}
		}
		if ((double)rainAlpha > 0.0)
		{
			for (int j = 0; j < backRain.Length; j++)
			{
				backRain[j].Draw(rainAlpha);
			}
		}
		if (!((double)leavesAlpha <= 0.0))
		{
			for (int k = 0; k < backLeaf.Length; k++)
			{
				backLeaf[k].Draw(leavesAlpha);
			}
		}
	}

	public void DrawStar()
	{
		if (!((double)starLife <= 0.0))
		{
			float num = starLife;
			if ((double)starLife > 0.5)
			{
				num = 1f - starLife;
			}
			Textures.tex[ParticleManager.spritesTexIdx].Draw(starVec, 0, new Vector2(1f, 0.06f), starRotation, 1f, 1f, 1f, num * 1f);
		}
	}
}
