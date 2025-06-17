using MapEdit;
using MapEdit.map;
using Microsoft.Xna.Framework;
using ProjectTower.particles;
using ProjectTower.texturesheet;

namespace ProjectTower.map;

public class PortalGlowMgr
{
	public Vector2[] glowVec;

	private int[] vecDir;

	public float frame;

	public int totalVecs;

	private bool canGlow;

	private const int TOTAL_VECS = 32;

	public PortalGlowMgr()
	{
		glowVec = new Vector2[32];
		vecDir = new int[32];
	}

	public void Draw()
	{
		bool indoors = Game1.indoors;
		for (int i = 0; i < totalVecs; i++)
		{
			float num = vecDir[i];
			if (!indoors)
			{
				num *= -1f;
			}
			Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(glowVec[i] + new Vector2((float)((double)num * -64.0 * 0.5), 0f), 0), 0, new Vector2(0.75f, 0.75f) * ScrollManager.cannedDepth[0], 0f, 1f, 0.8f, 0.6f, 1f);
			Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(glowVec[i] + new Vector2(num * -64f, 0f), 0), 0, new Vector2(0.75f, 0.75f) * ScrollManager.cannedDepth[0], 0f, 1f, 0.8f, 0.6f, 1f);
		}
	}

	public void Update()
	{
		Map map = Game1.map;
		double num = frame;
		frame += Game1.frameTime;
		if ((double)frame > 1.0)
		{
			frame -= 1f;
		}
		if ((int)(num * 30.0) != (int)((double)frame * 30.0))
		{
			for (int i = 0; i < totalVecs; i++)
			{
				ParticleManager.AddAdditiveParticle(26, glowVec[i] + Rand.GetRandomVec2(0f, 0f, 0f, 32f), default(Vector2), 0f, (float)vecDir[i] * 0.1f, -1, -1);
				ParticleManager.AddBackAdditiveParticle(26, glowVec[i] + Rand.GetRandomVec2(0f, 0f, 0f, 32f), default(Vector2), 0f, (float)vecDir[i] * 0.1f, -1, -1);
			}
			canGlow = false;
		}
		totalVecs = 0;
		int num2 = (int)((double)ScrollManager.scroll.X / 64.0);
		int num3 = (int)((double)ScrollManager.scroll.Y / 32.0);
		int num4 = 14;
		int num5 = 15;
		_ = Game1.indoors;
		for (int j = num2 - num4; j < num2 + num4; j++)
		{
			for (int k = num3 - num5; k < num3 + num5; k++)
			{
				if (j > 0 && k > 0 && j < map.xUnits - 2 && k < map.yUnits - 1 && map.col[j, k].col == 0 && map.col[j + 1, k].col == 0 && LayerTintCatalog.layerTintData[map.col[j, k].layer].indoors != LayerTintCatalog.layerTintData[map.col[j + 1, k].layer].indoors && totalVecs < 32)
				{
					glowVec[totalVecs] = new Vector2((float)((double)j * 64.0 + 64.0), (float)((double)k * 64.0 * 0.5));
					vecDir[totalVecs] = ((!LayerTintCatalog.layerTintData[map.col[j, k].layer].indoors) ? 1 : (-1));
					totalVecs++;
				}
			}
		}
	}
}
