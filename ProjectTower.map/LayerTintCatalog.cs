using System.Collections.Generic;
using System.IO;
using MapEdit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectTower.director.bloom;
using ProjectTower.map.layertint;

namespace ProjectTower.map;

public class LayerTintCatalog
{
	public struct LayerTintLayer
	{
		public float r;

		public float g;

		public float b;

		public float sat;

		public float tint;

		public LayerTintLayer(float r, float g, float b, float sat, float tint)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.sat = sat;
			this.tint = tint;
		}

		public LayerTintLayer(BinaryReader reader)
		{
			r = reader.ReadSingle();
			g = reader.ReadSingle();
			b = reader.ReadSingle();
			sat = reader.ReadSingle();
			tint = reader.ReadSingle();
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(r);
			writer.Write(g);
			writer.Write(b);
			writer.Write(sat);
			writer.Write(tint);
		}
	}

	public struct LayerTintData
	{
		public float tR;

		public float tG;

		public float tB;

		public float bR;

		public float bG;

		public float bB;

		public float gamma;

		public float brite;

		public bool indoors;

		public float bgR;

		public float bgG;

		public float bgB;

		public float burnR;

		public float burnG;

		public float burnB;

		public float sat;

		public float indoorf;

		public float pR;

		public float pG;

		public float pB;

		public float pA;

		public float lightMap;

		public float dotsAlpha;

		public float snowAlpha;

		public float rainAlpha;

		public float leavesAlpha;

		public float bloomThreshhold;

		public float bloomBase;

		public float bloomIntensity;

		public float bloomSat;

		public float bloodAlpha;

		public float bloodSat;

		public float lightFac;

		public float floorVal;

		public float lightThresh;

		public float lightRed;

		public float lightBlue;

		public float lightDesat;

		public float darkBlur;

		public LayerTintLayer[] layerTintLayer;

		public string name;

		public LayerTintData(string name, float tR, float tG, float tB, float bR, float bG, float bB, float gamma, float brite, float bloomThreshhold, float bloomBase, float bloomIntensity, float bloomSat, float floorVal, float lightThresh, float lightBlue, float lightRed, float lightDesat, float darkBlur, float bgR, float bgG, float bgB, float burnR, float burnG, float burnB, bool indoors, float sat, float pR, float pG, float pB, float pA, float lightMap, float lightFac, float dotsAlpha, float snowAlpha, float rainAlpha, float leavesAlpha, float bloodAlpha, float bloodSat, LayerTintLayer[] layerTintLayer)
		{
			this.name = name;
			this.tR = tR;
			this.tG = tG;
			this.tB = tB;
			this.bR = bR;
			this.bG = bG;
			this.bB = bB;
			this.bgR = bgR;
			this.bgG = bgG;
			this.bgB = bgB;
			this.burnR = burnR;
			this.burnG = burnG;
			this.burnB = burnB;
			this.bloomBase = bloomBase;
			this.bloomIntensity = bloomIntensity;
			this.bloomSat = bloomSat;
			this.bloomThreshhold = bloomThreshhold;
			this.floorVal = floorVal;
			this.lightThresh = lightThresh;
			this.lightRed = lightRed;
			this.lightBlue = lightBlue;
			this.lightDesat = lightDesat;
			this.darkBlur = darkBlur;
			this.gamma = gamma;
			this.brite = brite;
			this.indoors = indoors;
			indoorf = (indoors ? 1f : 0f);
			this.sat = sat;
			this.pR = pR;
			this.pG = pG;
			this.pB = pB;
			this.pA = pA;
			this.lightMap = lightMap;
			this.lightFac = lightFac;
			this.dotsAlpha = dotsAlpha;
			this.snowAlpha = snowAlpha;
			this.rainAlpha = rainAlpha;
			this.leavesAlpha = leavesAlpha;
			this.bloodAlpha = bloodAlpha;
			this.bloodSat = bloodSat;
			this.layerTintLayer = layerTintLayer;
		}

		public LayerTintData(BinaryReader reader)
		{
			name = reader.ReadString();
			tR = reader.ReadSingle();
			tG = reader.ReadSingle();
			tB = reader.ReadSingle();
			bR = reader.ReadSingle();
			bG = reader.ReadSingle();
			bB = reader.ReadSingle();
			bgR = reader.ReadSingle();
			bgG = reader.ReadSingle();
			bgB = reader.ReadSingle();
			burnR = reader.ReadSingle();
			burnG = reader.ReadSingle();
			burnB = reader.ReadSingle();
			bloomBase = reader.ReadSingle();
			bloomIntensity = reader.ReadSingle();
			bloomSat = reader.ReadSingle();
			bloomThreshhold = reader.ReadSingle();
			floorVal = reader.ReadSingle();
			lightThresh = reader.ReadSingle();
			lightRed = reader.ReadSingle();
			lightBlue = reader.ReadSingle();
			lightDesat = reader.ReadSingle();
			darkBlur = reader.ReadSingle();
			gamma = reader.ReadSingle();
			brite = reader.ReadSingle();
			indoors = reader.ReadBoolean();
			indoorf = (indoors ? 1f : 0f);
			sat = reader.ReadSingle();
			pR = reader.ReadSingle();
			pG = reader.ReadSingle();
			pB = reader.ReadSingle();
			pA = reader.ReadSingle();
			lightMap = reader.ReadSingle();
			lightFac = reader.ReadSingle();
			dotsAlpha = reader.ReadSingle();
			snowAlpha = reader.ReadSingle();
			rainAlpha = reader.ReadSingle();
			leavesAlpha = reader.ReadSingle();
			bloodAlpha = reader.ReadSingle();
			bloodSat = reader.ReadSingle();
			layerTintLayer = new LayerTintLayer[19];
			for (int i = 0; i < layerTintLayer.Length; i++)
			{
				layerTintLayer[i] = new LayerTintLayer(reader);
			}
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(name);
			writer.Write(tR);
			writer.Write(tG);
			writer.Write(tB);
			writer.Write(bR);
			writer.Write(bG);
			writer.Write(bB);
			writer.Write(bgR);
			writer.Write(bgG);
			writer.Write(bgB);
			writer.Write(burnR);
			writer.Write(burnG);
			writer.Write(burnB);
			writer.Write(bloomBase);
			writer.Write(bloomIntensity);
			writer.Write(bloomSat);
			writer.Write(bloomThreshhold);
			writer.Write(floorVal);
			writer.Write(lightThresh);
			writer.Write(lightRed);
			writer.Write(lightBlue);
			writer.Write(lightDesat);
			writer.Write(darkBlur);
			writer.Write(gamma);
			writer.Write(brite);
			writer.Write(indoors);
			writer.Write(sat);
			writer.Write(pR);
			writer.Write(pG);
			writer.Write(pB);
			writer.Write(pA);
			writer.Write(lightMap);
			writer.Write(lightFac);
			writer.Write(dotsAlpha);
			writer.Write(snowAlpha);
			writer.Write(rainAlpha);
			writer.Write(leavesAlpha);
			writer.Write(bloodAlpha);
			writer.Write(bloodSat);
			for (int i = 0; i <= 18; i++)
			{
				layerTintLayer[i].Write(writer);
			}
		}
	}

	public static List<LayerTintData> layerTintData;

	private static LayerTintData workingLayerTintData;

	public static Texture2D parchmentTex;

	private static Effect parchmentEffect;

	private static Effect gameParchEffect;

	private static GraphicsDevice dev;

	private static float parchFrame;

	public static void Init(ContentManager Content, GraphicsDevice device)
	{
		parchmentTex = Content.Load<Texture2D>("gfx/parchment");
		parchmentEffect = Content.Load<Effect>("fx/parchment");
		gameParchEffect = Content.Load<Effect>("fx/gameparch");
		dev = device;
		InitData();
	}

	public static string[] GetLayerNameArray()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < layerTintData.Count; i++)
		{
			list.Add(layerTintData[i].name);
		}
		return list.ToArray();
	}

	public static LayerTintData CopyLayerTint(LayerTintData source)
	{
		return new LayerTintData(source.name, source.tR, source.tG, source.tB, source.bR, source.bG, source.bB, source.gamma, source.brite, source.bloomThreshhold, source.bloomBase, source.bloomIntensity, source.bloomSat, source.floorVal, source.lightThresh, source.lightBlue, source.lightRed, source.lightDesat, source.darkBlur, source.bgR, source.bgG, source.bgB, source.burnR, source.burnG, source.burnB, (source.indoors ? 1 : 0) != 0, source.sat, source.pR, source.pG, source.pB, source.pA, source.lightMap, source.lightFac, source.dotsAlpha, source.snowAlpha, source.rainAlpha, source.leavesAlpha, source.bloodAlpha, source.bloodSat, new LayerTintLayer[19]
		{
			source.layerTintLayer[0],
			source.layerTintLayer[1],
			source.layerTintLayer[2],
			source.layerTintLayer[3],
			source.layerTintLayer[4],
			source.layerTintLayer[5],
			source.layerTintLayer[6],
			source.layerTintLayer[7],
			source.layerTintLayer[8],
			source.layerTintLayer[9],
			source.layerTintLayer[10],
			source.layerTintLayer[11],
			source.layerTintLayer[12],
			source.layerTintLayer[13],
			source.layerTintLayer[14],
			source.layerTintLayer[15],
			source.layerTintLayer[16],
			source.layerTintLayer[17],
			source.layerTintLayer[18]
		});
	}

	public static void PrepareMainEffect(Effect mainEffect, int layer, int pLayer, float layerProg)
	{
		if (layer != -1 && pLayer != -1)
		{
			_ = layerTintData[pLayer];
			_ = layerTintData[layer];
			_ = layerTintData[pLayer];
			dev.Textures[1] = parchmentTex;
			Game1.glowMgr.alpha = layerTintData[pLayer].lightMap + (layerTintData[layer].lightMap - layerTintData[pLayer].lightMap) * layerProg;
			mainEffect.Parameters["tR"].SetValue(layerTintData[pLayer].tR + (layerTintData[layer].tR - layerTintData[pLayer].tR) * layerProg);
			mainEffect.Parameters["tG"].SetValue(layerTintData[pLayer].tG + (layerTintData[layer].tG - layerTintData[pLayer].tG) * layerProg);
			mainEffect.Parameters["tB"].SetValue(layerTintData[pLayer].tB + (layerTintData[layer].tB - layerTintData[pLayer].tB) * layerProg);
			mainEffect.Parameters["bR"].SetValue(layerTintData[pLayer].bR + (layerTintData[layer].bR - layerTintData[pLayer].bR) * layerProg);
			mainEffect.Parameters["bG"].SetValue(layerTintData[pLayer].bG + (layerTintData[layer].bG - layerTintData[pLayer].bG) * layerProg);
			mainEffect.Parameters["bB"].SetValue(layerTintData[pLayer].bB + (layerTintData[layer].bB - layerTintData[pLayer].bB) * layerProg);
			mainEffect.Parameters["k"].SetValue(0f);
			mainEffect.Parameters["kcube"].SetValue(0.03f);
			float value = (float)(((double)layerTintData[pLayer].brite + ((double)layerTintData[layer].brite - (double)layerTintData[pLayer].brite) * (double)layerProg) * 0.75);
			BloomComponent.bloomBase = layerTintData[pLayer].bloomBase + (layerTintData[layer].bloomBase - layerTintData[pLayer].bloomBase) * layerProg;
			BloomComponent.bloomIntensity = layerTintData[pLayer].bloomIntensity + (layerTintData[layer].bloomIntensity - layerTintData[pLayer].bloomIntensity) * layerProg;
			BloomComponent.bloomSat = layerTintData[pLayer].bloomSat + (layerTintData[layer].bloomSat - layerTintData[pLayer].bloomSat) * layerProg;
			BloomComponent.bloomThreshhold = layerTintData[pLayer].bloomThreshhold + (layerTintData[layer].bloomThreshhold - layerTintData[pLayer].bloomThreshhold) * layerProg;
			BloomComponent.floorValue = layerTintData[pLayer].floorVal + (layerTintData[layer].floorVal - layerTintData[pLayer].floorVal) * layerProg;
			float baseSat = layerTintData[pLayer].sat + (layerTintData[layer].sat - layerTintData[pLayer].sat) * layerProg;
			float value2 = layerTintData[pLayer].gamma + (layerTintData[layer].gamma - layerTintData[pLayer].gamma) * layerProg;
			float value3 = layerTintData[pLayer].burnR + (layerTintData[layer].burnR - layerTintData[pLayer].burnR) * layerProg;
			float value4 = layerTintData[pLayer].burnG + (layerTintData[layer].burnG - layerTintData[pLayer].burnG) * layerProg;
			float value5 = layerTintData[pLayer].burnB + (layerTintData[layer].burnB - layerTintData[pLayer].burnB) * layerProg;
			Game1.glowMgr.lightFac = layerTintData[pLayer].lightFac + (layerTintData[layer].lightFac - layerTintData[pLayer].lightFac) * layerProg;
			BloomComponent.lightThresh = layerTintData[pLayer].lightThresh + (layerTintData[layer].lightThresh - layerTintData[pLayer].lightThresh) * layerProg;
			BloomComponent.lightBlue = layerTintData[pLayer].lightBlue + (layerTintData[layer].lightBlue - layerTintData[pLayer].lightBlue) * layerProg;
			BloomComponent.lightRed = layerTintData[pLayer].lightRed + (layerTintData[layer].lightRed - layerTintData[pLayer].lightRed) * layerProg;
			BloomComponent.lightFac = (float)((((double)layerTintData[pLayer].lightMap > 0.0) ? 1.0 : 0.0) + ((((double)layerTintData[layer].lightMap > 0.0) ? 1.0 : 0.0) - (((double)layerTintData[pLayer].lightMap > 0.0) ? 1.0 : 0.0)) * (double)layerProg);
			BloomComponent.lightDesat = layerTintData[pLayer].lightDesat + (layerTintData[layer].lightDesat - layerTintData[pLayer].lightDesat) * layerProg;
			BloomComponent.darkBlur = layerTintData[pLayer].darkBlur + (layerTintData[layer].darkBlur - layerTintData[pLayer].darkBlur) * layerProg;
			Game1.dotsMgr.dotsAlpha = layerTintData[pLayer].dotsAlpha + (layerTintData[layer].dotsAlpha - layerTintData[pLayer].dotsAlpha) * layerProg;
			Game1.dotsMgr.snowAlpha = layerTintData[pLayer].snowAlpha + (layerTintData[layer].snowAlpha - layerTintData[pLayer].snowAlpha) * layerProg;
			Game1.dotsMgr.rainAlpha = layerTintData[pLayer].rainAlpha + (layerTintData[layer].rainAlpha - layerTintData[pLayer].rainAlpha) * layerProg;
			_ = 7;
			mainEffect.Parameters["burnR"].SetValue(value3);
			mainEffect.Parameters["burnG"].SetValue(value4);
			mainEffect.Parameters["burnB"].SetValue(value5);
			mainEffect.Parameters["brite"].SetValue(value);
			mainEffect.Parameters["gamma"].SetValue(value2);
			BloomComponent.baseSat = baseSat;
		}
	}

	public static void DrawParchment(int layer, int pLayer, float layerProg)
	{
		Vector2 vector = ScrollManager.scroll / (ScrollManager.screenSize * 3f);
		vector.X -= (int)vector.X;
		vector.Y -= (int)vector.Y;
		if (layer != -1 && pLayer != -1)
		{
			float num = layerTintData[pLayer].pA + (layerTintData[layer].pA - layerTintData[pLayer].pA) * layerProg;
			if ((double)num > 0.0)
			{
				parchmentEffect.Parameters["pX"].SetValue(vector.X);
				parchmentEffect.Parameters["pY"].SetValue(vector.Y);
				parchmentEffect.Parameters["pA"].SetValue(num);
				parchmentEffect.Parameters["r"].SetValue(layerTintData[pLayer].pR + (layerTintData[layer].pR - layerTintData[pLayer].pR) * layerProg);
				parchmentEffect.Parameters["g"].SetValue(layerTintData[pLayer].pG + (layerTintData[layer].pG - layerTintData[pLayer].pG) * layerProg);
				parchmentEffect.Parameters["b"].SetValue(layerTintData[pLayer].pB + (layerTintData[layer].pB - layerTintData[pLayer].pB) * layerProg);
				SpriteTools.BeginAlpha(parchmentEffect);
				SpriteTools.sprite.Draw(parchmentTex, new Rectangle(0, 0, (int)ScrollManager.screenSize.X, (int)ScrollManager.screenSize.Y), Color.White);
				SpriteTools.End();
			}
			else
			{
				DrawParchmentOnly();
			}
		}
	}

	public static void DrawParchmentOnly()
	{
		int num = (int)((double)ScrollManager.screenSize.X / 13.0);
		gameParchEffect.Parameters["baseFac"].SetValue(0f);
		gameParchEffect.Parameters["parchFac"].SetValue(0.1f);
		gameParchEffect.Parameters["h"].SetValue((float)num / (float)parchmentTex.Height);
		float num2 = 0f - 0f;
		gameParchEffect.Parameters["frame"].SetValue(num2 * 3f);
		SpriteTools.BeginWrappedSubtractive(gameParchEffect);
		SpriteTools.sprite.Draw(parchmentTex, default(Vector2), new Rectangle(0, 0, (int)ScrollManager.screenSize.X, num), Color.White, 0f, default(Vector2), 1f, SpriteEffects.None, 1f);
		SpriteTools.sprite.Draw(parchmentTex, new Vector2(ScrollManager.screenSize.X, 0f), new Rectangle(0, 0, (int)ScrollManager.screenSize.Y, num), Color.White, 1.570796f, default(Vector2), 1f, SpriteEffects.None, 1f);
		SpriteTools.sprite.Draw(parchmentTex, ScrollManager.screenSize, new Rectangle(0, 0, (int)ScrollManager.screenSize.X, num), Color.White, 3.141593f, default(Vector2), 1f, SpriteEffects.None, 1f);
		SpriteTools.sprite.Draw(parchmentTex, new Vector2(0f, ScrollManager.screenSize.Y), new Rectangle(0, 0, (int)ScrollManager.screenSize.Y, num), Color.White, 4.712389f, default(Vector2), 1f, SpriteEffects.None, 1f);
		SpriteTools.End();
	}

	public static void Finalize(int layer, int pLayer, float layerProg)
	{
		dev.Textures[1] = null;
		DrawParchment(layer, pLayer, layerProg);
	}

	public static void SetBloomTint(Effect bloomTintEffect, int l, int layer, int pLayer, float layerProg, float detailFac)
	{
		if (layer != -1 && pLayer != -1)
		{
			float value = layerTintData[pLayer].layerTintLayer[l].r + (layerTintData[layer].layerTintLayer[l].r - layerTintData[pLayer].layerTintLayer[l].r) * layerProg;
			float value2 = layerTintData[pLayer].layerTintLayer[l].g + (layerTintData[layer].layerTintLayer[l].g - layerTintData[pLayer].layerTintLayer[l].g) * layerProg;
			float value3 = layerTintData[pLayer].layerTintLayer[l].b + (layerTintData[layer].layerTintLayer[l].b - layerTintData[pLayer].layerTintLayer[l].b) * layerProg;
			float value4 = layerTintData[pLayer].layerTintLayer[l].sat + (layerTintData[layer].layerTintLayer[l].sat - layerTintData[pLayer].layerTintLayer[l].sat) * layerProg;
			float value5 = layerTintData[pLayer].layerTintLayer[l].tint + (layerTintData[layer].layerTintLayer[l].tint - layerTintData[pLayer].layerTintLayer[l].tint) * layerProg;
			_ = 7;
			bloomTintEffect.Parameters["r"].SetValue(value);
			bloomTintEffect.Parameters["g"].SetValue(value2);
			bloomTintEffect.Parameters["b"].SetValue(value3);
			bloomTintEffect.Parameters["sat"].SetValue(value4);
			bloomTintEffect.Parameters["tint"].SetValue(value5);
		}
	}

	public static void InitData()
	{
		layerTintData = new List<LayerTintData>();
		for (int i = 0; i < 27; i++)
		{
			layerTintData.Add(default(LayerTintData));
		}
		ProjectTower.map.layertint.LayerTintData.SetData();
	}

	internal static void Read(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		layerTintData = new List<LayerTintData>();
		for (int i = 0; i < num; i++)
		{
			layerTintData.Add(new LayerTintData(reader));
		}
	}

	internal static void Write(BinaryWriter writer)
	{
		writer.Write(layerTintData.Count);
		for (int i = 0; i < layerTintData.Count; i++)
		{
			layerTintData[i].Write(writer);
		}
	}
}
