//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:奇遇系统 Sheet:奇遇怪物
using System.Collections.Generic;

public partial class JDeventOgre
{
	public int id;  //副本ID;
	public int type;  //奇遇类型;
	public int level;  //难度;
	public string name;  //難度名稱;
	public int ulv;  //开放等级;
	public int boss;  //是否BOSS;
	public string scene;  //场景名;
	public string map;  //地图名;
	public string desc;  //关卡描述;
	public int AP;  //推荐战力;
	public int time;  //时间限制;
	public List<int> star;  //[三星奖励时间,二星奖励时间,一星奖励时间];
	public int max_gold;  //上限;
	public List<ItemGroupInfo> item;  //[,,,,,,];
}