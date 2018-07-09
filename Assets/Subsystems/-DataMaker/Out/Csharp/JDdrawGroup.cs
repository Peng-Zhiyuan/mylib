//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:抽奖系统 Sheet:抽奖组配置
using System.Collections.Generic;
public partial class Dummy1466
{
	public int key;  //附送物品组;
	public int num;  //附送物品数量;
	public int val;  //附送物品概率;
}
public partial class Dummy1467
{
	public int key;  //奖励物品组;
	public int num;  //数量;
	public int val;  //概率;
}

public partial class JDdrawGroup
{
	public int id;  //ID;
	public int type;  //类型;
	public int lv;  //角色等级;
	public int gbCost;  //消耗金币;
	public int zbCost;  //消耗钻石;
	public string hint;  //文字提示;
	public string equip;  //文字提示;
	public List<Dummy1466> sureItem;  //[];
	public List<Dummy1467> item;  //[,,,,,,,,,];
}