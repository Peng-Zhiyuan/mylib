//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:奇遇系统 Sheet:奇遇系统
using System.Collections.Generic;

public partial class JDevent
{
	public int id;  //玩法ID;
	public string name;  //玩法名稱;
	public int type;  //类型;
	public int ulv;  //开启等级;
	public string week;  //开启日期;
	public int dnum;  //每日次数;
	public List<string> time;  //[开启时间,结束时间];
}