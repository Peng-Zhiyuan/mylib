//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:奇遇系统 Sheet:角斗场
using System.Collections.Generic;

public partial class JDjuedouLevel
{
	public int id;  //难度;
	public string name;  //难度名称;
	public int ulv;  //开放等级;
	public int num;  //轮数;
	public int award;  //奖励礼包物品组;
	public int hard;  //难度;
	public int reset;  //刷新最大次数;
	public List<ItemGroupInfo> item;  //[,,];
}