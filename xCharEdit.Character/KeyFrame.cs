using System.Collections.Generic;
using CharlieWin.chars.script;

namespace xCharEdit.Character;

public class KeyFrame
{
	public int frameRef;

	public int duration;

	public List<string> script;

	public List<ScriptCommand> scriptCommand;

	public bool lerp;

	public KeyFrame()
	{
		frameRef = -1;
		duration = 0;
		script = new List<string>();
		scriptCommand = new List<ScriptCommand>();
	}

	public KeyFrame(KeyFrame srcKey)
	{
		frameRef = srcKey.frameRef;
		duration = srcKey.duration;
		lerp = srcKey.lerp;
		script = new List<string>();
		scriptCommand = new List<ScriptCommand>();
		foreach (string item in srcKey.script)
		{
			AddScript(item);
		}
	}

	public ScriptCommand GetScriptCommand(int idx)
	{
		return scriptCommand[idx];
	}

	public void AddScript(string val)
	{
		script.Add(val);
		scriptCommand.Add(ScriptCommandParser.ParseString(val));
	}
}
