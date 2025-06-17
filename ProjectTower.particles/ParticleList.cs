using MapEdit;
using Microsoft.Xna.Framework;

namespace ProjectTower.particles;

public class ParticleList
{
	public Particle[] particle;

	public int totalParticles;

	public const int BODY_PART_BASE = 2048;

	public const int BAG_BASE = 4096;

	public const int TOTAL_PARTICLES = 512;

	public const int TOTAL_SUBTRACTIVE_PARTICLES = 1024;

	public const int TOTAL_ALPHA_PARTICLES = 512;

	public const int TOTAL_ADDITIVE_PARTICLES = 1024;

	public int type;

	public ParticleList(int type)
	{
		this.type = type;
		switch (type)
		{
		case 0:
		case 3:
			particle = new Particle[1024];
			break;
		case 1:
		case 4:
			particle = new Particle[512];
			break;
		case 2:
		case 5:
			particle = new Particle[1024];
			break;
		default:
			particle = new Particle[512];
			break;
		}
		for (int i = 0; i < particle.Length; i++)
		{
			particle[i] = new Particle(i, type);
		}
	}

	internal int AddParticle(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner, bool priority)
	{
		for (int i = 0; i < particle.Length; i++)
		{
			if (!particle[i].exists)
			{
				particle[i].Init(type, loc, traj, size, rotation, flags, owner);
				if (i + 1 > totalParticles)
				{
					totalParticles = i + 1;
				}
				return i;
			}
			int num = particle[i].type;
			if (num == 1 || num == 23)
			{
				particle[i].Init(type, loc, traj, size, rotation, flags, owner);
				if (i + 1 > totalParticles)
				{
					totalParticles = i + 1;
				}
				return i;
			}
		}
		return -1;
	}

	internal int AddParticle(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		for (int i = 0; i < particle.Length; i++)
		{
			if (!particle[i].exists)
			{
				particle[i].Init(type, loc, traj, size, rotation, flags, owner);
				if (i + 1 > totalParticles)
				{
					totalParticles = i + 1;
				}
				return i;
			}
		}
		return -1;
	}

	internal void UpdateParticles()
	{
		int num = totalParticles;
		totalParticles = 0;
		for (int i = 0; i < num; i++)
		{
			if (particle[i].exists)
			{
				float frameTime = Game1.frameTime;
				particle[i].Update(frameTime);
				if (i + 1 > totalParticles)
				{
					totalParticles = i + 1;
				}
			}
		}
	}

	internal void Draw()
	{
		for (int i = 0; i < totalParticles; i++)
		{
			if (particle[i].exists)
			{
				particle[i].Draw(1f);
			}
		}
	}

	internal void Reset()
	{
		for (int i = 0; i < particle.Length; i++)
		{
			particle[i].exists = false;
		}
	}
}
