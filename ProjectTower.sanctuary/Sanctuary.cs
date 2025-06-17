using LootEdit;
using LootEdit.loot;
using MapEdit.map;
using Microsoft.Xna.Framework;

namespace ProjectTower.sanctuary;

public class Sanctuary
{
	public struct SanctuaryChar
	{
		private const float BASE_TIME = 3f;

		public int charIdx;

		public int monsterIdx;

		public float spawnTime;

		public float settingAlpha;

		public SanctuaryChar(int cIdx)
		{
			charIdx = -1;
			spawnTime = 3f + (float)cIdx + Rand.GetRandomFloat(0f, 10f);
			monsterIdx = -1;
			settingAlpha = 0f;
		}
	}

	public int creed;

	public int visitcount;

	public int area;

	public int x;

	public int y;

	public int segIdx;

	public int left;

	public int right;

	public int top;

	public int bottom;

	public Vector2 loc;

	public int imgIdx;

	public float claimFrame;

	public float frame;

	public const int CHAR_MERCH_1 = 0;

	public const int CHAR_MERCH_2 = 1;

	public const int CHAR_MERCH_3 = 2;

	public const int CHAR_MERCH_4 = 3;

	public const int CHAR_PILGRIM_1 = 4;

	public const int CHAR_PILGRIM_2 = 5;

	public const int CHAR_PILGRIM_3 = 6;

	public const int CHAR_PILGRIM_4 = 7;

	public const int CHAR_ICON = 8;

	public const int BASE_CHARS = 4;

	public const int TOTAL_CHARS = 8;

	public string trigger;

	public string flag;

	public int[] merchant;

	public bool shrine;

	public const int MERCHANT_OFF = 0;

	public const int MERCHANT_PRIEST = 1;

	public const int MERCHANT_MERCHANT = 2;

	public const int MERCHANT_BLACKSMITH = 3;

	public const int MERCHANT_MAGE = 4;

	public const int MERCHANT_ALCHEMIST = 5;

	public const int MERCHANT_GUIDE = 6;

	public const int MERCHANT_LEADER = 7;

	public const int MERCHANT_SELLSWORD = 8;

	public const int TOTAL_MERCHANT_TYPES = 9;

	public float desecrationFrame;

	public int desecrationWave;

	public int desecrationWavesTotal;

	public float desecrationAlpha;

	public SanctuaryChar[] sanctuaryChar;

	public int ID;

	public Sanctuary(Seg seg, int ID)
	{
		this.ID = ID;
		trigger = null;
		flag = null;
		creed = 0;
		x = (int)((double)seg.loc.X / 64.0);
		y = (int)((double)seg.loc.Y / 32.0);
		int num = 12;
		int num2 = 12;
		int num3 = 2;
		left = x - num;
		right = x + num;
		top = y - num2;
		bottom = y + num3;
		loc = new Vector2((float)((double)x * 64.0 + 32.0), (float)((double)y * 64.0 * 0.5 + 6.40000009536743));
		merchant = new int[4];
		sanctuaryChar = new SanctuaryChar[8];
		for (int i = 0; i < 8; i++)
		{
			sanctuaryChar[i] = new SanctuaryChar(i);
		}
	}

	public void Reset()
	{
		desecrationFrame = 0f;
		desecrationAlpha = 0f;
		creed = 0;
		for (int i = 0; i < 8; i++)
		{
			sanctuaryChar[i] = new SanctuaryChar(i);
		}
	}

	private void SetIcon(int lootDefFlags)
	{
		for (int i = 0; i < LootCatalog.category[4].loot.Count; i++)
		{
			LootDef lootDef = LootCatalog.category[4].loot[i];
			if (lootDef.flags == lootDefFlags)
			{
				imgIdx = (int)lootDef.values[0];
			}
		}
	}
}
