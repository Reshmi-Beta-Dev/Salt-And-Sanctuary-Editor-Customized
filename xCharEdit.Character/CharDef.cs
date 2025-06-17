using System.Collections.Generic;
using ProjectTower.io;

namespace xCharEdit.Character;

public class CharDef
{
	public string texName = "";

	public const string VERSION_CURRENT = "Version 1.01";

	public const string VERSION_1_0 = "Version 1.0";

	public List<Animation> animation;

	public List<Frame> frame;

	public string path;

	public List<string> tex;

	public int texVars;

	public const int FRAME_MAX = 5000;

	public const int ANIM_MAX = 500;

	public const int SPECTEX_WEAPON = 0;

	public const int AUXTEX_SHIELD = 0;

	public int specTex;

	public const int BODY_MAX = 256;

	public const int WEAP_IDX = 256;

	public const int WEAP_MAX = 384;

	public const int SHIELD_IDX = 384;

	public const int SHIELD_MAX = 512;

	public const int TRIGGER_IDX = 1000;

	public const int ACTOR_IDX = 2000;

	public const int SWOOSH_IDX = 32;

	public const int SWOOSH_1 = 32;

	public const int SWOOSH_2 = 33;

	public const int SWOOSH_3 = 34;

	public const int SWOOSH_4 = 35;

	public const int TOTAL_SWOOSHES = 4;

	public CharDef()
	{
		animation = new List<Animation>();
		frame = new List<Frame>();
		path = "char";
	}

	public CharDef(string path)
	{
		animation = new List<Animation>();
		frame = new List<Frame>();
		this.path = path;
		ReadShort(abs: true);
	}

	public void RefreshUsedFrames()
	{
		for (int i = 0; i < frame.Count; i++)
		{
			frame[i].used = false;
		}
		for (int j = 0; j < animation.Count; j++)
		{
			for (int k = 0; k < animation[j].keyFrame.Count; k++)
			{
				KeyFrame keyFrame = animation[j].keyFrame[k];
				if (keyFrame.duration > 0 && keyFrame.frameRef >= 0)
				{
					frame[keyFrame.frameRef].used = true;
				}
			}
		}
	}

	public bool GetHasAnimation(string s)
	{
		for (int i = 0; i < animation.Count; i++)
		{
			if (animation[i].name == s)
			{
				return true;
			}
		}
		return false;
	}

	public int GetAnimationIdx(string s)
	{
		for (int i = 0; i < animation.Count; i++)
		{
			if (animation[i].name == s)
			{
				return i;
			}
		}
		return 0;
	}

	public void SetAnimation(int idx, Animation _animation)
	{
		animation[idx] = _animation;
	}

	public void ReadShort(bool abs)
	{
		if (!abs)
		{
			FileMgr.Open(path + ".zmx");
		}
		else
		{
			FileMgr.Open(path);
		}
		path = FileMgr.reader.ReadString();
		texName = FileMgr.reader.ReadString();
		specTex = FileMgr.reader.ReadInt32();
		int num = FileMgr.reader.ReadInt32();
		animation = new List<Animation>();
		for (int i = 0; i < num; i++)
		{
			string text = FileMgr.reader.ReadString();
			if (!(text != ""))
			{
				continue;
			}
			animation.Add(new Animation());
			animation[i] = new Animation();
			animation[i].name = text;
			int num2 = FileMgr.reader.ReadInt32();
			for (int j = 0; j < num2; j++)
			{
				animation[i].keyFrame.Add(new KeyFrame());
				KeyFrame keyFrame = animation[i].keyFrame[j];
				keyFrame.frameRef = FileMgr.reader.ReadInt32();
				keyFrame.duration = FileMgr.reader.ReadInt32();
				keyFrame.lerp = FileMgr.reader.ReadBoolean();
				byte b = FileMgr.reader.ReadByte();
				for (byte b2 = 0; b2 < b; b2++)
				{
					keyFrame.AddScript(FileMgr.reader.ReadString());
				}
			}
		}
		int num3 = FileMgr.reader.ReadInt32();
		frame = new List<Frame>();
		for (int k = 0; k < num3; k++)
		{
			if (FileMgr.reader.ReadBoolean())
			{
				frame.Add(new Frame());
				frame[k].parts = FileMgr.reader.ReadInt32();
				for (int l = 0; l < frame[k].parts; l++)
				{
					frame[k].part[l].Read(FileMgr.reader);
				}
			}
			else
			{
				frame.Add(new Frame());
			}
		}
		FileMgr.Close();
	}
}
