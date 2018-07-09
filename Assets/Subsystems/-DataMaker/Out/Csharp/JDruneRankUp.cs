//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:护符系统 Sheet:护符进阶
using System.Collections.Generic;
public partial class RuneRankUpInfo
{
	public int i;  //消耗材料ID;
	public int a;  //消耗材料数量;
}

public partial class JDruneRankUp
{
	public int id;  //ID;
	public int rate;  //成功率;
	public int gbCost;  //金币消耗;
	public List<RuneRankUpInfo> cost;  //[,];
}