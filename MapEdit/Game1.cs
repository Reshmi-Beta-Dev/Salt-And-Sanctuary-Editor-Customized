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
			if (mouseWheel > 0)
			{
				gZoom += (float)mouseWheel / 44f;
			}
			if (mouseWheel < 0)
			{
				gZoom += (float)mouseWheel / 44f;
			}
			if (mouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && preState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				Vector2 vector2 = vector - pmVec;
				if (flag2)
				{
					if (selLayer > -1 && selLayer < 20 && selSeg > -1)
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
				else
				{
					ctrlClickCounter = 0;
				}
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
							selSeg = num21;
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
			if (preState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && selLayer > -1 && selLayer < 20 && selSeg > -1 && selSeg < map.layer[selLayer].seg.Count)
			{
				try
				{
					Seg seg5 = map.layer[selLayer].seg[selSeg];
					if (seg5 != null && flag3)
					{
						Vector2 vector3 = vector - pmVec;
						seg5.loc += vector3 / ScrollManager.GetSize(seg5.depth);
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
			if (preState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && selLayer > -1 && selLayer < 20 && selSeg > -1)
			{
				Seg seg6 = map.layer[selLayer].seg[selSeg];
				if (seg6 != null && flag3)
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
		isShift = false;
		bool ctrlDown = state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl) || state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightControl);
		for (int i = 0; i < pressedKeys.Length; i++)
		{
			bool flag = true;
			if (pressedKeys[i] == Microsoft.Xna.Framework.Input.Keys.LeftShift)
			{
				isShift = true;
			}
			for (int j = 0; j < pressedKeys2.Length; j++)
			{
				if (pressedKeys[i] == pressedKeys2[j])
				{
					flag = false;
				}
			}
			if (!flag || selLayer <= -1 || selLayer >= 20 || pressedKeys[i] != Microsoft.Xna.Framework.Input.Keys.Delete)
			{
				continue;
			}
			try
			{
				if (inView)
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

		// Ctrl+G: jump to hovered segment's sheet and layer
		if (ctrlDown && WasKeyJustPressed(pressedKeys, pressedKeys2, Microsoft.Xna.Framework.Input.Keys.G))
		{
			int hoveredSeg = GetHoveredSegIndex();
			if (hoveredSeg > -1 && selLayer >= 0 && selLayer < 20)
			{
				Seg s = map.layer[selLayer].seg[hoveredSeg];
				if (s != null && !string.IsNullOrEmpty(s.texture) && Game1.textures.ContainsKey(s.texture))
				{
					Program.gui.SwitchToLayerAndSheet(selLayer, s.texture);
				}
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

	private int GetHoveredSegIndex()
	{
		if (selLayer < 0 || selLayer >= 20) return -1;
		Layer layer = map.layer[selLayer];
		Vector2 m = MVec();
		for (int i = 0; i < layer.seg.Count; i++)
		{
			Seg seg = layer.seg[i];
			if (seg == null) continue;
			var rect = GetSegRect(seg, selLayer);
			Vector2 rl = ScrollManager.GetRealLoc(m, seg.depth);
			if ((double)rl.X > (double)rect.Left && (double)rl.Y > (double)rect.Top && (double)rl.X < (double)rect.Right && (double)rl.Y < (double)rect.Bottom)
			{
				return i;
			}
		}
		return -1;
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
							num = i;
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
}
