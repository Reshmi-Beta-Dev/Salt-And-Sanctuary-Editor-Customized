using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower;

namespace MapEdit.map;

public class WorldMapBaker
{
	public static RenderTarget2D rTarg;

	public static RenderTarget2D outTarg;

	public static RenderTarget2D[,] tiles;

	public static bool baked;

	private static Effect worldMapTileEffect;

	private static Effect worldMapTileCompositor;

	private static Texture2D worldMapparchment;

	public static void Init(ContentManager Content)
	{
		worldMapTileEffect = Content.Load<Effect>("fx/worldmaptile");
		worldMapTileCompositor = Content.Load<Effect>("fx/worldmapcompositor");
		worldMapparchment = Content.Load<Texture2D>("gfx/worldmapparchment");
	}

	public static void Draw(GraphicsDevice dev, Effect bloomTintEffect, Effect pmaEffect, bool sepia)
	{
		Vector2 scroll = ScrollManager.scroll;
		Vector2 screenSize = ScrollManager.screenSize;
		rTarg = new RenderTarget2D(dev, 4096, 2048);
		outTarg = new RenderTarget2D(dev, 4096, 2048);
		int num = 0;
		int num2 = 32;
		int num3 = 0;
		int num4 = 16;
		float num5 = 3000f;
		float num6 = 3000f;
		int num7 = 256;
		int num8 = 192;
		float num9 = 128f;
		float num10 = 0.95f;
		float num11 = num5 / num10;
		float num12 = num6 / num10;
		float num13 = 128f * num10;
		float num14 = num9 * num10;
		float zoom = -40f;
		tiles = new RenderTarget2D[num2, num4];
		for (int i = num; i < num2; i++)
		{
			for (int j = num3; j < num4; j++)
			{
				tiles[i, j] = new RenderTarget2D(dev, num7, num8);
				ScrollManager.scroll = new Vector2((float)i * num11, (float)j * num12);
				ScrollManager.zoom = zoom;
				ScrollManager.screenSize = new Vector2(num7, num8);
				ScrollManager.UpdateCannedValues();
				float num15 = 0f;
				dev.SetRenderTarget(tiles[i, j]);
				dev.Clear(new Color(num15, num15, num15, 1f));
				SpriteTools.BeginAlpha();
				if (!Game1.hideInactiveLayers) {
					Game1.map.Draw(11, 15, Game1.glowMgr, bloomTintEffect, 1f);
					Game1.map.Draw(15, 16, Game1.glowMgr, bloomTintEffect, 1f);
					Game1.map.Draw(16, 18, Game1.glowMgr, bloomTintEffect, 1f);
					Game1.map.Draw(0, 5, Game1.glowMgr, bloomTintEffect, 1f);
					Game1.map.Draw(5, 6, Game1.glowMgr, bloomTintEffect, 1f);
					Game1.map.Draw(6, 10, Game1.glowMgr, bloomTintEffect, 1f);
				}
				if (sepia)
				{
					SpriteTools.End();
					SpriteTools.BeginSubtractive();
					SpriteTools.sprite.Draw(Game1.nullTex, new Rectangle(0, 0, tiles[i, j].Width, tiles[i, j].Height), new Color(0.2f, 0.2f, 0.2f, 1f));
					SpriteTools.End();
					SpriteTools.BeginAlpha();
					Game1.map.mapEditDraw.DrawColForWorldMap();
				}
				SpriteTools.End();
			}
			Console.WriteLine("Preparing... [" + (int)((double)i * 100.0 / (double)num2) + "%]");
		}
		dev.SetRenderTarget(rTarg);
		if (sepia)
		{
			dev.Clear(new Color(1f, 1f, 1f, 1f));
			worldMapTileEffect.Parameters["a"].SetValue(1f);
			worldMapTileEffect.Parameters["v"].SetValue(0.015f);
			worldMapTileEffect.Parameters["sat"].SetValue(0.1f);
			SpriteTools.BeginAlpha(worldMapTileEffect);
		}
		else
		{
			dev.Clear(new Color(0f, 0f, 0f, 1f));
			SpriteTools.BeginAlpha();
		}
		for (int k = num; k < num2; k++)
		{
			for (int l = num3; l < num4; l++)
			{
				SpriteTools.sprite.Draw(tiles[k, l], new Vector2((float)k * num13, (float)l * num14), Color.White);
			}
			Console.WriteLine("Writing... [" + (int)((double)k * 100.0 / (double)num2) + "%]");
		}
		SpriteTools.End();
		dev.SetRenderTarget(outTarg);
		dev.Textures[1] = worldMapparchment;
		if (sepia)
		{
			SpriteTools.BeginAlpha(worldMapTileCompositor);
		}
		else
		{
			SpriteTools.BeginOpaque();
		}
		SpriteTools.sprite.Draw(rTarg, default(Vector2), Color.White);
		SpriteTools.End();
		dev.Textures[1] = null;
		dev.SetRenderTarget(null);
		baked = true;
		Stream stream = File.Open("maps/images/" + (sepia ? "worldmap.png" : "worldmapns.png"), FileMode.OpenOrCreate, FileAccess.Write);
		outTarg.SaveAsPng(stream, 4096, 2048);
		stream.Close();
		ScrollManager.scroll = scroll;
		ScrollManager.screenSize = screenSize;
	}
}
