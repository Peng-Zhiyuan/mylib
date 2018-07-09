//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:装备系统 Sheet:装备强化
using System.Collections.Generic;
public partial class EquipLvCostInfo
{
	public int i;  //消耗材料ID;
	public int a;  //消耗材料数量;
}
public partial class EquipLvInsureInfo
{
	public int i;  //保护材料ID;
	public int a;  //保护材料数量;
	public int rate;  //成功率修正;
	public int failLv;  //失败后降级修正;
}
public partial class Dummy342
{
	public int i;  //回收道具;
	public int a;  //回收数量;
}

public partial class JDequipLv
{
	public int id;  //id;
	public float attr;  //主属性加成百分比;
	public int rate;  //成功几率;
	public List<EquipLvCostInfo> cost;  //[,];
	public int gbCost;  //金币消耗;
	public int failLv;  //失败后降级;
	public EquipLvInsureInfo insure;
	public List<Dummy342> sell;  //[,,,,,];
}