using System.IO;
using LootEdit;

namespace DialogEdit.dialog;

public class NodeOption
{
	public string[] text;

	public string action;

	public string coopAction;

	public NodeOption()
	{
		text = new string[13];
		for (int i = 0; i < text.Length; i++)
		{
			text[i] = "";
		}
		action = "";
		coopAction = "";
	}

	public NodeOption(NodeOption nodeOption)
	{
		text = new string[nodeOption.text.Length];
		for (int i = 0; i < text.Length; i++)
		{
			text[i] = nodeOption.text[i];
		}
		action = nodeOption.action;
		coopAction = nodeOption.coopAction;
	}

	internal void Write(BinaryWriter writer)
	{
		for (int i = 0; i < 13; i++)
		{
			if (i < text.Length)
			{
				writer.Write(text[i]);
			}
			else
			{
				writer.Write(text[0] + " - " + TranslationMgr.GetLangStrFromIdx(i));
			}
		}
		writer.Write(action);
		writer.Write(coopAction);
	}

	internal void Read(BinaryReader reader)
	{
		for (int i = 0; i < text.Length; i++)
		{
			text[i] = reader.ReadString();
		}
		action = reader.ReadString();
		coopAction = reader.ReadString();
	}
}
