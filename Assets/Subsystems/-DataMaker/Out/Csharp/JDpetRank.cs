//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:女武神 Sheet:女武神进阶
using System.Collections.Generic;
public partial class Dummy1334
{
	public int i;  //消耗道具ID;
	public int a;  //消耗道具数量;
}

public partial class JDpetRank
{
	public int id;  //标识;
	public int lvlimit;  //女武神等级限制;
	public int gbCost;  //消耗金币;
	public List<Dummy1334> cost;  //[,];
	public int model;  //模型;
	public List<int> skill;  //[战士技能ID,骑士技能ID,刺客技能ID,猎人技能ID,法师技能ID,牧师技能ID];
	public List<AttrEffect> attr;  //[,,,];
}