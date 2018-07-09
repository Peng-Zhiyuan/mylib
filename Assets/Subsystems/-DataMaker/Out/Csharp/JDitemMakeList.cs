//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:物品列表 Sheet:道具合成列表
using System.Collections.Generic;
public partial class ItemCount
{
	public int i;  //消耗道具;
	public int a;  //数量;
}

public partial class JDitemMakeList
{
	public int id;  //合成道具ID;
	public List<ItemCount> cost;  //[,,,];
}