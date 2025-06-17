using System.IO;
using System.Text;
using LootEdit;

namespace MonsterEdit.monsters;

public class MonsterDef
{
	public struct MonsterDrop
	{
		public string dropLoot;

		public float dropRate;

		public int dropCount;

		public MonsterDrop(float rate, string loot)
		{
			dropRate = rate;
			dropLoot = loot;
			dropCount = 1;
		}

		public MonsterDrop(BinaryReader reader)
		{
			dropRate = reader.ReadSingle();
			dropLoot = reader.ReadString();
			dropCount = reader.ReadInt32();
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(dropRate);
			writer.Write((dropLoot == null) ? "" : dropLoot);
			writer.Write(dropCount);
		}
	}

	public string stepSnd = "";

	public string jabSnd = "";

	public string fierceSnd = "";

	public string growlSnd = "";

	public string laughSnd = "";

	public string dieSnd = "";

	public string screamSnd = "";

	public string hitSnd = "";

	public float scale = 1f;

	public string attackAnim = "attack";

	public string strongAnim = "strong";

	public string specialAnim = "special";

	public string idleAnim = "idle";

	public string runStartAnim = "runstart";

	public string runEndAnim = "runend";

	public string runAnim = "run";

	public string blockAnim = "block";

	public string blockInAnim = "blockin";

	public string blockOutAnim = "blockout";

	public string blockAdvAnim = "blockadv";

	public string blockRetAnim = "blockret";

	public string blockAbsAnim = "blockabs";

	public float runSpeed = 300f;

	public string name;

	public string[] title;

	public string[] desc;

	public StringBuilder titleStr;

	public string def;

	public string texture;

	public bool canJump;

	public bool slowBack;

	public bool bestiary;

	public string helm;

	public string armor;

	public string gloves;

	public string boots;

	public string weapon;

	public string shield;

	public int hair;

	public int hairColor;

	public int beard;

	public int beardColor;

	public int skinClass;

	public int skinIdx;

	public int eyes;

	public float hp;

	public float attack;

	public float defense;

	public float poise;

	public float stamina;

	public float poiseAttack;

	public float blockReduce;

	public float blockDeflect;

	public float blockDmgReduce;

	public float blockMagReduce;

	public float fireDef;

	public float litDef;

	public float bladedDef;

	public float poisonDef;

	public float holyDef;

	public float darkDef;

	public float phaseThresh;

	public float crazeThresh;

	public bool fadeLayer;

	public int salt;

	public int ai;

	public int type;

	public int flags;

	public int creature;

	public int bloodType;

	public int boxWidth;

	public int boxHeight;

	public const int TYPE_NPC = 0;

	public const int TYPE_MONSTER = 1;

	public const int TYPE_CHEST = 2;

	public const int TYPE_SWITCH = 3;

	public const int TYPE_TRIPWIRE = 4;

	public const int TYPE_TRAP = 5;

	public const int TYPE_DESTRUCTIBLE_TRAP = 6;

	public const int TYPE_CRITTER = 7;

	public const int TYPE_MIMIC = 8;

	public const int TYPE_EXTRACTABLE = 9;

	public const int FLAGS_NONE = 0;

	public const int FLAGS_FOLLOWER = 1;

	public const int FLAGS_FRIENDLY = 2;

	public const int FLAGS_OBELISK = 3;

	public const int FLAGS_SACK = 4;

	public const int FLAGS_SHIP_BATTLE = 5;

	public const int FLAGS_BLIND = 6;

	public const int FLAGS_RUNE_PRIEST = 7;

	public const int FLAGS_HORSEHEAD = 8;

	public const int CREATURE_HUMAN = 0;

	public const int CREATURE_ZOMBIE = 1;

	public const int CREATURE_DEMON = 2;

	public const int CREATURE_INSECT = 3;

	public const int CREATURE_BLOB = 4;

	public const int CREATURE_METAL = 5;

	public const int CREATURE_STONE = 6;

	public const int CREATURE_SKELETON = 7;

	public const int CREATURE_GHOST = 8;

	public const int CREATURE_CYBORG = 9;

	public const int AI_NONE = 0;

	public const int AI_SOLDIER = 1;

	public const int AI_ARCHER = 2;

	public const int AI_BULL = 3;

	public const int AI_SHROUD = 4;

	public const int AI_RAGS = 5;

	public const int AI_DOG = 6;

	public const int AI_KNIGHT = 7;

	public const int AI_WRAITH = 8;

	public const int AI_BLOB = 9;

	public const int AI_RAIDER = 10;

	public const int AI_SORCEROR = 11;

	public const int AI_BAT = 12;

	public const int AI_DRAGON = 13;

	public const int AI_FIEND = 14;

	public const int AI_HAWK = 15;

	public const int AI_IMP = 16;

	public const int AI_TORTURED = 17;

	public const int AI_TORTURE_TREE = 18;

	public const int AI_SKULL = 19;

	public const int AI_WITCH = 20;

	public const int AI_GAS_BAG = 21;

	public const int AI_BANDAGES = 22;

	public const int AI_LAKE_WITCH = 23;

	public const int AI_LEAP_MELEE = 24;

	public const int AI_LICH = 25;

	public const int AI_INQUISITOR = 26;

	public const int AI_HANGMAN = 27;

	public const int AI_EYEBALL = 28;

	public const int AI_HORSEMAN = 29;

	public const int AI_SALT_BAT = 30;

	public const int AI_CROW = 31;

	public const int AI_RUIN_GHOST = 32;

	public const int AI_RUIN_KNIGHT = 33;

	public const int AI_RUIN_AXE = 34;

	public const int AI_CULT = 35;

	public const int AI_SQUIDMIMIC = 36;

	public const int AI_SKELETON_ARCHER = 37;

	public const int AI_SKELETON_RAGS = 38;

	public const int AI_SKELETON_SOLDIER = 39;

	public const int AI_DRONE = 40;

	public const int AI_SHOCK_TROOPER = 41;

	public const int TOTAL_MONSTER_DROPS = 6;

	public MonsterDrop[] monsterDrop;

	public const int BLOOD_DUST = 0;

	public const int BLOOD_DUST_QUIET = 1;

	public const int BLOOD_SPARKS = 2;

	public const int BLOOD_RED = 3;

	public const int BLOOD_HERO = 4;

	public const int BLOOD_SWOOSH = 5;

	public const int BLOOD_GOO = 6;

	public const int BLOOD_METAL = 7;

	public const int BLOOD_DEMON = 8;

	public const int BLOOD_STONE = 9;

	public const int BLOOD_GLOW = 10;

	public bool giant;

	public bool hover;

	public int attackReach;

	public int strongReach;

	public int specialReach;

	public const int REACH_CLOSE = 0;

	public const int REACH_MELEE = 1;

	public const int REACH_REACH = 2;

	public const int REACH_LUNGE = 3;

	public const int REACH_THROWN = 4;

	public const int REACH_RANGED = 5;

	public MonsterDef(BinaryReader reader)
	{
		Read(reader);
	}

	public MonsterDef(MonsterDef otherDef)
	{
		name = otherDef.name;
		title = new string[13];
		desc = new string[13];
		for (int i = 0; i < title.Length; i++)
		{
			title[i] = otherDef.title[i];
		}
		for (int j = 0; j < desc.Length; j++)
		{
			desc[j] = otherDef.title[j];
		}
		boxWidth = otherDef.boxWidth;
		boxHeight = otherDef.boxHeight;
		def = otherDef.def;
		texture = otherDef.texture;
		fadeLayer = otherDef.fadeLayer;
		helm = otherDef.helm;
		armor = otherDef.armor;
		gloves = otherDef.gloves;
		boots = otherDef.boots;
		weapon = otherDef.weapon;
		shield = otherDef.shield;
		phaseThresh = otherDef.phaseThresh;
		crazeThresh = otherDef.crazeThresh;
		hair = otherDef.hair;
		hairColor = otherDef.hairColor;
		slowBack = otherDef.slowBack;
		bestiary = otherDef.bestiary;
		skinClass = otherDef.skinClass;
		skinIdx = otherDef.skinIdx;
		eyes = otherDef.eyes;
		hp = otherDef.hp;
		attack = otherDef.attack;
		defense = otherDef.defense;
		poise = otherDef.poise;
		stamina = otherDef.stamina;
		poiseAttack = otherDef.poiseAttack;
		blockReduce = otherDef.blockReduce;
		blockDeflect = otherDef.blockDeflect;
		blockDmgReduce = otherDef.blockDmgReduce;
		blockMagReduce = otherDef.blockMagReduce;
		fireDef = otherDef.fireDef;
		litDef = otherDef.litDef;
		bladedDef = otherDef.bladedDef;
		poisonDef = otherDef.poisonDef;
		holyDef = otherDef.holyDef;
		darkDef = otherDef.darkDef;
		salt = otherDef.salt;
		ai = otherDef.ai;
		type = otherDef.type;
		flags = otherDef.flags;
		creature = otherDef.creature;
		bloodType = otherDef.bloodType;
		stepSnd = otherDef.stepSnd;
		jabSnd = otherDef.jabSnd;
		fierceSnd = otherDef.fierceSnd;
		growlSnd = otherDef.growlSnd;
		laughSnd = otherDef.laughSnd;
		dieSnd = otherDef.dieSnd;
		screamSnd = otherDef.screamSnd;
		hitSnd = otherDef.hitSnd;
		scale = otherDef.scale;
		giant = otherDef.giant;
		hover = otherDef.hover;
		attackAnim = otherDef.attackAnim;
		strongAnim = otherDef.strongAnim;
		specialAnim = otherDef.specialAnim;
		idleAnim = otherDef.idleAnim;
		runStartAnim = otherDef.runStartAnim;
		runEndAnim = otherDef.runEndAnim;
		runAnim = otherDef.runAnim;
		blockAnim = otherDef.blockAnim;
		blockInAnim = otherDef.blockInAnim;
		blockOutAnim = otherDef.blockOutAnim;
		blockAdvAnim = otherDef.blockAdvAnim;
		blockRetAnim = otherDef.blockRetAnim;
		blockAbsAnim = otherDef.blockAbsAnim;
		attackReach = otherDef.attackReach;
		strongReach = otherDef.strongReach;
		specialReach = otherDef.specialReach;
		runSpeed = otherDef.runSpeed;
		monsterDrop = new MonsterDrop[6];
		for (int k = 0; k < monsterDrop.Length; k++)
		{
			monsterDrop[k] = new MonsterDrop(otherDef.monsterDrop[k].dropRate, otherDef.monsterDrop[k].dropLoot);
		}
	}

	public MonsterDef()
	{
		title = new string[13];
		desc = new string[13];
		for (int i = 0; i < title.Length; i++)
		{
			title[i] = "";
		}
		for (int j = 0; j < desc.Length; j++)
		{
			desc[j] = "";
		}
		monsterDrop = new MonsterDrop[6];
	}

	public void Write(BinaryWriter writer)
	{
		writer.Write(name);
		for (int i = 0; i < 13; i++)
		{
			if (i < title.Length)
			{
				writer.Write(title[i]);
			}
			else
			{
				writer.Write(title[0] + " - " + TranslationMgr.GetLangStrFromIdx(i));
			}
		}
		for (int j = 0; j < 13; j++)
		{
			if (j < desc.Length)
			{
				writer.Write(desc[j]);
			}
			else
			{
				writer.Write("Untranslated Description: " + TranslationMgr.GetLangStrFromIdx(j));
			}
		}
		writer.Write(boxWidth);
		writer.Write(boxHeight);
		writer.Write(phaseThresh);
		writer.Write(crazeThresh);
		writer.Write(def);
		writer.Write(texture);
		writer.Write(helm);
		writer.Write(armor);
		writer.Write(gloves);
		writer.Write(boots);
		writer.Write(weapon);
		writer.Write(shield);
		writer.Write(stepSnd);
		writer.Write(jabSnd);
		writer.Write(fierceSnd);
		writer.Write(hitSnd);
		writer.Write(growlSnd);
		writer.Write(laughSnd);
		writer.Write(dieSnd);
		writer.Write(screamSnd);
		writer.Write(hair);
		writer.Write(hairColor);
		writer.Write(beard);
		writer.Write(beardColor);
		writer.Write(skinIdx);
		writer.Write(skinClass);
		writer.Write(eyes);
		writer.Write(hp);
		writer.Write(attack);
		writer.Write(defense);
		writer.Write(poise);
		writer.Write(stamina);
		writer.Write(poiseAttack);
		writer.Write(blockReduce);
		writer.Write(blockDeflect);
		writer.Write(blockDmgReduce);
		writer.Write(blockMagReduce);
		writer.Write(runSpeed);
		writer.Write(fireDef);
		writer.Write(litDef);
		writer.Write(bladedDef);
		writer.Write(poisonDef);
		writer.Write(holyDef);
		writer.Write(darkDef);
		writer.Write(salt);
		writer.Write(ai);
		writer.Write(type);
		writer.Write(flags);
		writer.Write(giant);
		writer.Write(hover);
		writer.Write(creature);
		writer.Write(slowBack);
		writer.Write(bestiary);
		writer.Write(fadeLayer);
		writer.Write(attackAnim);
		writer.Write(strongAnim);
		writer.Write(specialAnim);
		writer.Write(attackReach);
		writer.Write(strongReach);
		writer.Write(specialReach);
		writer.Write(idleAnim);
		writer.Write(runAnim);
		writer.Write(runStartAnim);
		writer.Write(runEndAnim);
		writer.Write(blockAnim);
		writer.Write(blockInAnim);
		writer.Write(blockOutAnim);
		writer.Write(blockAdvAnim);
		writer.Write(blockRetAnim);
		writer.Write(blockAbsAnim);
		for (int k = 0; k < monsterDrop.Length; k++)
		{
			monsterDrop[k].Write(writer);
		}
	}

	public void Read(BinaryReader reader)
	{
		name = reader.ReadString();
		title = new string[13];
		desc = new string[13];
		for (int i = 0; i < title.Length; i++)
		{
			title[i] = reader.ReadString();
		}
		for (int j = 0; j < desc.Length; j++)
		{
			desc[j] = reader.ReadString();
		}
		boxWidth = reader.ReadInt32();
		boxHeight = reader.ReadInt32();
		phaseThresh = reader.ReadSingle();
		crazeThresh = reader.ReadSingle();
		def = reader.ReadString();
		texture = reader.ReadString();
		helm = reader.ReadString();
		armor = reader.ReadString();
		gloves = reader.ReadString();
		boots = reader.ReadString();
		weapon = reader.ReadString();
		shield = reader.ReadString();
		stepSnd = reader.ReadString();
		jabSnd = reader.ReadString();
		fierceSnd = reader.ReadString();
		hitSnd = reader.ReadString();
		growlSnd = reader.ReadString();
		laughSnd = reader.ReadString();
		dieSnd = reader.ReadString();
		screamSnd = reader.ReadString();
		hair = reader.ReadInt32();
		hairColor = reader.ReadInt32();
		beard = reader.ReadInt32();
		beardColor = reader.ReadInt32();
		skinIdx = reader.ReadInt32();
		skinClass = reader.ReadInt32();
		eyes = reader.ReadInt32();
		hp = reader.ReadSingle();
		attack = reader.ReadSingle();
		defense = reader.ReadSingle();
		poise = reader.ReadSingle();
		stamina = reader.ReadSingle();
		poiseAttack = reader.ReadSingle();
		blockReduce = reader.ReadSingle();
		blockDeflect = reader.ReadSingle();
		blockDmgReduce = reader.ReadSingle();
		blockMagReduce = reader.ReadSingle();
		runSpeed = reader.ReadSingle();
		fireDef = reader.ReadSingle();
		litDef = reader.ReadSingle();
		bladedDef = reader.ReadSingle();
		poisonDef = reader.ReadSingle();
		holyDef = reader.ReadSingle();
		darkDef = reader.ReadSingle();
		salt = reader.ReadInt32();
		ai = reader.ReadInt32();
		type = reader.ReadInt32();
		flags = reader.ReadInt32();
		giant = reader.ReadBoolean();
		hover = reader.ReadBoolean();
		creature = reader.ReadInt32();
		slowBack = reader.ReadBoolean();
		bestiary = reader.ReadBoolean();
		fadeLayer = reader.ReadBoolean();
		attackAnim = reader.ReadString();
		strongAnim = reader.ReadString();
		specialAnim = reader.ReadString();
		attackReach = reader.ReadInt32();
		strongReach = reader.ReadInt32();
		specialReach = reader.ReadInt32();
		idleAnim = reader.ReadString();
		runAnim = reader.ReadString();
		runStartAnim = reader.ReadString();
		runEndAnim = reader.ReadString();
		blockAnim = reader.ReadString();
		blockInAnim = reader.ReadString();
		blockOutAnim = reader.ReadString();
		blockAdvAnim = reader.ReadString();
		blockRetAnim = reader.ReadString();
		blockAbsAnim = reader.ReadString();
		monsterDrop = new MonsterDrop[6];
		for (int k = 0; k < monsterDrop.Length; k++)
		{
			monsterDrop[k] = new MonsterDrop(reader);
		}
	}

	public static float GetRange(int reach)
	{
		return reach switch
		{
			0 => 120f, 
			1 => 180f, 
			2 => 250f, 
			3 => 350f, 
			4 => 500f, 
			5 => 900f, 
			_ => 100f, 
		};
	}

	internal static string GetMonsterFlagsStrFromInt(int p)
	{
		return p switch
		{
			0 => "None", 
			1 => "Follower", 
			2 => "Friendly", 
			3 => "Obelisk", 
			4 => "Sack", 
			5 => "Ship Battle", 
			6 => "Blind", 
			7 => "Rune Priest", 
			8 => "Horsehead", 
			_ => "", 
		};
	}

	internal static string GetCharAIStrFromInt(int p)
	{
		return p switch
		{
			0 => "None", 
			1 => "Soldier", 
			2 => "Archer", 
			3 => "Bull", 
			4 => "Shroud", 
			5 => "Rags", 
			6 => "Dog", 
			7 => "Knight", 
			8 => "Wraith", 
			9 => "Blob", 
			10 => "Raider", 
			11 => "Sorceror", 
			12 => "Bat", 
			13 => "Dragon", 
			14 => "Fiend", 
			15 => "Hawk", 
			16 => "Imp", 
			17 => "Tortured", 
			18 => "Torture Tree", 
			19 => "Skull", 
			20 => "Witch", 
			21 => "Gasbag", 
			22 => "Bandages", 
			23 => "Lake Witch", 
			24 => "Leap Melee", 
			25 => "Lich", 
			26 => "Inquisitor", 
			27 => "Hangman", 
			28 => "Eyeball", 
			29 => "Horseman", 
			30 => "Salt Bat", 
			31 => "Crow", 
			32 => "Ruin Ghost", 
			33 => "Ruin Knight", 
			34 => "Ruin Axe", 
			35 => "Cult", 
			37 => "Skeleton Archer", 
			38 => "Skeleton Rags", 
			39 => "Skeleton Soldier", 
			40 => "Drone", 
			41 => "Shock Trooper", 
			_ => "", 
		};
	}
}
