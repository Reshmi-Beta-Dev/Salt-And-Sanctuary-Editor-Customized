using ProjectTower.particles.particles;
using ProjectTower.particles.particles.debris;
using ProjectTower.particles.particles.glows;
using ProjectTower.particles.particles.gore;
using ProjectTower.particles.particles.hit;

namespace ProjectTower.particles;

public class ParticleCatalog
{
	public static BaseParticle[] particle;

	public const int SMOKE = 0;

	public const int FIRE = 1;

	public const int DUST = 2;

	public const int BLOOD_ARC = 3;

	public const int SPURT_SUB = 4;

	public const int HIT = 5;

	public const int GLOB_SUB = 6;

	public const int BONE_DUST = 7;

	public const int SPARK = 8;

	public const int SLASH = 9;

	public const int WOOSH = 10;

	public const int ARROW = 11;

	public const int ARROW_TRAIL = 12;

	public const int SPLASH_NORM = 13;

	public const int WISP = 14;

	public const int ASH = 15;

	public const int PICKUP_GLOW = 16;

	public const int PICKUP_SMOKE = 17;

	public const int SMASH_BIT = 18;

	public const int SMASH_SMOKE = 19;

	public const int SMASH_DUST = 20;

	public const int MAGIC_BUILD = 21;

	public const int SPELL_FIRE = 22;

	public const int SPELL_SMOKE = 23;

	public const int MAGIC_SPELL = 24;

	public const int BLOOD_SPELL = 25;

	public const int DOOR_GLOW = 26;

	public const int BLOOD_BUILD = 27;

	public const int ZAP = 28;

	public const int ZAP_ARC = 29;

	public const int DUST_FARM = 30;

	public const int SANCTUARY_GLOW = 31;

	public const int SANCTUARY_BEAM = 32;

	public const int BACK_SLIDE_CRASH = 33;

	public const int BACK_BACK_SLIDE_CRASH = 34;

	public const int MAGIC_AURA = 35;

	public const int HEAL_AURA = 36;

	public const int HEAL_GLOW = 37;

	public const int STATUE_WISP = 38;

	public const int TENDENCY_BIT = 39;

	public const int ELEMENTAL_BIT = 40;

	public const int ELEMENTAL_DECAY = 41;

	public const int NOVA_SOURCE = 42;

	public const int NOVA_BLAST = 43;

	public const int NOVA_BOLT = 44;

	public const int POISON = 45;

	public const int BODYFIRE = 46;

	public const int FACEBREATH = 47;

	public const int SWORD_RUNE_CIRCLE = 48;

	public const int SWORD_RUNE = 49;

	public const int SWORD_RUNE_GLOW = 50;

	public const int POISON_BARF = 51;

	public const int AXE_LOB = 52;

	public const int FIREPOT = 53;

	public const int FLAME_TRAIL = 54;

	public const int GRENADO = 55;

	public const int GRENADO_TRAIL = 56;

	public const int SPARK_FARM = 57;

	public const int SPARK_GLOW = 58;

	public const int GLOW_SPARK = 59;

	public const int GRENADO_HIT = 60;

	public const int DAGGER = 61;

	public const int WATERPOT = 62;

	public const int REFRACT_SMOKE = 63;

	public const int REFRACT_SANCT_WATER = 64;

	public const int SANCT_WATER = 65;

	public const int REFRACT_HOLY_WATER = 66;

	public const int HOLY_WATER = 67;

	public const int WATER_HIT = 68;

	public const int LIT_BALL_ZAP = 69;

	public const int SORCEROR_BOLT = 70;

	public const int SORCEROR_TRAIL = 71;

	public const int SORCERORY = 72;

	public const int SORCERY_RUNE = 73;

	public const int SORCERY_RUNE_BOLT = 74;

	public const int MEGA_SMASH_FARM = 75;

	public const int MEGA_SMASH_BIT = 76;

	public const int MEGA_SMASH_FARM_SHORT = 77;

	public const int DRAGON_FIRE = 78;

	public const int TAIL_SMASH_FARM = 79;

	public const int DRAGON_FIRE_BIT = 80;

	public const int HOLY_CONE_FARM = 81;

	public const int HOLY_CONE_FARM_BIT = 82;

	public const int HOLY_CONE_BIT = 83;

	public const int DEMON_SPURT = 84;

	public const int DEMON_SPLASH = 85;

	public const int METAL_SPURT = 86;

	public const int DEMON_GLOB = 87;

	public const int GOO_SPURT = 88;

	public const int GOO_SPLASH = 89;

	public const int GOO_GLOB = 90;

	public const int GOLEM_FIRE = 91;

	public const int SCYTHE = 92;

	public const int SCYTHE_TRAIL = 93;

	public const int POTS_FIRE = 94;

	public const int POTS_POISON = 95;

	public const int POTS_FIRE_CHASERS = 96;

	public const int POTS_AUX = 97;

	public const int POTS_AUX_GAS = 98;

	public const int HOOK = 99;

	public const int FLAME_JET = 100;

	public const int BUILD_GLOW = 101;

	public const int BUILD_GLOW_BIT = 102;

	public const int BUILD_GLOW_BLAST = 103;

	public const int AURA_FARM = 104;

	public const int AURA_FARM_BIT = 105;

	public const int WILD_FIRE = 106;

	public const int ROT_WOOD_BIT = 107;

	public const int BLUNDER_SHOT = 108;

	public const int BLUNDER_BIT = 109;

	public const int MUZZLE_FLASH = 110;

	public const int BLUNDER_RAIN_FARM = 111;

	public const int GOLD = 112;

	public const int OBELISK_GLOW = 113;

	public const int GOLD_GLOW = 114;

	public const int POISON_FIRE = 115;

	public const int LAVA_BARF = 116;

	public const int BOLT = 117;

	public const int SPELL_BLADE = 118;

	public const int FLAME_BLADE_TRAP = 119;

	public const int GOLEM_SPARK = 120;

	public const int TORCH_SPARK = 121;

	public const int BRAIN_BIT = 122;

	public const int EGG = 123;

	public const int RUNE_GLOW = 124;

	public const int JUMP_GLOW = 125;

	public const int FLINT_SHOT = 126;

	public const int HIT_NUMBER = 127;

	public const int MAGIC_SPRAY = 128;

	public const int BLOOD_TRAIL = 129;

	public const int DEMON_BLOOD_TRAIL = 130;

	public const int DESECRATION_GLOW = 131;

	public const int DESECRATION_BIT = 132;

	public const int HANG_IDEA = 133;

	public const int EYE_GLOW = 134;

	public const int REFRACT_CAVE_TRICKLE = 135;

	public const int CANDLE = 136;

	public const int AIR_WOOSH = 137;

	public const int ROTAT_AIR_WOOSH = 138;

	public const int PRIEST_TRAP = 139;

	public const int PRIEST_TRAP_FARM = 140;

	public const int BLOCK_GLOW = 141;

	public const int BOULDER = 142;

	public const int MEGA_SMASH_FARM_FAST = 143;

	public const int GAS_BLAST_FARM = 144;

	public const int GAS_BLAST_BIT = 145;

	public const int BLOOD_SPRAY = 146;

	public const int DEMON_BLOOD_SPRAY = 147;

	public const int REFRACT_SPRAY = 148;

	public const int BLUEZAP_BUILD = 149;

	public const int BLUEZAP_ZAP = 150;

	public const int BLUENOVA = 151;

	public const int BLUENOVA_TRAIL = 152;

	public const int BLUENOVA_EXPLODE = 153;

	public const int NIGHTMARESCREAM_FARM = 154;

	public const int NIGHTMARESCREAM_BIT = 155;

	public const int NAMEBLADE = 156;

	public const int NAME_VOID_FARM = 157;

	public const int NAME_VOID_BIT = 158;

	public const int NAME_VOID_ZAP = 159;

	public const int CLOAK_BLADE_FARM = 160;

	public const int CLOAK_BLADE = 161;

	public const int BLOOD_MAGIC_TRAIL = 162;

	public const int WATER_SPLASH = 163;

	public const int WATER_SPLASH_BIT = 164;

	public const int SPELL_WORD = 165;

	public const int SPELL_WORD_FARM = 166;

	public const int REFRACT_ARC_SPRAY = 167;

	public const int END_WATER_SPLASH = 168;

	public const int END_WATER_SPLASH_BIT = 169;

	public const int GUIDE_DOOR = 170;

	public const int GUIDE_DOOR_BIT = 171;

	public const int MEGA_SMASH_FARM_TALL = 172;

	public const int FAST_MEGA_SMASH_BIT = 173;

	public const int BLOOD_POT = 174;

	public const int BLOOD_HIT = 175;

	public const int TORTURE_SMASH = 176;

	public const int TORTURE_SMASH_BIT = 177;

	public const int STARFALL_FARM = 178;

	public const int UPGRADE_AURA = 179;

	public const int SMASH_SPARK = 180;

	public const int ELEMENTAL_STRIKE = 181;

	public const int TOTAL_PARTICLES = 182;

	public static void Init()
	{
		particle = new BaseParticle[182];
		particle[0] = new Smoke();
		particle[1] = new Fire();
		particle[2] = new Dust();
		particle[3] = new BloodArc();
		particle[4] = new Spurt();
		particle[5] = new Hit();
		particle[6] = new Glob();
		particle[26] = new DoorGlow();
		particle[63] = new RefractSmoke();
		particle[121] = new TorchSpark();
		particle[135] = new CaveTrickle();
		particle[137] = new AirWoosh();
		particle[138] = new RotatairWoosh();
	}
}
