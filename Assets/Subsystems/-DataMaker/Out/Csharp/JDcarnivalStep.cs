//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:开服嘉年华 Sheet:总奖励
using System.Collections.Generic;
public partial class casAwarditem
{
	public int key;  //奖励物品/物品组;
	public int num;  //数量;
	public int val;  //概率;
}

public partial class JDcarnivalStep
{
	public int id;  //任务数量;
	public string award_name;  //奖励名称;
	public List<casAwarditem> item;  //[,,,,,];
	public string name;  //繁体名;
}