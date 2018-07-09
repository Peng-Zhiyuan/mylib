//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:剧情副本 Sheet:关卡列表
using System.Collections.Generic;
public partial class ItemGroupInfo
{
	public int key;  //结算物品ID;
	public int num;  //结算物品数量;
	public int val;  //结算物品概率;
}

public partial class JDstage
{
	public int id;  //关卡ID;
	public string name;  //關卡名稱;
	public int boss;  //是否BOSS;
	public string head;  //怪物头像;
	public int boss_num;  //boss个数;
	public List<int> boss_list;  //[boss_id1,boss_id2,boss_id3];
	public string scene;  //场景名;
	public string map;  //地图名;
	public string bgm;  //bgm;
	public string desc;  //关卡描述;
	public int level;  //难度;
	public int dnum;  //min;
	public int ui_y;  //界面行;
	public int ui_x;  //界面列;
	public int story;  //所属章节;
	public int ulv;  //开启等级;
	public List<int> limit;  //[前置普通关卡,前置精英关卡];
	public List<int> power;  //[扣除总体力,扫荡消耗体力,进入战斗扣除体力];
	public int AP;  //推荐战斗力;
	public int lots;  //宝箱ID;
	public int exp;  //经验值;
	public int gb;  //金币;
	public List<int> star;  //[三星奖励时间,二星奖励时间,一星奖励时间];
	public List<ItemGroupInfo> item;  //[,,,,,,,,,];
	public int pieces;  //;
}