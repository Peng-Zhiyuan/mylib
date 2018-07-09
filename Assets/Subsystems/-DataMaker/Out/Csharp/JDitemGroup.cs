//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:物品列表 Sheet:物品组
using System.Collections.Generic;

public partial class JDitemGroupSub
{
	public int key;  //物品ID;
	public int num;  //物品数量;
	public int val;  //相对概率;
	public int lv;  //最小等级;
	public int maxlv;  //最大等级;
	public int vip;  //vip限制;
	public int zhiye;  //职业限制;
	public List<int> cost;  //[兑换消耗道具,消耗数量];

}
public partial class JDitemGroup
{
	public int id;  //物品组ID;
	public List<JDitemGroupSub> Coll;
}