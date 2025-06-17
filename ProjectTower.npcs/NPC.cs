using MapEdit.map;

namespace ProjectTower.npcs;

public class NPC
{
	public string monsterName;

	public int brandFire;

	public const int STYLE_NONE = -1;

	public const int STYLE_SITS = 0;

	public const int STYLE_NOBLES = 1;

	public const int STYLE_JESTER = 2;

	public const int STYLE_LEDGE = 3;

	public const int STYLE_OLDMAN = 4;

	public const int STYLE_HUNCH_LEDGE = 5;

	public const int STYLE_CAPTAIN = 6;

	public const int STYLE_BOATMAN = 7;

	public const int STYLE_PRINCESS = 8;

	public const int STYLE_PRINCESS_MAID = 9;

	public const int STYLE_SCARECROW_HEAD = 10;

	public NPC(string monsterName)
	{
		this.monsterName = monsterName;
	}

	public void InitFromSeg(Seg seg)
	{
	}
}
