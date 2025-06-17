using MapEdit;
using Microsoft.Xna.Framework;
using ProjectTower.texturesheet;

namespace ProjectTower.particles.particles.debris;

internal class Fire : BaseParticle
{
	public const int AUX_NORMAL = 0;

	public const int AUX_TORCHFIRE = 1;

	public const int AUX_FIREPLACE = 2;

	public const int AUX_BRAZIER = 3;

	public const int AUX_CAMPFIRE = 4;

	public override void Init(Particle p, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		p.loc = loc;
		p.traj = traj;
		p.size = size;
		p.rotation = rotation;
		p.aux = flags;
		p.flags = Rand.GetRandomInt(5, 9);
		p.owner = owner;
		p.frame = Rand.GetRandomFloat(0.3f, 0.7f);
		p.rDir = Rand.GetRandomFloat(-9f, 9f);
		switch (p.aux)
		{
		case 1:
			p.rotation = Rand.GetRandomFloat(-3.141593f, 3.141593f);
			p.frame = 0.35f;
			break;
		case 3:
			p.frame = 0.45f;
			p.rotation = 0f;
			break;
		}
		base.Init(p, loc, traj, size, rotation, flags, owner);
	}

	public override void Update(Particle p, float frameTime)
	{
		TrimFrame(p);
		switch (p.aux)
		{
		case 1:
		{
			if ((double)p.frame < 0.400000005960464)
			{
				p.loc += p.traj * frameTime;
			}
			if ((double)p.frame < 0.300000011920929)
			{
				p.loc.Y += p.traj.Y * frameTime;
			}
			double num = p.frame;
			p.frame -= frameTime;
			if ((int)(num * 30.0) != (int)((double)p.frame * 30.0))
			{
				p.rotation *= 0.7f;
			}
			if (!((double)p.frame > 0.0))
			{
				p.exists = false;
			}
			break;
		}
		case 3:
			if ((double)p.frame > 0.400000005960464)
			{
				p.rotation += (float)((double)p.rDir * (double)frameTime * 0.100000001490116);
			}
			else
			{
				p.rotation += p.rDir * frameTime;
			}
			if ((double)p.frame < 0.349999994039536)
			{
				p.traj.Y -= frameTime * 300f;
				p.traj.X += frameTime * 400f;
			}
			base.Update(p, frameTime);
			break;
		default:
			p.rotation += p.rDir * frameTime;
			base.Update(p, frameTime);
			break;
		}
	}

	public override void Draw(Particle p, float brite)
	{
		float num = p.frame * 0.5f;
		Vector2 vector = new Vector2(1f, 1f);
		switch (p.aux)
		{
		case 1:
			num *= 3f;
			vector.X -= (float)((0.349999994039536 - (double)p.frame) * 1.0);
			vector.Y += (float)((0.349999994039536 - (double)p.frame) * 4.0);
			break;
		case 3:
			if ((double)p.frame > 0.300000011920929)
			{
				vector.X += (float)(((double)p.frame - 0.349999994039536) * 15.0);
				vector.Y -= (float)(((double)p.frame - 0.349999994039536) * 5.0);
				float num2 = (0.45f - p.frame) * 20f;
				if ((double)num2 > 1.0)
				{
					num2 = 2f - num2;
				}
				Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(p.loc + new Vector2(0f, (float)((0.449999988079071 - (double)p.frame) * 20.0)), 0), 0, new Vector2(1f, 0.4f) * ScrollManager.cannedDepth[0], p.rotation, 1f, 0.5f, 0.2f, num2 * 0.25f);
			}
			num = (((double)p.frame <= 0.300000011920929) ? (p.frame / 0.3f) : ((float)((0.449999988079071 - (double)p.frame) / 0.150000005960464))) * 0.4f;
			break;
		}
		Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(p.loc, 0), p.flags, vector * ScrollManager.cannedDepth[0] * p.size, p.rotation, 1f, 0.5f, 0.1f, num);
		base.Draw(p, brite);
	}
}
