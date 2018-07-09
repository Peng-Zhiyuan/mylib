//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:开服嘉年华 Sheet:任务列表
using System.Collections.Generic;
public partial class catAwarditem
{
	public int key;  //概率/物品ID;
	public int num;  //物品组数量;
	public int val;  //独立概率;
}

public partial class JDcarnivalTask
{
	public int id;  //任务ID;
	public int day;  //天数;
	public int index;  //任务顺序;
	public string name;  //任务名称;
	public string desc;  //任务描述;
	public string icon;  //图示;
	public int type;  //任务类型;
	public int tar;  //目标;
	public List<int> key;  //[参数,,,,参数];
	public string lfpage;  //跳转;
	public List<catAwarditem> item;  //[,];
}