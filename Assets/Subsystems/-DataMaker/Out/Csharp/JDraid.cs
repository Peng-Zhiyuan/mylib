//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:剧情副本 Sheet:地下城列表
using System.Collections.Generic;

public partial class JDraid
{
	public int id;  //地下城ID;
	public string name;  //地下城名称;
	public string desc;  //地下城描述;
	public int typ;  //类型;
	public int hard;  //是否困难;
	public string boss_pic;  //boss头像;
	public int boss_num;  //boss个数;
	public List<int> boss_list;  //[boss_id1,boss_id2,boss_id3,boss_id4,boss_id5,boss_id6];
	public List<int> boss_show_talk;  //[boss1对话,boss2对话,boss3对话];
	public List<int> boss_dead_talk;  //[击败boss1对话,击败boss2对话,击败boss3对话];
	public string scene;  //场景名;
	public string bgm;  //bgm;
	public string map;  //地图名;
	public string mini_map;  //小地图名;
	public string flower;  //花纹;
	public string monster_node;  //怪物节点;
	public int ui_index;  //界面序列;
	public int ulv;  //开启等级;
	public List<int> limit;  //[前置关卡,前置地下城];
	public int fight_score;  //推荐战力;
	public int energy;  //消耗活力;
	public int dnum;  //单日次数;
	public List<int> speed;  //[竞速时间,奖励钻石];
	public List<int> tbox;  //[累积次数,奖励宝箱];
	public int lots;  //抽卡组;
	public int exp;  //经验值;
	public int gb;  //金币;
	public List<ItemGroupInfo> item;  //[,,,,,,,,,,,,];
}