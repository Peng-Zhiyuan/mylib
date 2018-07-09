//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:技能系统 Sheet:11.弹射效果
using System.Collections.Generic;

public partial class JDNSkillEffectTs
{
	public int id;  //效果ID;
	public string name;  //效果名称;
	public int fenlie;  //分裂次数;
	public int num;  //弹射次数;
	public int chongfu;  //是否重复;
	public int target;  //目标;
	public int area;  //弹射范围;
	public int speed;  //弹射速度;
	public int fx_id;  //飞行特效ID;
	public List<int> hit_emey_effect;  //[敌方碰撞效果,敌方碰撞效果];
	public List<int> hit_team_effect;  //[友方碰撞效果,友方碰撞效果];
}