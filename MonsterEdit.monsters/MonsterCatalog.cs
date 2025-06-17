using System.Collections.Generic;
using System.IO;
using ProjectTower.io;

namespace MonsterEdit.monsters;

public class MonsterCatalog
{
	public static List<MonsterDef> catalog;

	public static void Init()
	{
		catalog = new List<MonsterDef>();
	}

	internal static void Write(BinaryWriter writer)
	{
		writer.Write(catalog.Count);
		for (int i = 0; i < catalog.Count; i++)
		{
			catalog[i].Write(writer);
		}
	}

	internal static void Read(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		catalog = new List<MonsterDef>();
		for (int i = 0; i < num; i++)
		{
			catalog.Add(new MonsterDef(reader));
		}
	}

	public static void ReadMaster()
	{
		FileMgr.Open("monsters/monsters.zox");
		Read(FileMgr.reader);
		FileMgr.Close();
	}
}
