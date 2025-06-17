using System.IO;

namespace LootEdit;

public class LootDef
{
	public struct UpgradePath
	{
		public string reqLoot;

		public string outLoot;

		public int cost;

		public int reqCount;

		public UpgradePath(string reqLoot, string outLoot, int cost, int reqCount)
		{
			this.reqLoot = reqLoot;
			this.outLoot = outLoot;
			this.cost = cost;
			this.reqCount = reqCount;
		}

		internal void Write(BinaryWriter writer)
		{
			if (reqLoot == null || outLoot == null || reqLoot == "" || outLoot == "")
			{
				writer.Write(value: false);
				return;
			}
			writer.Write(value: true);
			writer.Write(reqLoot);
			writer.Write(reqCount);
			writer.Write(outLoot);
			writer.Write(cost);
		}

		internal void Read(BinaryReader reader)
		{
			if (reader.ReadBoolean())
			{
				reqLoot = reader.ReadString();
				reqCount = reader.ReadInt32();
				outLoot = reader.ReadString();
				cost = reader.ReadInt32();
			}
		}
	}

	public const int WEAP_SPECIAL_NONE = 0;

	public const int WEAP_SPECIAL_HEALING = 1;

	public const int WEAP_SPECIAL_CHAIN_WHIP = 2;

	public const int WEAP_SPECIAL_EXTRA_BLUNT = 3;

	public const int WEAP_SPECIAL_EXTRA_BLADES = 4;

	public const int WEAP_SPECIAL_SLOW_HITTER = 5;

	public const int WEAP_SPECIAL_FAST_HITTER = 6;

	public const int WEAP_SPECIAL_SLIDE = 7;

	public const int WEAP_SPECIAL_CHARM_MOVE = 8;

	public const int WEAP_SPECIAL_WOOD_STAFF = 9;

	public const int WEAP_SPECIAL_MAX = 10;

	public const int SHIELD_SPECIAL_NONE = 0;

	public const int SHIELD_SPECIAL_HEALING = 1;

	public const int SHIELD_SPECIAL_STAMINA_REGEN = 2;

	public const int SHIELD_SPECIAL_MAX = 3;

	public const int ARMOR_SPECIAL_NONE = 0;

	public const int ARMOR_SPECIAL_HEALING = 1;

	public const int ARMOR_SPECIAL_STAMINA_REGEN = 2;

	public const int ARMOR_SPECIAL_MAX = 3;

	public const int WEAP_TYPE_DAGGER = 0;

	public const int WEAP_TYPE_SWORD = 1;

	public const int WEAP_TYPE_HAMMER = 2;

	public const int WEAP_TYPE_AXE = 3;

	public const int WEAP_TYPE_SPEAR = 4;

	public const int WEAP_TYPE_HALBERD = 5;

	public const int WEAP_TYPE_GREATSWORD = 6;

	public const int WEAP_TYPE_GREATHAMMER = 7;

	public const int WEAP_TYPE_BOW = 8;

	public const int WEAP_TYPE_CROSSBOW = 9;

	public const int WEAP_TYPE_STAFF = 10;

	public const int WEAP_TYPE_WHIP = 11;

	public const int WEAP_TYPE_GREATAXE = 12;

	public const int WEAP_TYPE_POLEAXE = 13;

	public const int WEAP_TYPE_FLINTLOCK = 14;

	public const int WEAP_TYPE_TORCH = 15;

	public const int WEAP_TYPE_WAND = 16;

	public const int WEAP_TYPE_GREATSCISSOR = 17;

	public const int WEAP_TYPE_GUNBLADE = 18;

	public const int WEAP_TYPE_WHIPSWORD = 19;

	public const int WEAP_TYPE_LONGSWORD = 20;

	public const int WEAP_TYPE_MAX = 21;

	public const int EQUIPPABLE_FALSE = 0;

	public const int EQUIPPABLE_TWO_HAND = 1;

	public const int EQUIPPABLE_TRUE = 2;

	public const int SHIELD_TYPE_BUCKLER = 0;

	public const int SHIELD_TYPE_HEATER = 1;

	public const int SHIELD_TYPE_KITE = 2;

	public const int SHIELD_TYPE_TOWER = 3;

	public const int SHIELD_TYPE_1H_HACK = 4;

	public const int SHIELD_TYPE_MAX = 5;

	public const int SHIELD_REDUCT = 0;

	public const int SHIELD_DEFLECT = 1;

	public const int SHIELD_PHYS = 2;

	public const int SHIELD_FIRE = 3;

	public const int SHIELD_LIT = 4;

	public const int SHIELD_BLADED = 5;

	public const int SHIELD_POISON = 6;

	public const int SHIELD_HOLY = 7;

	public const int SHIELD_DARK = 8;

	public const int SHIELD_REQ_PRIM = 9;

	public const int SHIELD_REQ_SEC = 10;

	public const int SHIELD_REQ_UNUSED_1 = 11;

	public const int SHIELD_REQ_UNUSED_2 = 12;

	private const int SHIELD_TOTAL_VALUES = 13;

	public const int ARMOR_TYPE_HELM = 0;

	public const int ARMOR_TYPE_ARMOR = 1;

	public const int ARMOR_TYPE_GLOVES = 2;

	public const int ARMOR_TYPE_BOOTS = 3;

	public const int ARMOR_FLAGS_NONE = 0;

	public const int ARMOR_FLAGS_ROBES = 1;

	public const int ARMOR_FLAGS_MASK_HELM = 2;

	public const int ARMOR_FLAGS_FEM2 = 3;

	public const int ARMOR_FLAGS_BEARD_COVER_HELM = 4;

	public const int ARMOR_FLAGS_CAPE = 5;

	public const int ARMOR_FLAGS_CAPE_FEM2 = 6;

	public const int ARMOR_FLAGS_SCARF = 7;

	public const int ARMOR_FLAGS_SCARF_FEM2 = 8;

	public const int ARMOR_FLAGS_COAT = 9;

	public const int ARMOR_FLAGS_COAT_FEM2 = 10;

	public const int ARMOR_FLAGS_HAT = 11;

	public const int ARMOR_FLAGS_COAT_SURCOAT = 12;

	public const int ARMOR_FLAGS_COAT_SURCOAT_FEM2 = 13;

	public const int ARMOR_FLAGS_CAPE_SURCOAT = 14;

	public const int ARMOR_FLAGS_CAPE_SURCOAT_FEM2 = 15;

	public const int ARMOR_FLAGS_ROBES_FEM2 = 16;

	public int category;

	public int type;

	public int upgrade;

	public float upgradeFac;

	public string name;

	public string[] title;

	public string[] desc;

	public int img;

	public string texture;

	public int flags;

	public int special;

	public float weight;

	public float[] values;

	public UpgradePath[] upgradePath;

	public const int TOTAL_UPGRADES = 2;

	public float value;

	public float durability;

	public const int WEAP_ATTACK = 0;

	public const int WEAP_SCALING_STR = 1;

	public const int WEAP_SCALING_DEX = 2;

	public const int WEAP_SCALING_WIS = 3;

	public const int WEAP_SCALING_MAG = 4;

	public const int WEAP_REQ_PRIM = 5;

	public const int WEAP_REQ_SEC = 6;

	public const int WEAP_REQ_UNUSED_1 = 7;

	public const int WEAP_REQ_UNUSED_2 = 8;

	public const int WEAP_SCALING_SPECIAL = 9;

	public const int WEAP_SWOOSH_1_RED = 10;

	public const int WEAP_SWOOSH_1_GREEN = 11;

	public const int WEAP_SWOOSH_1_BLUE = 12;

	public const int WEAP_SWOOSH_1_ALPHA = 13;

	public const int WEAP_SWOOSH_1_SIZE = 14;

	public const int WEAP_SWOOSH_2_RED = 15;

	public const int WEAP_SWOOSH_2_GREEN = 16;

	public const int WEAP_SWOOSH_2_BLUE = 17;

	public const int WEAP_SWOOSH_2_ALPHA = 18;

	public const int WEAP_SWOOSH_2_SIZE = 19;

	public const int WEAP_SWOOSH_3_RED = 20;

	public const int WEAP_SWOOSH_3_GREEN = 21;

	public const int WEAP_SWOOSH_3_BLUE = 22;

	public const int WEAP_SWOOSH_3_ALPHA = 23;

	public const int WEAP_SWOOSH_3_SIZE = 24;

	public const int WEAP_TOTAL_VALUES = 25;

	public const int WEAP_ATTACK_BLADED = 25;

	public const int WEAP_DMG_SPARK = 5;

	public const int WEAP_DMG_FIRE = 6;

	public const int WEAP_DMG_LIT = 7;

	public const int WEAP_DMG_NATURAL = 8;

	public const int WEAP_DMG_POISON = 9;

	public const int WEAP_DMG_FROST = 10;

	public const int WEAP_DMG_MAGIC = 11;

	public const int WEAP_DMG_HOLY = 12;

	public const int WEAP_DMG_DARK = 13;

	public const int WEAP_FLAG_NONE = 0;

	public const int WEAP_FLAG_FIRE = 1;

	public const int WEAP_FLAG_LIT = 2;

	public const int WEAP_FLAG_POISON = 3;

	public const int WEAP_FLAG_FROST = 4;

	public const int WEAP_FLAG_HOLY = 5;

	public const int WEAP_FLAG_DARK = 6;

	public const int WEAP_FLAG_HP_LEECH = 7;

	public const int WEAP_FLAG_MP_LEECH = 8;

	public const int WEAP_FLAG_POISE = 9;

	public const int WEAP_FLAG_CHARM_MOVE = 10;

	public const int WEAP_FLAG_CHARM_MOVE2 = 11;

	public const int WEAP_FLAG_MAX = 12;

	public const int ARMOR_PHYS_DEFENSE = 0;

	public const int ARMOR_FIRE_DEFENSE = 1;

	public const int ARMOR_LIT_DEFENSE = 2;

	public const int ARMOR_BLADED_DEFENSE = 3;

	public const int ARMOR_POISON_DEFENSE = 4;

	public const int ARMOR_HOLY_DEFENSE = 5;

	public const int ARMOR_DARK_DEFENSE = 6;

	public const int ARMOR_POISE = 7;

	public const int ARMOR_REQ_PRIM = 8;

	public const int ARMOR_REQ_SEC = 9;

	public const int ARMOR_REQ_UNUSED_1 = 10;

	public const int ARMOR_REQ_UNUSED_2 = 11;

	public const int ARMOR_TOTAL_VALUES = 12;

	public const int CONSUMABLE_USE_ICON = 0;

	public const int CONSUMABLE_TOTAL_VALUES = 1;

	public const int MATERIALS_TOTAL_VALUES = 1;

	public const int RING_VALUE_IMG = 0;

	public const int RING_VALUE_UNUSED = 1;

	public const int RING_TOTAL_VALUES = 2;

	public const int KEY_TOTAL_VALUES = 1;

	public const int MAGIC_REQ_PRIM = 0;

	public const int MAGIC_REQ_SEC = 1;

	public const int MAGIC_COST = 2;

	public const int MAGIC_TOTAL_VALUES = 3;

	public const int UPGRADE_NORMAL = 0;

	public const int UPGRADE_KRAEKAN = 1;

	public const int UPGRADE_RED_CARBON = 2;

	public const int UPGRADE_NONE = 3;

	public const int UPGRADE_BLUE_DROWNED = 4;

	public const int UPGRADE_BEASTLY = 5;

	public const int UPGRADE_MAX = 6;

	public LootDef()
	{
		values = new float[1];
		desc = new string[13];
		title = new string[13];
		for (int i = 0; i < 13; i++)
		{
			desc[i] = "";
			title[i] = "New Loot";
		}
		name = "new";
		upgradePath = new UpgradePath[1];
	}

	public static string GetWeapFlagsStrFromInt(int i)
	{
		return i switch
		{
			0 => "None", 
			1 => "Fire", 
			2 => "Lit", 
			3 => "Poison", 
			4 => "Frost", 
			5 => "Holy", 
			6 => "Arcane", 
			7 => "HP Leech", 
			8 => "MP Leech", 
			9 => "Poise", 
			10 => "Charm Move (Hack)", 
			11 => "Charm Move2 (Hack)", 
			_ => "", 
		};
	}

	public static string GetWeapSpecialStrFromInt(int i)
	{
		return i switch
		{
			0 => "None", 
			1 => "Healing", 
			2 => "Chain whip", 
			3 => "Extra blunt", 
			4 => "Extra blades", 
			5 => "Slow Hitter", 
			6 => "Fast Hitter", 
			7 => "Slide", 
			8 => "Charm Move (hack)", 
			9 => "Wood Staff", 
			_ => "", 
		};
	}

	public static string GetShieldTypeStrFromInt(int i)
	{
		return i switch
		{
			0 => "Buckler", 
			1 => "Heater", 
			2 => "Kite", 
			3 => "Tower", 
			4 => "1h Hack", 
			_ => "", 
		};
	}

	public static string GetArmorTypeStrFromInt(int i)
	{
		return i switch
		{
			0 => "Helm", 
			1 => "Chest", 
			2 => "Gloves", 
			3 => "Boots", 
			_ => "", 
		};
	}

	public static string GetWeapTypeStrFromInt(int i)
	{
		return i switch
		{
			0 => "Dagger", 
			1 => "Sword", 
			2 => "Hammer", 
			3 => "Axe", 
			4 => "Spear", 
			5 => "Halberd", 
			6 => "Greatsword", 
			7 => "Greathammer", 
			8 => "Bow", 
			9 => "Crossbow", 
			10 => "Staff", 
			11 => "Whip", 
			12 => "Greataxe", 
			13 => "Poleaxe", 
			14 => "Flintlock", 
			16 => "Wand", 
			17 => "Greatscissor", 
			18 => "Gunblade", 
			19 => "Whipsword", 
			20 => "Longsword", 
			_ => "", 
		};
	}

	public void SetCategory(int category)
	{
		this.category = category;
		switch (category)
		{
		case 0:
			values = new float[25];
			upgradePath = new UpgradePath[2];
			break;
		case 1:
			values = new float[13];
			upgradePath = new UpgradePath[2];
			break;
		case 2:
			values = new float[12];
			upgradePath = new UpgradePath[2];
			break;
		case 3:
			values = new float[2];
			upgradePath = new UpgradePath[2];
			break;
		case 4:
			values = new float[1];
			upgradePath = new UpgradePath[1];
			break;
		case 5:
			values = new float[3];
			upgradePath = new UpgradePath[1];
			break;
		case 6:
			values = new float[1];
			upgradePath = new UpgradePath[1];
			break;
		case 7:
			values = new float[1];
			upgradePath = new UpgradePath[1];
			break;
		}
	}

	public void Write(BinaryWriter writer)
	{
		writer.Write(name);
		for (int i = 0; i < 13; i++)
		{
			if (i < title.Length)
			{
				writer.Write(title[i]);
				writer.Write(desc[i]);
			}
			else
			{
				writer.Write(title[0] + " - " + TranslationMgr.GetLangStrFromIdx(i));
				writer.Write("Untranslated description: " + TranslationMgr.GetLangStrFromIdx(i));
			}
		}
		writer.Write((texture == null) ? "" : texture);
		writer.Write(category);
		writer.Write(type);
		writer.Write(upgrade);
		writer.Write(upgradeFac);
		writer.Write(flags);
		writer.Write(weight);
		writer.Write(special);
		writer.Write(img);
		writer.Write(value);
		writer.Write(durability);
		for (int j = 0; j < values.Length; j++)
		{
			writer.Write(values[j]);
		}
		for (int k = 0; k < upgradePath.Length; k++)
		{
			upgradePath[k].Write(writer);
		}
	}

	public void Read(BinaryReader reader)
	{
		name = reader.ReadString();
		for (int i = 0; i < 13; i++)
		{
			title[i] = reader.ReadString();
			desc[i] = reader.ReadString();
		}
		texture = reader.ReadString();
		category = reader.ReadInt32();
		type = reader.ReadInt32();
		upgrade = reader.ReadInt32();
		upgradeFac = reader.ReadSingle();
		flags = reader.ReadInt32();
		weight = reader.ReadSingle();
		special = reader.ReadInt32();
		img = reader.ReadInt32();
		value = reader.ReadSingle();
		durability = reader.ReadSingle();
		SetCategory(category);
		for (int j = 0; j < values.Length; j++)
		{
			values[j] = reader.ReadSingle();
		}
		for (int k = 0; k < upgradePath.Length; k++)
		{
			upgradePath[k].Read(reader);
		}
	}

	public LootDef(LootDef otherDef)
	{
		SetCategory(otherDef.category);
		type = otherDef.type;
		upgrade = otherDef.upgrade;
		name = otherDef.name;
		title = new string[otherDef.title.Length];
		desc = new string[otherDef.desc.Length];
		for (int i = 0; i < title.Length; i++)
		{
			title[i] = otherDef.title[i];
		}
		for (int j = 0; j < desc.Length; j++)
		{
			desc[j] = otherDef.desc[j];
		}
		texture = otherDef.texture;
		flags = otherDef.flags;
		weight = otherDef.weight;
		special = otherDef.special;
		value = otherDef.value;
		for (int k = 0; k < values.Length; k++)
		{
			values[k] = otherDef.values[k];
		}
		for (int l = 0; l < upgradePath.Length; l++)
		{
			upgradePath[l] = new UpgradePath(otherDef.upgradePath[l].reqLoot, otherDef.upgradePath[l].outLoot, otherDef.upgradePath[l].cost, otherDef.upgradePath[l].reqCount);
		}
	}

	internal int GetUpgradeMaterialCount(int upgrade)
	{
		return upgrade switch
		{
			0 => 1, 
			1 => 2, 
			2 => 1, 
			3 => 2, 
			4 => 1, 
			5 => 2, 
			6 => 1, 
			_ => 1, 
		};
	}

	internal int GetUpgradeSaltCost(int upgrade)
	{
		return upgrade switch
		{
			0 => 250, 
			1 => 500, 
			2 => 1000, 
			3 => 1500, 
			4 => 2500, 
			5 => 5000, 
			6 => 10000, 
			_ => 500, 
		};
	}

	internal static string GetMagicTypeStrFromInt(int i)
	{
		return i switch
		{
			0 => "Elemental Spell", 
			1 => "Elemental Incantation", 
			2 => "Blood Spell", 
			3 => "Blood Incantation", 
			4 => "Holy Spell", 
			5 => "Holy Incantation", 
			_ => "", 
		};
	}

	internal static string GetMagicFlagsStrFromInt(int i)
	{
		return i switch
		{
			0 => "Bolt", 
			1 => "Great Bolt", 
			2 => "Missile", 
			3 => "Great Missile", 
			4 => "Heal", 
			5 => "Great Heal", 
			6 => "Regenerate", 
			7 => "Fireball", 
			8 => "Great Fireball", 
			9 => "Storm", 
			10 => "Great Storm", 
			11 => "Buff Weapon", 
			12 => "Great Buff Weapon", 
			13 => "Buff Shield", 
			14 => "Great Buff Shield", 
			15 => "Protection", 
			16 => "Great Protection", 
			17 => "Cure", 
			18 => "Great Cure", 
			19 => "Ball", 
			20 => "Great Ball", 
			21 => "Light", 
			22 => "Orbiters", 
			23 => "Satellite", 
			24 => "Ghost Wing", 
			25 => "Turret", 
			26 => "Poison Buff", 
			27 => "Vision Buff", 
			28 => "Rapid", 
			29 => "Great Rapid", 
			30 => "Dragonfire", 
			31 => "Flashfire", 
			32 => "Holy Orbiters", 
			33 => "Bandage", 
			34 => "Will Buff", 
			35 => "Phys Protect", 
			36 => "Mag Protect", 
			37 => "Cleanse", 
			38 => "Firestar", 
			39 => "Poison Gas", 
			40 => "Witch Swarm", 
			41 => "Witch Laser", 
			42 => "Revive", 
			43 => "Stars", 
			44 => "Starfall", 
			45 => "Hover blade", 
			_ => "", 
		};
	}

	internal static string GetRingTypeStrFromInt(int p)
	{
		return p switch
		{
			0 => "Ring", 
			1 => "Charm", 
			2 => "Rune", 
			_ => "", 
		};
	}

	internal static string GetCategoryFromInt(int p)
	{
		return p switch
		{
			0 => "Weapon", 
			1 => "Shield", 
			2 => "Armor", 
			3 => "Ring", 
			4 => "Consumable", 
			5 => "Magic", 
			6 => "Key", 
			7 => "Material", 
			_ => "", 
		};
	}

	internal static string GetCategoriesFromInt(int p)
	{
		return p switch
		{
			0 => "Weapons", 
			1 => "Shields", 
			2 => "Armors", 
			3 => "Rings", 
			4 => "Consumables", 
			5 => "Magic", 
			6 => "Keys", 
			7 => "Materials", 
			_ => "", 
		};
	}

	internal static string GetRingFlagsStrFromInt(int type, int p)
	{
		switch (type)
		{
		case 0:
			switch (p)
			{
			case 0:
				return "Phys Defense";
			case 1:
				return "Lit Defense";
			case 2:
				return "Fire Defense";
			case 3:
				return "Poison Defense";
			case 4:
				return "Bladed Def";
			case 5:
				return "Holy Defense";
			case 6:
				return "Dark Defense";
			case 7:
				return "Item Find";
			case 8:
				return "Salt Find";
			case 9:
				return "Gold Find";
			case 10:
				return "HP Regen";
			case 11:
				return "MP Regen";
			case 12:
				return "Stamina Regen";
			case 13:
				return "Poise";
			case 14:
				return "Str";
			case 15:
				return "Dex";
			case 16:
				return "Willpower";
			case 17:
				return "Endurance";
			case 18:
				return "Rolling";
			case 19:
				return "Dmg";
			case 20:
				return "HP to MP";
			case 21:
				return "Magic";
			case 22:
				return "Wisdom";
			case 23:
				return "Heals";
			case 24:
				return "Light";
			case 25:
				return "Fire Dmg";
			case 26:
				return "Cheap Magic";
			case 27:
				return "Cheap Prayers";
			case 28:
				return "Reduce Wounding";
			case 29:
				return "Reduce Fatigue";
			case 30:
				return "Salt Seek";
			case 31:
				return "Melee";
			case 32:
				return "Bloody";
			case 33:
				return "Mag Boost";
			case 34:
				return "Mag Balance";
			case 35:
				return "MP Moat";
			case 36:
				return "HP Leech";
			case 37:
				return "Reflect";
			case 38:
				return "Armor Melee";
			case 39:
				return "Shield - Corruption Fed";
			case 40:
				return "Shield - Thorns";
			case 41:
				return "Armor - Thorns";
			}
			break;
		case 1:
			switch (p)
			{
			case 0:
				return "Atk";
			case 1:
				return "Poise";
			case 2:
				return "Speed";
			case 3:
				return "Reach";
			case 4:
				return "Fire";
			case 5:
				return "Lit";
			case 6:
				return "Poison";
			case 7:
				return "Bladed";
			case 8:
				return "Holy";
			case 9:
				return "Dark";
			case 10:
				return "Cursed";
			case 11:
				return "HP Leech";
			case 12:
				return "MP Leech";
			case 13:
				return "Dying Overkill";
			case 14:
				return "Heavy Poison";
			case 15:
				return "Salt Overload";
			case 16:
				return "Lantern";
			case 17:
				return "Ease";
			case 18:
				return "Blunt";
			case 19:
				return "Shadow";
			}
			break;
		case 2:
			switch (p)
			{
			case 0:
				return "Upside Down";
			case 1:
				return "Dash";
			case 2:
				return "Wall Jump";
			case 3:
				return "Double Jump";
			case 4:
				return "Red Block";
			case 5:
				return "Blue Ether";
			}
			break;
		}
		return "";
	}

	internal static string GetMaterialTypeStrFromInt(int p)
	{
		return "";
	}

	internal static string GetMaterialFlagsStrFromInt(int p)
	{
		return "";
	}

	internal static string GetConsumableTypeStrFromInt(int p)
	{
		return p switch
		{
			0 => "Quick Use", 
			1 => "Arrow", 
			2 => "Bolt", 
			3 => "Flint Shot", 
			4 => "SMG Bullet", 
			5 => "Revolver Bullet", 
			6 => "Shotgun Shell", 
			_ => "", 
		};
	}

	internal static string GetShieldSpecialStrFromInt(int p)
	{
		return p switch
		{
			0 => "None", 
			1 => "Healing", 
			2 => "Stamina Regen", 
			_ => "", 
		};
	}

	internal static string GetUpgradeStrFromInt(int p)
	{
		return p switch
		{
			0 => "Normal", 
			1 => "Drowning (Kraekan)", 
			2 => "Charred (Red)", 
			3 => "None", 
			4 => "Frozen (Blue)", 
			5 => "Beastly", 
			_ => "", 
		};
	}

	internal static string GetConsumableFlagStrFromInt(int p)
	{
		return p switch
		{
			0 => "Potion", 
			1 => "Icon Iron", 
			2 => "Icon Cleric", 
			3 => "Icon Three", 
			4 => "Icon Woods", 
			5 => "Icon Dark", 
			6 => "Icon Splendor", 
			7 => "Icon Fool", 
			8 => "Icon Fire", 
			9 => "Icon Bones", 
			10 => "Arrow", 
			11 => "Big Arrow", 
			12 => "Fire Arrow", 
			13 => "Lit Arrow", 
			14 => "Poison Arrow", 
			15 => "Frost Arrow", 
			16 => "Holy Arrow", 
			17 => "Dark Arrow", 
			18 => "Bolt", 
			19 => "Big Bolt", 
			20 => "Fire Bolt", 
			21 => "Lit Bolt", 
			22 => "Poison Bolt", 
			23 => "Frost Bolt", 
			24 => "Holy Bolt", 
			25 => "Dark Bolt", 
			26 => "Potion Stamina", 
			27 => "Potion Cure", 
			28 => "Potion Thaw", 
			29 => "Salt Pouch", 
			30 => "Salt Bundle", 
			31 => "Salt Bag", 
			32 => "Salt Sack", 
			33 => "Salt Satchel", 
			34 => "Salt Pack", 
			35 => "Salt Case", 
			36 => "Salt Box", 
			37 => "Salt Crate", 
			38 => "Salt Chest", 
			39 => "Health Roll", 
			40 => "Blessed Water", 
			41 => "Mana Cloth", 
			42 => "Repair Kit", 
			43 => "Mana Crystal", 
			44 => "Healing Herbs", 
			45 => "Mana Herbs", 
			46 => "Blood Vial", 
			47 => "Black Salt", 
			48 => "Mana Mead", 
			49 => "Fire Water", 
			50 => "Bottled Sky", 
			51 => "Msg Bottle", 
			52 => "Msg Bottle Green", 
			53 => "Buff Fire", 
			54 => "Buff Lit", 
			55 => "Buff Poison", 
			56 => "Buff Frost", 
			57 => "Buff Holy", 
			58 => "Buff Dark", 
			59 => "Firepot", 
			60 => "Grenada", 
			61 => "Dagger", 
			62 => "Poison Dagger", 
			63 => "Flame Dagger", 
			64 => "Waterpot", 
			65 => "Health Shard", 
			66 => "Return Bell", 
			67 => "Vision", 
			68 => "Torch Consumable", 
			69 => "Wood Dagger", 
			70 => "Blue Shard", 
			71 => "Orange Phial", 
			72 => "Red Wine", 
			73 => "Blue Wine", 
			74 => "Horn Guide", 
			75 => "Horn Will", 
			76 => "Expunged Heart", 
			77 => "Magic Crystal", 
			78 => "Magic Urn", 
			79 => "Gold Wine", 
			80 => "Buff Sanc Fire", 
			81 => "Buff Sanc Lit", 
			82 => "Buff Sanc Poison", 
			83 => "Buff Sanc Frost", 
			84 => "Buff Sanc Holy", 
			85 => "Buff Sanc Dark", 
			86 => "Sanc Horn Will", 
			87 => "Egg Wrath", 
			88 => "Buff Focus", 
			89 => "Blood Pot", 
			90 => "Cleansing Cloth", 
			91 => "Coop Bell", 
			92 => "Antidote", 
			93 => "Crystal Sphere", 
			94 => "Potato", 
			95 => "Rock", 
			_ => "", 
		};
	}
}
