using System.Collections.Generic;
using System.IO;

namespace MapEdit.map.sequence;

public class SequenceLayer
{
	public List<SequenceSeg> seg;

	public SequenceLayer()
	{
		seg = new List<SequenceSeg>();
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write(seg.Count);
		foreach (SequenceSeg item in seg)
		{
			item.Write(writer);
		}
	}

	internal void Read(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		seg = new List<SequenceSeg>();
		for (int i = 0; i < num; i++)
		{
			seg.Add(new SequenceSeg(reader));
		}
	}
}
