//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:奇遇系统 Sheet:世界Boss
using System.Collections.Generic;

public partial class JDbossMap
{
	public int id;  //副本ID;
	public int boss;  //是否BOSS;
	public int count;  //boss个数;
	public int boss_id1;  //boss_id1;
	public int boss_id2;  //boss_id2;
	public int boss_id3;  //boss_id3;
	public string scene;  //场景名;
	public string map;  //地图名;
	public string desc;  //关卡描述;
	public int AP;  //推荐战力;
	public int rebornTime;  //复活时间;
	public int LimitTime;  //限制时间;
	public int gbReward;  //单次战斗奖励金币;
	public int gbGrow;  //每级成长万分比;
	public List<ItemGroupInfo> item;  //[,,];
	public string camera;  //相机;
	public string boss_point;  //坐标;
}