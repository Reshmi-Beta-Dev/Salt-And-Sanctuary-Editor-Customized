using System.Collections.Generic;
using System.IO;

namespace LootEdit.loot;

public class LootCategory
{
	public List<LootDef> loot;

	public LootCategory()
	{
		loot = new List<LootDef>();
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write(loot.Count);
		for (int i = 0; i < loot.Count; i++)
		{
			loot[i].Write(writer);
		}
	}

	internal void Read(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		loot.Clear();
		for (int i = 0; i < num; i++)
		{
			LootDef lootDef = new LootDef();
			lootDef.Read(reader);
			loot.Add(lootDef);
		}
	}
}
