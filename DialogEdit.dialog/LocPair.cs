namespace DialogEdit.dialog;

public class LocPair
{
	public string orig;

	public string[] locStr;

	public LocPair(int ID)
	{
		orig = "NEW_" + ID;
		locStr = new string[13];
		for (int i = 0; i < locStr.Length; i++)
		{
			locStr[i] = "";
		}
	}

	public LocPair(string p)
	{
		orig = p;
		locStr = new string[13];
		for (int i = 0; i < locStr.Length; i++)
		{
			locStr[i] = "";
		}
	}
}
