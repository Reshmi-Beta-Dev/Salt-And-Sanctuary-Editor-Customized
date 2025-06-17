using System;

namespace MapEdit;

internal static class Program
{
	public static GUI gui;

	[STAThread]
	private static void Main(string[] args)
	{
		gui = new GUI();
		gui.Show();
		new Game1(gui.getDrawSurface()).Run();
	}
}
