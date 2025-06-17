using System.Collections.Generic;
using System.IO;

namespace MapEdit.map.sequence;

public class SequenceMgr
{
	public List<Sequence> sequences;

	private Dictionary<int, List<int>> affectedSegs;

	public SequenceMgr()
	{
		sequences = new List<Sequence>();
	}

	internal void Add(Sequence seq)
	{
		sequences.Add(seq);
	}

	internal void MoveCols(int mx, int my)
	{
		foreach (Sequence sequence in sequences)
		{
			sequence.MoveCols(mx, my);
		}
	}

	internal void UpdateAffectedSegs()
	{
		affectedSegs = new Dictionary<int, List<int>>();
		for (int i = 0; i < sequences.Count; i++)
		{
			sequences[i].GetAffectedSegs(i, affectedSegs);
		}
	}

	internal void Draw(int selSeg)
	{
		sequences[selSeg].Draw();
	}

	internal void Swap(int layer, int segIdx, int oldID, int newID)
	{
	}

	internal void Swap(int selLayer, int i, int j)
	{
		if (!affectedSegs.ContainsKey(selLayer) || (!affectedSegs[selLayer].Contains(i) && !affectedSegs[selLayer].Contains(j)))
		{
			return;
		}
		int num = affectedSegs[selLayer].IndexOf(i);
		int num2 = affectedSegs[selLayer].IndexOf(j);
		if (num > -1 && num2 > -1)
		{
			affectedSegs[selLayer][num] = j;
			affectedSegs[selLayer][num2] = i;
		}
		else if (num > -1)
		{
			affectedSegs[selLayer][num] = j;
		}
		else if (num2 > -1)
		{
			affectedSegs[selLayer][num2] = i;
		}
		foreach (Sequence sequence in sequences)
		{
			sequence.Swap(selLayer, i, j);
		}
	}

	internal void Delete(int selLayer, int i)
	{
		if (affectedSegs.ContainsKey(selLayer))
		{
			foreach (Sequence sequence in sequences)
			{
				sequence.Delete(selLayer, i);
			}
		}
		UpdateAffectedSegs();
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write(sequences.Count);
		for (int i = 0; i < sequences.Count; i++)
		{
			sequences[i].Write(writer);
		}
	}

	internal void Read(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		sequences = new List<Sequence>();
		for (int i = 0; i < num; i++)
		{
			Sequence sequence = new Sequence();
			sequence.Read(reader);
			sequences.Add(sequence);
		}
	}

	internal void Reset()
	{
	}

	internal void Fire(string trigger)
	{
	}
}
