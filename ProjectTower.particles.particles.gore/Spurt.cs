using MapEdit;
using Microsoft.Xna.Framework;
using ProjectTower.texturesheet;

namespace ProjectTower.particles.particles.gore;

public class Spurt : BaseParticle
{
	public override void Init(Particle p, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		p.loc = loc;
		p.traj = traj;
		p.size = size;
		p.rotation = Trig.GetAngle(default(Vector2), traj);
		p.flags = Rand.GetRandomInt(9, 16);
		p.owner = owner;
		p.frame = Rand.GetRandomFloat(0.25f, 0.3f);
		p.rDir = Rand.GetRandomFloat(-2f, 2f);
		base.Init(p, loc, traj, size, rotation, flags, owner);
	}

	public override void Update(Particle p, float frameTime)
	{
		TrimFrame(p);
		float frame = p.frame;
		if ((double)p.frame < 0.5 && (double)p.traj.Y < -50.0)
		{
			p.traj.Y += frameTime * 1500f;
		}
		p.traj.Y += frameTime * 500f;
		if ((double)p.frame < 0.200000002980232)
		{
			p.traj.Y += frameTime * 1000f;
		}
		p.rotation += p.rDir * frameTime;
		base.Update(p, frameTime);
		if (p.exists && !((double)frame <= 0.200000002980232) && !((double)p.frame > 0.200000002980232))
		{
			p.traj *= 0.2f;
		}
	}

	public override void Draw(Particle p, float brite)
	{
		Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(p.loc, 0), p.flags, new Vector2(0.55f, 0.55f) * ScrollManager.cannedDepth[0] * (p.size + (float)((1.0 - (double)p.frame) * 0.100000001490116)), p.rotation, 0.5f, 1f, 1f, p.frame * 0.75f);
		base.Draw(p, brite);
	}
}
