using System.IO;
using Microsoft.Xna.Framework;

namespace xCharEdit.Character;

public class Part
{
	public Vector2 location;

	public float rotation;

	public Vector2 scaling;

	public int idx;

	public int flip;

	public int parent;

	public Vector2 parentLocOffset;

	public float parentRotationOffset;

	public Vector2 drawLoc;

	public float drawRotation;

	public Vector2 drawScale;

	public Vector2 drawParentLocOffset;

	public float drawParentRotationOffset;

	public Part()
	{
		idx = -1;
		parent = -1;
		scaling = new Vector2(1f, 1f);
	}

	internal void Write(BinaryWriter b)
	{
		b.Write(idx);
		b.Write(location.X);
		b.Write(location.Y);
		b.Write(rotation);
		b.Write(scaling.X);
		b.Write(scaling.Y);
		b.Write(flip);
		b.Write(parent);
		if (parent > -1)
		{
			b.Write(parentLocOffset.X);
			b.Write(parentLocOffset.Y);
			b.Write(parentRotationOffset);
		}
	}

	internal void Read(BinaryReader b)
	{
		idx = b.ReadInt32();
		location.X = b.ReadSingle();
		location.Y = b.ReadSingle();
		rotation = b.ReadSingle();
		scaling.X = b.ReadSingle();
		scaling.Y = b.ReadSingle();
		flip = b.ReadInt32();
		parent = b.ReadInt32();
		if (parent > -1)
		{
			parentLocOffset.X = b.ReadSingle();
			parentLocOffset.Y = b.ReadSingle();
			parentRotationOffset = b.ReadSingle();
		}
	}
}
