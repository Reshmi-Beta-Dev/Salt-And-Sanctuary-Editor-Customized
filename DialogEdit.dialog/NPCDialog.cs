using System.Collections.Generic;
using System.IO;

namespace DialogEdit.dialog;

public class NPCDialog
{
	public string name;

	public List<DialogNode> nodeList;

	public int rune;

	public NPCDialog()
	{
		name = "New NPC";
		nodeList = new List<DialogNode>();
	}

	public NPCDialog(NPCDialog npcd)
	{
		name = npcd.name;
		nodeList = new List<DialogNode>();
		DialogNode[] array = npcd.nodeList.ToArray();
		foreach (DialogNode dialogNode in array)
		{
			nodeList.Add(new DialogNode(dialogNode));
		}
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write(name);
		writer.Write(nodeList.Count);
		foreach (DialogNode node in nodeList)
		{
			node.Write(writer);
		}
	}

	internal void Read(BinaryReader reader)
	{
		name = reader.ReadString();
		rune = -1;
		int num = reader.ReadInt32();
		nodeList = new List<DialogNode>();
		for (int i = 0; i < num; i++)
		{
			DialogNode dialogNode = new DialogNode();
			dialogNode.Read(reader);
			nodeList.Add(dialogNode);
		}
	}
}
