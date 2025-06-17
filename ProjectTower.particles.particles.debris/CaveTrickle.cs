using MapEdit;
using Microsoft.Xna.Framework;
using ProjectTower.texturesheet;

namespace ProjectTower.particles.particles.debris;

internal class CaveTrickle : BaseParticle
{
	public override void Init(Particle p, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		p.loc = loc;
		p.traj = traj;
		p.size = size;
		p.rotation = rotation;
		p.aux = flags;
		p.flags = Rand.GetRandomInt(16, 21);
		p.owner = owner;
		p.frame = 1f;
		base.Init(p, loc, traj, size, rotation, flags, owner);
	}

	public override void Update(Particle p, float frameTime)
	{
		TrimFrame(p);
		_ = p.frame;
		p.traj.Y += frameTime * 2000f * (float)p.aux;
		base.Update(p, frameTime);
	}

	public override void Draw(Particle p, float brite)
	{
		Vector2 vector = new Vector2(p.size, (float)((1.0 - (double)p.frame) * 6.0 + 1.0) * p.size);
		if ((double)p.rotation < 1.0)
		{
			vector.X *= p.frame;
		}
		Vector2 screenLoc = ScrollManager.GetScreenLoc(p.loc, 0);
		Textures.tex[ParticleManager.spritesTexIdx].Draw(screenLoc, p.flags, vector * ScrollManager.cannedDepth[0], 0f, (p.owner == 1) ? 1f : 0f, 1f, (p.owner == 1) ? 1f : 0f, p.frame * Rand.GetRandomFloat(2.5f, 3f) * p.rotation);
		base.Draw(p, brite);
	}
}
