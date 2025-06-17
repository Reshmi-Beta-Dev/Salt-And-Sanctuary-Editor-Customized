using System;
using Microsoft.Xna.Framework;
using ProjectTower;
using SheetEdit.TextureSheet;

namespace xCharEdit.Character;

public class Frame
{
	public Part[] part;

	public string name;

	public int parts;

	public const int MAX_PARTS = 32;

	public const int ADJUST_IDX_NONE = -1;

	public const int ADJUST_IDX_TORSO = 0;

	public const int ADJUST_IDX_TORCH = 2;

	public bool used;

	public Frame()
	{
		part = new Part[32];
		for (int i = 0; i < part.Length; i++)
		{
			part[i] = new Part();
		}
		name = "";
	}

	public Frame(Frame keySrc)
	{
		this.part = new Part[32];
		name = keySrc.name;
		for (int i = 0; i < this.part.Length; i++)
		{
			Part part = keySrc.part[i];
			this.part[i] = new Part();
			Part obj = this.part[i];
			obj.idx = part.idx;
			obj.location = new Vector2(part.location.X, part.location.Y);
			obj.rotation = part.rotation;
			obj.scaling = new Vector2(part.scaling.X, part.scaling.Y);
			obj.flip = part.flip;
			obj.parent = part.parent;
			obj.parentLocOffset = new Vector2(part.parentLocOffset.X, part.parentLocOffset.Y);
			obj.parentRotationOffset = part.parentRotationOffset;
		}
	}

	public Part GetPart(int idx)
	{
		if (idx >= 0)
		{
			return part[idx];
		}
		return part[0];
	}

	public void SetPart(int idx, Part _part)
	{
		part[idx] = _part;
	}

	public Part[] GetPartArray()
	{
		return part;
	}

	public static float LerpRotation(float orig, float next, float progress)
	{
		float num = next - orig;
		while ((double)num > 3.14159274101257)
		{
			num -= 6.283185f;
		}
		for (; (double)num < -3.14159274101257; num += 6.283185f)
		{
		}
		return orig + num * progress;
	}

	public static Vector2 LerpScale(Vector2 orig, Vector2 next, float progress)
	{
		return orig + (next - orig) * progress;
	}

	public static Vector2 LerpLoc(Vector2 orig, Vector2 next, float progress)
	{
		return orig + (next - orig) * progress;
	}

	public static bool CanLerp(Frame orig, Frame next, int part)
	{
		if (orig.GetPart(part).idx >= 0 && next.GetPart(part).idx >= 0)
		{
			if (orig.GetPart(part).idx < 2000 || next.GetPart(part).idx < 2000)
			{
				if (orig.GetPart(part).idx == next.GetPart(part).idx)
				{
					return orig.GetPart(part).flip == next.GetPart(part).flip;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	internal bool CheckLoop(int child, int parent)
	{
		if (child == parent)
		{
			return true;
		}
		int num = 0;
		do
		{
			num++;
			if (GetPart(parent).parent == -1)
			{
				return false;
			}
			parent = GetPart(parent).parent;
		}
		while (parent != child && num <= 10000);
		return true;
	}

	internal void SetHierarchy(int parentIdx, int childIdx)
	{
		if (!CheckLoop(childIdx, parentIdx))
		{
			Part part = GetPart(parentIdx);
			Part part2 = GetPart(childIdx);
			part2.parent = parentIdx;
			float num = Trig.GetAngle(part2.location, part.location) - part.rotation;
			float dist = Trig.GetDist(part.location, part2.location);
			part2.parentLocOffset = new Vector2((float)Math.Cos(num), (float)Math.Sin(num)) * dist;
			part2.parentRotationOffset = part2.rotation - part.rotation;
			UpdateChildren(parentIdx);
		}
	}

	internal void UpdateChildren(int parentIdx)
	{
		Part part = GetPart(parentIdx);
		for (int i = 0; i < this.part.Length; i++)
		{
			Part part2 = GetPart(i);
			if (part2.idx > -1 && part2.parent == parentIdx)
			{
				part2.location = part.location + new Vector2((float)Math.Cos(part.rotation), (float)Math.Sin(part.rotation)) * part2.parentLocOffset.X + new Vector2((float)Math.Cos((double)part.rotation + 1.57079637050629), (float)Math.Sin((double)part.rotation + 1.57079637050629)) * part2.parentLocOffset.Y;
				part2.rotation = part.rotation + part2.parentRotationOffset;
				UpdateChildren(i);
			}
		}
	}

	internal void UpdateAllDrawChildren(int adjustFlags, float adjustVal, XTexture xTex)
	{
		int num = 0;
		while (true)
		{
			bool flag = false;
			for (int i = 0; i < part.Length; i++)
			{
				if (part[i].idx <= -1)
				{
					continue;
				}
				int num2 = i;
				int num3 = 0;
				while (part[num2].parent > -1)
				{
					num2 = part[num2].parent;
					num3++;
					if (num3 > num)
					{
						break;
					}
				}
				if (num3 == num)
				{
					flag = true;
					if (part[i].parent > -1)
					{
						UpdateSingleDrawChild(i, part[i].parent, adjustFlags, adjustVal, xTex);
					}
				}
			}
			if (flag)
			{
				num++;
				continue;
			}
			break;
		}
	}

	internal void UpdateSingleDrawChild(int i, int parentIdx, int adjustFlags, float adjustVal, XTexture xTex)
	{
		Part part = GetPart(parentIdx);
		Part part2 = GetPart(i);
		if (part2.idx <= -1 || part2.parent != parentIdx)
		{
			return;
		}
		part2.drawLoc = part.drawLoc + new Vector2((float)Math.Cos(part.drawRotation), (float)Math.Sin(part.drawRotation)) * part2.drawParentLocOffset.X + new Vector2((float)Math.Cos((double)part.drawRotation + 1.57079637050629), (float)Math.Sin((double)part.drawRotation + 1.57079637050629)) * part2.drawParentLocOffset.Y;
		part2.drawRotation = part.drawRotation + part2.drawParentRotationOffset;
		if (adjustFlags == 0)
		{
			if ((double)adjustVal > 3.14159274101257)
			{
				adjustVal -= 6.283185f;
			}
			if ((double)adjustVal < -3.14159274101257)
			{
				adjustVal += 6.283185f;
			}
			if (part2.idx < 12)
			{
				part2.drawRotation += adjustVal * 0.5f;
			}
			if (part2.idx >= 12 && part2.idx < 18)
			{
				part2.drawRotation += adjustVal * 0.5f;
			}
			if (part2.idx >= 18 && part2.idx < 20)
			{
				part2.drawRotation += adjustVal * 0.5f;
			}
		}
	}

	internal void UpdateDrawChildren(int parentIdx, int adjustFlags, float adjustVal)
	{
		Part part = GetPart(parentIdx);
		for (int i = 0; i < this.part.Length; i++)
		{
			Part part2 = GetPart(i);
			if (part2.idx <= -1 || part2.parent != parentIdx)
			{
				continue;
			}
			part2.drawLoc = part.drawLoc + new Vector2((float)Math.Cos(part.drawRotation), (float)Math.Sin(part.drawRotation)) * part2.drawParentLocOffset.X + new Vector2((float)Math.Cos((double)part.drawRotation + 1.57079637050629), (float)Math.Sin((double)part.drawRotation + 1.57079637050629)) * part2.drawParentLocOffset.Y;
			part2.drawRotation = part.drawRotation + part2.drawParentRotationOffset;
			if (adjustFlags == 0)
			{
				if ((double)adjustVal > 3.14159274101257)
				{
					adjustVal -= 6.283185f;
				}
				if ((double)adjustVal < -3.14159274101257)
				{
					adjustVal += 6.283185f;
				}
				if (part2.idx < 12)
				{
					part2.drawRotation += adjustVal * 0.5f;
				}
				if (part2.idx >= 12 && part2.idx < 18)
				{
					part2.drawRotation += adjustVal * 0.5f;
				}
				if (part2.idx >= 18 && part2.idx < 20)
				{
					part2.drawRotation += adjustVal * 0.5f;
				}
			}
			UpdateDrawChildren(i, adjustFlags, adjustVal);
		}
	}
}
