//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:竞技场系统 Sheet:段位设定
using System.Collections.Generic;

public partial class JDarenaRank
{
	public int id;  //段位ID;
	public string name;  //段位名称;
	public int duanwei;  //段位组;
	public int star;  //星数;
	public int socre;  //段位分数;
	public List<ItemGroupInfo> dayReward;  //[,,,,];
	public List<ItemGroupInfo> weekReward;  //[,,];
	public List<ItemGroupInfo> seasonReward;  //[,,];
}