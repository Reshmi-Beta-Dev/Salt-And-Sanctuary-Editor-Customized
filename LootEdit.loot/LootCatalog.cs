using System.Collections.Generic;
using System.IO;
using ProjectTower.io;

namespace LootEdit.loot;

public class LootCatalog
{
	public const int CATEGORY_WEAPON = 0;

	public const int CATEGORY_SHIELD = 1;

	public const int CATEGORY_ARMOR = 2;

	public const int CATEGORY_RING = 3;

	public const int CATEGORY_CONSUMABLE = 4;

	public const int CATEGORY_MAGIC = 5;

	public const int CATEGORY_KEYS = 6;

	public const int CATEGORY_MATERIALS = 7;

	public const int TOTAL_CATEGORIES = 8;

	public static LootCategory[] category;

	public static void Init()
	{
		category = new LootCategory[8];
		for (int i = 0; i < category.Length; i++)
		{
			category[i] = new LootCategory();
		}
	}

	public static void Write(BinaryWriter writer)
	{
		for (int i = 0; i < category.Length; i++)
		{
			category[i].Write(writer);
		}
	}

	public static void Read(BinaryReader reader)
	{
		for (int i = 0; i < category.Length; i++)
		{
			category[i].Read(reader);
		}
	}

	public static void ReadMaster()
	{
		FileMgr.Open("loot/loot.zlx");
		Read(FileMgr.reader);
		FileMgr.Close();
	}

	internal static int[] GetCategories(string[] loot)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < loot.Length; i++)
		{
			LootDef lootDef = null;
			for (int j = 0; j < category.Length; j++)
			{
				for (int k = 0; k < category[j].loot.Count; k++)
				{
					if (category[j].loot[k].name == loot[i])
					{
						lootDef = category[j].loot[k];
					}
				}
			}
			if (lootDef != null && !list.Contains(lootDef.category))
			{
				list.Add(lootDef.category);
			}
		}
		return list.ToArray();
	}
}
