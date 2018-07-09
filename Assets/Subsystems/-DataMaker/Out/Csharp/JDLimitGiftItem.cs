//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:商业系统 Sheet:推送内容
using System.Collections.Generic;
public partial class item
{
	public int id;  //道具ID;
	public int num;  //道具数量;
}

public partial class JDLimitGiftItemSub
{
	public int val;  //相对概率;
	public item item;

}
public partial class JDLimitGiftItem
{
	public int id;  //物品组ID;
	public List<JDLimitGiftItemSub> Coll;
}