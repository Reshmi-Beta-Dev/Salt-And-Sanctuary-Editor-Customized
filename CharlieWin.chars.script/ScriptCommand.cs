namespace CharlieWin.chars.script;

public class ScriptCommand
{
	public int command;

	public int iParam;

	public string sParam;

	public ScriptCommand(int command, int iParam, string sParam)
	{
		this.command = command;
		this.iParam = iParam;
		this.sParam = sParam;
	}
}
