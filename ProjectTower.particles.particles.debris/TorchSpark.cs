using MapEdit;
using Microsoft.Xna.Framework;
using ProjectTower.texturesheet;

namespace ProjectTower.particles.particles.debris;

internal class TorchSpark : BaseParticle
{
	public override void Init(Particle p, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		p.loc = loc;
		p.traj = traj;
		p.size = size;
		p.rotation = rotation;
		p.flags = Rand.GetRandomInt(5, 9);
		p.owner = owner;
		p.frame = Rand.GetRandomFloat(0.3f, 0.7f);
		p.rotation = Trig.GetAngle(default(Vector2), p.traj);
		p.size = p.traj.Length();
		base.Init(p, loc, traj, size, rotation, flags, owner);
	}

	public override void Update(Particle p, float frameTime)
	{
		TrimFrame(p);
		float frame = p.frame;
		base.Update(p, frameTime);
		if (p.exists && (int)((double)p.frame * 10.0) != (int)((double)frame * 10.0))
		{
			p.traj += Rand.GetRandomVec2(-1f, 1.2f, -1.2f, 0.8f) * 100f;
			p.rotation = Trig.GetAngle(default(Vector2), p.traj);
			p.size = p.traj.Length();
		}
	}

	public override void Draw(Particle p, float brite)
	{
		Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(p.loc, 0), p.flags, new Vector2(p.size / 1600f, 0.03f) * ScrollManager.cannedDepth[0], p.rotation, 1f, 1f, 1f, p.frame * 5f);
		base.Draw(p, brite);
	}
}
