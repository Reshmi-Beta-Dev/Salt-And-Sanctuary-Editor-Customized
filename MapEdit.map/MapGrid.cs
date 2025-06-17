using System.Collections.Generic;
using System.Linq;

namespace MapEdit.map;

public class MapGrid
{
	public struct GridChunk
	{
		public List<int>[] tempLayer;

		public int[][] layer;

		internal void Finalize()
		{
			layer = new int[tempLayer.Length][];
			for (int i = 0; i < tempLayer.Length; i++)
			{
				layer[i] = tempLayer[i].ToArray();
				tempLayer[i].Clear();
			}
		}

		internal void Init()
		{
			tempLayer = new List<int>[20];
			for (int i = 0; i < 20; i++)
			{
				tempLayer[i] = new List<int>();
			}
		}
	}

	public GridChunk[,] chunk;

	public int tX;

	public int tY;

	public const int GRID_WIDTH = 50;

	public const int GRID_HEIGHT = 50;

	public bool needsUpdate;

	public MapGrid()
	{
		needsUpdate = true;
	}

	public void Create(Map map)
	{
		tX = map.xUnits / 50 + 1;
		tY = map.yUnits / 50 + 1;
		chunk = new GridChunk[tX, tY];
		for (int i = 0; i < tX; i++)
		{
			for (int j = 0; j < tY; j++)
			{
				chunk[i, j].Init();
			}
		}
		for (int k = 0; k < 20; k++)
		{
			Layer layer = map.layer[k];
			for (int l = 0; l < layer.seg.Count(); l++)
			{
				Seg seg = layer.seg[l];
				int num = (int)((double)seg.loc.X / 3200.0);
				int num2 = (int)((double)seg.loc.Y / 1600.0);
				if (num < tX && num2 < tY && num >= 0 && num2 >= 0)
				{
					chunk[num, num2].tempLayer[k].Add(l);
				}
			}
		}
		for (int m = 0; m < tX; m++)
		{
			for (int n = 0; n < tY; n++)
			{
				chunk[m, n].Finalize();
			}
		}
		needsUpdate = false;
	}
}
