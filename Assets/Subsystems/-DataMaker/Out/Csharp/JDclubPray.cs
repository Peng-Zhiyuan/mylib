//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:公会系统 Sheet:工会祈福
using System.Collections.Generic;

public partial class JDclubPray
{
	public int id;  //祈福类型;
	public CostRes cost;
	public string PrayName;  //祈福名称;
	public int point;  //工会活跃度;
	public List<ItemGroupInfo> item;  //[,,];
}