//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:每日任务 Sheet:每日活跃度
using System.Collections.Generic;

public partial class JDdayTask
{
	public int id;  //标识;
	public int cycle;  //周期,1 OR 7(周长);
	public int show;  //显示类型;
	public string name;  //任务名称;
	public string icon;  //图标;
	public string desc;  //任务描述;
	public int type;  //任务类型;
	public int tar;  //任务目标;
	public int jump;  //跳转;
	public int target;  //锁定信息;
	public int point;  //奖励积分;
	public List<ItemGroupInfo> item;  //[,,];
}