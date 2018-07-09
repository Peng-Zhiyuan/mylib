//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:职业角色 Sheet:天赋栏位
using System.Collections.Generic;

public partial class JDNTalentPos
{
	public int id;  //标识;
	public int zhiye;  //职业ID;
	public int pos;  //位置ID;
	public int x;  //位置坐标x;
	public int y;  //位置坐标y;
	public int ulv;  //解锁等级;
	public List<int> skill;  //[解锁天赋ID,解锁天赋ID,解锁天赋ID];
	public int battle;  //挑战关卡ID;
}