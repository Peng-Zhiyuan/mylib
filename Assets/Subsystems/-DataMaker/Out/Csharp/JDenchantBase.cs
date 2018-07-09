//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:装备系统 Sheet:装备附魔
using System.Collections.Generic;
public partial class EnchantCost
{
	public int num;  //普通附魔消耗金币;
	public int id;  //普通附魔消耗道具;
	public int ret;  //返还;
}

public partial class JDenchantBase
{
	public int id;  //部位ID;
	public int lv;  //开启等级;
	public int num;  //附魔孔上限;
	public List<EnchantCost> cost;  //[,,];
}