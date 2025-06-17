using Microsoft.Xna.Framework;

namespace ProjectTower.particles.particles.gore;

public class BloodArc : BaseParticle
{
	public const int AUX_BACK_TO_FRONT = 0;

	public const int AUX_FRONT_TO_BACK = 1;

	public override void Init(Particle p, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		p.loc = loc;
		p.rotation = rotation;
		p.flags = flags;
		p.traj = traj;
		if ((double)p.traj.X < 0.0)
		{
			p.traj.X = 0f - p.traj.X;
		}
		if ((double)p.traj.Y < 0.0)
		{
			p.traj.Y = 0f - p.traj.Y;
		}
		p.frame = 0.12f;
		p.owner = owner;
		base.Init(p, loc, traj, size, rotation, flags, owner);
	}
}
