using System;
using System.Threading;

namespace ProjectTower.gamestate;

public class GameConsole
{
	private static object consoleSemaphore;

	private static bool inited;

	public static void Init()
	{
		consoleSemaphore = new object();
		inited = true;
	}

	public static void WriteLine(string s)
	{
		if (!inited)
		{
			Init();
		}
		if (!Monitor.TryEnter(consoleSemaphore, 1000))
		{
			return;
		}
		try
		{
			Console.WriteLine(s);
		}
		finally
		{
			Monitor.Exit(consoleSemaphore);
		}
	}
}
