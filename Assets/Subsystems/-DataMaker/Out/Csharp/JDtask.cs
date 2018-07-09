//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:任务系统 Sheet:任务列表
using System.Collections.Generic;
public partial class Dummy1
{
	public int key;  //选择物品组;
	public int num;  //选择物品组数量;
}

public partial class JDtask
{
	public int id;  //任务ID;
	public int group;  //任务链;
	public string name;  //任务名称;
	public string desc;  //任务描述;
	public int zhiye;  //职业限制;
	public int type;  //任务类型;
	public int key;  //参数;
	public int star;  //战斗星级,PVP情况下0代表失败,1胜利;
	public int tar;  //达成目标;
	public int jump;  //跳转;
	public List<int> child;  //[下级任务,下级任务];
	public int medal;  //奖励勋章;
	public List<ItemGroupInfo> item;  //[,,];
	public List<Dummy1> select;  //[,];
}