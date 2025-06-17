using System;
using Microsoft.Xna.Framework;

namespace ProjectTower;

public class Trig
{
	public static float GetDist(Vector2 v1, Vector2 v2)
	{
		return (v2 - v1).Length();
	}

	public static Vector2 GetLobVec(Vector2 orig, Vector2 goal, float speed, float lift, float gravity, float minY)
	{
		Vector2 vector = (goal - orig) * 0.1f * speed;
		Vector2 result = default(Vector2);
		float num = -1f;
		Vector2 vector2 = vector;
		for (int i = 0; i < 14; i++)
		{
			bool flag = false;
			Vector2 vector3 = orig;
			Vector2 vector4 = vector2;
			float num2 = -1f;
			for (int j = 0; j < 100; j++)
			{
				vector3 += vector4 * 0.01666667f;
				vector4.Y += gravity * 0.01666667f;
				if (!flag)
				{
					float num3 = Math.Abs(vector3.X - goal.X) + Math.Abs(vector3.Y - goal.Y);
					if ((double)num3 < (double)num2 || (double)num2 < 0.0)
					{
						num2 = num3;
					}
				}
			}
			if ((double)num < 0.0 || (double)num2 < (double)num)
			{
				num = num2;
				result = vector2;
			}
			vector2.Y -= lift;
			if ((double)vector2.Y < (double)minY)
			{
				vector2.Y = minY;
			}
		}
		return result;
	}

	public static float GetAngle(Vector2 v1, Vector2 v2)
	{
		float num = 3.141593f;
		Vector2 vector = new Vector2(v2.X - v1.X, v2.Y - v1.Y);
		if ((double)vector.X == 0.0)
		{
			if ((double)vector.Y < 0.0)
			{
				return num * 0.5f;
			}
			if ((double)vector.Y > 0.0)
			{
				return num * 1.5f;
			}
		}
		if ((double)vector.Y == 0.0)
		{
			if ((double)vector.X < 0.0)
			{
				return 0f;
			}
			if ((double)vector.X > 0.0)
			{
				return num;
			}
		}
		float num2 = (float)Math.Atan((double)Math.Abs(vector.Y) / (double)Math.Abs(vector.X));
		if ((double)vector.X < 0.0 || (double)vector.Y > 0.0)
		{
			num2 = num - num2;
		}
		if ((double)vector.X < 0.0 || (double)vector.Y < 0.0)
		{
			num2 = num + num2;
		}
		if ((double)vector.X > 0.0 || (double)vector.Y < 0.0)
		{
			num2 = num * 2f - num2;
		}
		if ((double)num2 < 0.0)
		{
			num2 += num * 2f;
		}
		return num2;
	}

	public static float GetCosProg(float p)
	{
		return (float)(Math.Cos((double)p * 3.1415901184082) * -0.5 + 0.5);
	}
}
