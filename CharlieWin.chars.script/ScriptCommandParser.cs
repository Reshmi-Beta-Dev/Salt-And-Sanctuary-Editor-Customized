using System;

namespace CharlieWin.chars.script;

public class ScriptCommandParser
{
	public static ScriptCommandDef[] command;

	public const int COMMAND_JOYJUMP = 0;

	public const int COMMAND_SETANIM = 1;

	public const int COMMAND_GOTOFRAME = 2;

	public const int COMMAND_SETJUMP = 3;

	public const int COMMAND_SLIDE = 4;

	public const int COMMAND_BACKUP = 5;

	public const int COMMAND_SETATKGOTO = 6;

	public const int COMMAND_SETLOWERGOTO = 7;

	public const int COMMAND_SETUPPERGOTO = 8;

	public const int COMMAND_CLEARGOTOS = 9;

	public const int COMMAND_FLOAT = 10;

	public const int COMMAND_KILLME = 11;

	public const int COMMAND_ETHEREAL = 12;

	public const int COMMAND_SOLID = 13;

	public const int COMMAND_SETSTRONGGOTO = 14;

	public const int COMMAND_QUAKE = 15;

	public const int COMMAND_RUNJUMP = 16;

	public const int COMMAND_CHARGE = 17;

	public const int COMMAND_UNFLOAT = 18;

	public const int COMMAND_IFUPGOTO = 19;

	public const int COMMAND_IFDOWNGOTO = 20;

	public const int COMMAND_ROLLBURN = 21;

	public const int COMMAND_DODGEBURN = 22;

	public const int COMMAND_JUMPBURN = 23;

	public const int COMMAND_SHOWGRABBER = 24;

	public const int COMMAND_OPENCHEST = 25;

	public const int COMMAND_LADDERUP = 26;

	public const int COMMAND_LADDERDOWN = 27;

	public const int COMMAND_LADDER_UP_OFF = 28;

	public const int COMMAND_LADDER_DOWN_OFF = 29;

	public const int COMMAND_ONLADDERDOWN = 30;

	public const int COMMAND_PLAY = 31;

	public const int COMMAND_SNDMOVE = 32;

	public const int COMMAND_SETFALL = 33;

	public const int COMMAND_USEITEM = 34;

	public const int COMMAND_START_CHANT = 35;

	public const int COMMAND_FIRE_CHANT = 36;

	public const int COMMAND_ACTIVATE_SWITCH = 37;

	public const int COMMAND_VOX_JAB = 38;

	public const int COMMAND_VOX_FIERCE = 39;

	public const int COMMAND_VOX_HIT = 40;

	public const int COMMAND_VOX_DIE = 41;

	public const int COMMAND_VOX_LAUGH = 42;

	public const int COMMAND_VOX_GROWL = 43;

	public const int COMMAND_VOX_SCREAM = 44;

	public const int COMMAND_READ_MESSAGE = 45;

	public const int COMMAND_HIDE_BOTTLE = 46;

	public const int COMMAND_SET_BUFF = 47;

	public const int COMMAND_RESET_SWIPES = 48;

	public const int COMMAND_SET_ITEM_GOTO = 49;

	public const int COMMAND_WARP = 50;

	public const int COMMAND_STARTWARP = 51;

	public const int COMMAND_SORCER = 52;

	public const int COMMAND_SET_REL_GOTO = 53;

	public const int COMMAND_LEAP = 54;

	public const int COMMAND_AIM_ON = 55;

	public const int COMMAND_AIM_OFF = 56;

	public const int COMMAND_SET_STRONG_ONLY_GOTO = 57;

	public const int COMMAND_GROUND_SLIDE = 58;

	public const int COMMAND_UPSIDE_DOWN = 59;

	public const int COMMAND_SET_ATK_ONLY_GOTO = 60;

	public const int COMMAND_SET_UPPER_ONLY_GOTO = 61;

	public const int COMMAND_ROLL_ATK = 62;

	public const int COMMAND_SELF_BUFF = 63;

	public const int COMMAND_IF_BUFFED_GOTO = 64;

	public const int COMMAND_KICK_RIPOSTE = 65;

	public const int COMMAND_IF_R_25_GOTO = 66;

	public const int COMMAND_IF_R_50_GOTO = 67;

	public const int COMMAND_IF_R_75_GOTO = 68;

	public const int COMMAND_SET_OFF_GOTO = 69;

	public const int COMMAND_ATK_CHARGE = 70;

	public const int COMMAND_STRONG_CHARGE = 71;

	public const int COMMAND_IF_DOWNED_GOTO = 72;

	public const int COMMAND_CAN_STOMP = 73;

	public const int COMMAND_CANT_STOMP = 74;

	public const int COMMAND_SWORD_WARP = 75;

	public const int COMMAND_START_HANG = 76;

	public const int COMMAND_END_HANG = 77;

	public const int COMMAND_LIGHT_CANDLE = 78;

	public const int COMMAND_IF_NO_TUNNEL = 79;

	public const int COMMAND_KILL_DIALOG = 80;

	public const int COMMAND_GOTO_OFF = 81;

	public const int COMMAND_SWITCH_TO_GHOST = 82;

	public const int COMMAND_IF_TARG_BELOW_GOTO = 83;

	public const int COMMAND_AIR_COMBO = 84;

	public const int COMMAND_IF_LIVING_GOTO = 85;

	public const int COMMAND_DMG_GRABBER = 86;

	public const int COMMAND_SET_STRONG_LIGHT_GOTO = 87;

	public const int COMMAND_CANT_TURN = 88;

	public const int COMMAND_CAN_TURN = 89;

	public const int COMMAND_FRICTION_OFF = 90;

	public const int COMMAND_FRICTION_ON = 91;

	public const int COMMAND_CAPE_STEP = 92;

	public const int COMMAND_MINI_CAPE_STEP = 93;

	public const int COMMAND_POISON_GRABBER = 94;

	public const int COMMAND_BLAST_GRABBER = 95;

	public const int COMMAND_CLOAK_WARP = 96;

	public const int COMMAND_START_CLOAK_WARP = 97;

	public const int COMMAND_PLAY_SPELL_CHARGE = 98;

	public const int COMMAND_SET_LOWER_ONLY_GOTO = 99;

	public const int COMMAND_IF_PHASE_GOTO = 100;

	public const int COMMAND_FACE_TARG = 101;

	public const int COMMAND_SET_MASH_THRESH_GOTO = 102;

	public const int COMMAND_ZOOM_BUMP = 103;

	public const int COMMAND_RESET_HIT_SWIPE = 104;

	public const int COMMAND_WEAP_SLIDE = 105;

	public const int COMMAND_CAN_ROLL = 106;

	public const int COMMAND_IF_CRAZE_GOTO = 107;

	public const int COMMAND_SETSTRONGUPPERGOTO = 108;

	public const int COMMAND_SETSTRONGLOWERGOTO = 109;

	public const int COMMAND_DROP_GRABBER = 110;

	public const int COMMAND_SET_JAMP_GOTO = 111;

	public const int COMMAND_SKELEWARP = 112;

	public const int COMMAND_IMPALE = 113;

	public const int COMMAND_EXE_BARGE = 114;

	public const int COMMAND_CRUSHIN = 115;

	public const int COMMAND_HIDE_HELM = 116;

	public const int COMMAND_FORCE_HELM_HAIR = 117;

	public const int COMMAND_FORCE_HELM_BEARD = 118;

	public const int COMMAND_FORCE_NAMELESS = 119;

	public const int TOTAL_COMMANDS = 120;

	public static void Init()
	{
		command = new ScriptCommandDef[120];
		command[116] = new ScriptCommandDef("hidehelm", ScriptCommandDef.ParamType.None);
		command[117] = new ScriptCommandDef("forcehelmhair", ScriptCommandDef.ParamType.None);
		command[118] = new ScriptCommandDef("forcehelmbeard", ScriptCommandDef.ParamType.None);
		command[119] = new ScriptCommandDef("forcenameless", ScriptCommandDef.ParamType.None);
		command[92] = new ScriptCommandDef("capestep", ScriptCommandDef.ParamType.None);
		command[115] = new ScriptCommandDef("crushin", ScriptCommandDef.ParamType.None);
		command[114] = new ScriptCommandDef("exebarge", ScriptCommandDef.ParamType.None);
		command[113] = new ScriptCommandDef("impale", ScriptCommandDef.ParamType.None);
		command[112] = new ScriptCommandDef("skelewarp", ScriptCommandDef.ParamType.None);
		command[106] = new ScriptCommandDef("canroll", ScriptCommandDef.ParamType.None);
		command[105] = new ScriptCommandDef("weapslide", ScriptCommandDef.ParamType.Int);
		command[111] = new ScriptCommandDef("setjampgoto", ScriptCommandDef.ParamType.Int);
		command[103] = new ScriptCommandDef("zoombump", ScriptCommandDef.ParamType.Int);
		command[102] = new ScriptCommandDef("setmashthreshgoto", ScriptCommandDef.ParamType.Int);
		command[104] = new ScriptCommandDef("resethitswipe", ScriptCommandDef.ParamType.None);
		command[101] = new ScriptCommandDef("facetarg", ScriptCommandDef.ParamType.None);
		command[98] = new ScriptCommandDef("sndspellcharge", ScriptCommandDef.ParamType.None);
		command[90] = new ScriptCommandDef("frictionoff", ScriptCommandDef.ParamType.None);
		command[91] = new ScriptCommandDef("frictionon", ScriptCommandDef.ParamType.None);
		command[96] = new ScriptCommandDef("cloakwarp", ScriptCommandDef.ParamType.None);
		command[97] = new ScriptCommandDef("startcloakwarp", ScriptCommandDef.ParamType.None);
		command[93] = new ScriptCommandDef("minicapestep", ScriptCommandDef.ParamType.None);
		command[85] = new ScriptCommandDef("iflivinggoto", ScriptCommandDef.ParamType.Int);
		command[86] = new ScriptCommandDef("dmggrabber", ScriptCommandDef.ParamType.Int);
		command[94] = new ScriptCommandDef("poisongrabber", ScriptCommandDef.ParamType.Int);
		command[84] = new ScriptCommandDef("aircombo", ScriptCommandDef.ParamType.None);
		command[88] = new ScriptCommandDef("cantturn", ScriptCommandDef.ParamType.None);
		command[89] = new ScriptCommandDef("canturn", ScriptCommandDef.ParamType.None);
		command[83] = new ScriptCommandDef("iftargbelowgoto", ScriptCommandDef.ParamType.Int);
		command[82] = new ScriptCommandDef("switchtoghost", ScriptCommandDef.ParamType.None);
		command[81] = new ScriptCommandDef("gotooff", ScriptCommandDef.ParamType.None);
		command[80] = new ScriptCommandDef("killdialog", ScriptCommandDef.ParamType.None);
		command[79] = new ScriptCommandDef("ifnotunnelgoto", ScriptCommandDef.ParamType.Int);
		command[78] = new ScriptCommandDef("lightcandle", ScriptCommandDef.ParamType.None);
		command[76] = new ScriptCommandDef("starthang", ScriptCommandDef.ParamType.None);
		command[77] = new ScriptCommandDef("endhang", ScriptCommandDef.ParamType.None);
		command[75] = new ScriptCommandDef("swordwarp", ScriptCommandDef.ParamType.None);
		command[65] = new ScriptCommandDef("kickriposte", ScriptCommandDef.ParamType.None);
		command[70] = new ScriptCommandDef("atkcharge", ScriptCommandDef.ParamType.None);
		command[71] = new ScriptCommandDef("strongcharge", ScriptCommandDef.ParamType.None);
		command[72] = new ScriptCommandDef("ifdownedgoto", ScriptCommandDef.ParamType.Int);
		command[73] = new ScriptCommandDef("canstomp", ScriptCommandDef.ParamType.None);
		command[74] = new ScriptCommandDef("cantstomp", ScriptCommandDef.ParamType.None);
		command[100] = new ScriptCommandDef("ifphasegoto", ScriptCommandDef.ParamType.Int);
		command[107] = new ScriptCommandDef("ifcrazegoto", ScriptCommandDef.ParamType.Int);
		command[66] = new ScriptCommandDef("ifr25goto", ScriptCommandDef.ParamType.Int);
		command[67] = new ScriptCommandDef("ifr50goto", ScriptCommandDef.ParamType.Int);
		command[68] = new ScriptCommandDef("ifr75goto", ScriptCommandDef.ParamType.Int);
		command[64] = new ScriptCommandDef("ifbuffedgoto", ScriptCommandDef.ParamType.Int);
		command[63] = new ScriptCommandDef("selfbuff", ScriptCommandDef.ParamType.None);
		command[61] = new ScriptCommandDef("setupperonlygoto", ScriptCommandDef.ParamType.Int);
		command[99] = new ScriptCommandDef("setloweronlygoto", ScriptCommandDef.ParamType.Int);
		command[59] = new ScriptCommandDef("upsidedown", ScriptCommandDef.ParamType.None);
		command[62] = new ScriptCommandDef("rollatk", ScriptCommandDef.ParamType.None);
		command[60] = new ScriptCommandDef("setatkonlygoto", ScriptCommandDef.ParamType.Int);
		command[55] = new ScriptCommandDef("aimon", ScriptCommandDef.ParamType.None);
		command[56] = new ScriptCommandDef("aimoff", ScriptCommandDef.ParamType.None);
		command[54] = new ScriptCommandDef("leap", ScriptCommandDef.ParamType.None);
		command[53] = new ScriptCommandDef("setrelgoto", ScriptCommandDef.ParamType.Int);
		command[50] = new ScriptCommandDef("warp", ScriptCommandDef.ParamType.None);
		command[51] = new ScriptCommandDef("startwarp", ScriptCommandDef.ParamType.None);
		command[52] = new ScriptCommandDef("sorcer", ScriptCommandDef.ParamType.None);
		command[47] = new ScriptCommandDef("setbuff", ScriptCommandDef.ParamType.None);
		command[48] = new ScriptCommandDef("resetswipes", ScriptCommandDef.ParamType.None);
		command[45] = new ScriptCommandDef("readmessage", ScriptCommandDef.ParamType.None);
		command[46] = new ScriptCommandDef("hidebottle", ScriptCommandDef.ParamType.None);
		command[38] = new ScriptCommandDef("voxjab", ScriptCommandDef.ParamType.None);
		command[39] = new ScriptCommandDef("voxfierce", ScriptCommandDef.ParamType.None);
		command[40] = new ScriptCommandDef("voxhit", ScriptCommandDef.ParamType.None);
		command[41] = new ScriptCommandDef("voxdie", ScriptCommandDef.ParamType.None);
		command[42] = new ScriptCommandDef("voxlaugh", ScriptCommandDef.ParamType.None);
		command[43] = new ScriptCommandDef("voxgrowl", ScriptCommandDef.ParamType.None);
		command[44] = new ScriptCommandDef("voxscream", ScriptCommandDef.ParamType.None);
		command[37] = new ScriptCommandDef("activateswitch", ScriptCommandDef.ParamType.None);
		command[35] = new ScriptCommandDef("startchant", ScriptCommandDef.ParamType.None);
		command[36] = new ScriptCommandDef("firechant", ScriptCommandDef.ParamType.None);
		command[34] = new ScriptCommandDef("useitem", ScriptCommandDef.ParamType.None);
		command[32] = new ScriptCommandDef("sndmove", ScriptCommandDef.ParamType.None);
		command[31] = new ScriptCommandDef("play", ScriptCommandDef.ParamType.String);
		command[28] = new ScriptCommandDef("ladderoffup", ScriptCommandDef.ParamType.None);
		command[29] = new ScriptCommandDef("ladderoffdown", ScriptCommandDef.ParamType.None);
		command[30] = new ScriptCommandDef("onladderdown", ScriptCommandDef.ParamType.None);
		command[26] = new ScriptCommandDef("ladderup", ScriptCommandDef.ParamType.None);
		command[27] = new ScriptCommandDef("ladderdown", ScriptCommandDef.ParamType.None);
		command[25] = new ScriptCommandDef("openchest", ScriptCommandDef.ParamType.None);
		command[24] = new ScriptCommandDef("showgrabber", ScriptCommandDef.ParamType.String);
		command[95] = new ScriptCommandDef("blastgrabber", ScriptCommandDef.ParamType.String);
		command[110] = new ScriptCommandDef("dropgrabber", ScriptCommandDef.ParamType.String);
		command[10] = new ScriptCommandDef("float", ScriptCommandDef.ParamType.None);
		command[18] = new ScriptCommandDef("unfloat", ScriptCommandDef.ParamType.None);
		command[0] = new ScriptCommandDef("joyjump", ScriptCommandDef.ParamType.None);
		command[33] = new ScriptCommandDef("setfall", ScriptCommandDef.ParamType.Int);
		command[1] = new ScriptCommandDef("setanim", ScriptCommandDef.ParamType.String);
		command[2] = new ScriptCommandDef("gotoframe", ScriptCommandDef.ParamType.Int);
		command[49] = new ScriptCommandDef("setitemgoto", ScriptCommandDef.ParamType.Int);
		command[3] = new ScriptCommandDef("setjump", ScriptCommandDef.ParamType.Int);
		command[4] = new ScriptCommandDef("slide", ScriptCommandDef.ParamType.Int);
		command[58] = new ScriptCommandDef("groundslide", ScriptCommandDef.ParamType.Int);
		command[5] = new ScriptCommandDef("backup", ScriptCommandDef.ParamType.Int);
		command[69] = new ScriptCommandDef("setoffgoto", ScriptCommandDef.ParamType.Int);
		command[6] = new ScriptCommandDef("setatkgoto", ScriptCommandDef.ParamType.Int);
		command[8] = new ScriptCommandDef("setuppergoto", ScriptCommandDef.ParamType.Int);
		command[7] = new ScriptCommandDef("setlowergoto", ScriptCommandDef.ParamType.Int);
		command[14] = new ScriptCommandDef("setstronggoto", ScriptCommandDef.ParamType.Int);
		command[108] = new ScriptCommandDef("setstronguppergoto", ScriptCommandDef.ParamType.Int);
		command[109] = new ScriptCommandDef("setstronglowergoto", ScriptCommandDef.ParamType.Int);
		command[57] = new ScriptCommandDef("setstrongonlygoto", ScriptCommandDef.ParamType.Int);
		command[87] = new ScriptCommandDef("setstronglightgoto", ScriptCommandDef.ParamType.Int);
		command[9] = new ScriptCommandDef("cleargotos", ScriptCommandDef.ParamType.None);
		command[15] = new ScriptCommandDef("quake", ScriptCommandDef.ParamType.Int);
		command[11] = new ScriptCommandDef("killme", ScriptCommandDef.ParamType.None);
		command[12] = new ScriptCommandDef("ethereal", ScriptCommandDef.ParamType.None);
		command[13] = new ScriptCommandDef("solid", ScriptCommandDef.ParamType.None);
		command[16] = new ScriptCommandDef("runjump", ScriptCommandDef.ParamType.None);
		command[17] = new ScriptCommandDef("charge", ScriptCommandDef.ParamType.Int);
		command[19] = new ScriptCommandDef("ifupgoto", ScriptCommandDef.ParamType.Int);
		command[20] = new ScriptCommandDef("ifdowngoto", ScriptCommandDef.ParamType.Int);
		command[21] = new ScriptCommandDef("rollburn", ScriptCommandDef.ParamType.None);
		command[22] = new ScriptCommandDef("dodgeburn", ScriptCommandDef.ParamType.None);
		command[23] = new ScriptCommandDef("jumpburn", ScriptCommandDef.ParamType.None);
	}

	public static ScriptCommand ParseString(string line)
	{
		for (int i = 0; i < command.Length; i++)
		{
			if (command[i] != null && line.Length >= command[i].text.Length && line.Substring(0, command[i].text.Length) == command[i].text)
			{
				return command[i].paramType switch
				{
					ScriptCommandDef.ParamType.String => new ScriptCommand(i, -1, line.Substring(command[i].text.Length + 1)), 
					ScriptCommandDef.ParamType.Int => new ScriptCommand(i, Convert.ToInt32(line.Substring(command[i].text.Length + 1)), ""), 
					_ => new ScriptCommand(i, -1, ""), 
				};
			}
		}
		return null;
	}
}
