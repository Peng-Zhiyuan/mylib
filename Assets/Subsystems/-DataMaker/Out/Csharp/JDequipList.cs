//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:装备系统 Sheet:装备列表
using System.Collections.Generic;
public partial class EvolveCost
{
	public int id;  //神铸装备ID;
	public int rate;  //成功率;
	public ItemCount ecost;
	public List<ItemCount> cost;  //[,,,];
}
public partial class Dummy341
{
	public int i;  //基础属性;
	public int a;  //属性值;
	public string n;  //属性描述;
}
public partial class EquipMainAttInfo
{
	public int i;  //主要属性;
	public int a;  //属性值;
	public string n;  //属性描述;
}

public partial class JDequipList
{
	public int id;  //装备ID;
	public int value;  //装备价值;
	public int quality;  //装备

	public int armorL;  //装备

	public int weaponL;  //职业

	public int type;  //装备

	public int armorT;  //防具

	public int weaponT;  //武器

	public int minLv;  //使用

	public int equipLv;  //GS;
	public int lvlupType;  //强化

	public int lvLimit;  //强化

	public ItemCount sell;
	public EvolveCost evolve;
	public int adv;  //远古随机类;
	public Dummy341 baseAttr;
	public List<EquipMainAttInfo> mainAttr;  //[,];
	public List<int> randAttr;  //[随机属性组,随机属性组,随机属性组,随机属性组];
	public int suit;  //所属套装;
	public List<int> skill_list;  //[战士激活技能ID,骑士激活技能ID,盗贼激活技能ID,猎人激活技能ID,法师激活技能ID,牧师激活技能ID];
	public string name;  //装备名称;
	public string des;  //装备描述;
	public string icon;  //装备ICON;
	public string model;  //模型id;
	public string achieve;  //是否统计成就;
}