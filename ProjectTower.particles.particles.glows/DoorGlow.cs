using MapEdit;
using Microsoft.Xna.Framework;
using ProjectTower.texturesheet;

namespace ProjectTower.particles.particles.glows;

public class DoorGlow : BaseParticle
{
	public override void Init(Particle p, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		p.frame = 0.5f;
		p.size = Rand.GetRandomFloat(1f, 3f);
		p.loc = loc;
		p.traj = default(Vector2);
		p.rotation = rotation;
		p.rDir = 0f;
		p.owner = -1;
		base.Init(p, loc, traj, size, rotation, flags, owner);
	}

	public override void Update(Particle p, float frameTime)
	{
		base.Update(p, frameTime);
	}

	public override void Draw(Particle p, float brite)
	{
		float num = (((double)p.frame > 0.25) ? (0.5f - p.frame) : p.frame);
		Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(p.loc, 0), 0, new Vector2(p.size, 0.25f) * ScrollManager.cannedDepth[0], (!ParticleManager.indoors) ? (0f - p.rotation) : p.rotation, 1f, 0.8f, 0.6f, num * 5f);
		base.Draw(p, brite);
	}
}
