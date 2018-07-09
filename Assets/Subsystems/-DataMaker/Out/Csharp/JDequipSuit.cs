//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:装备系统 Sheet:套装列表
using System.Collections.Generic;
public partial class SuitAttrEffect
{
	public int num;  //数量;
	public int id;  //效果ID;
	public int val;  //参数;
	public int type;  //参数;
	public int sub;  //参数;
	public string desc;  //属性描述;
	public int skill1;  //激活技能;
	public int skill2;  //激活技能;
	public int skill3;  //激活技能;
}

public partial class JDequipSuit
{
	public int id;  //套装ID;
	public string name;  //套装名称;
	public List<int> armorPosid;  //[装备id,装备id,装备id,装备id,装备id,装备id,装备id,装备id,装备id,装备id];
	public List<string> armorPosName;  //[武器名称,头部名称,肩膀名称,衣服名称,手套名称,裤子名称,鞋子名称,戒指名称,项链名称,饰品名称];
	public List<SuitAttrEffect> attr;  //[,,];
}