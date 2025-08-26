using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CharlieWin.chars.script;
using DialogEdit.dialog;
using LootEdit;
using LootEdit.loot;
using MapEdit.character;
using MapEdit.glows;
using MapEdit.map;
using MapEdit.map.sequence;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterEdit.monsters;
using ProjectTower;
using ProjectTower.director;
using ProjectTower.director.bloom;
using ProjectTower.map;
using ProjectTower.map.entities;
using ProjectTower.particles;
using ProjectTower.particles.env;
using ProjectTower.texturesheet;
using SheetEdit.TextureSheet;
using xCharEdit;
using xCharEdit.Character;

namespace MapEdit;

public class Game1 : Game
{
	public static int selSeg = -1;

	public static int recordedSelSequence = -1;

	public static Map[] sequenceEditMap = new Map[2];

	public static int selCol = 0;

	public static bool recordSequenceMode = false;

	public static bool showSequences = false;

	public static bool hideInactiveLayers = false;

	public static bool isCtrl = false;

	public static bool isShift = false;

	public static bool indoors = false;

	private float gZoom = -10f;

	private GraphicsDeviceManager graphics;

	public const int FILTER_ALL = 0;

	public const int FILTER_RINGS = 1;

	public const int FILTER_CHARMS = 2;

	public const int FILTER_SPELLS = 3;

	public const int FILTER_ARMOR = 4;

	public const int FILTER_WEAPONS = 5;

	public const int FILTER_SHIELDS = 6;

	public const int FILTER_MATERIALS = 7;

	public static bool brandMode;

	public static int filter;

	public static int mouseWheel;

	private Vector2 pmVec;

	public static bool needsExit;

	public static bool needsPaletteDraw;

	private Texture2D iconsTex;

	public static Texture2D nullTex;

	private const int RECT_NORMAL = 0;

	private const int RECT_GRAY = 1;

	private const int RECT_OUTLINE = 2;

	private const int RECT_SEG = 3;

	public static Dictionary<string, XTexture> textures;

	public static Dictionary<string, TreeNode> nodes;

	public static bool needsActorUpdate;

	private MouseState mouseState;

	private MouseState preState;

	private static PortalGlowMgr portalGlowMgr;

	private Dictionary<string, MemoryStream> textureMemStream;

	private Dictionary<string, Image> imageStream;

	public static string selTex;

	public static int selIdx;

	public static int selLayer;

	public static TreeNode selPaletteNode;

	public static List<int> paletteCellIdx;

	public static bool showMapGrid;

	public static bool highlightLayer;

	public static bool drawLight;

	public static bool hideBossBounds;

	public static bool needsBake;

	public static bool bakeSepia;

	public static Map map;

	public static bool showBloomTextures;

	public static bool flipMode;

	public Texture2D[] mapBack;

	private RenderTarget2D lightTarg;

	private RenderTarget2D mainTarg;

	private RenderTarget2D sceneTarg;

	private RenderTarget2D backTarg;

	private RenderTarget2D auxTarg;

	private RenderTarget2D flipTarg;

	private RenderTarget2D paletteTarget;

	private Effect mainEffect;

	private Effect bloomTintEffect;

	private Effect pmaEffect;

    private KeyboardState oldKeyState;
    private static int ctrlClickCounter;

	public static SpriteFont arial;

	public static bool showColMap;

	public static GlowMgr glowMgr;

	public static DotsMgr dotsMgr;

	public static Dictionary<string, CharDef> charDef;

	public static ActorMgr actorMgr;

	private Microsoft.Xna.Framework.Input.Keys[] pKeys;

	public static bool carts;

	public static bool brooms;

	public static bool highway;

	public static float frameTime;

	public static bool showneighbors;

	public static string title;

	private string pTitle;

	public static ParticleManager pMan;

	public IntPtr drawSurface;

	public const int PALETTE_CELL_WIDTH = 56;

	public const int PALETTE_CELL_HEIGHT = 56;

	public const int PALETTE_COL_COUNT = 5;

	// Glue/Parenting state
	private struct GroupMemberRef
	{
		public int layerIndex;
		public int segIndex;
	}

	private class GluedChild
	{
		public GroupMemberRef member;
		public Vector2 localOffset; // In parent-local XY basis
		public float localRotation; // child.rotation - parent.rotation
		public Vector2 scaleRatio; // child.scale / parent.scale
	}

	private static bool glueActive;
	private static GroupMemberRef glueParent;
	private static readonly List<GluedChild> gluedChildren = new List<GluedChild>();
	private static bool parentTransformChanged;

	// Prefab mode: gate glue/parenting behaviors to Prefabs only
	public static bool prefabMode;

	// Helper for prefab spawn block insertion without ValueTuple
	private class PrefabSpawnEntry
	{
		public bool isParent;
		public int order;
		public int savedLayer;
		public Seg seg;
		public float offX;
		public float offY;
		public float rot;
		public float srx;
		public float sry;
	}

	private static bool lockAllLatch;

	public Game1(IntPtr drawSurface)
	{
		graphics = new GraphicsDeviceManager(this);
		base.Content.RootDirectory = "Content";
		this.drawSurface = drawSurface;
		graphics.PreparingDeviceSettings += graphics_PreparingDeviceSettings;
		Control.FromHandle(base.Window.Handle).VisibleChanged += Game1_VisibleChanged;
	}

	private void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
	{
		e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface;
	}

	private void Game1_VisibleChanged(object sender, EventArgs e)
	{
		if (Control.FromHandle(base.Window.Handle).Visible)
		{
			Control.FromHandle(base.Window.Handle).Visible = false;
		}
	}

	protected override void Initialize()
	{
		Rand.rand = new Random();
		ScrollManager.Init(base.GraphicsDevice, new Vector2(1280f, 720f));
		ScrollManager.UpdateCannedValues();
		portalGlowMgr = new PortalGlowMgr();
		BlinkPlatMgr.Init();
		map = new Map();
		dotsMgr = new DotsMgr();
		graphics.PreferredBackBufferWidth = 1280;
		graphics.PreferredBackBufferHeight = 720;
		graphics.ApplyChanges();
		base.Initialize();
	}

	protected override void LoadContent()
	{
		ContentRig.Init(base.Content);
		ScriptCommandParser.Init();
		SpriteTools.Init(base.GraphicsDevice);
		iconsTex = base.Content.Load<Texture2D>("gfx/icons");
		nullTex = base.Content.Load<Texture2D>("gfx/1x1");
		arial = base.Content.Load<SpriteFont>("gfx/arial");
		mainTarg = new RenderTarget2D(base.GraphicsDevice, 1280, 720);
		backTarg = new RenderTarget2D(base.GraphicsDevice, 1280, 720);
		auxTarg = new RenderTarget2D(base.GraphicsDevice, 1280, 720);
		lightTarg = new RenderTarget2D(base.GraphicsDevice, 1280, 720);
		sceneTarg = new RenderTarget2D(base.GraphicsDevice, 1280, 720);
		flipTarg = new RenderTarget2D(base.GraphicsDevice, 1280, 720);
		paletteTarget = new RenderTarget2D(base.GraphicsDevice, 512, 2048);
		mainEffect = base.Content.Load<Effect>("fx/main");
		bloomTintEffect = base.Content.Load<Effect>("fx/bloomtint");
		pmaEffect = base.Content.Load<Effect>("fx/pma");
		RefractDraw.Init(base.GraphicsDevice, base.Content);
		RefractDraw.CreateTarg(base.GraphicsDevice);
		BloomComponent.Init(base.GraphicsDevice, base.Content);
		BloomComponent.CreateTargs(base.GraphicsDevice);
		WorldMapBaker.Init(base.Content);
		LayerTintCatalog.Init(base.Content, base.GraphicsDevice);
		Water.Init(base.GraphicsDevice, base.Content);
		ParticleCatalog.Init();
		mapBack = new Texture2D[3]
		{
			base.Content.Load<Texture2D>("gfx/mapback0"),
			base.Content.Load<Texture2D>("gfx/mapback1"),
			base.Content.Load<Texture2D>("gfx/mapback2")
		};
		glowMgr = new GlowMgr(base.Content);
		textures = new Dictionary<string, XTexture>();
		nodes = new Dictionary<string, TreeNode>();
		BinaryReader binaryReader = new BinaryReader(File.Open(ContentRig.basePath + "\\texturesheet\\master.zcm", FileMode.Open, FileAccess.Read));
		int num = binaryReader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			string text = binaryReader.ReadString();
			XTexture xTexture = ((!(text == "sprites")) ? new XTexture(text, binaryReader, null) : new XTexture(text, binaryReader, ContentRig.LoadTextureFromFile("\\gfx\\" + text + ".png")));
			textures.Add(xTexture.name, xTexture);
		}
		if (File.Exists(ContentRig.basePath + "\\gfx\\trees.zcm"))
		{
			binaryReader = new BinaryReader(File.Open(ContentRig.basePath + "\\gfx\\trees.zcm", FileMode.Open, FileAccess.Read));
			int num2 = binaryReader.ReadInt32();
			for (int j = 0; j < num2; j++)
			{
				string text2 = binaryReader.ReadString();
				TreeNode treeNode = MapCellTreeManager.ReadCellNodes(binaryReader);
				treeNode.Text = text2;
				nodes.Add(text2, treeNode);
			}
			binaryReader.Close();
		}
		else
		{
			foreach (KeyValuePair<string, XTexture> texture in textures)
			{
				TreeNode treeNode2 = MapCellTreeManager.CreateCellTree(texture.Value);
				treeNode2.Text = texture.Key;
				nodes.Add(texture.Key, treeNode2);
			}
		}
		Textures.tex = new XTexture[1];
		Textures.tex[0] = textures["sprites"];
		ParticleManager.spritesTexIdx = 0;
		ParticleManager.Init();
		charDef = new Dictionary<string, CharDef>();
		List<string> list = new List<string>();
		FileInfo[] files = new DirectoryInfo("./characters/").GetFiles("*.zsx");
		foreach (FileInfo fileInfo in files)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
			charDef.Add(fileNameWithoutExtension, new CharDef(fileInfo.FullName));
			list.Add(fileNameWithoutExtension);
		}
		actorMgr = new ActorMgr();
		LootCatalog.Init();
		LootCatalog.ReadMaster();
		MonsterCatalog.Init();
		MonsterCatalog.ReadMaster();
		binaryReader.Close();
		DialogMgr.Init();
		BinaryReader binaryReader2 = new BinaryReader(File.Open("dialog/dialog.zdx", FileMode.Open, FileAccess.Read));
		DialogMgr.Read(binaryReader2);
		binaryReader2.Close();
		Program.gui.Initialize();
	}

	private void DrawPalette()
	{
		// Do not use the normal texture palette rendering in Prefabs mode
		if (prefabMode || (selTex != null && string.Equals(selTex, "Prefabs", StringComparison.OrdinalIgnoreCase)))
		{
			return;
		}
		paletteCellIdx = new List<int>();
		base.GraphicsDevice.SetRenderTarget(paletteTarget);
		base.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0.2f, 0.2f, 0.2f, 1f));
		SpriteTools.BeginAlpha();
		XTexture xTexture = textures[selTex];
		int num = 0;
		int num2 = 0;
		int[] nodeIndices = Program.gui.GetNodeIndices(selPaletteNode, nodes[selTex]);
		if (nodeIndices != null)
		{
			MapCellTreeManager.GetNodeType(nodes[selTex]);
			for (int i = 0; i < nodeIndices.Length; i++)
			{
				if (nodeIndices[i] <= -1)
				{
					continue;
				}
				int num3 = nodeIndices[i];
				paletteCellIdx.Add(num3);
				XSprite xSprite = xTexture.cell[num3];
				Microsoft.Xna.Framework.Rectangle srcRect = xSprite.srcRect;
				float num4 = ((xSprite.srcRect.Width <= xSprite.srcRect.Height) ? (56f / (float)xSprite.srcRect.Height) : (56f / (float)xSprite.srcRect.Width));
				float num5 = (float)xSprite.srcRect.Width * num4;
				float num6 = (float)xSprite.srcRect.Height * num4;
				Microsoft.Xna.Framework.Rectangle destinationRectangle = new Microsoft.Xna.Framework.Rectangle(num2 * 56 + 28 - (int)((double)num5 / 2.0), num * 56 + 28 - (int)((double)num6 / 2.0), (int)num5, (int)num6);
				SpriteTools.sprite.Draw(xTexture.texture, destinationRectangle, srcRect, Microsoft.Xna.Framework.Color.White);
				if (i < xTexture.cell.Length - 1)
				{
					num2++;
					if (num2 >= 5)
					{
						num2 = 0;
						num++;
					}
				}
			}
		}
		SpriteTools.End();
		base.GraphicsDevice.SetRenderTarget(null);
		if (selPaletteNode == null)
		{
			return;
		}
		string text = selPaletteNode.Text;
		for (TreeNode parent = selPaletteNode.Parent; parent != null; parent = parent.Parent)
		{
			text = parent.Text + "\\" + text;
		}
		Program.gui.ConsoleWriteLine(text);
		if (textureMemStream == null)
		{
			textureMemStream = new Dictionary<string, MemoryStream>();
		}
		if (imageStream == null)
		{
			imageStream = new Dictionary<string, Image>();
		}
		int width = 280;
		int height = 56 * (num + 1);
		if (textureMemStream.ContainsKey(text) && imageStream.ContainsKey(text))
		{
			Program.gui.SetPictureImage(imageStream[text], width, height);
			return;
		}
		textureMemStream.Add(text, new MemoryStream());
		try
		{
			paletteTarget.SaveAsPng(textureMemStream[text], paletteTarget.Width, paletteTarget.Height);
			imageStream[text] = Image.FromStream(textureMemStream[text]);
			Program.gui.SetPictureImage(imageStream[text], width, height);
		}
		catch
		{
		}
	}

	protected override void UnloadContent()
	{
	}

	public void DrawRectangle(Microsoft.Xna.Framework.Rectangle rect, bool selected, int type)
	{
		DrawRectangle(rect, selected, type, 1f);
	}

	public void DrawSequence()
	{
		if (showSequences)
		{
			SpriteTools.BeginAdditive();
			for (int i = 0; i < map.sequenceMgr.sequences.Count; i++)
			{
				map.sequenceMgr.Draw(i);
			}
			SpriteTools.End();
		}
		else if (selLayer == 22 && selSeg >= 0 && selSeg < map.sequenceMgr.sequences.Count)
		{
			SpriteTools.BeginAdditive();
			map.sequenceMgr.Draw(selSeg);
			SpriteTools.End();
		}
	}

	public void DrawRectangle(Microsoft.Xna.Framework.Rectangle rect, bool selected, int type, float z)
	{
		float num = (selected ? 0.3f : 0.15f);
		Microsoft.Xna.Framework.Rectangle destinationRectangle = new Microsoft.Xna.Framework.Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		Vector2 screenLoc = ScrollManager.GetScreenLoc(new Vector2(destinationRectangle.X, destinationRectangle.Y), z);
		Vector2 screenLoc2 = ScrollManager.GetScreenLoc(new Vector2(destinationRectangle.Right, destinationRectangle.Bottom), z);
		float num2 = 0f;
		if (type == 1)
		{
			num2 = 1f;
		}
		if (type == 3)
		{
			num2 = 1f;
			num = 0.2f;
		}
		destinationRectangle.X = (int)screenLoc.X;
		destinationRectangle.Y = (int)screenLoc.Y;
		destinationRectangle.Width = (int)((double)screenLoc2.X - (double)screenLoc.X);
		destinationRectangle.Height = (int)((double)screenLoc2.Y - (double)screenLoc.Y);
		if (type != 2 && (type != 3 || selected))
		{
			SpriteTools.sprite.Draw(nullTex, destinationRectangle, new Microsoft.Xna.Framework.Color(new Vector4(1f, num2, num2, num)));
		}
		if (type == 3 && selected)
		{
			num *= 4f;
		}
		SpriteTools.sprite.Draw(nullTex, new Microsoft.Xna.Framework.Rectangle(destinationRectangle.X, destinationRectangle.Y, destinationRectangle.Width, 1), new Microsoft.Xna.Framework.Color(new Vector4(1f, num2, num2, num * 2f)));
		SpriteTools.sprite.Draw(nullTex, new Microsoft.Xna.Framework.Rectangle(destinationRectangle.X, destinationRectangle.Bottom - 1, destinationRectangle.Width, 1), new Microsoft.Xna.Framework.Color(new Vector4(1f, num2, num2, num * 2f)));
		SpriteTools.sprite.Draw(nullTex, new Microsoft.Xna.Framework.Rectangle(destinationRectangle.X, destinationRectangle.Top, 1, destinationRectangle.Height), new Microsoft.Xna.Framework.Color(new Vector4(1f, num2, num2, num * 2f)));
		SpriteTools.sprite.Draw(nullTex, new Microsoft.Xna.Framework.Rectangle(destinationRectangle.Right - 1, destinationRectangle.Top, 1, destinationRectangle.Height), new Microsoft.Xna.Framework.Color(new Vector4(1f, num2, num2, num * 2f)));
	}

	protected override void Update(GameTime gameTime)
	{
		if (needsExit)
		{
			Exit();
		}
		ScrollManager.UpdateCannedValues();
		glowMgr.Update();
		Map map = Game1.map;
		if (recordSequenceMode)
		{
			map = sequenceEditMap[1];
		}
		BlinkPlatMgr.Update();
		map.mapUpdate.Update();
		portalGlowMgr.Update();
		if (title != pTitle && title != null)
		{
			base.Window.Title = title;
		}
		Microsoft.Xna.Framework.Input.Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < pressedKeys.Length; i++)
		{
			switch (pressedKeys[i])
			{
			case Microsoft.Xna.Framework.Input.Keys.LeftShift:
			case Microsoft.Xna.Framework.Input.Keys.RightShift:
				flag2 = true;
				break;
			case Microsoft.Xna.Framework.Input.Keys.LeftControl:
			case Microsoft.Xna.Framework.Input.Keys.RightControl:
				flag = true;
				break;
			}
		}
		// Don't reset counter when Ctrl is released - only reset after save
		isCtrl = flag;
		Game1.map.RefreshDepths();
		if (recordSequenceMode)
		{
			for (int j = 0; j < 2; j++)
			{
				sequenceEditMap[j].RefreshDepths();
			}
		}
		mouseState = Mouse.GetState();
		Vector2 vector = MVec();
		actorMgr.Update(gameTime);
		dotsMgr.Update(frameTime);
		ParticleManager.UpdateParticles();
		Water.Update(map.layer[5]);
		frameTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
		if ((double)ScrollManager.zoom < (double)gZoom)
		{
			ScrollManager.zoom += (float)(((double)gZoom - (double)ScrollManager.zoom) * (double)frameTime * 3.0);
			if ((double)ScrollManager.zoom > (double)gZoom)
			{
				ScrollManager.zoom = gZoom;
			}
		}
		if ((double)ScrollManager.zoom > (double)gZoom)
		{
			ScrollManager.zoom += (float)(((double)gZoom - (double)ScrollManager.zoom) * (double)frameTime * 3.0);
			if ((double)ScrollManager.zoom < (double)gZoom)
			{
				ScrollManager.zoom = gZoom;
			}
		}
		if (selLayer == 19 && (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed || mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed))
		{
			needsActorUpdate = true;
		}
		if (needsActorUpdate)
		{
			try
			{
				int num = 0;
				int num2 = 19;
				foreach (Seg item in map.layer[num2].seg)
				{
					if (item == null)
					{
						continue;
					}
					_ = item.texture == "sack";
					foreach (MonsterDef item2 in MonsterCatalog.catalog)
					{
						if (!(item2.name == item.texture))
						{
							continue;
						}
						string text = "idle";
						if (item.strFlag != null && item.strFlag.Contains("deadin"))
						{
							text = "deadin";
						}
						if (item2.ai == 12 || item2.ai == 31 || item2.ai == 9)
						{
							text = "sleep";
						}
						if (item.texture == "deadprop" && item.strFlag != null && item.strFlag.StartsWith("deadprop"))
						{
							string[] array = item.strFlag.Split(' ');
							if (array.Length > 1)
							{
								text = array[1].Split('\r')[0];
							}
						}
						if (item2.type == 5 && item.strFlag != null && item.strFlag.StartsWith("trap"))
						{
							string[] array2 = item.strFlag.Split(' ');
							if (array2.Length > 1)
							{
								text = array2[1].Split('\r')[0];
							}
						}
						if (num >= actorMgr.actor.Count)
						{
							actorMgr.AddActor(new Vector2(item.loc.X, item.loc.Y), item2, charDef[item2.def], 1, text, item.depth);
						}
						else if (!actorMgr.actor[num].exists || actorMgr.actor[num].mDef.name != item.texture || actorMgr.actor[num].animName != text)
						{
							actorMgr.actor[num].Init(new Vector2(item.loc.X, item.loc.Y), item2, charDef[item2.def], 1, text, item.depth);
						}
						actorMgr.actor[num].loc = new Vector2(item.loc.X, item.loc.Y);
						actorMgr.actor[num].face = item.intFlag;
						if (item.strFlag == null || !item.strFlag.Contains("npcstyle"))
						{
							continue;
						}
						int num3 = item.strFlag.IndexOf("npcstyle") + 9;
						if (num3 >= item.strFlag.Length)
						{
							continue;
						}
						try
						{
							string text2 = item.strFlag.Substring(num3);
							if (text2.Contains('\r'))
							{
								text2 = text2.Split('\r')[0];
							}
							switch (Convert.ToInt32(text2))
							{
							case 0:
								if (actorMgr.actor[num].animName != "sit")
								{
									actorMgr.actor[num].SetAnim("sit");
								}
								if (actorMgr.actor[num].key < 3)
								{
									actorMgr.actor[num].key = 3;
								}
								break;
							case 1:
								if (brandMode)
								{
									if (actorMgr.actor[num].animName != "noblesbrand")
									{
										actorMgr.actor[num].SetAnim("noblesbrand");
									}
								}
								else if (actorMgr.actor[num].animName != "nobles")
								{
									actorMgr.actor[num].SetAnim("nobles");
								}
								break;
							case 2:
								if (brandMode)
								{
									if (actorMgr.actor[num].animName != "jesterbrand")
									{
										actorMgr.actor[num].SetAnim("jesterbrand");
									}
								}
								else if (actorMgr.actor[num].animName != "jest")
								{
									actorMgr.actor[num].SetAnim("jest");
								}
								break;
							case 3:
								if (brandMode)
								{
									if (actorMgr.actor[num].animName != "ledgebrand")
									{
										actorMgr.actor[num].SetAnim("ledgebrand");
									}
								}
								else if (actorMgr.actor[num].animName != "sadledge")
								{
									actorMgr.actor[num].SetAnim("sadledge");
								}
								break;
							case 4:
								if (actorMgr.actor[num].animName != "oldman")
								{
									actorMgr.actor[num].SetAnim("oldman");
								}
								break;
							case 5:
								if (actorMgr.actor[num].animName != "hunchledge")
								{
									actorMgr.actor[num].SetAnim("hunchledge");
								}
								break;
							case 6:
								if (actorMgr.actor[num].animName != "captain")
								{
									actorMgr.actor[num].SetAnim("captain");
								}
								break;
							case 7:
								if (actorMgr.actor[num].animName != "boatman")
								{
									actorMgr.actor[num].SetAnim("boatman");
								}
								break;
							case 8:
								if (actorMgr.actor[num].animName != "princess")
								{
									actorMgr.actor[num].SetAnim("princess");
								}
								break;
							case 9:
								if (actorMgr.actor[num].animName != "princessmaid")
								{
									actorMgr.actor[num].SetAnim("princessmaid");
								}
								break;
							case 10:
								if (actorMgr.actor[num].animName != "hidle")
								{
									actorMgr.actor[num].SetAnim("hidle");
								}
								break;
							}
						}
						catch (Exception)
						{
						}
					}
					num++;
				}
				while (actorMgr.actor.Count > num)
				{
					actorMgr.actor.RemoveAt(num);
				}
				needsActorUpdate = false;
			}
			catch (Exception)
			{
				Program.gui.ConsoleWriteLine("Update error");
			}
		}
		bool flag3 = true;
		if (selLayer > -1 && selLayer < 20 && selSeg > -1 && selSeg < map.layer[selLayer].seg.Count)
		{
			try
			{
				Seg seg = map.layer[selLayer].seg[selSeg];
				Vector2 screenLoc = ScrollManager.GetScreenLoc(seg.loc, seg.depth);
				if (!((double)screenLoc.X >= 0.0) || !((double)screenLoc.Y >= 0.0) || !((double)screenLoc.X <= (double)ScrollManager.screenSize.X) || !((double)screenLoc.Y <= (double)ScrollManager.screenSize.Y))
				{
					flag3 = false;
				}
			}
			catch
			{
			}
		}
		if (Program.gui.IsPictureFocus() && (double)vector.X > 0.0 && (double)vector.Y > 0.0 && (double)vector.X < 1280.0 && (double)vector.Y < 720.0)
		{
			// Ctrl+MouseWheel: scale active group; else zoom
			if (mouseWheel != 0)
			{
				if (isCtrl && prefabMode && glueActive && TryGetParentSeg(out Seg parentSeg))
				{
					if (parentSeg.isLocked) { /* ignore when locked */ }
					else {
					float step = (mouseWheel > 0 ? 1f : -1f) * 0.05f;
					Vector2 deltaScale = new Vector2(step, step);
					parentSeg.scaling += deltaScale;
					ClampScale(parentSeg);
					parentTransformChanged = true;
					RecomputeChildrenFromParent();
					}
				}
				else
				{
					gZoom += (float)mouseWheel / 44f;
				}
			}
			if (mouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && preState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				Vector2 vector2 = vector - pmVec;
				if (flag2)
				{
					if (glueActive && TryGetParentSeg(out Seg pSc))
					{
						if (flipMode)
						{
							vector2 *= new Vector2(-1f, -1f);
						}
						pSc.scaling += vector2 / ScrollManager.GetSize(1f) * 0.01f;
						ClampScale(pSc);
						parentTransformChanged = true;
						RecomputeChildrenFromParent();
					}
					else if (selLayer > -1 && selLayer < 20 && selSeg > -1)
					{
						Seg seg2 = map.layer[selLayer].seg[selSeg];
						if (seg2 != null && flag3)
						{
							if (flipMode)
							{
								vector2 *= new Vector2(-1f, -1f);
							}
							seg2.scaling += vector2 / ScrollManager.GetSize(1f) * 0.01f;
						}
					}
				}
				else
				{
					ScrollManager.scroll -= vector2 / ScrollManager.GetSize(1f);
				}
			}
			switch (selLayer)
			{
			case 20:
			{
				if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
				{
					Vector2 realLoc3 = ScrollManager.GetRealLoc(vector, 1f);
					int num12 = (int)((double)realLoc3.X / 64.0);
					int num13 = (int)((double)realLoc3.Y / 32.0);
					if ((double)realLoc3.X < 0.0)
					{
						num12--;
					}
					if ((double)realLoc3.Y < 0.0)
					{
						num13--;
					}
					int num14 = num12;
					int num15 = num13;
					int num16 = num12 + 1;
					int num17 = num13 + 1;
					if (flag2)
					{
						num14 -= 2;
						num16 += 2;
						num15 -= 2;
						num17 += 2;
					}
					for (int m = num14; m < num16; m++)
					{
						for (int n = num15; n < num17; n++)
						{
							map.SetCol(m, n, selCol, -1);
						}
					}
				}
				if (mouseState.RightButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
				{
					break;
				}
				Vector2 realLoc4 = ScrollManager.GetRealLoc(vector, 1f);
				int num18 = (int)((double)realLoc4.X / 64.0);
				int num19 = (int)((double)realLoc4.Y / 32.0);
				if (num18 >= 0 && num19 >= 0 && num18 < map.xUnits && num19 < map.yUnits * 2)
				{
					try
					{
						map.col[num18, num19].col = 0;
					}
					catch
					{
					}
				}
				break;
			}
			case 21:
				if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
				{
					Vector2 realLoc = ScrollManager.GetRealLoc(vector, 1f);
					int num4 = (int)((double)realLoc.X / 64.0);
					int num5 = (int)((double)realLoc.Y / 32.0);
					if ((double)realLoc.X < 0.0)
					{
						num4--;
					}
					if ((double)realLoc.Y < 0.0)
					{
						num5--;
					}
					int num6 = num4;
					int num7 = num5;
					int num8 = num4 + 1;
					int num9 = num5 + 1;
					if (flag2)
					{
						num6 -= 2;
						num8 += 2;
						num7 -= 2;
						num9 += 2;
					}
					for (int k = num6; k < num8; k++)
					{
						for (int l = num7; l < num9; l++)
						{
							map.SetCol(k, l, -1, selCol);
						}
					}
				}
				if (mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
				{
					Vector2 realLoc2 = ScrollManager.GetRealLoc(vector, 1f);
					int num10 = (int)((double)realLoc2.X / 64.0);
					int num11 = (int)((double)realLoc2.Y / 32.0);
					if (num10 >= 0 && num11 >= 0 && num10 < map.xUnits && num11 < map.yUnits * 2)
					{
						map.col[num10, num11].col = 0;
					}
				}
				break;
			}
			int num20 = selSeg;
						if (preState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && selLayer > -1 && selLayer < 20)
			{
				// Ctrl+Left-click counter for autosave
                if (flag)
				{
					ctrlClickCounter++;
					if (ctrlClickCounter >= 15)
					{
						try { Program.gui.PerformSave(); } catch {}
						ctrlClickCounter = 0;
					}
				}
				// Only reset counter when Ctrl is not held (not on every left-click)
				Layer layer = map.layer[selLayer];
				for (int num21 = 0; num21 < layer.seg.Count; num21++)
				{
					Seg seg3 = layer.seg[num21];
					if (seg3 != null)
					{
						Microsoft.Xna.Framework.Rectangle segRect = GetSegRect(seg3, selLayer);
						Vector2 realLoc5 = ScrollManager.GetRealLoc(vector, seg3.depth);
						if ((double)realLoc5.X > (double)segRect.Left && (double)realLoc5.Y > (double)segRect.Top && (double)realLoc5.X < (double)segRect.Right && (double)realLoc5.Y < (double)segRect.Bottom)
						{
							// In Prefabs mode with an active group, prevent selecting group members
							if (prefabMode && glueActive && IsInActiveGroup(selLayer, num21))
							{
								// Skip selection
							}
							else if (!seg3.isLocked)
							{
								selSeg = num21;
							}
						}
					}
				}
				if (selSeg != num20)
				{
					Program.gui.UpdateSelSeg();
				}
				else if (flag && !recordSequenceMode)
				{
					Seg seg4 = new Seg();
					seg4.CopyFrom(layer.seg[selSeg]);
					layer.seg.Add(seg4);
					selSeg = layer.seg.Count - 1;
					Program.gui.PopulateMapCells();
					Program.gui.UpdateSelSeg();
					preState = mouseState;
					map.mapGrid.needsUpdate = true;
					needsActorUpdate = true;
					return;
				}
			}
			if (preState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Released && mouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				for (int num22 = 0; num22 < actorMgr.actor.Count; num22++)
				{
					actorMgr.actor[num22].cFrame = 0f;
					actorMgr.actor[num22].key = 0;
				}
			}
			// Move: if in prefab mode and a glue parent exists, route LMB drag to the parent
			if (preState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && ((selLayer > -1 && selLayer < 20 && selSeg > -1 && selSeg < map.layer[selLayer].seg.Count) || (prefabMode && glueActive)))
			{
				try
				{
					if (prefabMode && glueActive && TryGetParentSeg(out Seg pSeg))
					{
						if (!pSeg.isLocked)
						{
							Vector2 vector3 = vector - pmVec;
							pSeg.loc += vector3 / ScrollManager.GetSize(pSeg.depth);
							parentTransformChanged = true;
							RecomputeChildrenFromParent();
						}
					}
					else
					{
						Seg seg5 = map.layer[selLayer].seg[selSeg];
						if (seg5 != null && flag3 && !seg5.isLocked)
						{
							Vector2 vector3 = vector - pmVec;
							seg5.loc += vector3 / ScrollManager.GetSize(seg5.depth);
						}
					}
				}
				catch (Exception)
				{
					Program.gui.ConsoleWriteLine("Update error");
				}
			}
			if (preState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
			{
				map.mapGrid.needsUpdate = true;
				needsActorUpdate = true;
			}
			// Right-click rotation: in prefab mode, route to parent if group is active
			if (preState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && ((selLayer > -1 && selLayer < 20 && selSeg > -1) || (prefabMode && glueActive)))
			{
				if (prefabMode && glueActive && TryGetParentSeg(out Seg pRot))
				{
					if (!pRot.isLocked)
					{
						Vector2 vector4 = vector - pmVec;
						if (flipMode) vector4.Y *= -1f;
						pRot.rotation += vector4.Y / 120f;
						while ((double)pRot.rotation < 0.0) pRot.rotation += 6.28f;
						while ((double)pRot.rotation > 6.28000020980835) pRot.rotation -= 6.28f;
						parentTransformChanged = true;
						RecomputeChildrenFromParent();
					}
				}
				else
				{
					Seg seg6 = map.layer[selLayer].seg[selSeg];
					if (seg6 != null && flag3 && !seg6.isLocked)
					{
						Vector2 vector4 = vector - pmVec;
						if (selLayer == 19)
						{
							if ((double)vector4.Y > 0.0)
							{
								seg6.intFlag = 0;
							}
							else if ((double)vector4.Y < 0.0)
							{
								seg6.intFlag = 1;
							}
						}
						else
						{
							if (flipMode)
							{
								vector4.Y *= -1f;
							}
							seg6.rotation += vector4.Y / 120f;
							while ((double)seg6.rotation < 0.0)
							{
								seg6.rotation += 6.28f;
							}
							while ((double)seg6.rotation > 6.28000020980835)
							{
								seg6.rotation -= 6.28f;
							}
						}
					}
				}
			}
			
			if (Program.gui.IsPictureFocus())
			{
				UpdateKeys(flag3);
			}
		}
		ScrollManager.UpdateCannedValues();
		pmVec = vector;
		mouseWheel = 0;
		preState = mouseState;
		base.Update(gameTime);
	}

	public static Vector2 MVec()
	{
		System.Drawing.Point mousePosition = Control.MousePosition;
		Vector2 pictureVec = Program.gui.GetPictureVec();
		if (!flipMode)
		{
			return new Vector2((float)mousePosition.X - pictureVec.X, (float)mousePosition.Y - pictureVec.Y);
		}
		return new Vector2(1280f, 720f) - new Vector2((float)mousePosition.X - pictureVec.X, (float)mousePosition.Y - pictureVec.Y);
	}

	private void UpdateKeys(bool inView) 
	{
		KeyboardState state = Keyboard.GetState();
		Microsoft.Xna.Framework.Input.Keys[] pressedKeys = state.GetPressedKeys();
		Microsoft.Xna.Framework.Input.Keys[] pressedKeys2 = oldKeyState.GetPressedKeys();
		
		// Fix Shift key detection - check both left and right shift
		isShift = state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift) || state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightShift);
		bool ctrlDown = state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl) || state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightControl);
		
		for (int i = 0; i < pressedKeys.Length; i++)
		{
			bool flag = true;
			for (int j = 0; j < pressedKeys2.Length; j++)
			{
				if (pressedKeys[i] == pressedKeys2[j])
				{
					flag = false;
				}
			}
			if (!flag || pressedKeys[i] != Microsoft.Xna.Framework.Input.Keys.Delete)
			{
				continue;
			}
			try
			{
				if (glueActive && TryGetParentSeg(out Seg delParent))
				{
					DeleteActiveGroup();
				}
				else if (inView && selLayer > -1 && selLayer < 20 && selSeg > -1)
				{
					map.sequenceMgr.UpdateAffectedSegs();
					map.sequenceMgr.Delete(selLayer, selSeg);
					map.layer[selLayer].seg.Remove(map.layer[selLayer].seg[selSeg]);
					map.mapGrid.needsUpdate = true;
					needsActorUpdate = true;
				}
			}
			catch
			{
			}
			Program.gui.PopulateMapCells();
		}

		// Ctrl+Shift+Space: toggle lock state for all segments (all layers)
		if (ctrlDown && isShift && state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space) && !lockAllLatch)
		{
			lockAllLatch = true;
			bool anyUnlocked = false;
			for (int l = 0; l < 20; l++)
			{
				Layer layer = map.layer[l];
				for (int i = 0; i < layer.seg.Count; i++)
				{
					Seg s = layer.seg[i];
					if (s == null) continue;
					if (!s.isLocked) { anyUnlocked = true; break; }
				}
				if (anyUnlocked) break;
			}
			for (int l = 0; l < 20; l++)
			{
				Layer layer = map.layer[l];
				for (int i = 0; i < layer.seg.Count; i++)
				{
					Seg s = layer.seg[i];
					if (s == null) continue;
					s.isLocked = anyUnlocked; // if any unlocked -> lock all; else unlock all
				}
			}
			return;
		}
		// Reset latch when Space is released
		if (!state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space)) lockAllLatch = false;

		// Space: toggle lock on selected or hovered segment
		if (WasKeyJustPressed(pressedKeys, pressedKeys2, Microsoft.Xna.Framework.Input.Keys.Space))
		{
			// Shift+Space disabled; if Shift is held without Ctrl, ignore; if Ctrl+Shift handled above
			if (isShift) { return; }
 			// If an object is selected, lock it but keep the layer selected for spawning
 			if (selLayer > -1 && selLayer < 20 && selSeg > -1)
 			{
 				Seg selectedSeg = map.layer[selLayer].seg[selSeg];
 				if (selectedSeg != null)
 				{
 					selectedSeg.isLocked = !selectedSeg.isLocked;
 					// Only deselect the specific segment, keep the layer selected
 					selSeg = -1;
 				}
 			}
 			// If no object is selected, lock/unlock the hovered object (include current layer)
 			else
 			{
 				int hLayer, hSeg;
 				if (TryGetHoveredSegment(out hLayer, out hSeg, true)) // Include current layer for Space key
 				{
 					map.layer[hLayer].seg[hSeg].isLocked = !map.layer[hLayer].seg[hSeg].isLocked;
 				}
 			}
 		}

		// Shift+Arrow disabled for lock/unlock (use Shift+Space instead)

		// Ctrl+/: jump to hovered segment's sheet and layer (smart selection)
		if (ctrlDown && WasKeyJustPressed(pressedKeys, pressedKeys2, Microsoft.Xna.Framework.Input.Keys.OemQuestion))
		{
			int hLayer, hSeg;
			if (TryGetHoveredSegment(out hLayer, out hSeg))
			{
				Seg s = map.layer[hLayer].seg[hSeg];
				if (s != null && !string.IsNullOrEmpty(s.texture) && Game1.textures.ContainsKey(s.texture))
				{
					Program.gui.SwitchToLayerAndSheet(hLayer, s.texture);
				}
			}
		}

		// G: glue – only in prefab mode; first press sets parent from selected; then glue hovered as child (ignore Ctrl+G)
		if (prefabMode && !ctrlDown && WasKeyJustPressed(pressedKeys, pressedKeys2, Microsoft.Xna.Framework.Input.Keys.G))
		{
			if (!glueActive)
			{
				if (selLayer > -1 && selLayer < 20 && selSeg > -1 && selSeg < map.layer[selLayer].seg.Count)
				{
					SetGlueParent(selLayer, selSeg);
				}
			}
			else
			{
				int hLayer, hSeg;
				if (TryGetHoveredSegment(out hLayer, out hSeg, true))
				{
					TryGlueChild(hLayer, hSeg);
				}
			}
		}

		// U: unglue all (only in prefab mode)
		if (prefabMode && WasKeyJustPressed(pressedKeys, pressedKeys2, Microsoft.Xna.Framework.Input.Keys.U))
		{
			UnglueAll();
		}

		// Ctrl+',' and Ctrl+'.' scale group around parent pivot (only in prefab mode)
		if (prefabMode && ctrlDown && WasKeyJustPressed(pressedKeys, pressedKeys2, Microsoft.Xna.Framework.Input.Keys.OemComma))
		{
			if (glueActive && TryGetParentSeg(out Seg s1))
			{
				s1.scaling *= 0.5f;
				ClampScale(s1);
				parentTransformChanged = true;
				RecomputeChildrenFromParent();
			}
		}
		if (prefabMode && ctrlDown && WasKeyJustPressed(pressedKeys, pressedKeys2, Microsoft.Xna.Framework.Input.Keys.OemPeriod))
		{
			if (glueActive && TryGetParentSeg(out Seg s2))
			{
				s2.scaling *= 2f;
				ClampScale(s2);
				parentTransformChanged = true;
				RecomputeChildrenFromParent();
			}
		}

		// Ctrl+Up / Ctrl+Down: move entire group within layer ordering (preserve internal order) – prefab mode only
		if (prefabMode && ctrlDown && WasKeyJustPressed(pressedKeys, pressedKeys2, Microsoft.Xna.Framework.Input.Keys.Up))
		{
			if (glueActive)
			{
				MoveActiveGroupInLayer(true);
			}
		}
		if (prefabMode && ctrlDown && WasKeyJustPressed(pressedKeys, pressedKeys2, Microsoft.Xna.Framework.Input.Keys.Down))
		{
			if (glueActive)
			{
				MoveActiveGroupInLayer(false);
			}
		}

		// Ctrl+Shift+S: save current prefab definition (parent + children) to ./prefabs
		if (prefabMode && ctrlDown && isShift && WasKeyJustPressed(pressedKeys, pressedKeys2, Microsoft.Xna.Framework.Input.Keys.S))
		{
			if (glueActive && TryGetParentSeg(out Seg _))
			{
				try { SaveActivePrefab(); Program.gui.ConsoleWriteLine("Prefab saved to ./prefabs/"); } catch {}
			}
		}

		oldKeyState = state;
	}

	private bool WasKeyJustPressed(Microsoft.Xna.Framework.Input.Keys[] now, Microsoft.Xna.Framework.Input.Keys[] before, Microsoft.Xna.Framework.Input.Keys key)
	{
		bool n = false, b = false;
		for (int i = 0; i < now.Length; i++) if (now[i] == key) { n = true; break; }
		for (int j = 0; j < before.Length; j++) if (before[j] == key) { b = true; break; }
		return n && !b;
	}

	private bool TryGetHoveredSegment(out int hoveredLayer, out int hoveredSeg, bool includeCurrentLayer = false)
	{
		hoveredLayer = -1;
		hoveredSeg = -1;
		Vector2 m = MVec();
 		
		// Prioritize layers based on current environment and visual depth
		int[] priority = new int[20];
		int priorityIndex = 0;
 		
		// For smart selection (Ctrl+/), ignore current layer
		// For Space key locking/unlocking, include current layer
		if (indoors)
		{
			// Inside: prioritize layers 18, 17, 16 (foreground) over 11, 12, 13, 14, 15 (background)
			for (int l = 18; l >= 11; l--)
			{
				if (includeCurrentLayer || l != selLayer) // Include current layer if requested
				{
					priority[priorityIndex++] = l;
				}
			}
		}
		else
		{
			// Outside: prioritize layers 10, 9, 8 (foreground) over 0, 1, 2, 3, 4, 5 (background)
			for (int l = 10; l >= 0; l--)
			{
				if (includeCurrentLayer || l != selLayer) // Include current layer if requested
				{
					priority[priorityIndex++] = l;
				}
			}
		}
 		
		// Search through prioritized layers
		for (int p = 0; p < priorityIndex; p++)
		{
			int l = priority[p];
			if (l < 0 || l >= 20) continue;
			if (!IsLayerInCurrentEnvironment(l)) continue;
 			Layer layerData = map.layer[l];
			// Iterate segments backwards to prioritize visually recent/top entries
			for (int i = layerData.seg.Count - 1; i >= 0; i--)
			{
				Seg s = layerData.seg[i];
				if (s == null) continue;
				// In Prefabs mode, ignore assets that are already part of the active group (parent or children)
				if (prefabMode && glueActive && IsInActiveGroup(l, i)) continue;
				var rect = GetSegRect(s, l);
				Vector2 rl = ScrollManager.GetRealLoc(m, s.depth);
				if ((double)rl.X > (double)rect.Left && (double)rl.Y > (double)rect.Top && (double)rl.X < (double)rect.Right && (double)rl.Y < (double)rect.Bottom)
				{
					hoveredLayer = l;
					hoveredSeg = i;
					return true;
				}
			}
		}
		return false;
	}
	
	private bool IsLayerInCurrentEnvironment(int l)
	{
		// Outside art layers: 0..10, Inside art layers: 11..18
		if (indoors)
		{
			return l >= 11 && l <= 18;
		}
		else
		{
			return l >= 0 && l <= 10;
		}
	}



	public static void SwapSegs(int i, int j)
	{
		map.sequenceMgr.UpdateAffectedSegs();
		try
		{
			if (selLayer > -1 && selLayer < 3)
			{
				Seg seg = map.layer[selLayer].seg[i];
				Seg seg2 = map.layer[selLayer].seg[j];
				if (seg != null && seg2 != null)
				{
					Seg seg3 = new Seg();
					seg3.CopyFrom(seg);
					seg.CopyFrom(seg2);
					seg2.CopyFrom(seg3);
					selSeg = j;
					map.sequenceMgr.Swap(selLayer, i, j);
				}
			}
		}
		catch
		{
		}
	}

	public Microsoft.Xna.Framework.Rectangle GetSegRect(Seg seg, int layer)
	{
		if (layer == 19)
		{
			return new Microsoft.Xna.Framework.Rectangle((int)seg.loc.X - 60, (int)seg.loc.Y - 200, 120, 200);
		}
		Vector2 loc = seg.loc;
		try
		{
			XSprite xSprite = textures[seg.texture].cell[seg.idx];
			Vector2 vector = new Vector2((float)Math.Cos(seg.rotation) * ((float)xSprite.srcRect.Right - xSprite.origin.X) * seg.scaling.X, (float)Math.Sin(seg.rotation) * ((float)xSprite.srcRect.Right - xSprite.origin.X) * seg.scaling.X);
			Vector2 vector2 = new Vector2((float)Math.Cos((double)seg.rotation + 1.57000005245209) * ((float)xSprite.srcRect.Bottom - xSprite.origin.Y) * seg.scaling.Y, (float)Math.Sin((double)seg.rotation + 1.57000005245209) * ((float)xSprite.srcRect.Bottom - xSprite.origin.Y) * seg.scaling.Y);
			Vector2 vector3 = new Vector2((float)Math.Cos(seg.rotation) * (xSprite.origin.X - (float)xSprite.srcRect.X) * seg.scaling.X, (float)Math.Sin(seg.rotation) * (xSprite.origin.X - (float)xSprite.srcRect.X) * seg.scaling.X);
			Vector2 vector4 = new Vector2((float)Math.Cos((double)seg.rotation + 1.57000005245209) * (xSprite.origin.Y - (float)xSprite.srcRect.Y) * seg.scaling.Y, (float)Math.Sin((double)seg.rotation + 1.57000005245209) * (xSprite.origin.Y - (float)xSprite.srcRect.Y) * seg.scaling.Y);
			Vector2 vector5 = loc - vector3 - vector4;
			Vector2 vector6 = loc + vector - vector4;
			Vector2 vector7 = loc - vector3 + vector2;
			Vector2 vector8 = loc + vector + vector2;
			Vector2 vector9 = loc;
			Vector2 vector10 = loc;
			if ((double)vector6.X < (double)vector9.X)
			{
				vector9.X = vector6.X;
			}
			if ((double)vector6.Y < (double)vector9.Y)
			{
				vector9.Y = vector6.Y;
			}
			if ((double)vector7.X < (double)vector9.X)
			{
				vector9.X = vector7.X;
			}
			if ((double)vector7.Y < (double)vector9.Y)
			{
				vector9.Y = vector7.Y;
			}
			if ((double)vector8.X < (double)vector9.X)
			{
				vector9.X = vector8.X;
			}
			if ((double)vector8.Y < (double)vector9.Y)
			{
				vector9.Y = vector8.Y;
			}
			if ((double)vector5.X < (double)vector9.X)
			{
				vector9.X = vector5.X;
			}
			if ((double)vector5.Y < (double)vector9.Y)
			{
				vector9.Y = vector5.Y;
			}
			if ((double)vector6.X > (double)vector10.X)
			{
				vector10.X = vector6.X;
			}
			if ((double)vector6.Y > (double)vector10.Y)
			{
				vector10.Y = vector6.Y;
			}
			if ((double)vector7.X > (double)vector10.X)
			{
				vector10.X = vector7.X;
			}
			if ((double)vector7.Y > (double)vector10.Y)
			{
				vector10.Y = vector7.Y;
			}
			if ((double)vector8.X > (double)vector10.X)
			{
				vector10.X = vector8.X;
			}
			if ((double)vector8.Y > (double)vector10.Y)
			{
				vector10.Y = vector8.Y;
			}
			if ((double)vector5.X > (double)vector10.X)
			{
				vector10.X = vector5.X;
			}
			if ((double)vector5.Y > (double)vector10.Y)
			{
				vector10.Y = vector5.Y;
			}
			return new Microsoft.Xna.Framework.Rectangle((int)vector9.X, (int)vector9.Y, (int)((double)vector10.X - (double)vector9.X), (int)((double)vector10.Y - (double)vector9.Y));
		}
		catch
		{
			return default(Microsoft.Xna.Framework.Rectangle);
		}
	}

	protected override void Draw(GameTime gameTime)
	{
		if (needsPaletteDraw && selTex != null)
		{
			XTexture xTexture = textures[selTex];
			if (xTexture.texture == null)
			{
				xTexture.texture = ContentRig.LoadTextureFromFile("\\gfx\\" + xTexture.name + ".png");
			}
			DrawPalette();
			needsPaletteDraw = false;
		}
		if (needsBake)
		{
			WorldMapBaker.Draw(base.GraphicsDevice, bloomTintEffect, pmaEffect, bakeSepia);
			needsBake = false;
		}
		Map map = Game1.map;
		if (recordSequenceMode)
		{
			map = (isCtrl ? sequenceEditMap[0] : sequenceEditMap[1]);
		}
		map.background = 0;
		int num = -1;
		int num2 = (int)((double)ScrollManager.scroll.X / 64.0);
		int num3 = (int)((double)ScrollManager.scroll.Y / 32.0);
		if (num2 >= 0 && num3 >= 0 && num2 < map.xUnits && num3 < map.yUnits)
		{
			num = map.col[num2, num3].layer;
			indoors = LayerTintCatalog.layerTintData[num].indoors;
			switch (num)
			{
			case 25:
				map.background = 1;
				break;
			case 26:
				map.background = 2;
				break;
			}
		}
		base.GraphicsDevice.SetRenderTarget(backTarg);
		base.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
		SpriteTools.BeginAlpha();
		if (map.background > -1 && !indoors)
		{
			try
			{
				SpriteTools.sprite.Draw(mapBack[map.background], new Microsoft.Xna.Framework.Rectangle(0, 0, (int)ScrollManager.screenSize.X, (int)ScrollManager.screenSize.Y), new Microsoft.Xna.Framework.Color(LayerTintCatalog.layerTintData[num].bgR, LayerTintCatalog.layerTintData[num].bgG, LayerTintCatalog.layerTintData[num].bgB, 1f));
			}
			catch
			{
			}
		}
		if (hideInactiveLayers && selLayer >= 0 && selLayer < 19)
		{
            map.Draw(selLayer, selLayer + 1, glowMgr, bloomTintEffect, 1f);
        }
		else if (indoors)
		{
			map.Draw(11, 15, glowMgr, bloomTintEffect, 1f);
			map.Draw(15, 16, glowMgr, bloomTintEffect, 1f);
		}
		else
		{
			map.Draw(0, 5, glowMgr, bloomTintEffect, 1f);
			map.Draw(5, 6, glowMgr, bloomTintEffect, 1f);
		}
		SpriteTools.End();
		SpriteTools.BeginSubtractive();
		ParticleManager.Draw(0);
		ParticleManager.Draw(3);
		SpriteTools.End();
		SpriteTools.BeginAlpha();
		ParticleManager.Draw(1);
		ParticleManager.Draw(4);
		SpriteTools.End();
		SpriteTools.BeginAdditive();
		ParticleManager.Draw(2);
		ParticleManager.Draw(5);
		SpriteTools.End();
		RefractDraw.Draw(auxTarg, backTarg);
		SpriteTools.BeginAlpha();
		for (int i = 0; i < actorMgr.actor.Count; i++)
		{
			if (actorMgr.actor[i] != null && actorMgr.actor[i].exists && actorMgr.actor[i].cDef != null)
			{
				actorMgr.actor[i].Draw(textures[actorMgr.actor[i].mDef.texture], 1f);
			}
		}
		SpriteTools.End();
		if (drawLight)
		{
			glowMgr.Prepare(textures["sprites"], lightTarg);
		}
		else
		{
			base.GraphicsDevice.SetRenderTarget(lightTarg);
			base.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(0f, 0f, 0f, 1f));
		}
		Water.Prepare(auxTarg);
		base.GraphicsDevice.SetRenderTarget(mainTarg);
		base.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
		SpriteTools.BeginOpaque();
		SpriteTools.sprite.Draw(auxTarg, new Microsoft.Xna.Framework.Rectangle(0, 0, (int)ScrollManager.screenSize.X, (int)ScrollManager.screenSize.Y), Microsoft.Xna.Framework.Color.White);
		SpriteTools.End();
		Water.Draw();
		SpriteTools.BeginAlpha();
		if (!hideInactiveLayers)
		{
			if (indoors)
			{
				map.Draw(16, 19, glowMgr, bloomTintEffect, 1f);
			}
			else
			{
				map.Draw(6, 11, glowMgr, bloomTintEffect, 1f);
			}
		}
		SpriteTools.End();
		SpriteTools.BeginAdditive();
		dotsMgr.DrawFore();
		glowMgr.Draw(textures["sprites"]);
		glowMgr.Clear();
		SpriteTools.End();
		base.GraphicsDevice.SetRenderTarget(sceneTarg);
		LayerTintCatalog.PrepareMainEffect(mainEffect, num, num, 1f);
		SpriteTools.BeginAlpha(mainEffect);
		SpriteTools.sprite.Draw(mainTarg, new Microsoft.Xna.Framework.Rectangle(0, 0, (int)ScrollManager.screenSize.X, (int)ScrollManager.screenSize.Y), Microsoft.Xna.Framework.Color.White);
		SpriteTools.End();
		LayerTintCatalog.Finalize(num, num, 1f);
		if (drawLight)
		{
			glowMgr.Draw(lightTarg);
		}
		if (flipMode)
		{
			BloomComponent.Draw(flipTarg, sceneTarg, lightTarg);
		}
		else
		{
			BloomComponent.Draw(null, sceneTarg, lightTarg);
		}
		SpriteTools.BeginPMAlpha();
		map.mapEditDraw.DrawChests(arial);
		SpriteTools.End();
		SpriteTools.BeginAlpha();
		DrawRectangle(new Microsoft.Xna.Framework.Rectangle(0, 0, map.xUnits * 64, (int)((double)(map.yUnits * 64) * 0.5)), selected: false, 2);
		DrawSelected();
		
		// Draw lock indicators over locked segments
		if (iconsTex != null)
		{
			for (int l = 0; l < 20; l++)
			{
				Layer layer = map.layer[l];
				for (int i = 0; i < layer.seg.Count; i++)
				{
					Seg s = layer.seg[i];
					if (s != null && s.isLocked)
					{
						Vector2 screenPos = ScrollManager.GetScreenLoc(s.loc, s.depth);
						if (screenPos.X > -50 && screenPos.X < ScrollManager.screenSize.X + 50 && 
							screenPos.Y > -50 && screenPos.Y < ScrollManager.screenSize.Y + 50)
						{
							// Draw a small lock icon above the locked segment
							Vector2 lockPos = new Vector2(screenPos.X - 8, screenPos.Y - 20);
							Microsoft.Xna.Framework.Color lockColor = new Microsoft.Xna.Framework.Color(1f, 0.5f, 0.5f, 0.8f); // Semi-transparent red
							SpriteTools.sprite.Draw(iconsTex, lockPos, new Microsoft.Xna.Framework.Rectangle(0, 0, 16, 16), lockColor, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 1f);
						}
					}
				}
			}
		}
		
		// Draw prefab parent/child badges (visual only)
		DrawGlueBadges();
		
		DrawCol();
		DrawPreview();
		if (showBloomTextures)
		{
			BloomComponent.DrawTargets();
		}
		SpriteTools.End();
		DrawSequence();
		if (flipMode)
		{
			base.GraphicsDevice.SetRenderTarget(null);
			SpriteTools.BeginOpaque();
			SpriteTools.sprite.Draw(flipTarg, new Vector2(1280f, 720f) / 2f, new Microsoft.Xna.Framework.Rectangle(0, 0, 1280, 720), Microsoft.Xna.Framework.Color.White, 3.141593f, new Vector2(1280f, 720f) / 2f, 1f, SpriteEffects.None, 1f);
			SpriteTools.End();
		}
		SpriteTools.sprite.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
		Vector2 realLoc = ScrollManager.GetRealLoc(MVec(), 1f);
		SpriteTools.sprite.DrawString(arial, realLoc.ToString() + " " + (int)((double)realLoc.X / 64.0) + ", " + (int)((double)realLoc.Y / 32.0), new Vector2(50f, 670f), Microsoft.Xna.Framework.Color.White);
		
		// Draw autosave counter with better positioning and styling
		if (arial != null)
		{
			string autosaveText = $"Clicks until autosave: {15 - ctrlClickCounter}";
			// Position it below the coordinate display, with a slight offset for better readability
			Vector2 autosavePos = new Vector2(50f, 690f);
			// Use a slightly different color to distinguish it from coordinates but keep it visible
			Microsoft.Xna.Framework.Color autosaveColor = new Microsoft.Xna.Framework.Color(0.9f, 0.9f, 1f, 1f);
			SpriteTools.sprite.DrawString(arial, autosaveText, autosavePos, autosaveColor);
			
			// Draw locked assets indicator
			int lockedCount = 0;
			for (int l = 0; l < 20; l++)
			{
				Layer layer = map.layer[l];
				for (int i = 0; i < layer.seg.Count; i++)
				{
					Seg s = layer.seg[i];
					if (s != null && s.isLocked)
					{
						lockedCount++;
					}
				}
			}
			
			if (lockedCount > 0)
			{
				string lockedText = $"Locked assets: {lockedCount}";
				Vector2 lockedPos = new Vector2(50f, 710f);
				Microsoft.Xna.Framework.Color lockedColor = new Microsoft.Xna.Framework.Color(1f, 0.8f, 0.8f, 1f); // Light red
				SpriteTools.sprite.DrawString(arial, lockedText, lockedPos, lockedColor);
			}
		}
		
		if (recordSequenceMode)
		{
			SpriteTools.sprite.DrawString(arial, "REC", new Vector2(70f, 640f), Microsoft.Xna.Framework.Color.White);
			SpriteTools.sprite.Draw(nullTex, new Vector2(50f, 645f), new Microsoft.Xna.Framework.Rectangle(0, 0, 1, 1), Microsoft.Xna.Framework.Color.Red, 0f, default(Vector2), new Vector2(18f, 18f), SpriteEffects.None, 1f);
		}
		SpriteTools.End();
		if (WorldMapBaker.baked)
		{
			SpriteTools.BeginOpaque();
			SpriteTools.sprite.Draw(WorldMapBaker.outTarg, new Microsoft.Xna.Framework.Rectangle(0, 0, 800, 800), new Microsoft.Xna.Framework.Rectangle(800, 400, 800, 800), Microsoft.Xna.Framework.Color.White);
			SpriteTools.sprite.Draw(WorldMapBaker.outTarg, new Microsoft.Xna.Framework.Rectangle(640, 0, 800, 400), new Microsoft.Xna.Framework.Rectangle(0, 0, WorldMapBaker.outTarg.Width, WorldMapBaker.outTarg.Height), Microsoft.Xna.Framework.Color.White);
			SpriteTools.End();
		}
		base.Draw(gameTime);
	}

	private void DrawPreview()
	{
		if (selTex != null && textures.ContainsKey(selTex) && selIdx > -1 && selIdx < textures[selTex].cell.Length && textures[selTex].cell[selIdx] != null)
		{
			Microsoft.Xna.Framework.Rectangle srcRect = textures[selTex].cell[selIdx].srcRect;
			Microsoft.Xna.Framework.Rectangle destinationRectangle = srcRect;
			destinationRectangle.X = 0;
			destinationRectangle.Y = 0;
			float num = ((destinationRectangle.Width <= destinationRectangle.Height) ? (100f / (float)destinationRectangle.Height) : (100f / (float)destinationRectangle.Width));
			destinationRectangle.Width = (int)((double)destinationRectangle.Width * (double)num);
			destinationRectangle.Height = (int)((double)destinationRectangle.Height * (double)num);
			if (textures[selTex].texture == null)
			{
				textures[selTex].texture = ContentRig.LoadTextureFromFile("\\gfx\\" + selTex + ".png");
			}
			SpriteTools.sprite.Draw(textures[selTex].texture, destinationRectangle, srcRect, new Microsoft.Xna.Framework.Color(1f, 1f, 1f, 0.8f));
		}
	}

	private void DrawCol()
	{
		Map map = Game1.map;
		if (recordSequenceMode && !isCtrl)
		{
			map = sequenceEditMap[1];
		}
		if (selLayer == 21)
		{
			map.mapEditDraw.DrawLayers();
		}
		if (selLayer == 20 || showColMap)
		{
			map.mapEditDraw.DrawCol();
		}
	}

	private void DrawSelected()
	{
            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && mouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Released && mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
		{
			int num = -1;
			if (selLayer > -1 && selLayer < 20)
			{
				Layer layer = map.layer[selLayer];
				for (int i = 0; i < layer.seg.Count; i++)
				{
					Seg seg = layer.seg[i];
					if (seg != null)
					{
						Microsoft.Xna.Framework.Rectangle segRect = GetSegRect(seg, selLayer);
						Vector2 realLoc = ScrollManager.GetRealLoc(MVec(), seg.depth);
						if ((double)realLoc.X > (double)segRect.Left && (double)realLoc.Y > (double)segRect.Top && (double)realLoc.X < (double)segRect.Right && (double)realLoc.Y < (double)segRect.Bottom)
						{
                                if (!seg.isLocked) num = i;
						}
					}
				}
			}
			if (num > -1)
			{
				DrawRectangle(GetSegRect(map.layer[selLayer].seg[num], selLayer), selected: false, 3, map.layer[selLayer].seg[num].depth);
			}
		}
		if (selSeg <= -1 || selLayer <= -1 || selLayer >= 20 || selSeg > map.layer[selLayer].seg.Count)
		{
			return;
		}
		try
		{
			if (selSeg < map.layer[selLayer].seg.Count)
			{
				Microsoft.Xna.Framework.Rectangle segRect2 = GetSegRect(map.layer[selLayer].seg[selSeg], selLayer);
				DrawRectangle(segRect2, selected: true, 3, map.layer[selLayer].seg[selSeg].depth);
				SpriteTools.End();
				SpriteTools.sprite.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
				float rotation = 0f;
				if (flipMode)
				{
					rotation = 3.141593f;
				}
				SpriteTools.sprite.DrawString(arial, map.layer[selLayer].seg[selSeg].loc.ToString(), ScrollManager.GetScreenLoc(new Vector2(segRect2.X, segRect2.Y), map.layer[selLayer].seg[selSeg].depth), Microsoft.Xna.Framework.Color.White, rotation, new Vector2(0f, 24f), 1f, SpriteEffects.None, 1f);
				SpriteTools.sprite.DrawString(arial, map.layer[selLayer].seg[selSeg].texture, ScrollManager.GetScreenLoc(new Vector2(segRect2.X, segRect2.Y), map.layer[selLayer].seg[selSeg].depth) + new Vector2(0f, -20f), Microsoft.Xna.Framework.Color.White, rotation, new Vector2(0f, 24f), 1f, SpriteEffects.None, 1f);
				SpriteTools.End();
				SpriteTools.BeginAlpha();
			}
		}
		catch
		{
			Program.gui.ConsoleWriteLine("Drawselected error");
		}
	}

	private void DrawCursor()
	{
		Microsoft.Xna.Framework.Rectangle value = default(Microsoft.Xna.Framework.Rectangle);
		Microsoft.Xna.Framework.Color white = Microsoft.Xna.Framework.Color.White;
		value.X = 0;
		value.Y = 0;
		value.Width = 32;
		value.Height = 32;
		SpriteTools.sprite.Draw(iconsTex, MVec(), value, white, 0f, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
	}

	internal static void InitSequenceRecord(int idx)
	{
		recordedSelSequence = idx;
		recordSequenceMode = true;
		for (int i = 0; i < 2; i++)
		{
			sequenceEditMap[i] = new Map();
			sequenceEditMap[i].CopyFrom(map);
		}
		map.sequenceMgr.sequences[recordedSelSequence].InitRecord();
	}

	internal static void SetSequenceRecord()
	{
		Sequence sequence = map.sequenceMgr.sequences[recordedSelSequence];
		sequence.Set(sequenceEditMap[1], sequenceEditMap[0]);
		sequence.editNode++;
		sequenceEditMap[0].CopyFrom(sequenceEditMap[1]);
	}

	internal static void FinalizeSequenceRecord()
	{
		try
		{
			map.sequenceMgr.sequences[recordedSelSequence].Set(sequenceEditMap[1], sequenceEditMap[0]);
			recordSequenceMode = false;
		}
		catch (Exception ex)
		{
			Program.gui.ConsoleWriteLine(ex.ToString());
		}
	}

	internal static void CleanupDupes()
	{
		int num = 0;
		Layer[] layer = map.layer;
		foreach (Layer l in layer)
		{
			while (CheckDupes(l))
			{
				num++;
			}
		}
		Program.gui.ConsoleWriteLine(num + " segments removed.");
	}

	private static bool CheckDupes(Layer l)
	{
		for (int i = 0; i < l.seg.Count; i++)
		{
			Seg seg = l.seg[i];
			for (int j = i + 1; j < l.seg.Count; j++)
			{
				Seg seg2 = l.seg[j];
				if (seg.idx == seg2.idx && seg.loc == seg2.loc && (double)seg.rotation == (double)seg2.rotation && seg.scaling == seg2.scaling)
				{
					l.seg.RemoveAt(j);
					return true;
				}
			}
		}
		return false;
	}

	public static bool GetValidCol(Vector2 v)
	{
		int num = (int)((double)v.X / 64.0);
		int num2 = (int)((double)v.Y / 32.0);
		if (num < 0 || num >= map.xUnits || num2 <= 0 || num2 >= map.yUnits * 2)
		{
			return false;
		}
		int col = map.col[num, num2].col;
		if (col == 0 || col == 15)
		{
			return false;
		}
		if (map.col[num, num2 - 1].col != 0)
		{
			return map.col[num, num2 - 1].col == 15;
		}
		return true;
	}

	public static float GetMinY(Vector2 v)
	{
		int num = (int)((double)v.X / 64.0);
		int num2 = (int)((double)v.Y / 32.0);
		float num3 = (float)(((double)v.X - (double)num * 64.0) / 64.0);
		float num4 = (float)(((double)v.Y - (double)num2 * 32.0) / 32.0);
		if (num < 0)
		{
			num = 0;
		}
		if (num >= map.xUnits)
		{
			num = map.xUnits - 1;
		}
		if (num >= 0 && num2 > 0 && num < map.xUnits && (double)num2 < (double)map.yUnits * 2.0 && map.col[num, num2].col == 1 && (map.col[num, num2 - 1].col == 2 || map.col[num, num2 - 1].col == 3) && (double)num4 < 10.0)
		{
			num2--;
			num4 += 1f;
		}
		float num5 = num4;
		if (num >= 0 && num2 >= 0 && num < map.xUnits && (double)num2 < (double)map.yUnits * 2.0)
		{
			switch (map.col[num, num2].col)
			{
			case 0:
			case 1:
			case 5:
			case 15:
				num5 = 0f;
				break;
			case 2:
			case 6:
				num5 = 1f - num3;
				break;
			case 3:
			case 7:
				num5 = num3;
				break;
			case 8:
				num5 = 1f - num3;
				break;
			case 9:
				num5 = num3;
				break;
			}
		}
		return (float)((double)num2 * 32.0 + (double)num5 * 32.0);
	}

	internal static void AnalyzeEntities()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		List<string> list = new List<string>();
		foreach (Seg item in map.layer[19].seg)
		{
			if (item == null || item.strFlag == null)
			{
				continue;
			}
			string strFlag = item.strFlag;
			char[] separator = new char[1] { '\n' };
			string[] array = strFlag.Split(separator);
			foreach (string text in array)
			{
				char[] separator2 = new char[1] { ' ' };
				string[] array2 = text.Split(separator2);
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] == "flag")
					{
						string texture = item.texture;
						if ((texture == "chest" || texture == "sack") && j < array2.Length - 1)
						{
							string text2 = array2[j + 1];
							if (text2.EndsWith("\r"))
							{
								text2 = text2.Substring(0, text2.Length - 1);
							}
							if (list.Contains(text2))
							{
								Program.gui.ConsoleWriteLine("Entity flag conflict: " + text2);
							}
							else
							{
								list.Add(text2);
							}
						}
					}
					if ((array2[j] == "chest" || array2[j] == "drops" || array2[j] == "drop") && j < array2.Length - 1)
					{
						string text3 = array2[j + 1];
						if (text3.EndsWith("\r"))
						{
							text3 = text3.Substring(0, text3.Length - 1);
						}
						if (dictionary.ContainsKey(text3))
						{
							dictionary[text3]++;
						}
						else
						{
							dictionary.Add(text3, 1);
						}
					}
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			int num = 5;
			switch (k)
			{
			case 0:
				num = 5;
				Program.gui.ConsoleWriteLine("Unused Magic:");
				break;
			case 1:
				num = 3;
				Program.gui.ConsoleWriteLine("Unused Rings:");
				break;
			case 2:
				num = 2;
				Program.gui.ConsoleWriteLine("Unused Armor:");
				break;
			case 3:
				num = 1;
				Program.gui.ConsoleWriteLine("Unused Shields:");
				break;
			}
			List<string> list2 = new List<string>();
			foreach (LootDef item2 in LootCatalog.category[num].loot)
			{
				list2.Add(item2.name);
			}
			foreach (KeyValuePair<string, int> item3 in dictionary)
			{
				if (list2.Contains(item3.Key))
				{
					list2.Remove(item3.Key);
				}
			}
			foreach (string item4 in list2)
			{
				Program.gui.ConsoleWriteLine("~" + item4);
			}
		}
		Program.gui.ConsoleWriteLine(dictionary.Count + " total");
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		while (dictionary.Count > 0)
		{
			string strB = "a";
			int num2 = -1;
			int num3 = 0;
			foreach (KeyValuePair<string, int> item5 in dictionary)
			{
				if (item5.Key.CompareTo(strB) < 0 || num2 == -1)
				{
					strB = item5.Key;
					num2 = num3;
				}
				num3++;
			}
			int num4 = 0;
			foreach (KeyValuePair<string, int> item6 in dictionary)
			{
				if (num4 == num2)
				{
					dictionary2.Add(item6.Key, item6.Value);
					dictionary.Remove(item6.Key);
					break;
				}
				num4++;
			}
		}
		int num5 = 0;
		foreach (KeyValuePair<string, int> item7 in dictionary2)
		{
			Program.gui.ConsoleWriteLine(num5 + ": " + item7.Key + ": " + item7.Value);
			num5++;
		}
	}

	private static bool TryGetParentSeg(out Seg parent)
	{
		parent = null;
		if (!glueActive) return false;
		if (glueParent.layerIndex < 0 || glueParent.layerIndex >= map.layer.Length) return false;
		Layer layerData = map.layer[glueParent.layerIndex];
		if (glueParent.segIndex < 0 || glueParent.segIndex >= layerData.seg.Count) return false;
		parent = layerData.seg[glueParent.segIndex];
		return parent != null;
	}

	private static void SetGlueParent(int layer, int seg)
	{
		glueParent = new GroupMemberRef { layerIndex = layer, segIndex = seg };
		gluedChildren.Clear();
		glueActive = true;
		parentTransformChanged = true;
	}

	private static void UnglueAll()
	{
		glueActive = false;
		gluedChildren.Clear();
		glueParent = default(GroupMemberRef);
		parentTransformChanged = false;
		// Also clear selection so further scaling/edits don't affect the dropped group
		selSeg = -1;
		try { Program.gui.UpdateSelSeg(); } catch { }
	}

	private static bool IsSameRef(int layer, int seg, GroupMemberRef r)
	{
		return r.layerIndex == layer && r.segIndex == seg;
	}

	private static bool TryGlueChild(int layer, int seg)
	{
		if (!glueActive || IsSameRef(layer, seg, glueParent)) return false;
		// Only allow gluing from the currently selected layer in Prefabs mode
		if (prefabMode && layer != selLayer) return false;
		if (!TryGetParentSeg(out Seg parentSeg)) return false;
		Layer childLayer = map.layer[layer];
		if (seg < 0 || seg >= childLayer.seg.Count) return false;
		Seg child = childLayer.seg[seg];
		if (child == null) return false;

		// Compute offsets in parent-local basis
		Vector2 delta = child.loc - parentSeg.loc;
		float px = (float)Math.Cos(parentSeg.rotation);
		float py = (float)Math.Sin(parentSeg.rotation);
		float qx = (float)Math.Cos(parentSeg.rotation + 1.57079637f);
		float qy = (float)Math.Sin(parentSeg.rotation + 1.57079637f);
		float localX = delta.X * px + delta.Y * py;
		float localY = delta.X * qx + delta.Y * qy;
		Vector2 localOffset = new Vector2(localX, localY);

		// Normalize by parent scale so a recompute does not nudge the child
		localOffset.X = SafeDiv(localOffset.X, parentSeg.scaling.X);
		localOffset.Y = SafeDiv(localOffset.Y, parentSeg.scaling.Y);

		// Rotation and scale ratios
		float localRot = child.rotation - parentSeg.rotation;
		while (localRot > 3.14159274f) localRot -= 6.28318548f;
		while (localRot < -3.14159274f) localRot += 6.28318548f;
		Vector2 ratio = new Vector2(
			SafeDiv(child.scaling.X, parentSeg.scaling.X),
			SafeDiv(child.scaling.Y, parentSeg.scaling.Y)
		);

		// Avoid duplicates
		if (!gluedChildren.Any(gc => gc.member.layerIndex == layer && gc.member.segIndex == seg))
		{
			gluedChildren.Add(new GluedChild
			{
				member = new GroupMemberRef { layerIndex = layer, segIndex = seg },
				localOffset = localOffset,
				localRotation = localRot,
				scaleRatio = ratio
			});
			parentTransformChanged = true;
			RecomputeChildrenFromParent();
			return true;
		}
		return false;
	}

	private static void RecomputeChildrenFromParent()
	{
		if (!glueActive || !parentTransformChanged) return;
		if (!TryGetParentSeg(out Seg parentSeg)) return;

		float px = (float)Math.Cos(parentSeg.rotation);
		float py = (float)Math.Sin(parentSeg.rotation);
		float qx = (float)Math.Cos(parentSeg.rotation + 1.57079637f);
		float qy = (float)Math.Sin(parentSeg.rotation + 1.57079637f);

		for (int i = 0; i < gluedChildren.Count; i++)
		{
			GluedChild gc = gluedChildren[i];
			if (gc.member.layerIndex < 0 || gc.member.layerIndex >= map.layer.Length) continue;
			Layer l = map.layer[gc.member.layerIndex];
			if (gc.member.segIndex < 0 || gc.member.segIndex >= l.seg.Count) continue;
			Seg child = l.seg[gc.member.segIndex];
			if (child == null) continue;

			Vector2 offsetWorld = new Vector2(
				gc.localOffset.X * px + gc.localOffset.Y * qx,
				gc.localOffset.X * py + gc.localOffset.Y * qy
			);
			// Apply parent scale to offsets
			offsetWorld *= new Vector2(parentSeg.scaling.X, parentSeg.scaling.Y);

			child.loc = parentSeg.loc + offsetWorld;
			child.rotation = WrapAngle(parentSeg.rotation + gc.localRotation);
			child.scaling = new Vector2(parentSeg.scaling.X * gc.scaleRatio.X, parentSeg.scaling.Y * gc.scaleRatio.Y);
		}

		parentTransformChanged = false;
	}

	private static float WrapAngle(float a)
	{
		while (a < 0f) a += 6.28318548f;
		while (a > 6.28318548f) a -= 6.28318548f;
		return a;
	}

	private static float SafeDiv(float a, float b)
	{
		if (Math.Abs(b) < 1e-4f) return 1f;
		return a / b;
	}

	private static void ClampScale(Seg s)
	{
		float min = 0.05f, max = 10f;
		s.scaling.X = Math.Min(max, Math.Max(min, s.scaling.X));
		s.scaling.Y = Math.Min(max, Math.Max(min, s.scaling.Y));
	}

	private static void MoveActiveGroupInLayer(bool toTop)
	{
		if (!glueActive) return;
		int targetLayer = selLayer;
		if (targetLayer < 0 || targetLayer >= map.layer.Length) return;
		Layer target = map.layer[targetLayer];
		// Capture references
		Seg parentRef = null;
		if (glueParent.layerIndex == targetLayer && glueParent.segIndex >= 0 && glueParent.segIndex < target.seg.Count)
		{
			parentRef = target.seg[glueParent.segIndex];
		}
		List<Seg> childRefs = new List<Seg>();
		for (int i = 0; i < gluedChildren.Count; i++)
		{
			var m = gluedChildren[i].member;
			if (m.layerIndex != targetLayer) { childRefs.Add(null); continue; }
			if (m.segIndex >= 0 && m.segIndex < target.seg.Count)
			{
				Seg s = target.seg[m.segIndex]; childRefs.Add(s);
			}
			else { childRefs.Add(null); }
		}
		// Build block in current order (parent first if present)
		List<Seg> block = new List<Seg>();
		if (parentRef != null) block.Add(parentRef);
		for (int i = 0; i < childRefs.Count; i++) { if (childRefs[i] != null && !block.Contains(childRefs[i])) block.Add(childRefs[i]); }
		block = block.OrderBy(s => target.seg.IndexOf(s)).ToList();
		if (block.Count == 0) { map.sequenceMgr.UpdateAffectedSegs(); Program.gui.PopulateMapCells(); return; }
		// Remove block
		for (int i = target.seg.Count - 1; i >= 0; i--) { if (block.Contains(target.seg[i])) target.seg.RemoveAt(i); }
		// Insert at desired edge preserving internal order
		if (toTop)
		{
			for (int i = 0; i < block.Count; i++) target.seg.Add(block[i]);
		}
		else
		{
			for (int i = block.Count - 1; i >= 0; i--) target.seg.Insert(0, block[i]);
		}
		// Remap glue indices strictly by reference
		if (parentRef != null)
		{
			int newParentIdx = target.seg.IndexOf(parentRef);
			if (newParentIdx >= 0) glueParent = new GroupMemberRef { layerIndex = targetLayer, segIndex = newParentIdx };
		}
		for (int i = 0; i < gluedChildren.Count; i++)
		{
			var m = gluedChildren[i].member;
			if (m.layerIndex != targetLayer) continue;
			Seg cref = childRefs[i]; if (cref == null) continue;
			int ni = target.seg.IndexOf(cref);
			if (ni >= 0) gluedChildren[i].member = new GroupMemberRef { layerIndex = targetLayer, segIndex = ni };
		}
		map.sequenceMgr.UpdateAffectedSegs();
		Program.gui.PopulateMapCells();
	}

	private static void DeleteActiveGroup()
	{
		if (!glueActive) return;
		// Delete children first to keep parent indices stable if possible
		// Collect member refs (parent + children)
		List<GroupMemberRef> refs = new List<GroupMemberRef>();
		refs.Add(glueParent);
		for (int i = 0; i < gluedChildren.Count; i++) refs.Add(gluedChildren[i].member);

		// Sort descending by seg index per layer so removals don't invalidate following indices
		foreach (var g in refs.GroupBy(r => r.layerIndex))
		{
			int layer = g.Key;
			Layer l = map.layer[layer];
			foreach (var r in g.OrderByDescending(x => x.segIndex))
			{
				if (r.segIndex >= 0 && r.segIndex < l.seg.Count)
				{
					map.sequenceMgr.UpdateAffectedSegs();
					map.sequenceMgr.Delete(layer, r.segIndex);
					l.seg.RemoveAt(r.segIndex);
				}
			}
		}
		map.mapGrid.needsUpdate = true;
		needsActorUpdate = true;
		UnglueAll();
	}

	public static bool HasActiveGlueGroup()
	{
		return glueActive;
	}

	private void DrawGlueBadges()
	{
		if (!prefabMode || !glueActive || arial == null)
		{
			return;
		}
		// Draw parent badge
		Seg parent;
		if (TryGetParentSeg(out parent))
		{
			Vector2 p = ScrollManager.GetScreenLoc(parent.loc, parent.depth);
			if (p.X > -50 && p.X < ScrollManager.screenSize.X + 50 && p.Y > -50 && p.Y < ScrollManager.screenSize.Y + 50)
			{
				// Shadow/outline
				SpriteTools.sprite.DrawString(arial, "P", p + new Vector2(1f, 1f), new Microsoft.Xna.Framework.Color(0f, 0f, 0f, 0.6f), 0f, new Vector2(8f, 24f), 1.0f, SpriteEffects.None, 1f);
				// Green P
				SpriteTools.sprite.DrawString(arial, "P", p, new Microsoft.Xna.Framework.Color(0.2f, 1f, 0.2f, 0.9f), 0f, new Vector2(8f, 24f), 1.0f, SpriteEffects.None, 1f);
			}
		}
		// Draw child badges
		for (int i = 0; i < gluedChildren.Count; i++)
		{
			var r = gluedChildren[i].member;
			if (r.layerIndex < 0 || r.layerIndex >= map.layer.Length) continue;
			Layer l = map.layer[r.layerIndex];
			if (r.segIndex < 0 || r.segIndex >= l.seg.Count) continue;
			Seg child = l.seg[r.segIndex];
			if (child == null) continue;
			Vector2 c = ScrollManager.GetScreenLoc(child.loc, child.depth);
			if (c.X > -50 && c.X < ScrollManager.screenSize.X + 50 && c.Y > -50 && c.Y < ScrollManager.screenSize.Y + 50)
			{
				SpriteTools.sprite.DrawString(arial, "C", c + new Vector2(1f, 1f), new Microsoft.Xna.Framework.Color(0f, 0f, 0f, 0.6f), 0f, new Vector2(8f, 24f), 1.0f, SpriteEffects.None, 1f);
				SpriteTools.sprite.DrawString(arial, "C", c, new Microsoft.Xna.Framework.Color(1f, 1f, 0.2f, 0.9f), 0f, new Vector2(8f, 24f), 1.0f, SpriteEffects.None, 1f);
			}
		}
	}

	private static bool IsInActiveGroup(int layerIndex, int segIndex)
	{
		if (!glueActive) return false;
		if (glueParent.layerIndex == layerIndex && glueParent.segIndex == segIndex) return true;
		for (int i = 0; i < gluedChildren.Count; i++)
		{
			var r = gluedChildren[i].member;
			if (r.layerIndex == layerIndex && r.segIndex == segIndex) return true;
		}
		return false;
	}

	private static void SaveActivePrefab()
	{
		if (!glueActive) return;
		Seg parent;
		if (!TryGetParentSeg(out parent)) return;
		string dir = "./prefabs";
		if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
		string name = $"prefab-{DateTime.UtcNow:yyyyMMddHHmmssfff}";
		string path = Path.Combine(dir, name + ".json");
		// Compute per-layer internal order (relative ordering within the group only)
		var layerToMembers = new Dictionary<int, List<PrefabSpawnEntry>>();
		// Add parent
		if (!layerToMembers.ContainsKey(glueParent.layerIndex)) layerToMembers[glueParent.layerIndex] = new List<PrefabSpawnEntry>();
		layerToMembers[glueParent.layerIndex].Add(new PrefabSpawnEntry { isParent = true, order = 0, seg = parent, offX = 0f, offY = 0f, rot = 0f, srx = 1f, sry = 1f });
		// Add children
		for (int i = 0; i < gluedChildren.Count; i++)
		{
			var r = gluedChildren[i].member;
			if (!layerToMembers.ContainsKey(r.layerIndex)) layerToMembers[r.layerIndex] = new List<PrefabSpawnEntry>();
			layerToMembers[r.layerIndex].Add(new PrefabSpawnEntry { isParent = false, order = i + 1, seg = map.layer[r.layerIndex].seg[r.segIndex], offX = 0f, offY = 0f, rot = 0f, srx = 1f, sry = 1f });
		}
		// Build order maps per layer using actual seg indices in the layer list (preserve draw stacking)
		var parentOrderMap = new Dictionary<int, int>(); // layer -> order
		var childOrderMap = new Dictionary<string, int>(); // key: layer|segIndex
		foreach (var kv in layerToMembers)
		{
			int layer = kv.Key;
			// Pair each entry with its current seg index in the layer for stable ordering
			var paired = new List<System.Collections.Generic.KeyValuePair<int, PrefabSpawnEntry>>();
			for (int i = 0; i < kv.Value.Count; i++)
			{
				PrefabSpawnEntry entry = kv.Value[i];
				int segIndex = map.layer[layer].seg.IndexOf(entry.seg);
				paired.Add(new System.Collections.Generic.KeyValuePair<int, PrefabSpawnEntry>(segIndex, entry));
			}
			var ordered = paired.OrderBy(p => p.Key).ToList();
			for (int rank = 0; rank < ordered.Count; rank++)
			{
				var item = ordered[rank];
				if (item.Value.isParent)
				{
					parentOrderMap[layer] = rank;
				}
				else
				{
					childOrderMap[layer.ToString() + "|" + item.Key.ToString()] = rank;
				}
			}
		}
		var sb = new System.Text.StringBuilder();
		sb.Append("{\n");
		sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "  \"parent\": {{ \"texture\": \"{0}\", \"idx\": {1}, \"scaleX\": {2}, \"scaleY\": {3}, \"rotation\": {4}, \"layer\": {5}, \"order\": {6} }},\n", parent.texture ?? "", parent.idx, parent.scaling.X, parent.scaling.Y, parent.rotation, glueParent.layerIndex, parentOrderMap.ContainsKey(glueParent.layerIndex) ? parentOrderMap[glueParent.layerIndex] : 0);
		sb.Append("  \"members\": [\n");
		for (int i = 0; i < gluedChildren.Count; i++)
		{
			var r = gluedChildren[i].member;
			if (r.layerIndex < 0 || r.layerIndex >= map.layer.Length) continue;
			Layer l = map.layer[r.layerIndex];
			if (r.segIndex < 0 || r.segIndex >= l.seg.Count) continue;
			Seg child = l.seg[r.segIndex];
			if (child == null) continue;
			var gc = gluedChildren[i];
			sb.Append("    {");
			sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "\"texture\": \"{0}\", \"idx\": {1}, \"layer\": {2}, ", child.texture ?? "", child.idx, r.layerIndex);
			sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "\"localOffsetX\": {0}, \"localOffsetY\": {1}, ", gc.localOffset.X, gc.localOffset.Y);
			sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "\"localRotation\": {0}, ", gc.localRotation);
			sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "\"scaleRatioX\": {0}, \"scaleRatioY\": {1}, ", gc.scaleRatio.X, gc.scaleRatio.Y);
			int cOrder = 0; childOrderMap.TryGetValue(r.layerIndex.ToString() + "|" + r.segIndex.ToString(), out cOrder);
			sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "\"order\": {0}", cOrder);
			sb.Append(" }");
			if (i < gluedChildren.Count - 1) sb.Append(",");
			sb.Append("\n");
		}
		sb.Append("  ]\n}");
		File.WriteAllText(path, sb.ToString());
		// Generate a thumbnail by drawing the group to a small render target and saving to PNG
		try
		{
			int tw = 112, th = 112;
			var gd = SpriteTools.sprite.GraphicsDevice;
			var rt = new Microsoft.Xna.Framework.Graphics.RenderTarget2D(gd, tw, th);
			gd.SetRenderTarget(rt);
			gd.Clear(Microsoft.Xna.Framework.Color.Transparent);
			SpriteTools.BeginAlpha();
			// Accurate fit: compute bounds of parent + children with rotation/scaling, then fit into thumbnail
			// Build a temporary list of segments with group-local positions
			List<Seg> groupSegs = new List<Seg>();
			Seg pCopy = new Seg(); pCopy.CopyFrom(parent); pCopy.loc = Vector2.Zero; groupSegs.Add(pCopy);
			for (int i = 0; i < gluedChildren.Count; i++)
			{
				var gc = gluedChildren[i];
				Seg c = new Seg();
				int layerIdx = gc.member.layerIndex; int segIdx = gc.member.segIndex;
				try { c.CopyFrom(map.layer[layerIdx].seg[segIdx]); } catch { continue; }
				// compute group-local loc using saved offsets and parent transform (no global offset)
				float px = (float)Math.Cos(parent.rotation); float py = (float)Math.Sin(parent.rotation);
				float qx = (float)Math.Cos(parent.rotation + 1.57079637f); float qy = (float)Math.Sin(parent.rotation + 1.57079637f);
				Vector2 worldOffset = new Vector2(gc.localOffset.X * parent.scaling.X, gc.localOffset.Y * parent.scaling.Y);
				Vector2 local = new Vector2(worldOffset.X * px + worldOffset.Y * qx, worldOffset.X * py + worldOffset.Y * qy);
				c.loc = local;
				groupSegs.Add(c);
			}
			// Compute bounds by transforming sprite corners for each seg
			float minX = float.MaxValue, minY = float.MaxValue, maxX = float.MinValue, maxY = float.MinValue;
			for (int i = 0; i < groupSegs.Count; i++)
			{
				Seg s = groupSegs[i];
				if (s == null || string.IsNullOrEmpty(s.texture) || !textures.ContainsKey(s.texture)) continue;
				try
				{
					var tex = textures[s.texture];
					var cell = tex.cell[s.idx];
					Vector2 origin = cell.origin - new Vector2(cell.srcRect.X, cell.srcRect.Y);
					float w = cell.srcRect.Width;
					float h = cell.srcRect.Height;
					// corners relative to origin
					Vector2[] corners = new Vector2[4];
					corners[0] = new Vector2(-origin.X, -origin.Y);
					corners[1] = new Vector2(w - origin.X, -origin.Y);
					corners[2] = new Vector2(-origin.X, h - origin.Y);
					corners[3] = new Vector2(w - origin.X, h - origin.Y);
					float cs = (float)Math.Cos(s.rotation), sn = (float)Math.Sin(s.rotation);
					for (int k = 0; k < 4; k++)
					{
						Vector2 v = corners[k];
						v.X *= s.scaling.X; v.Y *= s.scaling.Y;
						Vector2 rtv = new Vector2(v.X * cs - v.Y * sn, v.X * sn + v.Y * cs) + s.loc;
						if (rtv.X < minX) minX = rtv.X;
						if (rtv.Y < minY) minY = rtv.Y;
						if (rtv.X > maxX) maxX = rtv.X;
						if (rtv.Y > maxY) maxY = rtv.Y;
					}
				}
				catch { }
			}
			if (minX == float.MaxValue) { minX = -16; minY = -16; maxX = 16; maxY = 16; }
			Vector2 boundsSize = new Vector2(Math.Max(1f, maxX - minX), Math.Max(1f, maxY - minY));
			Vector2 boundsCenter = new Vector2((minX + maxX) / 2f, (minY + maxY) / 2f);
			float padding = 6f;
			float kx = (tw - padding) / boundsSize.X;
			float ky = (th - padding) / boundsSize.Y;
			float scaleK = Math.Max(0.01f, Math.Min(kx, ky));
 			Vector2 center = new Vector2(tw / 2f, th / 2f);
 			// Draw all segments with accurate fit and ordering (parent first, then children as in list order)
 			for (int i = 0; i < groupSegs.Count; i++)
 			{
 				Seg s = groupSegs[i];
 				if (s == null || string.IsNullOrEmpty(s.texture) || !textures.ContainsKey(s.texture)) continue;
 				try
 				{
 					var tex = textures[s.texture];
 					var cell = tex.cell[s.idx];
 					Vector2 drawPos = center + (s.loc - boundsCenter) * scaleK;
 					Vector2 drawScale = new Vector2(s.scaling.X * scaleK, s.scaling.Y * scaleK);
 					SpriteTools.sprite.Draw(tex.texture, drawPos, cell.srcRect, Microsoft.Xna.Framework.Color.White, s.rotation, cell.origin - new Vector2(cell.srcRect.X, cell.srcRect.Y), drawScale, SpriteEffects.None, 1f);
 				}
 				catch { }
 			}
			SpriteTools.End();
			gd.SetRenderTarget(null);
			// Save PNG
			string pngPath = Path.Combine(dir, name + ".png");
			using (var fs = File.Open(pngPath, FileMode.Create, FileAccess.Write))
			{
				rt.SaveAsPng(fs, tw, th);
			}
			rt.Dispose();
			// If Prefabs sheet is selected, refresh it
			if (Program.gui != null && prefabMode)
			{
				Program.gui.Invoke(new Action(() =>
				{
					try { Program.gui.GetType().GetMethod("RenderPrefabsPalette", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(Program.gui, null); } catch {}
				}));
			}
		}
		catch { }
		// After save, unglue all groups in the editor
		UnglueAll();
		// Clear selection by default (leave objects in place)
 		selSeg = -1;
 		try { Program.gui.UpdateSelSeg(); } catch { }
 	}

	public static void SpawnPrefabFromJson(string jsonPath)
	{
		try
		{
			// If a glue group is currently active, unglue it before spawning a new prefab
			if (glueActive) { UnglueAll(); }
 			if (!File.Exists(jsonPath)) return;
 			string txt = File.ReadAllText(jsonPath);
 			// Extract parent block
 			int pIdx = txt.IndexOf("\"parent\"");
 			if (pIdx < 0) return;
 			int pbStart = txt.IndexOf('{', pIdx);
 			int pbEnd = txt.IndexOf('}', pbStart);
 			if (pbStart < 0 || pbEnd < 0) return;
 			string pBlock = txt.Substring(pbStart + 1, pbEnd - pbStart - 1);
 			string pTex = ExtractString(pBlock, "\"texture\"");
 			int pCell = ExtractInt(pBlock, "\"idx\"");
 			float pScaleX = ExtractFloat(pBlock, "\"scaleX\"");
 			float pScaleY = ExtractFloat(pBlock, "\"scaleY\"");
 			float pRot = ExtractFloat(pBlock, "\"rotation\"");
 			int pLayerSaved = ExtractInt(pBlock, "\"layer\"");
 			int pOrder = ExtractInt(pBlock, "\"order\"");
 			// Members array
 			int membersIdx = txt.IndexOf("\"members\"");
 			if (membersIdx < 0) return;
 			int arrStart = txt.IndexOf('[', membersIdx);
 			int arrEnd = txt.IndexOf(']', arrStart);
 			if (arrStart < 0 || arrEnd < 0) return;
 			string arr = txt.Substring(arrStart + 1, arrEnd - arrStart - 1);
 			string[] items = arr.Split(new char[] { '}' }, StringSplitOptions.RemoveEmptyEntries);
 			Vector2 baseLoc = ScrollManager.scroll; // spawn at current scroll
 			// Choose parent layer: prefer current selection; else saved layer; else mid layer 15
 			int parentLayer = (selLayer >= 0 && selLayer < 20) ? selLayer : ((pLayerSaved >= 0 && pLayerSaved < 20) ? pLayerSaved : 15);
 			// Spawn parent (defer insertion until after we collect all members)
 			Seg pSeg = new Seg();
 			pSeg.texture = pTex;
 			pSeg.idx = pCell;
 			pSeg.scaling = new Vector2(pScaleX == 0 ? 1f : pScaleX, pScaleY == 0 ? 1f : pScaleY);
 			pSeg.rotation = pRot;
 			pSeg.loc = baseLoc;
 			// Collect per-layer entries (parent + children)
 			var perLayer = new Dictionary<int, List<PrefabSpawnEntry>>();
 			if (!perLayer.ContainsKey(parentLayer)) perLayer[parentLayer] = new List<PrefabSpawnEntry>();
 			perLayer[parentLayer].Add(new PrefabSpawnEntry { isParent = true, order = pOrder, savedLayer = pLayerSaved, seg = pSeg, offX = 0f, offY = 0f, rot = 0f, srx = 1f, sry = 1f });
 			for (int ii = 0; ii < items.Length; ii++)
 			{
 				string it = items[ii];
 				int texIdx = it.IndexOf("\"texture\""); if (texIdx < 0) continue;
 				string texture = ExtractString(it, "\"texture\"");
 				int idx = ExtractInt(it, "\"idx\"");
 				int layerIdx = parentLayer;
 				int savedLayer = ExtractInt(it, "\"layer\"");
 				float offX = ExtractFloat(it, "\"localOffsetX\"");
 				float offY = ExtractFloat(it, "\"localOffsetY\"");
 				float rot = ExtractFloat(it, "\"localRotation\"");
 				float srx = ExtractFloat(it, "\"scaleRatioX\"");
 				float sry = ExtractFloat(it, "\"scaleRatioY\"");
 				int ord = ExtractInt(it, "\"order\"");
 				if (layerIdx < 0 || layerIdx >= map.layer.Length) continue;
 				Seg seg = new Seg();
 				seg.texture = texture;
 				seg.idx = idx;
 				seg.scaling = new Vector2(Math.Max(0.01f, pSeg.scaling.X * srx), Math.Max(0.01f, pSeg.scaling.Y * sry));
 				seg.rotation = WrapAngle(pSeg.rotation + rot);
 				// position from normalized offset
 				float px = (float)Math.Cos(pSeg.rotation); float py = (float)Math.Sin(pSeg.rotation);
 				float qx = (float)Math.Cos(pSeg.rotation + 1.57079637f); float qy = (float)Math.Sin(pSeg.rotation + 1.57079637f);
 				Vector2 worldOffset = new Vector2(offX * pSeg.scaling.X, offY * pSeg.scaling.Y);
 				Vector2 world = new Vector2(worldOffset.X * px + worldOffset.Y * qx, worldOffset.X * py + worldOffset.Y * qy);
 				seg.loc = baseLoc + world;
 				if (!perLayer.ContainsKey(layerIdx)) perLayer[layerIdx] = new List<PrefabSpawnEntry>();
 				perLayer[layerIdx].Add(new PrefabSpawnEntry { isParent = false, order = ord, savedLayer = savedLayer, seg = seg, offX = offX, offY = offY, rot = rot, srx = srx, sry = sry });
 			}
 			// Insert per-layer by saved sub-layer depth (desc) then intra-layer order (asc), append so later draws on top
 			foreach (var kv in perLayer)
 			{
 				int lidx = kv.Key;
 				var list = kv.Value
 					.OrderByDescending(e => (e.savedLayer >= 0 && e.savedLayer < map.layer.Length) ? map.layer[e.savedLayer].depth : 0f)
 					.ThenBy(e => e.order)
 					.ToList();
 				for (int j = 0; j < list.Count; j++)
 				{
 					map.layer[lidx].seg.Add(list[j].seg);
 				}
 			}
 			// Resolve parent index and build children refs after insertion
 			int parentIdx = map.layer[parentLayer].seg.IndexOf(pSeg);
 			List<GluedChild> newChildren = new List<GluedChild>();
 			foreach (var kv in perLayer)
 			{
 				int lidx = kv.Key;
 				for (int j = 0; j < kv.Value.Count; j++)
 				{
 					var entry = kv.Value[j];
 					if (entry.isParent) continue;
 					int newIndex = map.layer[lidx].seg.IndexOf(entry.seg);
 					newChildren.Add(new GluedChild
 					{
 						member = new GroupMemberRef { layerIndex = lidx, segIndex = newIndex },
 						localOffset = new Vector2(entry.offX, entry.offY),
 						localRotation = entry.rot,
 						scaleRatio = new Vector2(entry.srx, entry.sry)
 					});
 				}
 			}
 			// Activate group
 			glueActive = true;
 			glueParent = new GroupMemberRef { layerIndex = parentLayer, segIndex = parentIdx };
 			gluedChildren.Clear();
 			gluedChildren.AddRange(newChildren);
 			parentTransformChanged = true;
 			RecomputeChildrenFromParent();
 			map.mapGrid.needsUpdate = true;
 			needsActorUpdate = true;
 		}
 		catch {}
 	}

	private static string ExtractString(string src, string key)
	{
		int k = src.IndexOf(key); if (k < 0) return "";
		int q1 = src.IndexOf('"', k + key.Length); if (q1 < 0) return "";
		int q2 = src.IndexOf('"', q1 + 1); if (q2 < 0) return "";
		return src.Substring(q1 + 1, q2 - q1 - 1);
	}

	private static int ExtractInt(string src, string key)
	{
		float f = ExtractFloat(src, key);
		return (int)f;
	}

	private static float ExtractFloat(string src, string key)
	{
		int k = src.IndexOf(key); if (k < 0) return 0f;
		int c = src.IndexOf(':', k); if (c < 0) return 0f;
		int end = c + 1;
		while (end < src.Length && (char.IsWhiteSpace(src[end]) || src[end] == '"')) end++;
		int e = end;
		while (e < src.Length && (char.IsDigit(src[e]) || src[e] == '-' || src[e] == '.' )) e++;
		string num = src.Substring(end, e - end);
		float.TryParse(num, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float val);
		return val;
	}
}

