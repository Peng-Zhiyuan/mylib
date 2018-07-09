//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:新手引导 Sheet:第一场战斗英雄
using System.Collections.Generic;
public partial class FirstBattleHeroAttr
{
	public int id;  //属性ID;
	public int val;  //初始属性值;
}

public partial class JDFirstBattleHero
{
	public int id;  //职业ID;
	public string name;  //名字;
	public int lv;  //等级;
	public List<int> skill;  //[技能1符文,技能2符文,技能3符文,技能4符文,技能5符文];
	public List<int> equip;  //[装备ID,装备ID,装备ID,装备ID,装备ID,装备ID,装备ID,装备ID,装备ID,装备ID];
	public List<FirstBattleHeroAttr> attr;  //[,,];
	public List<int> equip1;  //[装备ID,装备ID,装备ID,装备ID,装备ID,装备ID,装备ID,装备ID,装备ID,装备ID];
	public List<FirstBattleHeroAttr> attr2;  //[,,];
	public WingInfo wing;
}