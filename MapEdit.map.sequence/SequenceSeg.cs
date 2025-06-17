using System.IO;
using Microsoft.Xna.Framework;

namespace MapEdit.map.sequence;

public class SequenceSeg
{
	public struct LayerSegID
	{
		public int layer;

		public int segID;
	}

	public Vector2 loc;

	public Vector2 scaling;

	public float rotation;

	public int ID;

	public SequenceSeg(Seg seg, int ID)
	{
		rotation = seg.rotation;
		loc = seg.loc;
		scaling = seg.scaling;
		this.ID = ID;
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write(ID);
		writer.Write(rotation);
		writer.Write(loc.X);
		writer.Write(loc.Y);
		writer.Write(scaling.X);
		writer.Write(scaling.Y);
	}

	public SequenceSeg(BinaryReader reader)
	{
		ID = reader.ReadInt32();
		rotation = reader.ReadSingle();
		loc = new Vector2(reader.ReadSingle(), reader.ReadSingle());
		scaling = new Vector2(reader.ReadSingle(), reader.ReadSingle());
	}
}
