using MapEdit;
using Microsoft.Xna.Framework;
using ProjectTower.texturesheet;

namespace ProjectTower.particles.particles.gore;

public class Glob : BaseParticle
{
	public override void Init(Particle p, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		p.loc = loc;
		p.traj = traj;
		p.size = size;
		p.rotation = Trig.GetAngle(default(Vector2), traj);
		p.flags = Rand.GetRandomInt(16, 19);
		p.owner = owner;
		p.frame = Rand.GetRandomFloat(0.125f, 0.4f);
		p.rDir = Rand.GetRandomFloat(-2f, 2f);
		p.aux = 0;
		base.Init(p, loc, traj, size, rotation, flags, owner);
	}

	public override void Update(Particle p, float frameTime)
	{
		TrimFrame(p);
		if ((double)p.frame < 0.5 && (double)p.traj.Y < -50.0)
		{
			p.traj.Y += frameTime * 1500f;
		}
		p.traj.Y += frameTime * 500f;
		p.rotation += p.rDir * frameTime;
		base.Update(p, frameTime);
	}

	public override void Draw(Particle p, float brite)
	{
		Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(p.loc, 0), p.flags, new Vector2(0.85f, 0.85f) * ScrollManager.cannedDepth[0] * (p.size + (float)((1.0 - (double)p.frame) * 0.100000001490116)) * 0.35f, p.rotation, 0.5f, 1f, 1f, p.frame * 0.95f);
		base.Draw(p, brite);
	}
}
