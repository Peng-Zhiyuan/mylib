//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:技能系统 Sheet:1.伤害效果
using System.Collections.Generic;
public partial class SkillTargetInfo
{
	public int target;  //作用对象;
	public int target_max;  //对象上限;
	public int area;  //作用区域;
	public List<int> area_arg;  //[区域原点,区域参数,区域参数];
	public List<int> origin_offset;  //[原点偏移x,原点偏移y];
}
public partial class SePowerInfo
{
	public float x;  //力量x;
	public float y;  //力量y;
	public float z;  //力量z;
}

public partial class JDNSkillEffectDamage
{
	public int id;  //效果ID;
	public string name;  //名称;
	public SkillTargetInfo target_info;
	public int type;  //类型;
	public int buffer_type;  //BUFF/DEBUFF类型;
	public int out_effect;  //消失效果;
	public int out_spec_effect;  //特殊消失;
	public int damage_type;  //伤害类型;
	public int begin_time;  //起效时间;
	public string pecent;  //百分比;
	public string ext_value;  //额外值;
	public int time;  //持续时间;
	public int frequency;  //频率;
	public int ad_mode;  //高级模式;
	public List<int> ad_arg;  //[高级模式参数,高级模式参数];
	public int total_damage;  //平摊总伤害;
	public int unit_hurt_max;  //同一单位受到伤害次数;
	public int level_max;  //叠加层数;
	public int damage_follow_effect;  //伤害伴随效果;
	public List<int> damage_hit_effect;  //[伤害命中效果,伤害命中效果,伤害命中效果];
	public int damage_miss_effect;  //伤害未命中效果;
	public int damage_crit_effect;  //伤害暴击效果;
	public int kill_effect;  //伤害击杀目标效果;
	public int hit_fx;  //击中特效;
	public int hit_se;  //击中音效;
	public int  critical_rating;  //暴击几率提高;
	public int critical_strike_demage;  //暴击伤害;
	public int b_must_hit;  //是否必然命中;
	public int b_must_ig_doge;  //是否无视闪避;
	public int b_must_crit;  //是否必然暴击;
	public int b_ignore_defence;  //是否无视护甲;
	public SePowerInfo power;
}