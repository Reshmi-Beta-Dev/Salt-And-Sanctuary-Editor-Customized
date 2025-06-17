using System;
using MapEdit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonsterEdit.monsters;
using ProjectTower;
using SheetEdit.TextureSheet;
using xCharEdit;
using xCharEdit.Character;

namespace ClothesEdit.character;

public class Actor
{
	public int FACE_RIGHT = 1;

	public float scale = 0.35f;

	public int FACE_LEFT;

	public int face;

	public int anim;

	public int key;

	public float cFrame;

	public string animName;

	public CharDef cDef;

	public MonsterDef mDef;

	public bool exists;

	public Vector2 loc;

	public float depth;

	public int food;

	private int catRef;

	private const string CLOTHES = "T-Shirt";

	private const string HAT = "Beanie";

	public Actor()
	{
		exists = false;
	}

	public void Init(Vector2 loc, MonsterDef mDef, CharDef def, int face, string anim, float depth)
	{
		exists = true;
		this.loc = loc;
		cDef = def;
		this.mDef = mDef;
		this.face = face;
		this.depth = depth;
		SetAnim(anim);
	}

	public void SetAnim(string anim)
	{
		for (int i = 0; i < cDef.animation.Count; i++)
		{
			Animation animation = cDef.animation[i];
			if (animation != null && animation.name == anim)
			{
				animName = anim;
				this.anim = i;
				key = 0;
				cFrame = 0f;
				break;
			}
		}
	}

	public void Update(GameTime gameTime)
	{
		try
		{
			Animation animation = cDef.animation[anim];
			KeyFrame keyFrame = animation.keyFrame[key];
			if (animName == "deadin" || animName == "awakein" || animName == "awakein2" || animName == "awakein3" || animName == "awakein4" || animName == "awakein5")
			{
				key = 0;
				return;
			}
			if (animName == "awarpin")
			{
				for (int i = 0; i < animation.keyFrame.Count; i++)
				{
					KeyFrame keyFrame2 = animation.keyFrame[i];
					if (keyFrame2.frameRef <= -1)
					{
						continue;
					}
					Frame frame = cDef.frame[keyFrame2.frameRef];
					for (int j = 0; j < frame.part.Length; j++)
					{
						if (frame.part[j].idx > -1)
						{
							key = i;
							return;
						}
					}
				}
			}
			cFrame += (float)(gameTime.ElapsedGameTime.TotalSeconds * 30.0);
			if ((double)cFrame > (double)keyFrame.duration)
			{
				cFrame -= keyFrame.duration;
				key++;
				if (key >= animation.keyFrame.Count)
				{
					key = 0;
				}
				keyFrame = animation.keyFrame[key];
			}
			if (keyFrame.frameRef < 0)
			{
				key = 0;
			}
		}
		catch
		{
			key = 0;
		}
	}

	public void Draw(XTexture xTex, float brite)
	{
		try
		{
			if (xTex.name == "switch")
			{
				key = 0;
			}
			if (cDef.animation[anim].keyFrame[key].lerp)
			{
				int num = cDef.animation[anim].keyFrame[key].frameRef;
				if (num < 0)
				{
					num = 0;
				}
				int num2 = key + 1;
				if (num2 >= cDef.animation[anim].keyFrame.Count)
				{
					num2 = 0;
				}
				DrawCharacter(num, cDef.animation[anim].keyFrame[num2].frameRef, xTex, brite);
			}
			else
			{
				int num3 = cDef.animation[anim].keyFrame[key].frameRef;
				if (num3 < 0)
				{
					num3 = 0;
				}
				DrawCharacter(num3, -1, xTex, brite);
			}
		}
		catch (Exception)
		{
			anim = 0;
			key = 0;
		}
	}

	public void DrawCharacter(int frameIdx, int next, XTexture xTex, float brite)
	{
		Rectangle value = default(Rectangle);
		Vector2 origin = default(Vector2);
		if (cDef == null)
		{
			return;
		}
		Frame frame = cDef.frame[frameIdx];
		float num = 1f;
		scale = ScrollManager.GetSize(depth);
		Vector2 v = new Vector2(loc.X, loc.Y);
		Vector2 screenLoc = ScrollManager.GetScreenLoc(v, depth);
		bool flag = Game1.GetValidCol(v);
		if ((double)screenLoc.X < 0.0 || (double)screenLoc.X > (double)ScrollManager.screenSize.X || (double)screenLoc.Y < 0.0 || (double)screenLoc.Y > (double)ScrollManager.screenSize.Y)
		{
			return;
		}
		Vector2 screenLoc2;
		if (mDef.name == "deadprop")
		{
			screenLoc2 = ScrollManager.GetScreenLoc(v, depth);
			flag = true;
		}
		else if (mDef.hover)
		{
			screenLoc2 = ScrollManager.GetScreenLoc(v, depth);
			flag = true;
		}
		else if (mDef.ai == 9)
		{
			screenLoc2 = ScrollManager.GetScreenLoc(v, depth);
			flag = true;
		}
		else
		{
			v.Y = Game1.GetMinY(v);
			screenLoc2 = ScrollManager.GetScreenLoc(v, depth);
		}
		for (int i = 0; i < frame.GetPartArray().Length; i++)
		{
			Part part = frame.GetPart(i);
			if (part.idx <= -1)
			{
				continue;
			}
			float num2 = part.rotation;
			if (float.IsNaN(part.location.X))
			{
				part.location.X = 0f;
			}
			if (float.IsNaN(part.location.Y))
			{
				part.location.Y = 0f;
			}
			Vector2 location = part.location;
			Vector2 position = location * scale + screenLoc2;
			Vector2 vector = part.scaling * scale;
			bool flag2 = false;
			if ((face == FACE_RIGHT && part.flip == 0) || (face == FACE_LEFT && part.flip == 1))
			{
				flag2 = true;
			}
			if (face == FACE_LEFT)
			{
				num2 = 0f - num2;
				position.X -= (float)((double)location.X * (double)scale * 2.0);
			}
			if (next > -1)
			{
				Frame frame2 = cDef.frame[next];
				if (Frame.CanLerp(frame, frame2, i))
				{
					Part part2 = frame2.GetPart(i);
					float progress = cFrame / (float)cDef.animation[anim].keyFrame[key].duration;
					Vector2 location2 = part.location;
					Vector2 location3 = part2.location;
					float num3 = part.rotation;
					float num4 = part2.rotation;
					if (face == FACE_LEFT)
					{
						num3 = 0f - num3;
						num4 = 0f - num4;
						location2.X -= part.location.X * 2f;
						location3.X -= part2.location.X * 2f;
					}
					position = Frame.LerpLoc(location2, location3, progress) * scale + screenLoc2;
					num2 = Frame.LerpRotation(num3, num4, progress);
					vector = Frame.LerpScale(part.scaling, part2.scaling, progress) * scale;
				}
			}
			Color color = new Color(brite, brite, brite, num);
			if (!flag)
			{
				color = new Color(brite, 0f, 0f, num);
			}
			if (part.idx >= 1000 && !((double)num < 1.0))
			{
				continue;
			}
			Texture2D texture2D;
			if (part.idx < 256)
			{
				texture2D = xTex.texture;
				if (texture2D == null)
				{
					xTex.texture = ContentRig.LoadTextureFromFile("\\gfx\\" + mDef.texture + ".png");
					texture2D = xTex.texture;
				}
				value = xTex.GetSpriteRect(part.idx);
				origin = xTex.GetSpriteOrigin(part.idx);
				origin.X -= value.X;
				origin.Y -= value.Y;
				if (!flag2)
				{
					origin.X = (float)value.Width - origin.X;
				}
			}
			else if (part.idx >= 256 && part.idx < 384)
			{
				if (mDef.name == "deadprop" || animName == "jesterbrand" || animName == "noblesbrand" || animName == "ledgebrand")
				{
					texture2D = Game1.textures["consumables"].texture;
					if (texture2D == null)
					{
						Game1.textures["consumables"].texture = ContentRig.LoadTextureFromFile("\\gfx\\consumables.png");
						texture2D = Game1.textures["consumables"].texture;
					}
					value = Game1.textures["consumables"].GetSpriteRect(part.idx - 256);
					origin = Game1.textures["consumables"].GetSpriteOrigin(part.idx - 256);
					origin.X -= value.X;
					origin.Y -= value.Y;
					if (!flag2)
					{
						origin.X = (float)value.Width - origin.X;
					}
				}
				else
				{
					texture2D = null;
				}
			}
			else
			{
				texture2D = null;
			}
			if (texture2D != null)
			{
				Vector2 vector2 = vector * 0.5f;
				SpriteTools.sprite.Draw(texture2D, position, value, color, num2, origin, vector2, (!flag2) ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 1f);
			}
		}
	}
}
