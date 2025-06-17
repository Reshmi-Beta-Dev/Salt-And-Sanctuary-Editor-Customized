using System.Collections.Generic;

namespace SheetEdit.TextureSheet;

public class XSpriteFlags
{
	public const int MAP_FLAGS_NONE = 0;

	public const int MAP_FLAGS_LAYERBUMP = 1;

	public const int MAP_FLAGS_4XLAYERBUMP = 2;

	public const int MAP_FLAGS_8XLAYERBUMP = 3;

	public const int MAP_FLAGS_TORCH = 4;

	public const int MAP_FLAGS_SWAY = 5;

	public const int MAP_FLAGS_CANDLE = 6;

	public const int MAP_FLAGS_CAMP_FIRE = 7;

	public const int MAP_FLAGS_FOG = 8;

	public const int MAP_FLAGS_V_ELEVATOR_X3 = 9;

	public const int MAP_FLAGS_H_ELEVATOR_X3 = 10;

	public const int MAP_FLAGS_SANCTUARY = 11;

	public const int MAP_FLAGS_WATER = 12;

	public const int MAP_FLAGS_TRIGGER = 13;

	public const int MAP_FLAGS_DOOR = 14;

	public const int MAP_FLAGS_LADDER_KICK = 15;

	public const int MAP_FLAGS_BOSS_ARENA = 16;

	public const int MAP_FLAGS_FIREPLACE = 17;

	public const int MAP_FLAGS_BRAZIER = 18;

	public const int MAP_FLAGS_LANTERN = 19;

	public const int MAP_FLAGS_WAVE = 20;

	public const int MAP_FLAGS_RAIN = 21;

	public const int MAP_FLAGS_BOSS_CANDLES = 22;

	public const int MAP_FLAGS_SPIN_BASE = 23;

	public const int MAP_FLAGS_SPIN_PLAT = 24;

	public const int MAP_FLAGS_GLOW_MUSHROOM_BIG = 25;

	public const int MAP_FLAGS_GLOW_MUSHROOM_SMALL = 26;

	public const int MAP_FLAGS_SWAMP_WATER = 27;

	public const int MAP_FLAGS_ROT_WOOD = 28;

	public const int MAP_FLAGS_SECRET_DOOR = 29;

	public const int MAP_FLAGS_SECRET_SLASH = 30;

	public const int MAP_FLAGS_OBELISK_LIMIT = 31;

	public const int MAP_FLAGS_WATERWHEEL_BASE = 32;

	public const int MAP_FLAGS_WATERWHEEL_PLAT = 33;

	public const int MAP_FLAGS_GRASS = 34;

	public const int MAP_FLAGS_SLOW_SWAY = 35;

	public const int MAP_FLAGS_AREA_BEACH = 36;

	public const int MAP_FLAGS_AREA_TOWER_O_STORMS = 37;

	public const int MAP_FLAGS_AREA_SUNKEN_KEEP = 38;

	public const int MAP_FLAGS_AREA_PARTY_FORT = 39;

	public const int MAP_FLAGS_AREA_VILLAGE = 40;

	public const int MAP_FLAGS_AREA_CAVEY_CAVE = 41;

	public const int MAP_FLAGS_AREA_BANDITS_PASS = 42;

	public const int MAP_FLAGS_AREA_FOREST = 43;

	public const int MAP_FLAGS_AREA_RED_DUNGEON = 44;

	public const int MAP_FLAGS_AREA_DOMEY_DOME = 45;

	public const int MAP_FLAGS_AREA_ZIGGURAT = 46;

	public const int MAP_FLAGS_AREA_RUINS = 47;

	public const int MAP_FLAGS_AREA_DARK_WOODS = 48;

	public const int MAP_FLAGS_AREA_SIAM_LAKE = 49;

	public const int MAP_FLAGS_AREA_FAR_BEACH = 50;

	public const int MAP_FLAGS_AREA_SWAMPY_SWAMP = 51;

	public const int MAP_FLAGS_AREA_COASTAL_FORT = 52;

	public const int MAP_FLAGS_BLINK_MAIN_1 = 53;

	public const int MAP_FLAGS_BLINK_MAIN_2 = 54;

	public const int MAP_FLAGS_BLINK_QUICK_1 = 55;

	public const int MAP_FLAGS_BLINK_QUICK_2 = 56;

	public const int MAP_FLAGS_BLINK_QUICK_3 = 57;

	public const int MAP_FLAGS_BLINK_QUICK_4 = 58;

	public const int MAP_FLAGS_BLINK_QUICK_5 = 59;

	public const int MAP_FLAGS_BLINK_QUICK_6 = 60;

	public const int MAP_FLAGS_LEAF_SWAY = 61;

	public const int MAP_FLAGS_BRANCH_SWAY = 62;

	public const int MAP_FLAGS_TRICKLE = 63;

	public const int MAP_FLAGS_BIG_TRICKLE = 64;

	public const int MAP_FLAGS_CANDLE_ROW = 65;

	public const int MAP_FLAGS_TUBE_1 = 66;

	public const int MAP_FLAGS_TUBE_2 = 67;

	public const int MAP_FLAGS_TUBE_3 = 68;

	public const int MAP_FLAGS_TUBE_D1 = 69;

	public const int MAP_FLAGS_TUBE_D2 = 70;

	public const int MAP_FLAGS_VESSEL_1 = 71;

	public const int MAP_FLAGS_VESSEL_2 = 72;

	public const int MAP_FLAGS_VESSEL_3 = 73;

	public const int MAP_FLAGS_SPRITECANDLE = 74;

	public const int MAP_FLAGS_WOOSH = 75;

	public const int MAP_FLAGS_WOOSH_CW = 76;

	public const int MAP_FLAGS_WOOSH_CCW = 77;

	public const int MAP_FLAGS_RED_BLOCKER = 78;

	public const int MAP_FLAGS_BLUE_ETHEREAL = 79;

	public const int MAP_FLAGS_AREA_LAB = 80;

	public const int MAP_FLAGS_AREA_TOMB = 81;

	public const int MAP_FLAGS_AREA_OLD_PALACE = 82;

	public const int MAP_FLAGS_RIGHT_SKIFF = 83;

	public const int MAP_FLAGS_LEFT_SKIFF = 84;

	public const int MAP_FLAGS_AREA_DUNGEON_CAVE = 85;

	public const int MAP_FLAGS_CANDLE_TREE = 86;

	public const int MAP_FLAGS_TREE_CANDLE = 87;

	public const int MAP_FLAGS_V_TRICKLE = 88;

	public const int MAP_FLAGS_FLICKER_CANDLE = 89;

	public const int MAP_FLAGS_AREA_DARK_CREED = 90;

	public const int MAP_FLAGS_BLUE_WAVES = 91;

	public const int MAP_FLAGS_BRAND_FIRE = 92;

	public const int MAP_FLAGS_AREA_FLOATING_CASTLE = 93;

	public const int CHAR_FLAGS_NONE = 0;

	public const int CHAR_FLAGS_HELMET = 1;

	public const int CHAR_FLAGS_TORSO = 2;

	public const int CHAR_FLAGS_BRACERS = 3;

	public const int CHAR_FLAGS_GLOVES = 4;

	public const int CHAR_FLAGS_LEGS = 5;

	public const int CHAR_FLAGS_BOOTS = 6;

	public const int CHAR_FLAGS_WEAPON = 7;

	public const int CHAR_FLAGS_SHIELD = 8;

	public const int CHAR_FLAGS_SHOULDERS = 9;

	public const int CHAR_FLAGS_DREAD_HELM_1 = 10;

	public const int CHAR_FLAGS_DREAD_HELM_2 = 11;

	public const int CHAR_FLAGS_SWORDRING = 12;

	public const int CHAR_FLAGS_ADDITIVE = 13;

	public const int CHAR_FLAGS_WRAITH_SMOKE = 14;

	public const int CHAR_FLAGS_NO_HIT = 15;

	public const int CHAR_FLAGS_GOLEM_HELM = 16;

	public const int CHAR_FLAGS_BAT_WING = 17;

	public const int CHAR_FLAGS_PHANTASM_HEART = 18;

	public const int CHAR_FLAGS_BULL_EYE = 19;

	public const int CHAR_FLAGS_DRAGON_EYE = 20;

	public const int CHAR_FLAGS_OBELISK_EYE = 21;

	public const int CHAR_FLAGS_FIRE = 22;

	public const int CHAR_FLAGS_GHOSTWAIST = 23;

	public const int CHAR_FLAGS_NORECT = 24;

	public const int CHAR_FLAGS_WRAITH_EYE = 25;

	public const int CHAR_FLAGS_WRAITH_EYE_2 = 26;

	public const int CHAR_FLAGS_PUPIL = 27;

	public const int CHAR_FLAGS_ROPE_1 = 28;

	public const int CHAR_FLAGS_ROPE_2 = 29;

	public const int CHAR_FLAGS_ROPE_3 = 30;

	public const int CHAR_FLAGS_ROPE_4 = 31;

	public const int CHAR_FLAGS_ROPE_5 = 32;

	public const int CHAR_FLAGS_ROPE_6 = 33;

	public const int CHAR_FLAGS_ROPE_7 = 34;

	public const int CHAR_FLAGS_ROPE_8 = 35;

	public const int CHAR_FLAGS_LANTERN = 36;

	public const int CHAR_FLAGS_RUNE_1 = 37;

	public const int CHAR_FLAGS_RUNE_2 = 38;

	public const int CHAR_FLAGS_STONE_HEART = 39;

	public const int CHAR_FLAGS_CRUSHED_HEAD = 40;

	public const int CHAR_FLAGS_TREE_BAR = 41;

	public const int CHAR_FLAGS_TREE_DISC = 42;

	public const int CHAR_FLAGS_TORTURE_HEAD = 43;

	public const int CHAR_FLAGS_TORTURE_SOUL = 44;

	public static List<string> strList;

	internal static void PopulateMap()
	{
		strList = new List<string>();
		strList.Add("None");
		strList.Add("Layerbump");
		strList.Add("4X Layerbump");
		strList.Add("8X Layerbump");
		strList.Add("Torch");
		strList.Add("Sway");
		strList.Add("Candle");
		strList.Add("Campfire");
		strList.Add("Fog");
		strList.Add("V Elevator x3");
		strList.Add("H Elevator x3");
		strList.Add("Sanctuary");
		strList.Add("Water");
		strList.Add("Trigger");
		strList.Add("Door");
		strList.Add("Ladderkick");
		strList.Add("BossArena");
		strList.Add("Fireplace");
		strList.Add("Brazier");
		strList.Add("Lantern");
		strList.Add("Wave");
		strList.Add("Rain");
		strList.Add("Boss Candles");
		strList.Add("Spin base");
		strList.Add("Spin plat");
		strList.Add("Glowshroom Big");
		strList.Add("Glowshroom Small");
		strList.Add("Swampwater");
		strList.Add("Rotwood");
		strList.Add("Secret Door");
		strList.Add("Secret Slash");
		strList.Add("Obelisk limit");
		strList.Add("Waterwheel Base");
		strList.Add("Waterwheel Plat");
		strList.Add("Grass");
		strList.Add("Slow Sway");
		strList.Add("AREA_BEACH");
		strList.Add("AREA_TOWER_O_STORMS");
		strList.Add("AREA_SUNKEN_KEEP");
		strList.Add("AREA_PARTY_FORT");
		strList.Add("AREA_VILLAGE");
		strList.Add("AREA_CAVEY_CAVE");
		strList.Add("AREA_BANDITS_PASS");
		strList.Add("AREA_FOREST");
		strList.Add("AREA_RED_DUNGEON");
		strList.Add("AREA_DOMEY_DOME");
		strList.Add("AREA_ZIGGURAT");
		strList.Add("AREA_RUINS");
		strList.Add("AREA_DARK_WOODS");
		strList.Add("AREA_SIAM_LAKE");
		strList.Add("AREA_FAR_BEACH");
		strList.Add("AREA_SWAMPY_SWAMP");
		strList.Add("AREA_COASTAL_FORT");
		strList.Add("Blink Main 1");
		strList.Add("Blink Main 2");
		strList.Add("Blink Quick 1");
		strList.Add("Blink Quick 2");
		strList.Add("Blink Quick 3");
		strList.Add("Blink Quick 4");
		strList.Add("Blink Quick 5");
		strList.Add("Blink Quick 6");
		strList.Add("Leaf Sway");
		strList.Add("Branch Sway");
		strList.Add("Trickle");
		strList.Add("Big Trickle");
		strList.Add("Candle Row");
		strList.Add("Tube 1");
		strList.Add("Tube 2");
		strList.Add("Tube 3");
		strList.Add("Tube d1");
		strList.Add("Tube d2");
		strList.Add("Vessel 1");
		strList.Add("Vessel 2");
		strList.Add("Vessel 3");
		strList.Add("Spritecandle");
		strList.Add("Woosh");
		strList.Add("Woosh CW");
		strList.Add("Woosh CCW");
		strList.Add("Red Blocker");
		strList.Add("Blue Ethereal");
		strList.Add("AREA_LAB");
		strList.Add("AREA_TOMB");
		strList.Add("AREA_OLD_PALACE");
		strList.Add("Right Skiff");
		strList.Add("Left Skiff");
		strList.Add("AREA_DUNGEON_CAVE");
		strList.Add("Candle Tree");
		strList.Add("Tree Candle");
		strList.Add("V Trickle");
		strList.Add("Flicker Candle");
		strList.Add("AREA_DARK_CREED");
		strList.Add("Blue waves");
		strList.Add("Brand fire");
		strList.Add("AREA_FLOATING_CASTLE");
	}

	internal static void PopulateChars()
	{
		strList = new List<string>();
		strList.Add("None");
		strList.Add("Helmet");
		strList.Add("Torso");
		strList.Add("Bracers");
		strList.Add("Gloves");
		strList.Add("Legs");
		strList.Add("Boots");
		strList.Add("Weapon");
		strList.Add("Shield");
		strList.Add("Shoulders");
		strList.Add("Dreadhelm1");
		strList.Add("Dreadhelm2");
		strList.Add("Swordring");
		strList.Add("Additive");
		strList.Add("Wraith Smoke");
		strList.Add("No Hit");
		strList.Add("Golem Helm");
		strList.Add("Bat Wing");
		strList.Add("Phantasm Heart");
		strList.Add("Bull Eye");
		strList.Add("Dragon Eye");
		strList.Add("Obelisk Eye");
		strList.Add("Fire");
		strList.Add("Ghostwaist");
		strList.Add("No Rect");
		strList.Add("Wraith Eye");
		strList.Add("Wraith Eye 2");
		strList.Add("Pupil");
		strList.Add("Rope1");
		strList.Add("Rope2");
		strList.Add("Rope3");
		strList.Add("Rope4");
		strList.Add("Rope5");
		strList.Add("Rope6");
		strList.Add("Rope7");
		strList.Add("Rope8");
		strList.Add("Lantern");
		strList.Add("Rune 1");
		strList.Add("Rune 2");
		strList.Add("Stone Heart");
		strList.Add("Crushed Head");
		strList.Add("Tree Bar");
		strList.Add("Tree Disc");
		strList.Add("Torture Head");
		strList.Add("Torture Soul");
	}
}
