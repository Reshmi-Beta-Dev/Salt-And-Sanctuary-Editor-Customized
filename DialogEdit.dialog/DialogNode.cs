using System.IO;
using LootEdit;

namespace DialogEdit.dialog;

public class DialogNode
{
	public string name;

	public string[] text;

	public NodeOption[] option;

	public string[] precheckFlagStr;

	public string[] precheckFlagGoto;

	private const int TOTAL_PRECHECKS = 4;

	public string postSetFlagStr;

	public string postGoto;

	public const int TOTAL_NODE_OPTIONS = 5;

	public string giveScript;

	public string storeScript;

	public DialogNode()
	{
		name = "New Node";
		text = new string[13];
		for (int i = 0; i < 13; i++)
		{
			text[i] = "";
		}
		option = new NodeOption[5];
		for (int j = 0; j < 5; j++)
		{
			option[j] = new NodeOption();
		}
		precheckFlagStr = new string[4];
		precheckFlagGoto = new string[4];
		for (int k = 0; k < 4; k++)
		{
			precheckFlagStr[k] = "";
			precheckFlagGoto[k] = "";
		}
		postSetFlagStr = "";
		postGoto = "";
		storeScript = "";
		giveScript = "";
	}

	public DialogNode(DialogNode dialogNode)
	{
		name = dialogNode.name;
		text = new string[dialogNode.text.Length];
		for (int i = 0; i < text.Length; i++)
		{
			text[i] = dialogNode.text[i];
		}
		option = new NodeOption[5];
		for (int j = 0; j < 5; j++)
		{
			option[j] = new NodeOption(dialogNode.option[j]);
		}
		precheckFlagStr = new string[dialogNode.precheckFlagStr.Length];
		precheckFlagGoto = new string[dialogNode.precheckFlagGoto.Length];
		for (int k = 0; k < 4; k++)
		{
			precheckFlagStr[k] = dialogNode.precheckFlagStr[k];
			precheckFlagGoto[k] = dialogNode.precheckFlagGoto[k];
		}
		postSetFlagStr = dialogNode.postSetFlagStr;
		postGoto = dialogNode.postGoto;
		giveScript = dialogNode.giveScript;
		storeScript = dialogNode.storeScript;
	}

	internal void Write(BinaryWriter writer)
	{
		writer.Write(name);
		for (int i = 0; i < 13; i++)
		{
			if (i < text.Length)
			{
				writer.Write(text[i]);
			}
			else
			{
				writer.Write("Untranslated text: " + TranslationMgr.GetLangStrFromIdx(i));
			}
		}
		for (int j = 0; j < 5; j++)
		{
			option[j].Write(writer);
		}
		for (int k = 0; k < 4; k++)
		{
			writer.Write(precheckFlagStr[k]);
			writer.Write(precheckFlagGoto[k]);
		}
		writer.Write(postSetFlagStr);
		writer.Write(postGoto);
		writer.Write(giveScript);
		writer.Write(storeScript);
	}

	internal void Read(BinaryReader reader)
	{
		name = reader.ReadString();
		for (int i = 0; i < text.Length; i++)
		{
			text[i] = reader.ReadString();
		}
		for (int j = 0; j < 5; j++)
		{
			option[j].Read(reader);
		}
		for (int k = 0; k < 4; k++)
		{
			precheckFlagStr[k] = reader.ReadString();
			precheckFlagGoto[k] = reader.ReadString();
		}
		postSetFlagStr = reader.ReadString();
		postGoto = reader.ReadString();
		giveScript = reader.ReadString();
		storeScript = reader.ReadString();
	}
}
