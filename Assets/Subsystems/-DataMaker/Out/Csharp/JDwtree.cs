//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:奇遇系统 Sheet:世界树
using System.Collections.Generic;

public partial class JDwtree
{
	public int id;  //层数;
	public int limit_time;  //限制时间（毫秒）;
	public string camera_fx;  //摄像机特效;
	public int boss;  //是否BOSS;
	public int count;  //boss个数;
	public int boss_id1;  //boss_id1;
	public int boss_id2;  //boss_id2;
	public int boss_id3;  //boss_id3;
	public string scene;  //场景名;
	public string map;  //地图名;
	public string desc;  //關卡描述;
	public int AP;  //推荐战力;
	public int time;  //时间限制;
	public int lv_limit;  //等级限制;
	public List<ItemGroupInfo> item;  //[,];
}