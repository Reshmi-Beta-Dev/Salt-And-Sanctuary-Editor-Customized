using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEdit;

public class ScrollManager
{
	public static float zoom = 1f;

	public static Vector2 screenSize;

	public static Vector2 scroll;

	private static Matrix projectionMatrix;

	private static GraphicsDevice dev;

	public const int DEPTH_ONE = 0;

	public const int DEPTH_ZERO = 1;

	public const int DEPTH_MINUS_ONE = 2;

	public const int DEPTH_TWO = 3;

	public const int DEPTH_THREE = 4;

	public const int DEPTH_FOUR = 5;

	public const int DEPTH_FIVE = 6;

	public const int DEPTH_EIGHT = 11;

	public const int DEPTH_MINUS_TWO = 7;

	public const int DEPTH_MINUS_THREE = 8;

	public const int DEPTH_MINUS_FOUR = 9;

	public const int DEPTH_MINUS_FIVE = 10;

	public static float[] cannedDepth;

	public static float candleAlpha;

	public static void Init(GraphicsDevice _dev, Vector2 _screenSize)
	{
		dev = _dev;
		SetProjectionMatrix((float)Math.PI / 4f);
		screenSize = new Vector2(1280f, 720f);
		zoom = -10f;
		scroll = default(Vector2);
		cannedDepth = new float[12];
	}

	public static void UpdateCannedValues()
	{
		cannedDepth[0] = GetCannedSize(1f);
		cannedDepth[1] = GetCannedSize(0f);
		cannedDepth[2] = GetCannedSize(-1f);
		cannedDepth[3] = GetCannedSize(2f);
		cannedDepth[4] = GetCannedSize(3f);
		cannedDepth[5] = GetCannedSize(4f);
		cannedDepth[11] = GetCannedSize(8f);
		cannedDepth[6] = GetCannedSize(5f);
		cannedDepth[7] = GetCannedSize(-2f);
		cannedDepth[8] = GetCannedSize(-3f);
		cannedDepth[9] = GetCannedSize(-4f);
		cannedDepth[10] = GetCannedSize(-5f);
	}

	private static float GetCannedSize(float dist)
	{
		Matrix view = Matrix.CreateLookAt(new Vector3(zoom, 0f, 0f), new Vector3(dist, 0f, 0f), new Vector3(0f, 1f, 0f));
		Vector3 vector = dev.Viewport.Project(new Vector3(dist, 0f, 0f), projectionMatrix, view, Matrix.Identity);
		return dev.Viewport.Project(new Vector3(dist, 0f, 0.01f), projectionMatrix, view, Matrix.Identity).X - vector.X;
	}

	public static void SetProjectionMatrix(float fov)
	{
		projectionMatrix = Matrix.CreatePerspectiveFieldOfView(fov, dev.Viewport.AspectRatio, 0.3f, 1000f);
	}

	public static float GetSize(float dist)
	{
		Matrix view = Matrix.CreateLookAt(new Vector3(zoom, 0f, 0f), new Vector3(dist, 0f, 0f), new Vector3(0f, 1f, 0f));
		Vector3 vector = dev.Viewport.Project(new Vector3(dist, 0f, 0f), projectionMatrix, view, Matrix.Identity);
		return dev.Viewport.Project(new Vector3(dist, 0f, 0.01f), projectionMatrix, view, Matrix.Identity).X - vector.X;
	}

	public static Vector2 GetRealLoc(Vector2 loc, float layer)
	{
		return (loc - screenSize / 2f) / GetSize(layer) + scroll;
	}

	public static Vector2 GetScreenLoc(Vector2 loc, float layer)
	{
		return (loc - scroll) * GetSize(layer) + screenSize / 2f;
	}

	public static Vector2 GetScreenLoc(Vector3 loc, float layer)
	{
		return (new Vector2(loc.X, loc.Y - loc.Z) - scroll) * GetSize(layer) + screenSize / 2f;
	}

	public static Vector2 GetScreenLoc(Vector2 loc, int layer)
	{
		return (loc - scroll) * cannedDepth[layer] + screenSize / 2f;
	}

	public static Vector2 GetScreenLoc(Vector3 loc, int layer)
	{
		return (new Vector2(loc.X, loc.Y - loc.Z) - scroll) * cannedDepth[layer] + screenSize / 2f;
	}
}
