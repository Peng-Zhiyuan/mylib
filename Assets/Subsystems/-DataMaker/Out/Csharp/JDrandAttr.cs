//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:装备系统 Sheet:装备洗练
using System.Collections.Generic;
public partial class Dummy1304
{
	public int item;  //消耗资源ID;
	public int init;  //初始;
	public int inc;  //成长;
	public int max;  //最大价格;
}
public partial class Dummy1305
{
	public int init;  //初始;
	public int inc;  //成长;
	public int max;  //最大价格;
}

public partial class JDrandAttr
{
	public int id;  //品质;
	public List<Dummy1304> cost;  //[];
	public Dummy1305 gbCost;
	public int limit;  //每日次数限制;
}