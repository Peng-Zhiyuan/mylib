//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:公会系统 Sheet:工会副本关卡
using System.Collections.Generic;

public partial class JDclubRaidStage
{
	public int id;  //关卡ID;
	public string name;  //關卡名稱;
	public string mini_map;  //小地图名;
	public int limit_time;  //限制时间（毫秒）;
	public int boss;  //是否BOSS;
	public int boss_num;  //boss个数;
	public List<int> boss_list;  //[boss_id1,boss_id2,boss_id3];
	public string scene;  //场景名;
	public string map;  //地图名;
	public string desc;  //关卡描述;
	public int level;  //难度;
	public int dnum;  //每次次数;
	public int ui_y;  //界面行;
	public int ui_x;  //界面列;
	public int story;  //所属章节;
	public List<int> limit;  //[前置普通关卡,推荐战斗力];
	public List<ItemGroupInfo> item;  //[,,,,,,,,,];
}