//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:战场系统 Sheet:战场地图
using System.Collections.Generic;
public partial class Dummy337
{
	public int key;  //胜利物品ID;
	public int num;  //胜利物品数量;
	public int val;  //胜利物品概率;
}
public partial class Dummy338
{
	public int key;  //失败物品ID;
	public int num;  //失败物品数量;
	public int val;  //失败物品概率;
}

public partial class JDbattleMap
{
	public int id;  //战场ID;
	public string name;  //名字;
	public string mark;  //标记;
	public int gtype;  //玩法类型;
	public int type;  //人数;
	public int ulv;  //开放等级;
	public int week;  //开启日期;
	public List<string> time;  //[开启时间,结束时间];
	public List<string> time2;  //[开启时间2,结束时间2];
	public string scene;  //场景名;
	public string map;  //地图名;
	public int winHonor;  //胜利荣誉;
	public int loseHonor;  //失败荣誉;
	public List<Dummy337> winReward;  //[,,];
	public List<Dummy338> loseRewarad;  //[,,];
}