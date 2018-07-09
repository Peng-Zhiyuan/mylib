//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:公会系统 Sheet:工会副本章节
using System.Collections.Generic;

public partial class JDclubRaidChapter
{
	public int id;  //章节ID;
	public string title;  //章节名称;
	public string des;  //章节描述;
	public int hard;  //难度;
	public int openLv;  //会长等级;
	public string mini_map;  //小地图名;
	public int cost;  //消耗活跃度;
	public string boss_pic;  //boss头像;
	public int joinLv;  //参与等级;
	public int limit;  //前置关卡;
	public List<int> stage;  //[开始关卡,结束关卡];
	public int limitChapter;  //前置地下城;
}