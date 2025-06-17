using Microsoft.Xna.Framework;

namespace ProjectTower.particles;

public class ParticleManager
{
	public const int BACK_SUB = 0;

	public const int BACK_NORMAL = 1;

	public const int BACK_ADD = 2;

	public const int FORE_SUB = 3;

	public const int FORE_NORMAL = 4;

	public const int FORE_ADD = 5;

	public const int BACK_REFRACT = 6;

	public const int FORE_REFRACT = 7;

	public const int TOTAL_LISTS = 8;

	public static ParticleList[] particleList;

	public static Vector3[][] swooshData;

	public static int spritesTexIdx;

	public static int swooshesTexIdx;

	public static bool indoors;

	public static void Reset()
	{
		for (int i = 0; i < particleList.Length; i++)
		{
			particleList[i].Reset();
		}
	}

	public static void Init()
	{
		particleList = new ParticleList[8];
		for (int i = 0; i < particleList.Length; i++)
		{
			particleList[i] = new ParticleList(i);
		}
		swooshData = new Vector3[4][];
		swooshData[0] = new Vector3[9]
		{
			new Vector3(-164f, -1f, 2.857799f),
			new Vector3(-158f, -49f, 1.695151f),
			new Vector3(-134f, -96f, 2.042919f),
			new Vector3(-105f, -128f, 2.307054f),
			new Vector3(-63f, -154f, 2.587285f),
			new Vector3(-7f, -164f, 2.964884f),
			new Vector3(51f, -156f, 3.278659f),
			new Vector3(97f, -125f, 3.734595f),
			new Vector3(131f, -79f, 4.075881f)
		};
		swooshData[1] = new Vector3[8]
		{
			new Vector3(-109f, -59f, 4.71f),
			new Vector3(-61f, -73f, 2.857799f),
			new Vector3(-6f, -80f, 3.015001f),
			new Vector3(52f, -78f, 3.176062f),
			new Vector3(95f, -66f, 3.413739f),
			new Vector3(135f, -48f, 3.564447f),
			new Vector3(165f, -12f, 4.017651f),
			new Vector3(163f, 21f, 4.772921f)
		};
		swooshData[2] = new Vector3[5]
		{
			new Vector3(1f, -4f, 3.14f),
			new Vector3(31f, 4f, 3.14f),
			new Vector3(60f, 0f, 3.14f),
			new Vector3(102f, -2f, 3.14f),
			new Vector3(131f, 5f, 3.14f)
		};
		swooshData[3] = new Vector3[5]
		{
			new Vector3(-167f, -87f, 1.57f),
			new Vector3(-169f, -120f, 1.57f),
			new Vector3(-168f, -140f, 1.57f),
			new Vector3(-145f, -65f, 1.57f),
			new Vector3(-117f, -52f, 1.57f)
		};
	}

	public static int AddParticle(int list, int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		return particleList[list].AddParticle(type, loc, traj, size, rotation, flags, owner);
	}

	public static int AddRefractParticle(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		return particleList[7].AddParticle(type, loc, traj, size, rotation, flags, owner);
	}

	public static int AddBackRefractParticle(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		return particleList[6].AddParticle(type, loc, traj, size, rotation, flags, owner);
	}

	public static int AddNormalParticle(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		return particleList[4].AddParticle(type, loc, traj, size, rotation, flags, owner);
	}

	public static int AddAdditiveParticle(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		return particleList[5].AddParticle(type, loc, traj, size, rotation, flags, owner);
	}

	public static int AddSubtractiveParticle(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		return particleList[3].AddParticle(type, loc, traj, size, rotation, flags, owner);
	}

	public static int AddBackNormalParticle(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		return particleList[1].AddParticle(type, loc, traj, size, rotation, flags, owner);
	}

	public static int AddBackAdditiveParticle(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		if (type != 35 && type != 36)
		{
			return particleList[2].AddParticle(type, loc, traj, size, rotation, flags, owner);
		}
		return particleList[2].AddParticle(type, loc, traj, size, rotation, flags, owner, priority: true);
	}

	public static int AddBackSubtractiveParticle(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		return particleList[0].AddParticle(type, loc, traj, size, rotation, flags, owner);
	}

	public static void UpdateParticles()
	{
		for (int i = 0; i < 8; i++)
		{
			particleList[i].UpdateParticles();
		}
	}

	internal static void Draw(int type)
	{
		particleList[type].Draw();
	}

	internal static void RemoveCharacterParticles(int ID)
	{
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < particleList[i].totalParticles; j++)
			{
				if (particleList[i].particle[j].exists && particleList[i].particle[j].owner == ID)
				{
					particleList[i].particle[j].exists = false;
				}
			}
		}
	}
}
