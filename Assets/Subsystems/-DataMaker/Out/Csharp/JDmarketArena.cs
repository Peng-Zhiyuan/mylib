//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:商城系统 Sheet:竞技场商店
using System.Collections.Generic;
public partial class Dummy1312
{
	public int id;  //兑换id;
	public int num;  //兑换数量;
}
public partial class Dummy1313
{
	public int id;  //消耗id;
	public int num;  //消耗数量;
}

public partial class JDmarketArena
{
	public int id;  //id;
	public int level;  //段位要求;
	public List<Dummy1312> add;  //[];
	public List<Dummy1313> sub;  //[];
}