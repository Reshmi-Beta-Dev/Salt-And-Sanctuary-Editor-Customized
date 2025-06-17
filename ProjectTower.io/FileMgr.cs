using System.IO;

namespace ProjectTower.io;

public class FileMgr
{
	public static BinaryReader reader;

	public static void Open(string path)
	{
		reader = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read));
	}

	public static void Close()
	{
		reader.Close();
	}
}
