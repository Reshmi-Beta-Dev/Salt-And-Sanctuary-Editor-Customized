using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DialogEdit.dialog;
using LootEdit;
using LootEdit.loot;
using MapEdit.map;
using MapEdit.map.sequence;
using Microsoft.Xna.Framework;
using MonsterEdit.monsters;
using ProjectTower.map;
using SheetEdit.TextureSheet;
using xCharEdit.Character;

namespace MapEdit;

public class GUI : Form
{
	public string fullPath;

	public bool paletteHover;

	private System.Drawing.Point paletteClickPoint;

	public bool paletteScrolling;

	private LayerTintEdit lte;

	private IContainer components;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem fileToolStripMenuItem;

	private ToolStripMenuItem mnuFileNew;

	private ToolStripMenuItem mnuFileOpen;

	private ToolStripMenuItem mnuFileSave;

	private ToolStripMenuItem mnuFileSaveAs;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripMenuItem mnuFileQuit;

	private ListBox lstSheets;

	private Label lblSheetsOrEntities;

	private ListBox lstCells;

	private ListBox lstMapCells;

	private ComboBox cmbLayer;

	private Label label4;

	private ToolStripMenuItem toolsToolStripMenuItem;

	private Label lblSegFlags;

	private ComboBox cmbSegFlags;

	private ToolStripMenuItem sequenceToolStripMenuItem;

	private ToolStripMenuItem mnuBeginRecording;

	private ToolStripMenuItem mnuFinalizeRecording;

	private ToolStripMenuItem mnuCancelRecording;

	private ToolStripMenuItem newToolStripMenuItem;

	private TextBox txtCellName;

	private ToolStripMenuItem recordSnapshotToolStripMenuItem;

	private ComboBox cmbLoot;

	private Label label5;

	private PictureBox pctSurface;

	private TextBox txtConsole;

	private ToolStripMenuItem filterToolStripMenuItem;

	private ToolStripMenuItem allToolStripMenuItem;

	private ToolStripMenuItem ringsToolStripMenuItem;

	private ToolStripMenuItem charmsToolStripMenuItem;

	private ToolStripMenuItem spellsToolStripMenuItem;

	private ToolStripMenuItem armorToolStripMenuItem;

	private ToolStripMenuItem weaponsToolStripMenuItem;

	private ToolStripMenuItem shieldsToolStripMenuItem;

	private ToolStripMenuItem materialsToolStripMenuItem;

	private RichTextBox txtRScript;

	private ToolStripMenuItem flagsToolStripMenuItem;

	private ToolStripMenuItem highlightLayerToolStripMenuItem;

	private ToolStripMenuItem showCollisionMapToolStripMenuItem;

	private ToolStripMenuItem drawLightToolStripMenuItem;

	private ToolStripMenuItem showSequencesToolStripMenuItem;

	private ToolStripMenuItem showMapGridToolStripMenuItem;

	private ToolStripMenuItem showBossBoundsToolStripMenuItem;

	private ToolStripMenuItem hideInactiveLayersMenuItem;

    private Panel pnlCells;

	private PictureBox pctCells;

	private TextBox txtPaletteHover;

	private ToolStripMenuItem hacksToolStripMenuItem;

	private ToolStripMenuItem batchProcessToolStripMenuItem1;

	private ToolStripMenuItem cleanDuplicatesToolStripMenuItem;

	private ToolStripMenuItem fixFogToolStripMenuItem2;

	private ToolStripMenuItem makeMinimapToolStripMenuItem1;

	private ToolStripMenuItem flipModeToolStripMenuItem1;

	private ToolStripMenuItem launchDialogEditToolStripMenuItem1;

	private ToolStripMenuItem brandModeToolStripMenuItem1;

	private ToolStripMenuItem findProgressionFlagToolStripMenuItem;

	private ToolStripMenuItem nudgeColToolStripMenuItem1;

	private ToolStripMenuItem upToolStripMenuItem1;

	private ToolStripMenuItem layerTintEditToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator2;

	private TreeView trvCells;

	private ToolStripSeparator toolStripSeparator3;

	private ToolStripMenuItem sendToBackToolStripMenuItem;

	private ToolStripMenuItem bringToFrontToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator4;

	private ToolStripMenuItem gridDuplicateToolStripMenuItem;

	private ToolStripMenuItem nWToolStripMenuItem;

	private ToolStripMenuItem nToolStripMenuItem;

	private ToolStripMenuItem nEToolStripMenuItem;

	private ToolStripMenuItem wToolStripMenuItem;

	private ToolStripMenuItem eToolStripMenuItem;

	private ToolStripMenuItem sWToolStripMenuItem;

	private ToolStripMenuItem sToolStripMenuItem;

	private ToolStripMenuItem sEToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator5;

	private ToolStripMenuItem fixedResizeToolStripMenuItem;

	private ToolStripMenuItem xToolStripMenuItem;

	private ToolStripMenuItem toolStripMenuItem2;

	private ToolStripMenuItem flipHorizontalToolStripMenuItem;

	private ToolStripMenuItem sepiaToolStripMenuItem;

	private ToolStripMenuItem noSepiaToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator6;

	private ToolStripMenuItem toggleCellPaletteToolStripMenuItem;

	private ToolStripMenuItem showBloomTexturesToolStripMenuItem;

	private ToolStripMenuItem rotateToolStripMenuItem;

	private ToolStripMenuItem cCWToolStripMenuItem;

	private ToolStripMenuItem cWToolStripMenuItem;

	[DllImport("user32.dll")]
	public static extern bool LockWindowUpdate(IntPtr hWndLock);

	public GUI()
	{
		InitializeComponent();
	}

	public IntPtr getDrawSurface()
	{
		return pctSurface.Handle;
	}

	public void Initialize()
	{
		PopulateSheets();
		for (int i = 0; i < LootCatalog.category.Length; i++)
		{
			LootCategory lootCategory = LootCatalog.category[i];
			for (int j = 0; j < lootCategory.loot.Count; j++)
			{
				cmbLoot.Items.Add(lootCategory.loot[j].name);
			}
		}
		lte = new LayerTintEdit();
		string path = "../../../../../../maps/layertint.zlt";
		if (File.Exists(path))
		{
			BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read));
			LayerTintCatalog.Read(binaryReader);
			binaryReader.Close();
			lte.LayerTintDataLoaded(path);
		}
	}

	public void ConsoleWriteLine(string s)
	{
		txtConsole.AppendText("\r\n" + s);
	}

	private void GUI_Load(object sender, EventArgs e)
	{
		allToolStripMenuItem.Checked = true;
		cmbLayer.Items.Add("Back5");
		cmbLayer.Items.Add("Back4");
		cmbLayer.Items.Add("Back3");
		cmbLayer.Items.Add("Back2");
		cmbLayer.Items.Add("Back1");
		cmbLayer.Items.Add("Mid");
		cmbLayer.Items.Add("Fore1");
		cmbLayer.Items.Add("Fore2");
		cmbLayer.Items.Add("Fore3");
		cmbLayer.Items.Add("Fore4");
		cmbLayer.Items.Add("Fore5");
		cmbLayer.Items.Add("I_Back4");
		cmbLayer.Items.Add("I_Back3");
		cmbLayer.Items.Add("I_Back2");
		cmbLayer.Items.Add("I_Back1");
		cmbLayer.Items.Add("I_Mid");
		cmbLayer.Items.Add("I_Fore1");
		cmbLayer.Items.Add("I_Fore2");
		cmbLayer.Items.Add("I_Fore3");
		cmbLayer.Items.Add("Entities");
		cmbLayer.Items.Add("Col");
		cmbLayer.Items.Add("Layer");
		cmbLayer.Items.Add("Sequences");
		MapCellTreeManager.SetTreeImages(trvCells);
		lstMapCells.Enabled = false;
		base.MouseWheel += pctSurface_MouseWheel;
		Game1.drawLight = true;
		drawLightToolStripMenuItem.Checked = true;
		showBossBoundsToolStripMenuItem.Checked = true;
	}

	private void pctSurface_MouseWheel(object sender, MouseEventArgs e)
	{
		Game1.mouseWheel = e.Delta;
	}

	internal void SetPictureImage(Image bmp, int width, int height)
	{
		pctCells.Image = bmp;
		pctCells.Size = new Size(width, height);
	}

	internal bool IsPictureFocus()
	{
		return Form.ActiveForm == this;
	}

	internal Vector2 GetPictureVec()
	{
		if (pctSurface.IsDisposed)
		{
			return default(Vector2);
		}
		try
		{
			double num = pctSurface.PointToScreen(System.Drawing.Point.Empty).X;
			double num2 = pctSurface.PointToScreen(System.Drawing.Point.Empty).Y;
			return new Vector2((float)num, (float)num2);
		}
		catch
		{
		}
		return default(Vector2);
	}

	private void PopulateSheets()
	{
		lstSheets.Items.Clear();
		foreach (string key in Game1.textures.Keys)
		{
			XTexture xTexture = Game1.textures[key];
			if (xTexture.type == 2 || xTexture.type == 3 || xTexture.name == "smashables" || xTexture.name == "weapons")
			{
				lstSheets.Items.Add(key);
			}
		}
	}

	private void lstSheets_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstSheets.SelectedIndex > -1)
		{
			int selLayer = Game1.selLayer;
			if ((uint)(selLayer - 19) > 3u)
			{
				trvCells.Visible = true;
				txtRScript.Visible = false;
			}
			Game1.selTex = (string)lstSheets.Items[lstSheets.SelectedIndex];
			UpdateCellTree();
			Game1.needsPaletteDraw = true;
			lstCells.Items.Clear();
			for (int i = 0; i < Game1.textures[Game1.selTex].cell.Length && Game1.textures[Game1.selTex].cell[i] != null; i++)
			{
				lstCells.Items.Add(Game1.textures[Game1.selTex].cell[i].name);
			}
		}
	}

	private void lstCells_SelectedIndexChanged(object sender, EventArgs e)
	{
		Game1.selIdx = lstCells.SelectedIndex;
		if (Game1.selLayer == 20 || Game1.selLayer == 21)
		{
			Game1.selCol = lstCells.SelectedIndex;
		}
		if (!Game1.isCtrl)
		{
			return;
		}
		if (Game1.selLayer == 19)
		{
			if (Game1.selSeg > -1)
			{
				Layer layer = Game1.map.layer[Game1.selLayer];
				if (Game1.selSeg < layer.seg.Count)
				{
					layer.seg[Game1.selSeg].texture = MonsterCatalog.catalog[Game1.selIdx].name;
				}
			}
		}
		else if (Game1.selSeg > -1)
		{
			Layer layer2 = Game1.map.layer[Game1.selLayer];
			if (Game1.selSeg < layer2.seg.Count)
			{
				Seg seg = layer2.seg[Game1.selSeg];
				seg.texture = Game1.selTex;
				seg.idx = Game1.selIdx;
				seg.scaling = new Vector2(1f, 1f);
			}
		}
	}

	private void lstCells_DoubleClick(object sender, EventArgs e)
	{
		if (Game1.selLayer <= -1 || Game1.selLayer >= 20)
		{
			return;
		}
		Seg seg = new Seg();
		seg.idx = Game1.selIdx;
		seg.texture = Game1.selTex;
		seg.loc = ScrollManager.scroll;
		seg.scaling = new Vector2(1f, 1f);
		if (Game1.flipMode)
		{
			seg.rotation = 3.141593f;
		}
		if (Game1.selLayer == 19)
		{
			seg.texture = MonsterCatalog.catalog[Game1.selIdx].name;
		}
		else
		{
			try
			{
				if (Game1.textures[seg.texture].type == 3)
				{
					seg.strFlag = Game1.textures[seg.texture].cell[Game1.selIdx].name;
				}
			}
			catch
			{
				return;
			}
		}
		Game1.map.layer[Game1.selLayer].seg.Add(seg);
		Game1.map.mapGrid.needsUpdate = true;
		PopulateMapCells();
		if (Game1.selLayer == 19)
		{
			Game1.needsActorUpdate = true;
		}
	}

	public void PopulateMapCells()
	{
		lstMapCells.Items.Clear();
		if (Game1.selLayer == 22)
		{
			lstMapCells.Enabled = true;
			{
				foreach (Sequence sequence in Game1.map.sequenceMgr.sequences)
				{
					lstMapCells.Items.Add(sequence.name);
				}
				return;
			}
		}
		lstMapCells.Enabled = false;
		if (!lstMapCells.Enabled || Game1.selLayer <= -1 || Game1.selLayer >= 20)
		{
			return;
		}
		if (Game1.selLayer == 19)
		{
			foreach (Seg item in Game1.map.layer[Game1.selLayer].seg)
			{
				lstMapCells.Items.Add(item.texture);
			}
			return;
		}
		foreach (Seg item2 in Game1.map.layer[Game1.selLayer].seg)
		{
			lstMapCells.Items.Add(Game1.textures[item2.texture].cell[item2.idx].name);
		}
	}
    // Layers = 0 - 18, Entities = 19, Collision = 20, Layer Tint = 21, Sequences = 22
    private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
	{
		Game1.selLayer = cmbLayer.SelectedIndex;
		bool flag = true;
		bool flag2 = false;
		switch (Game1.selLayer)
		{
		case 19:
		{
			lstCells.Items.Clear();
			for (int i = 0; i < MonsterCatalog.catalog.Count; i++)
			{
				lstCells.Items.Add(MonsterCatalog.catalog[i].name);
			}
			flag = false;
			break;
		}
		case 20:
			lstCells.Items.Clear();
			lstCells.Items.Add("COL_NONE");
			lstCells.Items.Add("COL_FULL");
			lstCells.Items.Add("COL_RISE");
			lstCells.Items.Add("COL_FALL");
			lstCells.Items.Add("COL_SPIKES");
			lstCells.Items.Add("COL_LEDGE");
			lstCells.Items.Add("COL_LEDGE_RISE");
			lstCells.Items.Add("COL_LEDGE_FALL");
			lstCells.Items.Add("COL_TRAPDOOR_RISE");
			lstCells.Items.Add("COL_TRAPDOOR_FALL");
			lstCells.Items.Add("COL_LADDER_RIGHT");
			lstCells.Items.Add("COL_LADDER_LEFT");
			lstCells.Items.Add("COL_PLAT_TOP_LIMIT");
			lstCells.Items.Add("COL_PLAT_BOTTOM_LIMIT");
			lstCells.Items.Add("COL_OBELISK_LIMIT");
			lstCells.Items.Add("COL_POISON");
			lstCells.Items.Add("COL_PIPE_UP");
			lstCells.Items.Add("COL_PIPE_DOWN");
			lstCells.Items.Add("COL_PIPE_RIGHT");
			lstCells.Items.Add("COL_PIPE_LEFT");
			Game1.selCol = 1;
			flag = false;
			break;
		case 21:
		{
			lstCells.Items.Clear();
			string[] layerNameArray = LayerTintCatalog.GetLayerNameArray();
			foreach (object item in layerNameArray)
			{
				try
				{
					lstCells.Items.Add(item);
				}
				catch
				{
				}
			}
			Game1.selCol = 0;
			flag = false;
			break;
		}
		case 22:
			flag2 = true;
			break;
		default:
			if (Game1.selLayer < 20)
			{
				flag = true;
			}
			break;
		}
		if (flag2)
		{
			txtCellName.Visible = true;
			lstMapCells.Visible = true;
			lstMapCells.Size = new Size(lstMapCells.Size.Width, pnlCells.Bottom - lstMapCells.Top);
			pnlCells.Visible = false;
			lstSheets.Visible = false;
			lstCells.Visible = false;
			trvCells.Visible = false;
			txtRScript.Visible = true;
			trvCells.Visible = false;
		}
		else if (flag)
		{
			txtCellName.Visible = false;
			lstMapCells.Visible = false;
			lstSheets.Visible = true;
			pnlCells.Visible = true;
			lstCells.Visible = false;
			lblSheetsOrEntities.Text = "Sheets";
			trvCells.Visible = true;
			trvCells.Location = new System.Drawing.Point(txtRScript.Location.X, txtRScript.Location.Y);
			TreeView treeView = trvCells;
			int num = txtRScript.Size.Width;
			int num2 = txtRScript.Size.Height;
			Size size = new Size(num, num2);
			treeView.Size = size;
			txtRScript.Visible = false;
		}
		else
		{
			txtCellName.Visible = false;
			lstMapCells.Visible = false;
			pnlCells.Visible = false;
			lstSheets.Visible = false;
			lstCells.Location = lstSheets.Location;
			lstCells.Size = new Size(lstSheets.Size.Width, pnlCells.Bottom - lstSheets.Top);
			lstCells.Visible = true;
			lblSheetsOrEntities.Text = "Cells";
			txtRScript.Visible = true;
			trvCells.Visible = false;
		}
		PopulateMapCells();
	}

	private void mnuFileSaveAs_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "Zka Map Extension|*.zax";
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			string text = (fullPath = saveFileDialog.FileName);
			string[] array = text.Split('\\');
			string text2 = array[array.Length - 1];
			if (text2.Substring(text2.Length - 4).ToLower() == ".zax")
			{
				text2.Substring(0, text2.Length - 4);
			}
			mnuFileSave.Enabled = true;
			Game1.map.Write(text, Game1.textures);
			Game1.title = "MapEdit - " + Path.GetFileNameWithoutExtension(fullPath);
		}
	}

	public void UpdateCellTree()
	{
		Game1.selPaletteNode = null;
		trvCells.BeginUpdate();
		trvCells.Nodes.Clear();
		AddCellTreeNodes(Game1.selTex, Game1.selTex);
		trvCells.EndUpdate();
	}

	private void AddCellTreeNodes(string name, string texture)
	{
		if (name != null && texture != null && Game1.nodes.ContainsKey(texture))
		{
			TreeNode treeNode = Game1.nodes[texture].Clone() as TreeNode;
			PruneTree(treeNode);
			treeNode.Text = name;
			trvCells.Nodes.Add(treeNode);
		}
	}

	private void PruneTree(TreeNode viewableNode)
	{
		bool flag;
		do
		{
			flag = false;
			foreach (TreeNode node in viewableNode.Nodes)
			{
				if (node.Nodes.Count == 0)
				{
					flag = true;
					node.Remove();
					break;
				}
			}
		}
		while (flag);
		foreach (TreeNode node2 in viewableNode.Nodes)
		{
			PruneTree(node2);
		}
	}

	public string GetPath()
	{
		string[] array = Directory.GetCurrentDirectory().Split('\\');
		string text = "";
		for (int i = 0; i < array.Length - 6; i++)
		{
			text = text + array[i] + "\\";
		}
		return text + "maps\\";
	}

	private void mnuFileOpen_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Zka Map Extension|*.zax";
		string path = GetPath();
		if (Directory.Exists(path))
		{
			openFileDialog.InitialDirectory = path;
		}
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		string text = (fullPath = openFileDialog.FileName);
		string[] array = text.Split('\\');
		string text2 = array[array.Length - 1];
		if (text2.Substring(text2.Length - 4).ToLower() == ".zax")
		{
			text2.Substring(0, text2.Length - 4);
		}
		mnuFileSave.Enabled = true;
		Game1.map.Read(text);
		Game1.needsActorUpdate = true;
		Game1.title = "MapEdit - " + Path.GetFileNameWithoutExtension(fullPath);
		ScrollManager.scroll = new Vector2((float)((double)Game1.map.xUnits * 64.0 * 0.5), (float)((double)Game1.map.yUnits * 64.0 * 0.25));
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < Game1.map.layer.Length; i++)
		{
			Layer layer = Game1.map.layer[i];
			if (layer.seg != null)
			{
				num += layer.seg.Count;
			}
		}
		int num3 = Game1.map.xUnits * Game1.map.yUnits;
		for (int j = 0; j < Game1.map.xUnits; j++)
		{
			for (int k = 0; k < Game1.map.yUnits; k++)
			{
				if (Game1.map.col[j, k].col != 0)
				{
					num2++;
				}
			}
		}
		ConsoleWriteLine("World size: " + Game1.map.xUnits + ", " + Game1.map.yUnits + " (" + num3 + " tiles)");
		ConsoleWriteLine("Segs: " + num);
		ConsoleWriteLine("Collision Tiles: " + num2);
	}

	private void mnuFileSave_Click(object sender, EventArgs e)
	{
		Game1.map.Write(fullPath, Game1.textures);
		string[] array = fullPath.Split('\\');
		string text = array[array.Length - 1];
		string text2 = fullPath.Substring(0, fullPath.Length - text.Length);
		string text3 = text.Substring(0, text.Length - 4);
		if (!Directory.Exists(text2 + "bak\\"))
		{
			Directory.CreateDirectory(text2 + "bak\\");
		}
		string path = text2 + "bak\\" + text3 + "-" + DateTime.UtcNow.Ticks + ".zax";
		Game1.map.Write(path, Game1.textures);
		Game1.AnalyzeEntities();
		string path2 = text2 + "flaglist.txt";
		List<string> list = new List<string>();
		foreach (Seg item in Game1.map.layer[19].seg)
		{
			if (item.strFlag == null || !item.strFlag.Contains("boss"))
			{
				continue;
			}
			string[] array2 = item.strFlag.Split('\r');
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].Contains("boss"))
				{
					string[] array3 = array2[i].Split(' ');
					if (array3.Length > 1)
					{
						list.Add("Flag: " + array3[1]);
					}
				}
			}
		}
		File.WriteAllLines(path2, list.ToArray());
	}

	private void batchProcessToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void btnSwapUp_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer >= 19)
		{
			return;
		}
		Game1.map.sequenceMgr.UpdateAffectedSegs();
		if (Game1.selSeg > 0)
		{
			SwapSegs(Game1.selSeg - 1, Game1.selSeg);
			Game1.selSeg--;
			if (lstMapCells.Enabled)
			{
				lstMapCells.SelectedIndex = Game1.selSeg;
			}
		}
	}

	public void SwapSegs(int i, int j)
	{
		if (Game1.selLayer < 0)
		{
			return;
		}
		Layer layer = Game1.map.layer[Game1.selLayer];
		if (layer.seg[i] == null || layer.seg[j] == null || i < 0 || j > layer.seg.Count - 1)
		{
			return;
		}
		try
		{
			Seg seg = new Seg();
			seg.CopyFrom(layer.seg[i]);
			layer.seg[i].CopyFrom(layer.seg[j]);
			layer.seg[j].CopyFrom(seg);
			Game1.map.sequenceMgr.Swap(Game1.selLayer, i, j);
			if (lstMapCells.Enabled)
			{
				string value = lstMapCells.Items[i].ToString();
				lstMapCells.Items[i] = lstMapCells.Items[j].ToString();
				lstMapCells.Items[j] = value;
			}
		}
		catch
		{
		}
	}

	private void btnSwapDown_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer >= 19)
		{
			return;
		}
		_ = lstMapCells.Items.Count;
		int count = Game1.map.layer[Game1.selLayer].seg.Count;
		Game1.map.sequenceMgr.UpdateAffectedSegs();
		if (Game1.selSeg < count - 1)
		{
			SwapSegs(Game1.selSeg, Game1.selSeg + 1);
			Game1.selSeg++;
			if (lstMapCells.Enabled)
			{
				lstMapCells.SelectedIndex = Game1.selSeg;
			}
		}
	}

	private void lstMapCells_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstMapCells.Enabled)
		{
			Game1.selSeg = lstMapCells.SelectedIndex;
			if (Game1.selLayer == 22 && Game1.selSeg > -1 && Game1.selSeg < Game1.map.sequenceMgr.sequences.Count)
			{
				Sequence sequence = Game1.map.sequenceMgr.sequences[Game1.selSeg];
				if (sequence != null)
				{
					txtCellName.Text = sequence.name;
				}
			}
		}
		RefreshSegFlags();
	}

	private void RefreshSegFlags()
	{
		if (Game1.selLayer == 19)
		{
			Seg seg = Game1.map.layer[Game1.selLayer].seg[Game1.selSeg];
			if (seg.texture == "deadprop")
			{
				for (int i = 0; i < MonsterCatalog.catalog.Count; i++)
				{
					if (MonsterCatalog.catalog[i].name == "deadprop")
					{
						PopulateWithAnims(i);
					}
				}
			}
			else
			{
				for (int j = 0; j < MonsterCatalog.catalog.Count; j++)
				{
					if (MonsterCatalog.catalog[j].name == seg.texture && MonsterCatalog.catalog[j].type == 5)
					{
						PopulateWithAnims(j);
					}
				}
			}
		}
		if (Game1.selLayer > -1 && Game1.selLayer < 20 && Game1.selSeg > -1)
		{
			if (Game1.map.layer[Game1.selLayer].seg[Game1.selSeg] == null)
			{
				return;
			}
			if (Game1.selLayer != 19)
			{
				XTexture xTexture = Game1.textures[Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].texture];
				if (xTexture.type == 3)
				{
					Seg seg2 = Game1.map.layer[Game1.selLayer].seg[Game1.selSeg];
					XSprite xSprite = xTexture.cell[seg2.idx];
					CharDef charDef = Game1.charDef[xSprite.name];
					cmbSegFlags.Items.Clear();
					try
					{
						foreach (Animation item in charDef.animation)
						{
							if (item != null)
							{
								cmbSegFlags.Items.Add(item.name);
							}
						}
						cmbSegFlags.SelectedIndex = seg2.intFlag;
					}
					catch (Exception)
					{
					}
				}
				if (xTexture.type == 2)
				{
					Seg seg3 = Game1.map.layer[Game1.selLayer].seg[Game1.selSeg];
					switch (xTexture.cell[seg3.idx].flags)
					{
					case 11:
						cmbSegFlags.Items.Clear();
						cmbSegFlags.Items.Add("None");
						cmbSegFlags.Items.Add("Iron");
						cmbSegFlags.Items.Add("Cleric");
						cmbSegFlags.Items.Add("Three");
						cmbSegFlags.Items.Add("Woods");
						cmbSegFlags.Items.Add("Dark");
						cmbSegFlags.Items.Add("Splendor");
						cmbSegFlags.Items.Add("Fool");
						cmbSegFlags.Items.Add("Fire");
						cmbSegFlags.Items.Add("Bones");
						cmbSegFlags.SelectedIndex = seg3.intFlag;
						break;
					case 13:
					case 14:
					case 15:
					case 29:
					case 30:
						cmbSegFlags.Items.Clear();
						foreach (Sequence sequence2 in Game1.map.sequenceMgr.sequences)
						{
							cmbSegFlags.Items.Add(sequence2.name);
						}
						cmbSegFlags.SelectedIndex = seg3.intFlag;
						break;
					}
				}
			}
			if (Game1.selLayer == 19)
			{
				Seg seg4 = Game1.map.layer[Game1.selLayer].seg[Game1.selSeg];
				if (seg4.strFlag == null)
				{
					txtRScript.Clear();
				}
				else
				{
					txtRScript.Text = seg4.strFlag;
				}
			}
			else if (Game1.selLayer == 15 || Game1.selLayer == 5)
			{
				Seg seg5 = Game1.map.layer[Game1.selLayer].seg[Game1.selSeg];
				XTexture xTexture2 = Game1.textures[seg5.texture];
				if (xTexture2.type == 2)
				{
					switch (xTexture2.cell[seg5.idx].flags)
					{
					case 9:
					case 10:
					case 11:
					case 13:
					case 14:
					case 15:
					case 22:
					case 29:
					case 30:
						if (seg5.strFlag == null)
						{
							txtRScript.Clear();
						}
						else
						{
							txtRScript.Text = seg5.strFlag;
						}
						break;
					}
				}
			}
		}
		if (Game1.selLayer != 22 || Game1.selSeg <= -1 || Game1.selSeg >= Game1.map.sequenceMgr.sequences.Count)
		{
			return;
		}
		Sequence sequence = Game1.map.sequenceMgr.sequences[Game1.selSeg];
		if (sequence.script != null)
		{
			string[] array = new string[sequence.script.Count];
			for (int k = 0; k < sequence.script.Count; k++)
			{
				array[k] = sequence.script[k];
			}
			txtRScript.Lines = array;
		}
		else
		{
			txtRScript.Clear();
		}
	}

	private void PopulateWithAnims(int i)
	{
		MonsterDef monsterDef = MonsterCatalog.catalog[i];
		CharDef charDef = Game1.charDef[monsterDef.def];
		cmbSegFlags.Items.Clear();
		foreach (Animation item in charDef.animation)
		{
			cmbSegFlags.Items.Add(item.name);
		}
	}

	internal void UpdateSelSeg()
	{
		try
		{
			if (lstMapCells.Enabled)
			{
				lstMapCells.SelectedIndex = Game1.selSeg;
			}
			else
			{
				RefreshSegFlags();
			}
		}
		catch (Exception)
		{
		}
	}

	private void cmbSegFlags_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (Game1.selLayer <= -1 || Game1.selLayer >= 20 || Game1.selSeg <= -1)
		{
			return;
		}
		if (Game1.selLayer == 19)
		{
			Seg seg = Game1.map.layer[Game1.selLayer].seg[Game1.selSeg];
			if (seg.texture == "deadprop")
			{
				txtRScript.Text = "deadprop " + cmbSegFlags.Items[cmbSegFlags.SelectedIndex].ToString();
				return;
			}
			for (int i = 0; i < MonsterCatalog.catalog.Count; i++)
			{
				if (MonsterCatalog.catalog[i].name == seg.texture && MonsterCatalog.catalog[i].type == 5)
				{
					txtRScript.Text = "trap " + cmbSegFlags.Items[cmbSegFlags.SelectedIndex].ToString();
				}
			}
			return;
		}
		XTexture xTexture = Game1.textures[Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].texture];
		if (xTexture.type == 3)
		{
			Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].intFlag = cmbSegFlags.SelectedIndex;
		}
		if (xTexture.type == 2)
		{
			int flags = xTexture.cell[Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].idx].flags;
			if (flags == 11 || (uint)(flags - 13) <= 2u || (uint)(flags - 29) <= 1u)
			{
				Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].intFlag = cmbSegFlags.SelectedIndex;
			}
		}
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer > -1 && Game1.selLayer < 20 && Game1.selSeg > -1)
		{
			Game1.map.sequenceMgr.UpdateAffectedSegs();
			Game1.map.sequenceMgr.Delete(Game1.selLayer, Game1.selSeg);
			Game1.map.layer[Game1.selLayer].seg.Remove(Game1.map.layer[Game1.selLayer].seg[Game1.selSeg]);
			Game1.map.mapGrid.needsUpdate = true;
			Game1.needsActorUpdate = true;
		}
	}

	private void btnSendToBack_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer >= 19)
		{
			return;
		}
		Game1.map.sequenceMgr.UpdateAffectedSegs();
		while (Game1.selSeg > 0)
		{
			SwapSegs(Game1.selSeg, Game1.selSeg - 1);
			Game1.selSeg--;
			if (lstMapCells.Enabled)
			{
				lstMapCells.SelectedIndex = Game1.selSeg;
			}
		}
	}

	private void btnBringToFront_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer >= 19)
		{
			return;
		}
		_ = lstMapCells.Items.Count;
		int count = Game1.map.layer[Game1.selLayer].seg.Count;
		Game1.map.sequenceMgr.UpdateAffectedSegs();
		while (Game1.selSeg < count - 1)
		{
			SwapSegs(Game1.selSeg, Game1.selSeg + 1);
			Game1.selSeg++;
			if (lstMapCells.Enabled)
			{
				lstMapCells.SelectedIndex = Game1.selSeg;
			}
		}
	}

	private void upToolStripMenuItem_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < Game1.map.yUnits * 2 - 1; i++)
		{
			for (int j = 0; j < Game1.map.xUnits; j++)
			{
				Game1.map.col[j, i] = Game1.map.col[j, i + 1];
			}
		}
	}

	private void recordSequenceToolStripMenuItem_Click_1(object sender, EventArgs e)
	{
		if (Game1.selLayer == 22 && Game1.selSeg < Game1.map.sequenceMgr.sequences.Count && Game1.map.sequenceMgr.sequences[Game1.selSeg] != null)
		{
			Game1.InitSequenceRecord(Game1.selSeg);
		}
	}

	private void mnuCancelRecording_Click(object sender, EventArgs e)
	{
		Game1.recordSequenceMode = false;
	}

	private void mnuFinalizeRecording_Click(object sender, EventArgs e)
	{
		Game1.FinalizeSequenceRecord();
	}

	private void newToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Game1.selLayer = 22;
		Game1.map.sequenceMgr.Add(new Sequence
		{
			name = "New Sequence"
		});
		PopulateMapCells();
	}

	private void txtCellName_TextChanged(object sender, EventArgs e)
	{
		if (Game1.selLayer != 22 || Game1.selSeg >= Game1.map.sequenceMgr.sequences.Count)
		{
			return;
		}
		Sequence sequence = Game1.map.sequenceMgr.sequences[Game1.selSeg];
		if (sequence != null)
		{
			sequence.name = txtCellName.Text;
			if (Game1.selSeg > -1 && lstMapCells.Enabled)
			{
				lstMapCells.Items[Game1.selSeg] = txtCellName.Text;
			}
		}
	}

	private void recordSnapshotToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Game1.SetSequenceRecord();
	}

	private void cleanupDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void cmbLoot_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbLoot.SelectedIndex > -1)
		{
			txtRScript.AppendText(cmbLoot.Items[cmbLoot.SelectedIndex].ToString());
		}
	}

	private void fixFogToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void makeMinimapToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void GUI_FormClosed(object sender, FormClosedEventArgs e)
	{
		Game1.needsExit = true;
	}

	private void pctSurface_Click(object sender, EventArgs e)
	{
		pctSurface.Focus();
	}

	private void flipModeToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void allToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SetFilterChecks(0);
	}

	private void ringsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SetFilterChecks(1);
	}

	private void charmsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SetFilterChecks(2);
	}

	private void spellsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SetFilterChecks(3);
	}

	private void armorToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SetFilterChecks(4);
	}

	private void weaponsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SetFilterChecks(5);
	}

	private void shieldsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SetFilterChecks(6);
	}

	private void materialsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SetFilterChecks(7);
	}

	private void SetFilterChecks(int filter)
	{
		Game1.filter = filter;
		allToolStripMenuItem.Checked = Game1.filter == 0;
		ringsToolStripMenuItem.Checked = Game1.filter == 1;
		charmsToolStripMenuItem.Checked = Game1.filter == 2;
		spellsToolStripMenuItem.Checked = Game1.filter == 3;
		armorToolStripMenuItem.Checked = Game1.filter == 4;
		weaponsToolStripMenuItem.Checked = Game1.filter == 5;
		shieldsToolStripMenuItem.Checked = Game1.filter == 6;
		materialsToolStripMenuItem.Checked = Game1.filter == 7;
	}

	private void launchDialogEditToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void brandModeToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void fixFogToolStripMenuItem1_Click(object sender, EventArgs e)
	{
	}

	private void findProgressionFlagsToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void txtRScript_TextChanged(object sender, EventArgs e)
	{
		try
		{
			txtRScript.SuspendLayout();
			int selectionStart = txtRScript.SelectionStart;
			int selectionLength = txtRScript.SelectionLength;
			txtRScript.SelectionStart = 0;
			txtRScript.SelectionLength = txtRScript.Text.Length;
			txtRScript.SelectionColor = System.Drawing.Color.Black;
			txtRScript.SelectionFont = new Font(txtRScript.Font, FontStyle.Regular);
			List<string> list = new List<string>
			{
				"npcstyle", "brandfire", "disabledflag", "enabledflag", "boss", "flag", "trap", "deadin", "chest", "drop",
				"switch", "plat"
			};
			for (int i = 0; i < txtRScript.Text.Length; i++)
			{
				try
				{
					foreach (string item in list)
					{
						if (i <= txtRScript.Text.Length - item.Length && txtRScript.Text.Substring(i, item.Length) == item)
						{
							txtRScript.SelectionStart = i;
							txtRScript.SelectionLength = item.Length;
							txtRScript.SelectionColor = System.Drawing.Color.Teal;
						}
					}
				}
				catch
				{
				}
			}
			txtRScript.SelectionStart = selectionStart;
			txtRScript.SelectionLength = selectionLength;
		}
		finally
		{
			txtRScript.ResumeLayout();
		}
		string text = txtRScript.Text;
		if (!text.Contains('\r'))
		{
			text = text.Replace("\n", "\r\n");
		}
		if (Game1.selLayer == 19 && Game1.selSeg > -1 && Game1.selSeg < Game1.map.layer[Game1.selLayer].seg.Count)
		{
			Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].strFlag = text;
		}
		if (Game1.selLayer == 22 && Game1.selSeg > -1 && Game1.selSeg < Game1.map.sequenceMgr.sequences.Count)
		{
			Sequence sequence = Game1.map.sequenceMgr.sequences[Game1.selSeg];
			sequence.script = new List<string>();
			for (int j = 0; j < txtRScript.Lines.Length; j++)
			{
				sequence.script.Add(txtRScript.Lines[j]);
			}
		}
		if ((Game1.selLayer != 15 && Game1.selLayer != 5) || Game1.selSeg <= -1 || Game1.selSeg >= Game1.map.layer[Game1.selLayer].seg.Count)
		{
			return;
		}
		Seg seg = Game1.map.layer[Game1.selLayer].seg[Game1.selSeg];
		XTexture xTexture = Game1.textures[seg.texture];
		if (xTexture.type == 2)
		{
			switch (xTexture.cell[seg.idx].flags)
			{
			case 9:
			case 10:
			case 11:
			case 13:
			case 14:
			case 15:
			case 22:
			case 29:
			case 30:
				seg.strFlag = text;
				break;
			}
		}
	}

	private void highlightLayerToolStripMenuItem_Click(object sender, EventArgs e)
	{
		highlightLayerToolStripMenuItem.Checked = !highlightLayerToolStripMenuItem.Checked;
		Game1.highlightLayer = highlightLayerToolStripMenuItem.Checked;
	}

	private void showCollisionMapToolStripMenuItem_Click(object sender, EventArgs e)
	{
		showCollisionMapToolStripMenuItem.Checked = !showCollisionMapToolStripMenuItem.Checked;
		Game1.showColMap = showCollisionMapToolStripMenuItem.Checked;
	}

	private void drawLightToolStripMenuItem_Click(object sender, EventArgs e)
	{
		drawLightToolStripMenuItem.Checked = !drawLightToolStripMenuItem.Checked;
		Game1.drawLight = drawLightToolStripMenuItem.Checked;
	}

	private void showSequencesToolStripMenuItem_Click(object sender, EventArgs e)
	{
		showSequencesToolStripMenuItem.Checked = !showSequencesToolStripMenuItem.Checked;
		Game1.showSequences = showSequencesToolStripMenuItem.Checked;
	}

	private void showMapGridToolStripMenuItem_Click(object sender, EventArgs e)
	{
		showMapGridToolStripMenuItem.Checked = !showMapGridToolStripMenuItem.Checked;
		Game1.showMapGrid = showMapGridToolStripMenuItem.Checked;
	}

	private void showBossBoundsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		showBossBoundsToolStripMenuItem.Checked = !showBossBoundsToolStripMenuItem.Checked;
		Game1.hideBossBounds = !showBossBoundsToolStripMenuItem.Checked;
	}

    private void hideInactiveLayersMenuItem_Click(object sender, EventArgs e)
    {
        hideInactiveLayersMenuItem.Checked = !hideInactiveLayersMenuItem.Checked;
		Game1.hideInactiveLayers = hideInactiveLayersMenuItem.Checked;
    }

    private void pctCells_DoubleClick(object sender, EventArgs e)
	{
		if (Game1.selLayer <= -1 || Game1.selLayer >= 20)
		{
			return;
		}
		Seg seg = new Seg();
		seg.idx = Game1.selIdx;
		seg.texture = Game1.selTex;
		seg.loc = ScrollManager.scroll;
		seg.scaling = new Vector2(1f, 1f);
		if (Game1.flipMode)
		{
			seg.rotation = 3.141593f;
		}
		if (Game1.selLayer == 19)
		{
			seg.texture = MonsterCatalog.catalog[Game1.selIdx].name;
		}
		else
		{
			try
			{
				if (Game1.textures[seg.texture].type == 3)
				{
					seg.strFlag = Game1.textures[seg.texture].cell[Game1.selIdx].name;
				}
			}
			catch
			{
				return;
			}
		}
		Game1.map.layer[Game1.selLayer].seg.Add(seg);
		Game1.map.mapGrid.needsUpdate = true;
		PopulateMapCells();
		if (Game1.selLayer == 19)
		{
			Game1.needsActorUpdate = true;
		}
	}

	private void pctCells_MouseEnter(object sender, EventArgs e)
	{
		paletteHover = true;
	}

	private void pctCells_MouseLeave(object sender, EventArgs e)
	{
		paletteHover = false;
		txtPaletteHover.Visible = false;
	}

	private void pctCells_MouseMove(object sender, MouseEventArgs e)
	{
		if ((e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right) && paletteScrolling)
		{
			System.Drawing.Point position = Cursor.Position;
			int num = position.X - paletteClickPoint.X;
			int num2 = position.Y - paletteClickPoint.Y;
			if (num != 0 || num2 != 0)
			{
				int num3 = pnlCells.HorizontalScroll.Value - num;
				int num4 = pnlCells.VerticalScroll.Value - num2;
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num3 > pnlCells.HorizontalScroll.Maximum)
				{
					num3 = pnlCells.HorizontalScroll.Maximum;
				}
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num4 > pnlCells.VerticalScroll.Maximum)
				{
					num4 = pnlCells.VerticalScroll.Maximum;
				}
				pnlCells.HorizontalScroll.Value = num3;
				pnlCells.PerformLayout();
				pnlCells.VerticalScroll.Value = num4;
				pnlCells.PerformLayout();
				paletteClickPoint = position;
			}
			if (paletteHover)
			{
				txtPaletteHover.Visible = false;
			}
		}
		else
		{
			if (!paletteHover)
			{
				return;
			}
			string text = null;
			System.Drawing.Point location = e.Location;
			int num5 = location.Y / 56;
			int num6 = location.X / 56;
			XTexture xTexture = ((Game1.selTex != null) ? Game1.textures[Game1.selTex] : null);
			int num7 = num5 * 5 + num6;
			if (xTexture != null && num7 > -1 && num7 < Game1.paletteCellIdx.Count)
			{
				Game1.selIdx = Game1.paletteCellIdx[num7];
				text = xTexture.cell[Game1.selIdx].name;
			}
			if (text == null)
			{
				if (txtPaletteHover.Visible)
				{
					txtPaletteHover.Visible = false;
				}
				return;
			}
			if (!txtPaletteHover.Visible)
			{
				txtPaletteHover.Visible = true;
			}
			txtPaletteHover.Text = text;
			System.Drawing.Point position2 = Cursor.Position;
			int num8 = position2.X + 12;
			int num9 = position2.Y + 12;
			System.Drawing.Point p = new System.Drawing.Point(num8, num9);
			System.Drawing.Point location2 = PointToClient(p);
			if (location2.Y > pnlCells.Bottom - 37)
			{
				location2.Y = pnlCells.Bottom - 37;
			}
			if (location2.X > pnlCells.Right - 110)
			{
				location2.X = pnlCells.Right - 110;
			}
			txtPaletteHover.Location = location2;
			txtPaletteHover.Refresh();
			pctCells.Refresh();
			pnlCells.Refresh();
		}
	}

	private void pctCells_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right)
		{
			paletteClickPoint = Cursor.Position;
			paletteScrolling = true;
			Cursor.Current = Cursors.SizeAll;
		}
	}

	private void pctCells_MouseUp(object sender, MouseEventArgs e)
	{
		paletteScrolling = false;
		if (e.Button == MouseButtons.Right && Game1.selLayer < 19 && Game1.selSeg >= 0 && Game1.selLayer >= 0)
		{
			Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].idx = Game1.selIdx;
			Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].texture = Game1.selTex;
		}
	}

	private void pnlCells_MouseDoubleClick(object sender, MouseEventArgs e)
	{
	}

	private void batchProcessToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Zka Map Extension|*.zax";
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		string fileName = openFileDialog.FileName;
		string[] array = fileName.Split('\\');
		FileInfo[] files = new DirectoryInfo(fileName.Substring(0, fileName.Length - array[array.Length - 1].Length)).GetFiles();
		if (files == null || files.Length == 0)
		{
			return;
		}
		for (int i = 0; i < files.Length; i++)
		{
			if (files[i].Name.Substring(files[i].Name.Length - 3).ToLower() == "zax")
			{
				string text = (fullPath = files[i].FullName);
				Game1.map.Read(text);
				Game1.map.Write(text, Game1.textures);
				ConsoleWriteLine("Written " + text);
			}
		}
	}

	private void cleanDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Game1.CleanupDupes();
	}

	private void fixFogToolStripMenuItem2_Click(object sender, EventArgs e)
	{
		Layer[] layer = Game1.map.layer;
		for (int i = 0; i < layer.Length; i++)
		{
			foreach (Seg item in layer[i].seg)
			{
				if (item.idx > -1)
				{
					XTexture xTexture = Game1.textures[item.texture];
					if (xTexture.type == 2 && xTexture.cell[item.idx].flags == 8)
					{
						item.texture = "glows";
						item.idx = 0;
					}
				}
			}
		}
	}

	private void makeMinimapToolStripMenuItem1_Click(object sender, EventArgs e)
	{
	}

	private void flipModeToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		flipModeToolStripMenuItem1.Checked = !flipModeToolStripMenuItem1.Checked;
		Game1.flipMode = flipModeToolStripMenuItem1.Checked;
	}

	private void launchDialogEditToolStripMenuItem1_Click(object sender, EventArgs e)
	{
	}

	private void brandModeToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		brandModeToolStripMenuItem1.Checked = !brandModeToolStripMenuItem1.Checked;
		Game1.brandMode = brandModeToolStripMenuItem1.Checked;
	}

	private void fixFogToolStripMenuItem3_Click(object sender, EventArgs e)
	{
	}

	private void findProgressionFlagToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ConsoleWriteLine("-------------------");
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		foreach (Seg item2 in Game1.map.layer[19].seg)
		{
			if (item2.strFlag == null)
			{
				continue;
			}
			string[] array = item2.strFlag.Split('\n');
			string item = null;
			string text = null;
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = null;
				string[] array2 = array[i].Split(' ');
				for (int j = 0; j < array2.Length; j++)
				{
					if (text == null && array2[j] == "disabledflag" && j < array2.Length - 1)
					{
						string text3 = array2[j + 1];
						if (text3.EndsWith("\r"))
						{
							text3 = text3.Substring(0, text3.Length - 1);
						}
						text = text3;
					}
					if (text != null)
					{
						foreach (NPCDialog dialog in DialogMgr.dialogList)
						{
							if (!(dialog.name == item2.texture))
							{
								continue;
							}
							foreach (DialogNode node in dialog.nodeList)
							{
								if (node.giveScript == null || !(node.giveScript != ""))
								{
									continue;
								}
								string giveScript = node.giveScript;
								string[] separator = new string[1] { "\r\n" };
								string[] array3 = giveScript.Split(separator, StringSplitOptions.None);
								foreach (string text4 in array3)
								{
									for (int l = 0; l < LootCatalog.category.Length; l++)
									{
										foreach (LootDef item3 in LootCatalog.category[l].loot)
										{
											if (item3.name == text4 && l == 3 && item3.type == 2)
											{
												if (!dictionary.ContainsKey(item3.name))
												{
													dictionary.Add(item3.name, new List<string>());
												}
												if (!dictionary[item3.name].Contains(text))
												{
													dictionary[item3.name].Add(text);
												}
											}
										}
									}
								}
							}
						}
					}
					if ((array2[j] == "flag" || array2[j] == "boss") && j < array2.Length - 1)
					{
						string text5 = array2[j + 1];
						if (text5.EndsWith("\r"))
						{
							text5 = text5.Substring(0, text5.Length - 1);
						}
						item = text5;
					}
					if ((array2[j] == "chest" || array2[j] == "drops" || array2[j] == "drop") && j < array2.Length - 1)
					{
						string text6 = array2[j + 1];
						if (text6.EndsWith("\r"))
						{
							text6 = text6.Substring(0, text6.Length - 1);
						}
						text2 = text6;
					}
					if (text2 == null)
					{
						continue;
					}
					for (int m = 0; m < LootCatalog.category.Length; m++)
					{
						foreach (LootDef item4 in LootCatalog.category[m].loot)
						{
							if (item4.name == text2 && m == 6)
							{
								dictionary.Add(text2, new List<string> { item });
								text2 = null;
							}
						}
					}
				}
			}
		}
		foreach (KeyValuePair<string, List<string>> item5 in dictionary)
		{
			string text7 = "";
			for (int n = 0; n < item5.Value.Count; n++)
			{
				text7 = text7 + "\"" + item5.Value[n] + "\"" + ((n < item5.Value.Count - 1) ? ", " : "");
			}
			ConsoleWriteLine("requirements.Add(new string[] { \"" + item5.Key + "\", " + text7 + " });");
		}
	}

	private void upToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < Game1.map.yUnits * 2 - 1; i++)
		{
			for (int j = 0; j < Game1.map.xUnits; j++)
			{
				Game1.map.col[j, i] = Game1.map.col[j, i + 1];
			}
		}
	}

	private void layerTintEditToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (lte == null)
		{
			lte = new LayerTintEdit();
		}
		else if (lte.IsDisposed)
		{
			lte = new LayerTintEdit();
		}
		try
		{
			lte.Show();
			lte.Init();
		}
		catch
		{
		}
	}

	private void trvCells_AfterSelect(object sender, TreeViewEventArgs e)
	{
		Game1.selPaletteNode = trvCells.SelectedNode;
		Game1.needsPaletteDraw = true;
	}

	public bool IsNodeInSelectedFolder(int idx, TreeNode folder, TreeNode refNodes)
	{
		if (folder == null)
		{
			return false;
		}
		foreach (TreeNode node in FindRefFolder(folder, refNodes).Nodes)
		{
			if (MapCellTreeManager.GetNodeIdx(node) == idx)
			{
				return true;
			}
		}
		return false;
	}

	public int[] GetNodeIndices(TreeNode folder, TreeNode refNodes)
	{
		if (folder == null)
		{
			return null;
		}
		if (MapCellTreeManager.GetNodeType(folder) != 1)
		{
			return null;
		}
		TreeNode treeNode = FindRefFolder(folder, refNodes);
		List<int> list = new List<int>();
		foreach (TreeNode node in treeNode.Nodes)
		{
			list.Add(MapCellTreeManager.GetNodeIdx(node));
		}
		return list.ToArray();
	}

	private TreeNode FindRefFolder(TreeNode folder, TreeNode refNodes)
	{
		string nodePath = GetNodePath(folder);
		if (GetNodePath(refNodes) == nodePath)
		{
			return refNodes;
		}
		foreach (TreeNode node in refNodes.Nodes)
		{
			TreeNode treeNode = FindRefFolder(folder, node);
			if (treeNode != null)
			{
				return treeNode;
			}
		}
		return null;
	}

	private string GetNodePath(TreeNode node)
	{
		string text = node.Text;
		if (node.Parent != null)
		{
			text = node.Parent.Text + "\\" + text;
		}
		return text;
	}

	private void pctCells_Click(object sender, EventArgs e)
	{
	}

	private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer >= 19)
		{
			return;
		}
		Game1.map.sequenceMgr.UpdateAffectedSegs();
		while (Game1.selSeg > 0)
		{
			SwapSegs(Game1.selSeg, Game1.selSeg - 1);
			Game1.selSeg--;
			if (lstMapCells.Enabled)
			{
				lstMapCells.SelectedIndex = Game1.selSeg;
			}
		}
	}

	private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer >= 19)
		{
			return;
		}
		_ = lstMapCells.Items.Count;
		int count = Game1.map.layer[Game1.selLayer].seg.Count;
		Game1.map.sequenceMgr.UpdateAffectedSegs();
		while (Game1.selSeg < count - 1)
		{
			SwapSegs(Game1.selSeg, Game1.selSeg + 1);
			Game1.selSeg++;
			if (lstMapCells.Enabled)
			{
				lstMapCells.SelectedIndex = Game1.selSeg;
			}
		}
	}

	private void nWToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GridDuplicate(new System.Drawing.Point(-1, -1));
	}

	private void nToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GridDuplicate(new System.Drawing.Point(0, -1));
	}

	private void nEToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GridDuplicate(new System.Drawing.Point(1, -1));
	}

	private void wToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GridDuplicate(new System.Drawing.Point(-1, 0));
	}

	private void eToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GridDuplicate(new System.Drawing.Point(1, 0));
	}

	private void sWToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GridDuplicate(new System.Drawing.Point(-1, 1));
	}

	private void sToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GridDuplicate(new System.Drawing.Point(0, 1));
	}

	private void sEToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GridDuplicate(new System.Drawing.Point(1, 1));
	}

	private void GridDuplicate(System.Drawing.Point p)
	{
	}

	private void xToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer > -1 && Game1.selLayer < Game1.map.layer.Length && Game1.selSeg > -1 && Game1.selSeg < Game1.map.layer[Game1.selLayer].seg.Count)
		{
			Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].scaling *= 2f;
		}
	}

	private void toolStripMenuItem2_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer > -1 && Game1.selLayer < Game1.map.layer.Length && Game1.selSeg > -1 && Game1.selSeg < Game1.map.layer[Game1.selLayer].seg.Count)
		{
			Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].scaling *= 0.5f;
		}
	}

	private void flipHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void pnlCells_Paint(object sender, PaintEventArgs e)
	{
	}

	private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Game1.needsBake = true;
		Game1.bakeSepia = true;
	}

	private void noSepiaToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Game1.needsBake = true;
		Game1.bakeSepia = false;
	}

	private void toggleCellPaletteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (trvCells.Visible)
		{
			trvCells.Visible = false;
			txtRScript.Visible = true;
			return;
		}
		trvCells.Visible = true;
		trvCells.Location = new System.Drawing.Point(txtRScript.Location.X, txtRScript.Location.Y);
		trvCells.Size = new Size(txtRScript.Size.Width, txtRScript.Size.Height);
		txtRScript.Visible = false;
	}

	private void showBloomTexturesToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Game1.showBloomTextures = !Game1.showBloomTextures;
		showBloomTexturesToolStripMenuItem.Checked = Game1.showBloomTextures;
	}

	private void cCWToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer > -1 && Game1.selLayer < Game1.map.layer.Length && Game1.selSeg > -1 && Game1.selSeg < Game1.map.layer[Game1.selLayer].seg.Count)
		{
			Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].rotation -= 1.570796f;
		}
	}

	private void cWToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (Game1.selLayer > -1 && Game1.selLayer < Game1.map.layer.Length && Game1.selSeg > -1 && Game1.selSeg < Game1.map.layer[Game1.selLayer].seg.Count)
		{
			Game1.map.layer[Game1.selLayer].seg[Game1.selSeg].rotation += 1.570796f;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.mnuFileQuit = new System.Windows.Forms.ToolStripMenuItem();
		this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.layerTintEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.hacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.batchProcessToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.cleanDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.fixFogToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.makeMinimapToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.noSepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.flipModeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.launchDialogEditToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.brandModeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.findProgressionFlagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.nudgeColToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.upToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.sendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.gridDuplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.nWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.nEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.wToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.sWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.sEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
		this.fixedResizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.flipHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
		this.toggleCellPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.cCWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.cWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.sequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuBeginRecording = new System.Windows.Forms.ToolStripMenuItem();
		this.recordSnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuFinalizeRecording = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuCancelRecording = new System.Windows.Forms.ToolStripMenuItem();
		this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ringsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.charmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.spellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.armorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.weaponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.shieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.materialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.flagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.highlightLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.showCollisionMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.drawLightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.showSequencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.showMapGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.showBossBoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.showBloomTexturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.hideInactiveLayersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.lstSheets = new System.Windows.Forms.ListBox();
		this.lblSheetsOrEntities = new System.Windows.Forms.Label();
		this.lstCells = new System.Windows.Forms.ListBox();
		this.lstMapCells = new System.Windows.Forms.ListBox();
		this.cmbLayer = new System.Windows.Forms.ComboBox();
		this.label4 = new System.Windows.Forms.Label();
		this.lblSegFlags = new System.Windows.Forms.Label();
		this.cmbSegFlags = new System.Windows.Forms.ComboBox();
		this.txtCellName = new System.Windows.Forms.TextBox();
		this.cmbLoot = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.txtConsole = new System.Windows.Forms.TextBox();
		this.txtRScript = new System.Windows.Forms.RichTextBox();
		this.pnlCells = new System.Windows.Forms.Panel();
		this.pctCells = new System.Windows.Forms.PictureBox();
		this.txtPaletteHover = new System.Windows.Forms.TextBox();
		this.pctSurface = new System.Windows.Forms.PictureBox();
		this.trvCells = new System.Windows.Forms.TreeView();
		this.menuStrip1.SuspendLayout();
		this.pnlCells.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pctCells).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pctSurface).BeginInit();
		base.SuspendLayout();
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.fileToolStripMenuItem, this.toolsToolStripMenuItem, this.sequenceToolStripMenuItem, this.filterToolStripMenuItem, this.flagsToolStripMenuItem });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Size = new System.Drawing.Size(1587, 24);
		this.menuStrip1.TabIndex = 0;
		this.menuStrip1.Text = "menuStrip1";
		this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.mnuFileNew, this.mnuFileOpen, this.mnuFileSave, this.mnuFileSaveAs, this.toolStripSeparator1, this.mnuFileQuit });
		this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
		this.fileToolStripMenuItem.Text = "File";
		this.mnuFileNew.Name = "mnuFileNew";
		this.mnuFileNew.Size = new System.Drawing.Size(138, 22);
		this.mnuFileNew.Text = "New";
		this.mnuFileOpen.Name = "mnuFileOpen";
		this.mnuFileOpen.Size = new System.Drawing.Size(138, 22);
		this.mnuFileOpen.Text = "Open";
		this.mnuFileOpen.Click += new System.EventHandler(mnuFileOpen_Click);
		this.mnuFileSave.Enabled = false;
		this.mnuFileSave.Name = "mnuFileSave";
		this.mnuFileSave.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;
		this.mnuFileSave.Size = new System.Drawing.Size(138, 22);
		this.mnuFileSave.Text = "Save";
		this.mnuFileSave.Click += new System.EventHandler(mnuFileSave_Click);
		this.mnuFileSaveAs.Name = "mnuFileSaveAs";
		this.mnuFileSaveAs.Size = new System.Drawing.Size(138, 22);
		this.mnuFileSaveAs.Text = "Save As...";
		this.mnuFileSaveAs.Click += new System.EventHandler(mnuFileSaveAs_Click);
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
		this.mnuFileQuit.Name = "mnuFileQuit";
		this.mnuFileQuit.Size = new System.Drawing.Size(138, 22);
		this.mnuFileQuit.Text = "Quit";
		this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[14]
		{
			this.layerTintEditToolStripMenuItem, this.toolStripSeparator2, this.hacksToolStripMenuItem, this.toolStripSeparator3, this.sendToBackToolStripMenuItem, this.bringToFrontToolStripMenuItem, this.toolStripSeparator4, this.gridDuplicateToolStripMenuItem, this.toolStripSeparator5, this.fixedResizeToolStripMenuItem,
			this.flipHorizontalToolStripMenuItem, this.toolStripSeparator6, this.toggleCellPaletteToolStripMenuItem, this.rotateToolStripMenuItem
		});
		this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
		this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
		this.toolsToolStripMenuItem.Text = "Tools";
		this.layerTintEditToolStripMenuItem.Name = "layerTintEditToolStripMenuItem";
		this.layerTintEditToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
		this.layerTintEditToolStripMenuItem.Text = "Layer Tint Edit";
		this.layerTintEditToolStripMenuItem.Click += new System.EventHandler(layerTintEditToolStripMenuItem_Click);
		this.toolStripSeparator2.Name = "toolStripSeparator2";
		this.toolStripSeparator2.Size = new System.Drawing.Size(219, 6);
		this.hacksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.batchProcessToolStripMenuItem1, this.cleanDuplicatesToolStripMenuItem, this.fixFogToolStripMenuItem2, this.makeMinimapToolStripMenuItem1, this.flipModeToolStripMenuItem1, this.launchDialogEditToolStripMenuItem1, this.brandModeToolStripMenuItem1, this.findProgressionFlagToolStripMenuItem, this.nudgeColToolStripMenuItem1 });
		this.hacksToolStripMenuItem.Name = "hacksToolStripMenuItem";
		this.hacksToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
		this.hacksToolStripMenuItem.Text = "Hacks";
		this.batchProcessToolStripMenuItem1.Name = "batchProcessToolStripMenuItem1";
		this.batchProcessToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
		this.batchProcessToolStripMenuItem1.Text = "Batch Process...";
		this.batchProcessToolStripMenuItem1.Click += new System.EventHandler(batchProcessToolStripMenuItem1_Click);
		this.cleanDuplicatesToolStripMenuItem.Name = "cleanDuplicatesToolStripMenuItem";
		this.cleanDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
		this.cleanDuplicatesToolStripMenuItem.Text = "Clean Duplicates";
		this.cleanDuplicatesToolStripMenuItem.Click += new System.EventHandler(cleanDuplicatesToolStripMenuItem_Click);
		this.fixFogToolStripMenuItem2.Name = "fixFogToolStripMenuItem2";
		this.fixFogToolStripMenuItem2.Size = new System.Drawing.Size(192, 22);
		this.fixFogToolStripMenuItem2.Text = "Fix Fog";
		this.fixFogToolStripMenuItem2.Click += new System.EventHandler(fixFogToolStripMenuItem2_Click);
		this.makeMinimapToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.sepiaToolStripMenuItem, this.noSepiaToolStripMenuItem });
		this.makeMinimapToolStripMenuItem1.Name = "makeMinimapToolStripMenuItem1";
		this.makeMinimapToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
		this.makeMinimapToolStripMenuItem1.Text = "Make Minimap";
		this.makeMinimapToolStripMenuItem1.Click += new System.EventHandler(makeMinimapToolStripMenuItem1_Click);
		this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
		this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
		this.sepiaToolStripMenuItem.Text = "Sepia";
		this.sepiaToolStripMenuItem.Click += new System.EventHandler(sepiaToolStripMenuItem_Click);
		this.noSepiaToolStripMenuItem.Name = "noSepiaToolStripMenuItem";
		this.noSepiaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
		this.noSepiaToolStripMenuItem.Text = "No Sepia";
		this.noSepiaToolStripMenuItem.Click += new System.EventHandler(noSepiaToolStripMenuItem_Click);
		this.flipModeToolStripMenuItem1.Name = "flipModeToolStripMenuItem1";
		this.flipModeToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
		this.flipModeToolStripMenuItem1.Text = "Flip Mode";
		this.flipModeToolStripMenuItem1.Click += new System.EventHandler(flipModeToolStripMenuItem1_Click);
		this.launchDialogEditToolStripMenuItem1.Name = "launchDialogEditToolStripMenuItem1";
		this.launchDialogEditToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
		this.launchDialogEditToolStripMenuItem1.Text = "Launch DialogEdit";
		this.launchDialogEditToolStripMenuItem1.Click += new System.EventHandler(launchDialogEditToolStripMenuItem1_Click);
		this.brandModeToolStripMenuItem1.Name = "brandModeToolStripMenuItem1";
		this.brandModeToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
		this.brandModeToolStripMenuItem1.Text = "Brand Mode";
		this.brandModeToolStripMenuItem1.Click += new System.EventHandler(brandModeToolStripMenuItem1_Click);
		this.findProgressionFlagToolStripMenuItem.Name = "findProgressionFlagToolStripMenuItem";
		this.findProgressionFlagToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
		this.findProgressionFlagToolStripMenuItem.Text = "Find Progression Flags";
		this.findProgressionFlagToolStripMenuItem.Click += new System.EventHandler(findProgressionFlagToolStripMenuItem_Click);
		this.nudgeColToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.upToolStripMenuItem1 });
		this.nudgeColToolStripMenuItem1.Name = "nudgeColToolStripMenuItem1";
		this.nudgeColToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
		this.nudgeColToolStripMenuItem1.Text = "Nudge Col";
		this.upToolStripMenuItem1.Name = "upToolStripMenuItem1";
		this.upToolStripMenuItem1.Size = new System.Drawing.Size(89, 22);
		this.upToolStripMenuItem1.Text = "Up";
		this.upToolStripMenuItem1.Click += new System.EventHandler(upToolStripMenuItem1_Click);
		this.toolStripSeparator3.Name = "toolStripSeparator3";
		this.toolStripSeparator3.Size = new System.Drawing.Size(219, 6);
		this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
		this.sendToBackToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Control;
		this.sendToBackToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
		this.sendToBackToolStripMenuItem.Text = "Send to Bottom";
		this.sendToBackToolStripMenuItem.Click += new System.EventHandler(sendToBackToolStripMenuItem_Click);
		this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
		this.bringToFrontToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Control;
		this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
		this.bringToFrontToolStripMenuItem.Text = "Bring to Top";
		this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(bringToFrontToolStripMenuItem_Click);
		this.toolStripSeparator4.Name = "toolStripSeparator4";
		this.toolStripSeparator4.Size = new System.Drawing.Size(219, 6);
		this.gridDuplicateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.nWToolStripMenuItem, this.nToolStripMenuItem, this.nEToolStripMenuItem, this.wToolStripMenuItem, this.eToolStripMenuItem, this.sWToolStripMenuItem, this.sToolStripMenuItem, this.sEToolStripMenuItem });
		this.gridDuplicateToolStripMenuItem.Name = "gridDuplicateToolStripMenuItem";
		this.gridDuplicateToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
		this.gridDuplicateToolStripMenuItem.Text = "Grid Duplicate";
		this.nWToolStripMenuItem.Name = "nWToolStripMenuItem";
		this.nWToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.NumPad7 | System.Windows.Forms.Keys.Control;
		this.nWToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.nWToolStripMenuItem.Text = "NW";
		this.nWToolStripMenuItem.Click += new System.EventHandler(nWToolStripMenuItem_Click);
		this.nToolStripMenuItem.Name = "nToolStripMenuItem";
		this.nToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.NumPad8 | System.Windows.Forms.Keys.Control;
		this.nToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.nToolStripMenuItem.Text = "N";
		this.nToolStripMenuItem.Click += new System.EventHandler(nToolStripMenuItem_Click);
		this.nEToolStripMenuItem.Name = "nEToolStripMenuItem";
		this.nEToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.NumPad9 | System.Windows.Forms.Keys.Control;
		this.nEToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.nEToolStripMenuItem.Text = "NE";
		this.nEToolStripMenuItem.Click += new System.EventHandler(nEToolStripMenuItem_Click);
		this.wToolStripMenuItem.Name = "wToolStripMenuItem";
		this.wToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.NumPad4 | System.Windows.Forms.Keys.Control;
		this.wToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.wToolStripMenuItem.Text = "W";
		this.wToolStripMenuItem.Click += new System.EventHandler(wToolStripMenuItem_Click);
		this.eToolStripMenuItem.Name = "eToolStripMenuItem";
		this.eToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.NumPad6 | System.Windows.Forms.Keys.Control;
		this.eToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.eToolStripMenuItem.Text = "E";
		this.eToolStripMenuItem.Click += new System.EventHandler(eToolStripMenuItem_Click);
		this.sWToolStripMenuItem.Name = "sWToolStripMenuItem";
		this.sWToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.NumPad1 | System.Windows.Forms.Keys.Control;
		this.sWToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.sWToolStripMenuItem.Text = "SW";
		this.sWToolStripMenuItem.Click += new System.EventHandler(sWToolStripMenuItem_Click);
		this.sToolStripMenuItem.Name = "sToolStripMenuItem";
		this.sToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.NumPad2 | System.Windows.Forms.Keys.Control;
		this.sToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.sToolStripMenuItem.Text = "S";
		this.sToolStripMenuItem.Click += new System.EventHandler(sToolStripMenuItem_Click);
		this.sEToolStripMenuItem.Name = "sEToolStripMenuItem";
		this.sEToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.NumPad3 | System.Windows.Forms.Keys.Control;
		this.sEToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		this.sEToolStripMenuItem.Text = "SE";
		this.sEToolStripMenuItem.Click += new System.EventHandler(sEToolStripMenuItem_Click);
		this.toolStripSeparator5.Name = "toolStripSeparator5";
		this.toolStripSeparator5.Size = new System.Drawing.Size(219, 6);
		this.fixedResizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.xToolStripMenuItem, this.toolStripMenuItem2 });
		this.fixedResizeToolStripMenuItem.Name = "fixedResizeToolStripMenuItem";
		this.fixedResizeToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
		this.fixedResizeToolStripMenuItem.Text = "Fixed Resize";
		this.xToolStripMenuItem.Name = "xToolStripMenuItem";
		this.xToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+.";
		this.xToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.OemPeriod | System.Windows.Forms.Keys.Control;
		this.xToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
		this.xToolStripMenuItem.Text = "200%";
		this.xToolStripMenuItem.Click += new System.EventHandler(xToolStripMenuItem_Click);
		this.toolStripMenuItem2.Name = "toolStripMenuItem2";
		this.toolStripMenuItem2.ShortcutKeyDisplayString = "Ctrl+,";
		this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.Oemcomma | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
		this.toolStripMenuItem2.Text = "50%";
		this.toolStripMenuItem2.Click += new System.EventHandler(toolStripMenuItem2_Click);
		this.flipHorizontalToolStripMenuItem.Name = "flipHorizontalToolStripMenuItem";
		this.flipHorizontalToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+/";
		this.flipHorizontalToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.OemQuestion | System.Windows.Forms.Keys.Control;
		this.flipHorizontalToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
		this.flipHorizontalToolStripMenuItem.Text = "Flip Horizontal";
		this.flipHorizontalToolStripMenuItem.Click += new System.EventHandler(flipHorizontalToolStripMenuItem_Click);
		this.toolStripSeparator6.Name = "toolStripSeparator6";
		this.toolStripSeparator6.Size = new System.Drawing.Size(219, 6);
		this.toggleCellPaletteToolStripMenuItem.Name = "toggleCellPaletteToolStripMenuItem";
		this.toggleCellPaletteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.E | System.Windows.Forms.Keys.Control;
		this.toggleCellPaletteToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
		this.toggleCellPaletteToolStripMenuItem.Text = "Toggle Cell Palette";
		this.toggleCellPaletteToolStripMenuItem.Click += new System.EventHandler(toggleCellPaletteToolStripMenuItem_Click);
		this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.cCWToolStripMenuItem, this.cWToolStripMenuItem });
		this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
		this.rotateToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
		this.rotateToolStripMenuItem.Text = "Rotate";
		this.cCWToolStripMenuItem.Name = "cCWToolStripMenuItem";
		this.cCWToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+[";
		this.cCWToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.OemOpenBrackets | System.Windows.Forms.Keys.Control;
		this.cCWToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
		this.cCWToolStripMenuItem.Text = "90° CCW";
		this.cCWToolStripMenuItem.Click += new System.EventHandler(cCWToolStripMenuItem_Click);
		this.cWToolStripMenuItem.Name = "cWToolStripMenuItem";
		this.cWToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+]";
		this.cWToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.OemCloseBrackets | System.Windows.Forms.Keys.Control;
		this.cWToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
		this.cWToolStripMenuItem.Text = "90° CW";
		this.cWToolStripMenuItem.Click += new System.EventHandler(cWToolStripMenuItem_Click);
		this.sequenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.newToolStripMenuItem, this.mnuBeginRecording, this.recordSnapshotToolStripMenuItem, this.mnuFinalizeRecording, this.mnuCancelRecording });
		this.sequenceToolStripMenuItem.Name = "sequenceToolStripMenuItem";
		this.sequenceToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
		this.sequenceToolStripMenuItem.Text = "Sequence";
		this.newToolStripMenuItem.Name = "newToolStripMenuItem";
		this.newToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
		this.newToolStripMenuItem.Text = "New";
		this.newToolStripMenuItem.Click += new System.EventHandler(newToolStripMenuItem_Click);
		this.mnuBeginRecording.Name = "mnuBeginRecording";
		this.mnuBeginRecording.Size = new System.Drawing.Size(170, 22);
		this.mnuBeginRecording.Text = "Begin Recording";
		this.mnuBeginRecording.Click += new System.EventHandler(recordSequenceToolStripMenuItem_Click_1);
		this.recordSnapshotToolStripMenuItem.Name = "recordSnapshotToolStripMenuItem";
		this.recordSnapshotToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
		this.recordSnapshotToolStripMenuItem.Text = "Record Snapshot";
		this.recordSnapshotToolStripMenuItem.Click += new System.EventHandler(recordSnapshotToolStripMenuItem_Click);
		this.mnuFinalizeRecording.Name = "mnuFinalizeRecording";
		this.mnuFinalizeRecording.Size = new System.Drawing.Size(170, 22);
		this.mnuFinalizeRecording.Text = "Finalize Recording";
		this.mnuFinalizeRecording.Click += new System.EventHandler(mnuFinalizeRecording_Click);
		this.mnuCancelRecording.Name = "mnuCancelRecording";
		this.mnuCancelRecording.Size = new System.Drawing.Size(170, 22);
		this.mnuCancelRecording.Text = "Cancel Recording";
		this.mnuCancelRecording.Click += new System.EventHandler(mnuCancelRecording_Click);
		this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.allToolStripMenuItem, this.ringsToolStripMenuItem, this.charmsToolStripMenuItem, this.spellsToolStripMenuItem, this.armorToolStripMenuItem, this.weaponsToolStripMenuItem, this.shieldsToolStripMenuItem, this.materialsToolStripMenuItem });
		this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
		this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
		this.filterToolStripMenuItem.Text = "Filter";
		this.allToolStripMenuItem.Name = "allToolStripMenuItem";
		this.allToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.allToolStripMenuItem.Text = "All";
		this.allToolStripMenuItem.Click += new System.EventHandler(allToolStripMenuItem_Click);
		this.ringsToolStripMenuItem.Name = "ringsToolStripMenuItem";
		this.ringsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.ringsToolStripMenuItem.Text = "Rings";
		this.ringsToolStripMenuItem.Click += new System.EventHandler(ringsToolStripMenuItem_Click);
		this.charmsToolStripMenuItem.Name = "charmsToolStripMenuItem";
		this.charmsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.charmsToolStripMenuItem.Text = "Charms";
		this.charmsToolStripMenuItem.Click += new System.EventHandler(charmsToolStripMenuItem_Click);
		this.spellsToolStripMenuItem.Name = "spellsToolStripMenuItem";
		this.spellsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.spellsToolStripMenuItem.Text = "Spells";
		this.spellsToolStripMenuItem.Click += new System.EventHandler(spellsToolStripMenuItem_Click);
		this.armorToolStripMenuItem.Name = "armorToolStripMenuItem";
		this.armorToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.armorToolStripMenuItem.Text = "Armor";
		this.armorToolStripMenuItem.Click += new System.EventHandler(armorToolStripMenuItem_Click);
		this.weaponsToolStripMenuItem.Name = "weaponsToolStripMenuItem";
		this.weaponsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.weaponsToolStripMenuItem.Text = "Weapons";
		this.weaponsToolStripMenuItem.Click += new System.EventHandler(weaponsToolStripMenuItem_Click);
		this.shieldsToolStripMenuItem.Name = "shieldsToolStripMenuItem";
		this.shieldsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.shieldsToolStripMenuItem.Text = "Shields";
		this.shieldsToolStripMenuItem.Click += new System.EventHandler(shieldsToolStripMenuItem_Click);
		this.materialsToolStripMenuItem.Name = "materialsToolStripMenuItem";
		this.materialsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
		this.materialsToolStripMenuItem.Text = "Materials";
		this.materialsToolStripMenuItem.Click += new System.EventHandler(materialsToolStripMenuItem_Click);
		this.flagsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.highlightLayerToolStripMenuItem, this.showCollisionMapToolStripMenuItem, this.drawLightToolStripMenuItem, this.showSequencesToolStripMenuItem, this.showMapGridToolStripMenuItem, this.showBossBoundsToolStripMenuItem, this.showBloomTexturesToolStripMenuItem, this.hideInactiveLayersMenuItem });
		this.flagsToolStripMenuItem.Name = "flagsToolStripMenuItem";
		this.flagsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
		this.flagsToolStripMenuItem.Text = "Flags";
		this.highlightLayerToolStripMenuItem.Name = "highlightLayerToolStripMenuItem";
		this.highlightLayerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.L | System.Windows.Forms.Keys.Control;
		this.highlightLayerToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
		this.highlightLayerToolStripMenuItem.Text = "Highlight Layer";
		this.highlightLayerToolStripMenuItem.Click += new System.EventHandler(highlightLayerToolStripMenuItem_Click);
		this.showCollisionMapToolStripMenuItem.Name = "showCollisionMapToolStripMenuItem";
		this.showCollisionMapToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.M | System.Windows.Forms.Keys.Control;
		this.showCollisionMapToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
		this.showCollisionMapToolStripMenuItem.Text = "Show Collision Map";
		this.showCollisionMapToolStripMenuItem.Click += new System.EventHandler(showCollisionMapToolStripMenuItem_Click);
		this.drawLightToolStripMenuItem.Name = "drawLightToolStripMenuItem";
		this.drawLightToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
		this.drawLightToolStripMenuItem.Text = "Draw Light";
		this.drawLightToolStripMenuItem.Click += new System.EventHandler(drawLightToolStripMenuItem_Click);
		this.showSequencesToolStripMenuItem.Name = "showSequencesToolStripMenuItem";
		this.showSequencesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
		this.showSequencesToolStripMenuItem.Text = "Show Sequences";
		this.showSequencesToolStripMenuItem.Click += new System.EventHandler(showSequencesToolStripMenuItem_Click);
		this.showMapGridToolStripMenuItem.Name = "showMapGridToolStripMenuItem";
		this.showMapGridToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
		this.showMapGridToolStripMenuItem.Text = "Show MapGrid";
		this.showMapGridToolStripMenuItem.Click += new System.EventHandler(showMapGridToolStripMenuItem_Click);
		this.showBossBoundsToolStripMenuItem.Name = "showBossBoundsToolStripMenuItem";
		this.showBossBoundsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
		this.showBossBoundsToolStripMenuItem.Text = "Show Boss Bounds";
		this.showBossBoundsToolStripMenuItem.Click += new System.EventHandler(showBossBoundsToolStripMenuItem_Click);
		this.showBloomTexturesToolStripMenuItem.Name = "showBloomTexturesToolStripMenuItem";
		this.showBloomTexturesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
		this.showBloomTexturesToolStripMenuItem.Text = "Show Bloom Textures";
		this.showBloomTexturesToolStripMenuItem.Click += new System.EventHandler(showBloomTexturesToolStripMenuItem_Click);
		this.hideInactiveLayersMenuItem.Name = "hideInactiveLayersMenuItem";
		this.hideInactiveLayersMenuItem.Size = new System.Drawing.Size(224, 22);
		this.hideInactiveLayersMenuItem.Text = "Hide Inactive Layers";
		this.hideInactiveLayersMenuItem.Click += new System.EventHandler(hideInactiveLayersMenuItem_Click);
        this.hideInactiveLayersMenuItem.ShortcutKeys = System.Windows.Forms.Keys.P | System.Windows.Forms.Keys.Control;
        this.lstSheets.FormattingEnabled = true;
		this.lstSheets.Location = new System.Drawing.Point(12, 40);
		this.lstSheets.Name = "lstSheets";
		this.lstSheets.Size = new System.Drawing.Size(120, 199);
		this.lstSheets.TabIndex = 1;
		this.lstSheets.SelectedIndexChanged += new System.EventHandler(lstSheets_SelectedIndexChanged);
		this.lblSheetsOrEntities.AutoSize = true;
		this.lblSheetsOrEntities.Location = new System.Drawing.Point(12, 24);
		this.lblSheetsOrEntities.Name = "lblSheetsOrEntities";
		this.lblSheetsOrEntities.Size = new System.Drawing.Size(43, 13);
		this.lblSheetsOrEntities.TabIndex = 2;
		this.lblSheetsOrEntities.Text = "Sheets:";
		this.lstCells.FormattingEnabled = true;
		this.lstCells.Location = new System.Drawing.Point(12, 123);
		this.lstCells.Name = "lstCells";
		this.lstCells.Size = new System.Drawing.Size(120, 43);
		this.lstCells.TabIndex = 3;
		this.lstCells.Visible = false;
		this.lstCells.SelectedIndexChanged += new System.EventHandler(lstCells_SelectedIndexChanged);
		this.lstCells.DoubleClick += new System.EventHandler(lstCells_DoubleClick);
		this.lstMapCells.FormattingEnabled = true;
		this.lstMapCells.Location = new System.Drawing.Point(12, 66);
		this.lstMapCells.Name = "lstMapCells";
		this.lstMapCells.Size = new System.Drawing.Size(120, 43);
		this.lstMapCells.TabIndex = 5;
		this.lstMapCells.Visible = false;
		this.lstMapCells.SelectedIndexChanged += new System.EventHandler(lstMapCells_SelectedIndexChanged);
		this.cmbLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbLayer.FormattingEnabled = true;
		this.cmbLayer.Location = new System.Drawing.Point(189, 219);
		this.cmbLayer.Name = "cmbLayer";
		this.cmbLayer.Size = new System.Drawing.Size(114, 21);
		this.cmbLayer.TabIndex = 10;
		this.cmbLayer.SelectedIndexChanged += new System.EventHandler(cmbLayer_SelectedIndexChanged);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(149, 222);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(36, 13);
		this.label4.TabIndex = 11;
		this.label4.Text = "Layer:";
		this.lblSegFlags.AutoSize = true;
		this.lblSegFlags.Location = new System.Drawing.Point(147, 195);
		this.lblSegFlags.Name = "lblSegFlags";
		this.lblSegFlags.Size = new System.Drawing.Size(35, 13);
		this.lblSegFlags.TabIndex = 24;
		this.lblSegFlags.Text = "Flags:";
		this.cmbSegFlags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbSegFlags.FormattingEnabled = true;
		this.cmbSegFlags.Location = new System.Drawing.Point(189, 192);
		this.cmbSegFlags.Name = "cmbSegFlags";
		this.cmbSegFlags.Size = new System.Drawing.Size(114, 21);
		this.cmbSegFlags.TabIndex = 25;
		this.cmbSegFlags.SelectedIndexChanged += new System.EventHandler(cmbSegFlags_SelectedIndexChanged);
		this.txtCellName.Location = new System.Drawing.Point(12, 40);
		this.txtCellName.Name = "txtCellName";
		this.txtCellName.Size = new System.Drawing.Size(120, 20);
		this.txtCellName.TabIndex = 27;
		this.txtCellName.Visible = false;
		this.txtCellName.TextChanged += new System.EventHandler(txtCellName_TextChanged);
		this.cmbLoot.FormattingEnabled = true;
		this.cmbLoot.Location = new System.Drawing.Point(196, 24);
		this.cmbLoot.Name = "cmbLoot";
		this.cmbLoot.Size = new System.Drawing.Size(113, 21);
		this.cmbLoot.TabIndex = 30;
		this.cmbLoot.SelectedIndexChanged += new System.EventHandler(cmbLoot_SelectedIndexChanged);
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(159, 28);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(31, 13);
		this.label5.TabIndex = 29;
		this.label5.Text = "Loot:";
		this.txtConsole.Location = new System.Drawing.Point(12, 657);
		this.txtConsole.Multiline = true;
		this.txtConsole.Name = "txtConsole";
		this.txtConsole.ReadOnly = true;
		this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtConsole.Size = new System.Drawing.Size(298, 87);
		this.txtConsole.TabIndex = 35;
		this.txtRScript.Location = new System.Drawing.Point(138, 44);
		this.txtRScript.Name = "txtRScript";
		this.txtRScript.Size = new System.Drawing.Size(171, 142);
		this.txtRScript.TabIndex = 36;
		this.txtRScript.Text = "";
		this.txtRScript.TextChanged += new System.EventHandler(txtRScript_TextChanged);
		this.pnlCells.AutoScroll = true;
		this.pnlCells.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.pnlCells.Controls.Add(this.pctCells);
		this.pnlCells.Location = new System.Drawing.Point(12, 246);
		this.pnlCells.Name = "pnlCells";
		this.pnlCells.Size = new System.Drawing.Size(302, 414);
		this.pnlCells.TabIndex = 37;
		this.pnlCells.Paint += new System.Windows.Forms.PaintEventHandler(pnlCells_Paint);
		this.pnlCells.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(pnlCells_MouseDoubleClick);
		this.pctCells.Location = new System.Drawing.Point(0, 0);
		this.pctCells.Name = "pctCells";
		this.pctCells.Size = new System.Drawing.Size(100, 50);
		this.pctCells.TabIndex = 0;
		this.pctCells.TabStop = false;
		this.pctCells.Click += new System.EventHandler(pctCells_Click);
		this.pctCells.DoubleClick += new System.EventHandler(pctCells_DoubleClick);
		this.pctCells.MouseDown += new System.Windows.Forms.MouseEventHandler(pctCells_MouseDown);
		this.pctCells.MouseEnter += new System.EventHandler(pctCells_MouseEnter);
		this.pctCells.MouseLeave += new System.EventHandler(pctCells_MouseLeave);
		this.pctCells.MouseMove += new System.Windows.Forms.MouseEventHandler(pctCells_MouseMove);
		this.pctCells.MouseUp += new System.Windows.Forms.MouseEventHandler(pctCells_MouseUp);
		this.txtPaletteHover.BackColor = System.Drawing.SystemColors.InactiveCaption;
		this.txtPaletteHover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPaletteHover.Location = new System.Drawing.Point(203, 658);
		this.txtPaletteHover.Name = "txtPaletteHover";
		this.txtPaletteHover.Size = new System.Drawing.Size(100, 20);
		this.txtPaletteHover.TabIndex = 73;
		this.txtPaletteHover.Text = "Palette Hover";
		this.txtPaletteHover.Visible = false;
		this.pctSurface.Location = new System.Drawing.Point(315, 24);
		this.pctSurface.Name = "pctSurface";
		this.pctSurface.Size = new System.Drawing.Size(1279, 720);
		this.pctSurface.TabIndex = 34;
		this.pctSurface.TabStop = false;
		this.pctSurface.Click += new System.EventHandler(pctSurface_Click);
		this.trvCells.Location = new System.Drawing.Point(138, 44);
		this.trvCells.Name = "trvCells";
		this.trvCells.Size = new System.Drawing.Size(171, 142);
		this.trvCells.TabIndex = 74;
		this.trvCells.Visible = false;
		this.trvCells.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(trvCells_AfterSelect);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1587, 742);
		base.Controls.Add(this.trvCells);
		base.Controls.Add(this.txtPaletteHover);
		base.Controls.Add(this.cmbLoot);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.txtRScript);
		base.Controls.Add(this.pnlCells);
		base.Controls.Add(this.txtConsole);
		base.Controls.Add(this.pctSurface);
		base.Controls.Add(this.txtCellName);
		base.Controls.Add(this.cmbSegFlags);
		base.Controls.Add(this.lblSegFlags);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.cmbLayer);
		base.Controls.Add(this.lstMapCells);
		base.Controls.Add(this.lstCells);
		base.Controls.Add(this.lblSheetsOrEntities);
		base.Controls.Add(this.lstSheets);
		base.Controls.Add(this.menuStrip1);
		base.MainMenuStrip = this.menuStrip1;
		base.Name = "GUI";
		this.Text = "Salmon Maps";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(GUI_FormClosed);
		base.Load += new System.EventHandler(GUI_Load);
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		this.pnlCells.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pctCells).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pctSurface).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
