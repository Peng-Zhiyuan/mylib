//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:剧情副本 Sheet:章节列表
using System.Collections.Generic;
public partial class story_award
{
	public int star;  //星级;
	public int key;  //结算物品ID;
	public int num;  //结算物品数量;
	public int val;  //结算物品概率;
}

public partial class JDstory
{
	public int id;  //章节ID;
	public int mode;  //;
	public string name;  //章節名稱;
	public string index;  //第几章;
	public string desc;  //章節描述;
	public string mini_map;  //小地图名;
	public string flower;  //花纹;
	public int level;  //难度;
	public int ulv;  //开启等级;
	public List<int> limit;  //[前置普通关卡,前置精英关卡];
	public List<int> stage;  //[开始关卡,结束关卡];
	public List<story_award> award;  //[,,];
}