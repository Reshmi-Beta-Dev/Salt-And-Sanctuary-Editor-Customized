using System;
using Microsoft.Xna.Framework;

namespace ProjectTower;

internal class Rand
{
	public static Random rand;

	public static int GetRandomInt(int min, int max)
	{
		return min + (int)(rand.NextDouble() * (double)(max - min));
	}

	public static Vector2 GetRandomVec2(float xMin, float xMax, float yMin, float yMax)
	{
		return new Vector2(GetRandomFloat(xMin, xMax), GetRandomFloat(yMin, yMax));
	}

	public static Vector3 GetRandomVec3(float r)
	{
		Vector3 randomVec = GetRandomVec3(-1f, 1f, -1f, 1f, -1f, 1f);
		randomVec.Normalize();
		return randomVec * GetRandomFloat(0f, r);
	}

	public static Vector3 GetRandomVec3(float xMin, float xMax, float yMin, float yMax, float zMin, float zMax)
	{
		return new Vector3(GetRandomFloat(xMin, xMax), GetRandomFloat(yMin, yMax), GetRandomFloat(zMin, zMax));
	}

	public static Vector3 GetRandomVec3(float xRange, float yRange, float zRange)
	{
		return new Vector3(GetRandomFloat(0f - xRange, xRange), GetRandomFloat(0f - yRange, yRange), GetRandomFloat(0f - zRange, zRange));
	}

	public static float GetRandomFloat(float min, float max)
	{
		return min + (float)(rand.NextDouble() * ((double)max - (double)min));
	}

	public static double GetRandomDouble(double min, double max)
	{
		return min + rand.NextDouble() * (max - min);
	}

	public static bool CoinToss(float chanceToSucceed)
	{
		return (double)GetRandomFloat(0f, 1f) < (double)chanceToSucceed;
	}
}
