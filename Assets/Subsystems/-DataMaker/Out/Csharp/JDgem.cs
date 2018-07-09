//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:宝石系统 Sheet:宝石列表
using System.Collections.Generic;

public partial class JDgem
{
	public int id;  //宝石ID;
	public int type;  //宝石颜色;
	public int lv;  //宝石等级;
	public int sub;  //合成消耗数量;
	public int gem;  //合成宝石ID;
	public CostResource cost;
	public List<AttrEffect> attr;  //[,,];
	public List<SkillFwLockInfo> skill;  //[,];
}