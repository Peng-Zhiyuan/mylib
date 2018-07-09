//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:公会系统 Sheet:新公会悬赏
using System.Collections.Generic;

public partial class JDclubTask
{
	public int id;  //关卡ID;
	public int val;  //权重;
	public string icon;  //图标;
	public int level;  //星级;
	public string name;  //關卡名稱;
	public string desc;  //关卡描述;
	public string mini_map;  //小地图名;
	public int limit_time;  //限制时间（毫秒）;
	public int boss_num;  //boss个数;
	public List<int> boss_list;  //[boss_id1,boss_id2,boss_id3];
	public string scene;  //场景名;
	public string map;  //地图名;
	public List<ItemGroupInfo> item;  //[,];
}