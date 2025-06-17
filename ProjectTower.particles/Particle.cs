using Microsoft.Xna.Framework;

namespace ProjectTower.particles;

public class Particle
{
	public int ID;

	public Vector2 loc;

	public Vector2 traj;

	public float size;

	public float frame;

	public float rotation;

	public int owner;

	public int flags;

	public int face;

	public int type;

	public bool exists;

	public bool grounded;

	public float rDir;

	public int aux;

	public const int PARTICLEDRAW_NORMAL = 0;

	public const int PARTICLEDRAW_ADDITIVE = 1;

	public const int PARTICLEDRAW_THRESH = 2;

	public const int PARTICLEDRAW_SUBTRACTIVE = 3;

	public int particleType;

	public Particle(int ID, int particleType)
	{
		this.ID = ID;
		this.particleType = particleType;
		exists = false;
	}

	public void Update(float frameTime)
	{
		ParticleCatalog.particle[type].Update(this, frameTime);
	}

	public void Draw(float brite)
	{
		ParticleCatalog.particle[type].Draw(this, brite);
	}

	public void Init(int type, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		this.owner = -1;
		grounded = false;
		this.type = type;
		ParticleCatalog.particle[type].Init(this, loc, traj, size, rotation, flags, owner);
	}
}
