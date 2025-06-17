using System.Collections.Generic;
using System.IO;
using LootEdit;

namespace DialogEdit.dialog;

public class DialogMgr
{
	public static List<NPCDialog> dialogList;

	public static bool locStringsLoaded;

	public static List<LocPair> locStrings;

	public static void Init()
	{
		dialogList = new List<NPCDialog>();
		locStrings = new List<LocPair>();
	}

	public static void Write(BinaryWriter writer)
	{
		writer.Write(dialogList.Count);
		foreach (NPCDialog dialog in dialogList)
		{
			dialog.Write(writer);
		}
	}

	public static void ReadLocText(BinaryReader reader)
	{
		locStrings = new List<LocPair>();
		int num = reader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			LocPair locPair = new LocPair(reader.ReadString());
			for (int j = 0; j < 13; j++)
			{
				locPair.locStr[j] = reader.ReadString();
			}
			locStrings.Add(locPair);
		}
	}

	public static void WriteLocText(BinaryWriter writer)
	{
		writer.Write(locStrings.Count);
		foreach (LocPair locString in locStrings)
		{
			writer.Write(locString.orig);
			for (int i = 0; i < 13; i++)
			{
				if (i < locString.locStr.Length)
				{
					writer.Write((locString.locStr[i] == null) ? "" : locString.locStr[i]);
				}
				else
				{
					writer.Write(locString.locStr[0] + " - " + TranslationMgr.GetLangStrFromIdx(i));
				}
			}
		}
	}

	public static void Read(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		dialogList = new List<NPCDialog>();
		for (int i = 0; i < num; i++)
		{
			NPCDialog nPCDialog = new NPCDialog();
			nPCDialog.Read(reader);
			dialogList.Add(nPCDialog);
		}
	}
}
