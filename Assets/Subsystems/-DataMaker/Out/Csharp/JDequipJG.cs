//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:装备系统 Sheet:新精工
using System.Collections.Generic;
public partial class EquipJgCostInfo
{
	public int i;  //消耗材料ID;
	public int a;  //消耗材料数量;
}
public partial class Dummy1203
{
	public int i;  //返还材料ID;
	public int a;  //返还材料数量;
}

public partial class JDequipJG
{
	public int id;  //精工等级;
	public List<EquipJgCostInfo> cost;  //[,,];
	public int gbCost;  //消耗材料数量;
	public List<int> value;  //[白色提升属性,绿色提升属性,蓝色提升属性,紫色提升属性,橙色提升属性];
	public List<Dummy1203> sell;  //[,,,];
}