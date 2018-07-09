//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:技能系统 Sheet:变身效果
using System.Collections.Generic;

public partial class JDNSkillEffectSaiya
{
	public int id;  //效果ID;
	public string name;  //名字;
	public int model;  //变身模型id;
	public int time;  //变身时间;
	public List<int> effect;  //[变身获得效果,变身获得效果,变身获得效果,变身获得效果];
	public int attack;  //变身后普攻;
	public List<int> skill;  //[变身后技能1,变身后技能2,变身后技能3,变身后技能4,变身后技能5];
}