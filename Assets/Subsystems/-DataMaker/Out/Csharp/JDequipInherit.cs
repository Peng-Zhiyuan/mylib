//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:装备系统 Sheet:装备传承
using System.Collections.Generic;
public partial class EquipInheritCostInfo
{
	public int i;  //消耗资源ID;
	public int a;  //消耗资源数量;
}

public partial class JDequipInherit
{
	public int id;  //传承ID;
	public List<EquipInheritCostInfo> cost;  //[];
}