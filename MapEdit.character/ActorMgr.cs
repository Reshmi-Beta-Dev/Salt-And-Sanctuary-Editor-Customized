using System.Collections.Generic;
using ClothesEdit.character;
using Microsoft.Xna.Framework;
using MonsterEdit.monsters;
using xCharEdit.Character;

namespace MapEdit.character;

public class ActorMgr
{
	public List<Actor> actor;

	public ActorMgr()
	{
		actor = new List<Actor>();
	}

	public int AddActor(Vector2 loc, MonsterDef mDef, CharDef cDef, int face, string anim, float depth)
	{
		Actor actor = new Actor();
		actor.Init(loc, mDef, cDef, face, anim, depth);
		this.actor.Add(actor);
		return this.actor.Count - 1;
	}

	public void Reset()
	{
		actor = new List<Actor>();
	}

	public void Update(GameTime gameTime)
	{
		foreach (Actor item in actor)
		{
			item.Update(gameTime);
		}
	}
}
