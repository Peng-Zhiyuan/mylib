//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:翅膀系统 Sheet:翅膀升级
using System.Collections.Generic;
public partial class WingCost
{
	public int id;  //消耗道具ID;
	public int num;  //消耗道具数量;
}
public partial class AttrEffect
{
	public int id;  //属性ID;
	public int val;  //参数;
	public int type;  //参数;
	public int sub;  //参数;
	public string desc;  //name;
}

public partial class JDwingLv
{
	public int id;  //翅膀等级;
	public int rank;  //阶级;
	public int lv;  //等级;
	public int exp;  //需要经验;
	public int inc;  //单次升级经验;
	public List<WingCost> cost;  //[,,,,,];
	public List<AttrEffect> attr;  //[,,,,,];
}