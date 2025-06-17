using MapEdit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower.texturesheet;
using SheetEdit.TextureSheet;

namespace ProjectTower.particles.particles;

public class BaseParticle
{
	public virtual void Init(Particle p, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		p.exists = true;
	}

	public void TrimFrame(Particle p)
	{
		if (ParticleManager.particleList[p.particleType].totalParticles > 100)
		{
			p.frame -= Game1.frameTime;
		}
		if (ParticleManager.particleList[p.particleType].totalParticles > 200)
		{
			p.frame -= Game1.frameTime;
		}
	}

	public virtual void Update(Particle p, float frameTime)
	{
		p.loc += p.traj * frameTime;
		p.frame -= frameTime;
		if (!((double)p.frame > 0.0))
		{
			p.exists = false;
		}
	}

	public virtual void Draw(Particle p, float brite)
	{
	}

	public virtual void DrawFromTexture(Vector3 loc, int idx, Vector2 scale, float rotation, float r, float g, float b, float a)
	{
		DrawFromTexture(loc, idx, scale, rotation, r, g, b, a, SpriteEffects.None);
	}

	public virtual void DrawFromTexture(Vector3 loc, int idx, Vector2 scale, float rotation, float r, float g, float b, float a, SpriteEffects se)
	{
		XSprite cell = Textures.tex[ParticleManager.spritesTexIdx].GetCell(idx);
		if (float.IsNaN(rotation))
		{
			rotation = 0f;
		}
		SpriteTools.sprite.Draw(Textures.tex[ParticleManager.spritesTexIdx].GetTexture(), ScrollManager.GetScreenLoc(loc, 0), cell.srcRect, new Color(r, g, b, a), rotation, cell.origin - new Vector2(cell.srcRect.X, cell.srcRect.Y), scale * ScrollManager.cannedDepth[0], se, 1f);
	}
}
