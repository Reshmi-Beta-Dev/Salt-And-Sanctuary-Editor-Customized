using System;
using MapEdit;
using MapEdit.glows;
using MapEdit.map;
using Microsoft.Xna.Framework;
using ProjectTower.particles;
using SheetEdit.TextureSheet;

namespace ProjectTower.map;

public class MapUpdate
{
	private Map map;

	public MapUpdate(Map map)
	{
		this.map = map;
	}

	internal void UpdateDelta()
	{
		map.delta += Game1.frameTime;
		if (!((double)map.delta <= 62.8199996948242))
		{
			map.delta -= 62.82f;
		}
	}

	public void Update()
	{
		map.pDelta = map.delta;
		UpdateDelta();
		if ((int)((double)map.pDelta * 30.0) == (int)((double)map.delta * 30.0))
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			int num = ((i == 0) ? 15 : 5);
			Layer layer = map.layer[num];
			int num2 = (int)((double)ScrollManager.scroll.X / 3200.0);
			int num3 = (int)((double)ScrollManager.scroll.Y / 1600.0);
			for (int j = num2 - 1; j < num2 + 2; j++)
			{
				for (int k = num3 - 1; k < num3 + 2; k++)
				{
					if (j < 0 || k < 0 || j >= map.mapGrid.tX || k >= map.mapGrid.tY)
					{
						continue;
					}
					for (int l = 0; l < map.mapGrid.chunk[j, k].layer[num].Length; l++)
					{
						try
						{
							Seg seg = layer.seg[map.mapGrid.chunk[j, k].layer[num][l]];
							if (seg == null)
							{
								continue;
							}
							XTexture xTexture = Game1.textures[seg.texture];
							Vector2 screenLoc = ScrollManager.GetScreenLoc(seg.loc, 0);
							float num4 = 0f;
							float num5 = ScrollManager.screenSize.Y;
							if (xTexture.cell[seg.idx].flags == 63 || xTexture.cell[seg.idx].flags == 64 || xTexture.cell[seg.idx].flags == 88)
							{
								num4 -= 600f * ScrollManager.cannedDepth[0];
								num5 += 600f * ScrollManager.cannedDepth[0];
							}
							if (!((double)screenLoc.X > (double)num4) || !((double)screenLoc.Y > 0.0) || !((double)screenLoc.X < (double)ScrollManager.screenSize.X) || !((double)screenLoc.Y < (double)num5))
							{
								continue;
							}
							switch (xTexture.cell[seg.idx].flags)
							{
							case 4:
								ParticleManager.AddBackRefractParticle(63, seg.loc, Rand.GetRandomVec2(-10f, 100f, -300f, -200f), Rand.GetRandomFloat(0.1f, 0.3f), Rand.GetRandomFloat(-1f, 1f), 0, 0);
								ParticleManager.AddBackSubtractiveParticle(0, seg.loc, Rand.GetRandomVec2(-10f, 100f, -300f, -200f), Rand.GetRandomFloat(0.1f, 0.3f), Rand.GetRandomFloat(-1f, 1f), 0, 0);
								ParticleManager.AddBackAdditiveParticle(1, seg.loc, Rand.GetRandomVec2(-10f, 100f, -300f, -200f) * 0.5f, Rand.GetRandomFloat(0.1f, 0.3f), Rand.GetRandomFloat(-1f, 1f), 0, 0);
								if (Rand.CoinToss(0.1f))
								{
									ParticleManager.AddBackAdditiveParticle(121, seg.loc, Rand.GetRandomVec2(-10f, 100f, -300f, -200f) * 0.5f, Rand.GetRandomFloat(0.1f, 0.3f), Rand.GetRandomFloat(-1f, 1f), 0, 0);
								}
								break;
							case 63:
							case 88:
							{
								int num6 = 1;
								if (xTexture.cell[seg.idx].flags == 88)
								{
									num6 = -1;
								}
								ParticleManager.AddBackRefractParticle(135, seg.loc + new Vector2(0f, -600f * (float)num6), default(Vector2), Rand.GetRandomFloat(0.1f, 0.2f) * seg.scaling.X, 1f, num6, 0);
								ParticleManager.AddBackAdditiveParticle(135, seg.loc + new Vector2(0f, -600f * (float)num6), default(Vector2), Rand.GetRandomFloat(0.1f, 0.2f) * seg.scaling.X, 0.25f, num6, 0);
								break;
							}
							case 75:
							{
								Vector2 vector = new Vector2((float)Math.Cos(seg.rotation), (float)Math.Sin(seg.rotation)) * Rand.GetRandomFloat(250f, 500f) * seg.scaling.X;
								if (Rand.CoinToss(0.5f))
								{
									ParticleManager.AddAdditiveParticle(137, seg.loc - vector / 2f + Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 30f, vector, Rand.GetRandomFloat(0.01f, 1f), seg.rotation, 0, 0);
								}
								else
								{
									ParticleManager.AddBackAdditiveParticle(137, seg.loc - vector / 2f + Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 30f, vector, Rand.GetRandomFloat(0.01f, 1f), seg.rotation, 0, 0);
								}
								break;
							}
							case 76:
								if (Rand.CoinToss(0.5f))
								{
									ParticleManager.AddAdditiveParticle(138, seg.loc + Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 30f, Rand.GetRandomVec2(5f, 20f, 0f, 0f), Rand.GetRandomFloat(0.01f, 1f), seg.rotation, 0, 0);
								}
								else
								{
									ParticleManager.AddBackAdditiveParticle(138, seg.loc + Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 30f, Rand.GetRandomVec2(5f, 20f, 0f, 0f), Rand.GetRandomFloat(0.01f, 1f), seg.rotation, 0, 0);
								}
								break;
							case 77:
								if (Rand.CoinToss(0.5f))
								{
									ParticleManager.AddAdditiveParticle(138, seg.loc + Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 30f, Rand.GetRandomVec2(-20f, -5f, 0f, 0f), Rand.GetRandomFloat(0.01f, 1f), seg.rotation, 0, 0);
								}
								else
								{
									ParticleManager.AddBackAdditiveParticle(138, seg.loc + Rand.GetRandomVec2(-1f, 1f, -1f, 1f) * 30f, Rand.GetRandomVec2(-20f, -5f, 0f, 0f), Rand.GetRandomFloat(0.01f, 1f), seg.rotation, 0, 0);
								}
								break;
							}
						}
						catch
						{
						}
					}
				}
			}
		}
	}

	public void AddGlowsToDrawList(XTexture texture, Seg seg, GlowMgr glowMgr, Layer lr)
	{
		map.glowBrite = 0.2f;
		if (texture.type == 2)
		{
			switch (texture.GetCell(seg.idx).flags)
			{
			case 4:
			{
				int type8 = 1;
				float num36 = ScrollManager.GetSize(1f) * 10f;
				float num37 = 1f;
				float num38 = (float)(Math.Cos((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.100000001490116 + 0.800000011920929);
				_ = (float)(Math.Sin((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.200000002980232 + 0.5);
				_ = map.glowBrite;
				_ = map.glowBrite;
				_ = map.glowBrite;
				Vector2 screenLoc7 = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
				glowMgr.Add(0, screenLoc7, 1f, 1f, 1f, num36, 0);
				glowMgr.Add(type8, screenLoc7, map.glowBrite, map.glowBrite, map.glowBrite, num36 * 0.75f, 1);
				break;
			}
			case 6:
			{
				int type7 = 1;
				float num32 = ScrollManager.GetSize(1f) * 10f;
				float num33 = 1f;
				float num34 = (float)(Math.Cos((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.100000001490116 + 0.800000011920929);
				float num35 = (float)(Math.Sin((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.200000002980232 + 0.5);
				float r3 = num33 * map.glowBrite;
				float g3 = num34 * map.glowBrite;
				float b4 = num35 * map.glowBrite;
				Vector2 screenLoc6 = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
				glowMgr.Add(0, screenLoc6, 1f, 1f, 1f, num32, 0);
				glowMgr.Add(type7, screenLoc6, map.glowBrite, map.glowBrite, map.glowBrite, num32 * 0.75f, 1);
				glowMgr.Add(type7, screenLoc6, r3, g3, b4, num32 * Rand.GetRandomFloat(0.1f, 0.12f), 0);
				break;
			}
			case 7:
			case 17:
			case 18:
			case 92:
			{
				int type6 = 1;
				float num24 = ScrollManager.GetSize(1f) * 20f;
				float num25 = 1f;
				float num26 = (float)(Math.Cos((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.100000001490116 + 0.699999988079071);
				float num27 = (float)(Math.Sin((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.200000002980232 + 0.5);
				float num28 = num25 * map.glowBrite;
				float num29 = num26 * map.glowBrite;
				float num30 = num27 * map.glowBrite;
				float num31 = num28 * 0.5f;
				float g2 = num29 * 0.5f;
				float b3 = num30 * 0.5f;
				Vector2 screenLoc5 = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
				glowMgr.Add(0, screenLoc5, 1f, 1f, 1f, num24, 0);
				glowMgr.Add(type6, screenLoc5, map.glowBrite, map.glowBrite, map.glowBrite, num24 * 0.75f, 1);
				glowMgr.Add(type6, screenLoc5, num31 * 1.5f, g2, b3, num24 * Rand.GetRandomFloat(0.1f, 0.12f), 0);
				break;
			}
			case 19:
			{
				float num20 = (float)Math.Cos((double)map.delta * 2.5 + (double)seg.loc.X + (double)seg.loc.Y) * 0.1f + 1.570796f;
				int type5 = 1;
				Vector2 loc = seg.loc + new Vector2((float)Math.Cos(num20), (float)Math.Sin(num20)) * 100f;
				float num21 = ScrollManager.GetSize(1f) * 4f;
				float num22 = 1f;
				float num23 = (float)(Math.Cos((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.100000001490116 + 0.899999976158142);
				_ = (float)(Math.Sin((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.200000002980232 + 0.5);
				_ = map.glowBrite;
				_ = map.glowBrite;
				_ = map.glowBrite;
				glowMgr.Add(0, ScrollManager.GetScreenLoc(loc, seg.depth), 1f, 1f, 1f, num21 * 3f, 0);
				glowMgr.Add(type5, ScrollManager.GetScreenLoc(loc, seg.depth), map.glowBrite, map.glowBrite, map.glowBrite, num21, 1);
				glowMgr.Add(type5, ScrollManager.GetScreenLoc(loc, seg.depth), map.glowBrite, map.glowBrite, map.glowBrite, num21 * 2f, 1);
				break;
			}
			case 25:
			{
				int type4 = 1;
				float num13 = ScrollManager.GetSize(1f) * 10f;
				float num14 = (float)(Math.Cos((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.100000001490116 + 0.699999988079071);
				float num15 = (float)(Math.Sin((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.200000002980232 + 0.5);
				float num16 = 1f;
				float num17 = num14 * map.glowBrite;
				float num18 = num15 * map.glowBrite;
				float num19 = num16 * map.glowBrite;
				Vector2 screenLoc4 = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
				glowMgr.Add(0, screenLoc4, 0.1f, 1f, 1f, num13, 0);
				glowMgr.Add(type4, screenLoc4, num17 * 1.2f, num18 * 0.25f, num19 * 1.2f, num13 * 0.75f, 0);
				break;
			}
			case 26:
			{
				int type3 = 1;
				float num6 = ScrollManager.GetSize(1f) * 10f;
				float num7 = (float)(Math.Cos((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.100000001490116 + 0.800000011920929);
				float num8 = (float)(Math.Sin((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.200000002980232 + 0.5);
				float num9 = 1f;
				float num10 = num7 * map.glowBrite;
				float num11 = num8 * map.glowBrite;
				float num12 = num9 * map.glowBrite;
				Vector2 screenLoc3 = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
				glowMgr.Add(0, screenLoc3, 0.1f, 1f, 1f, num6 * 0.5f, 0);
				glowMgr.Add(type3, screenLoc3, num10 * 0.125f, num11 * 0.5f, num12 * 1f, num6 * 0.5f, 0);
				break;
			}
			case 31:
			{
				int type2 = 1;
				float num3 = ScrollManager.GetSize(1f) * 10f;
				float num4 = (float)(Math.Cos((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.100000001490116 + 0.699999988079071);
				_ = (float)(Math.Sin((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.200000002980232 + 0.5);
				float num5 = 1f;
				float r2 = num4 * map.glowBrite;
				_ = map.glowBrite;
				float b2 = num5 * map.glowBrite;
				Vector2 screenLoc2 = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
				glowMgr.Add(0, screenLoc2, 1f, 0.1f, 1f, num3 * 0.5f, 0);
				glowMgr.Add(type2, screenLoc2, r2, 0f, b2, num3 * 0.1f, 0);
				glowMgr.Add(type2, screenLoc2, r2, 0f, 0f, num3 * 0.05f, 0);
				break;
			}
			case 74:
			{
				int type = 1;
				float num = ScrollManager.GetSize(1f) * 10f;
				float num2 = (float)(Math.Cos((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.100000001490116 + 0.699999988079071);
				float r = (float)(Math.Sin((double)map.delta + (double)seg.loc.X + (double)seg.loc.Y) * 0.200000002980232 + 0.5) * map.glowBrite;
				float g = num2 * map.glowBrite;
				float b = 1f * map.glowBrite;
				Vector2 screenLoc = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
				glowMgr.Add(0, screenLoc, 1f, 1f, 1f, num, 0);
				glowMgr.Add(type, screenLoc, r, g, b, num, 0);
				glowMgr.Add(type, screenLoc, r, g, b, num * Rand.GetRandomFloat(0.1f, 0.12f), 0);
				glowMgr.Add(type, screenLoc, 1f, 1f, 1f, num * Rand.GetRandomFloat(0.01f, 0.012f), 0);
				break;
			}
			}
		}
	}
}
