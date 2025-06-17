using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SheetEdit.TextureSheet;

namespace MapEdit;

public class MapCellTreeManager
{
	public class NodeData
	{
		public const int TYPE_FILE = 0;

		public const int TYPE_FOLDER = 1;

		public const int IMG_FILE = 0;

		public const int IMG_FOLDER_OPEN = 1;

		public const int IMG_FOLDER_CLOSED = 2;

		public const int IMG_SHORTCUT = 3;

		public int itemIdx;

		public int type;

		public NodeData(int type, int itemIdx)
		{
			this.type = type;
			this.itemIdx = itemIdx;
		}

		public NodeData(BinaryReader reader)
		{
			Read(reader);
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(type);
			writer.Write(itemIdx);
		}

		public void Read(BinaryReader reader)
		{
			type = reader.ReadInt32();
			itemIdx = reader.ReadInt32();
		}
	}

	public static int GetNodeIdx(TreeNode node)
	{
		return (node.Tag as NodeData).itemIdx;
	}

	public static int GetNodeType(TreeNode node)
	{
		return (node.Tag as NodeData).type;
	}

	public static TreeNode ReadCellNodes(BinaryReader reader)
	{
		return ReadCellNode(reader);
	}

	private static TreeNode ReadCellNode(BinaryReader reader)
	{
		TreeNode treeNode = new TreeNode();
		treeNode.Text = reader.ReadString();
		NodeData tag = new NodeData(reader);
		treeNode.Tag = tag;
		int num = reader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			TreeNode node = ReadCellNode(reader);
			treeNode.Nodes.Add(node);
		}
		SetNodeImage(treeNode);
		return treeNode;
	}

	private static void SetNodeImage(TreeNode node)
	{
		node.ImageIndex = (((node.Tag as NodeData).type == 1) ? (node.IsExpanded ? 1 : 2) : 0);
		node.SelectedImageIndex = node.ImageIndex;
	}

	public static void SetTreeImages(TreeView trv)
	{
		trv.ImageList = new ImageList();
		trv.ImageList.Images.Add(Icon.ExtractAssociatedIcon("./icons/document.ico").ToBitmap());
		trv.ImageList.Images.Add(Icon.ExtractAssociatedIcon("./icons/folder_open.ico").ToBitmap());
		trv.ImageList.Images.Add(Icon.ExtractAssociatedIcon("./icons/folder_closed.ico").ToBitmap());
		trv.ImageList.Images.Add(Icon.ExtractAssociatedIcon("./icons/shortcut.ico").ToBitmap());
	}

	public static TreeNode CreateCellTree(XTexture xTex)
	{
		TreeNode treeNode = new TreeNode("Cells");
		treeNode.Tag = new NodeData(1, -1);
		SetNodeImage(treeNode);
		if (xTex != null)
		{
			for (int i = 0; i < xTex.cell.Length; i++)
			{
				XSprite xSprite = xTex.cell[i];
				if (xSprite.name != "")
				{
					TreeNode treeNode2 = new TreeNode(xSprite.name);
					treeNode2.Tag = new NodeData(0, i);
					SetNodeImage(treeNode2);
					treeNode.Nodes.Add(treeNode2);
				}
			}
		}
		return treeNode;
	}
}
