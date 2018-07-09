//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:成就系统 Sheet:成就列表
using System.Collections.Generic;

public partial class JDachieveTask
{
	public int id;  //标识;
	public int group;  //分类;
	public int tag;  //任务系列;
	public int type;  //任务类型;
	public string icon;  //图标;
	public string name;  //任务名称;
	public string desc;  //任务描述;
	public int tar;  //任务目标;
	public List<int> key;  //[任务参数,任务参数,任务参数,任务参数,任务参数,任务参数,任务参数,任务参数,任务参数,任务参数,任务参数,任务参数,任务参数];
	public int career;  //职业;
	public int title;  //奖励称号ID;
	public List<ItemGroupInfo> item;  //[,,];
}