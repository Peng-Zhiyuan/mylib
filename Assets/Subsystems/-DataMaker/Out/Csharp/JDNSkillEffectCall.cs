//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:技能系统 Sheet:9.召唤效果
using System.Collections.Generic;
public partial class SkillCallInfo
{
	public int monster;  //怪物ID;
	public int call_type;  //召唤方式;
	public int x;  //召唤位置X;
	public int y;  //召唤位置Y;
	public int z;  //召唤位置Z;
	public List<SkillCallDepInfo> dep_coll;  //[,];
}
public partial class SkillCallDepInfo
{
	public int _id;  //消失方式;
	public int arg;  //参数;
}

public partial class JDNSkillEffectCall
{
	public int id;  //效果ID;
	public string name;  //效果名;
	public List<SkillCallInfo> call_lis;  //[,,参数];
}