//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:技能系统 Sheet:2.特殊效果
using System.Collections.Generic;
public partial class SkillBufferInfo
{
	public int b_type;  //BUFF/DEBUFF类型;
	public int clear_effect;  //BUFF清除效果（非正常消失）;
	public int finish_effect;  //BUFF正常消失效果;
	public List<SkillBuffOutInfo> out_deps;  //[,,BUFF/DEBUFF消失参数];
	public int die_jia;  //叠加层数;
}
public partial class SkillBuffOutInfo
{
	public int dep;  //BUFF/DEBUFF消失条件;
	public int arg;  //BUFF/DEBUFF消失参数;
}

public partial class JDNSkillEffectSpe
{
	public int id;  //效果ID;
	public string name;  //效果名称;
	public SkillTargetInfo target_info;
	public int rate;  //触发概率 ;
	public int follow;  //跟随效果;
	public int effect_id;  //效果ID;
	public List<int> arg;  //[参数,参数,参数];
	public int take_fx;  //特效;
	public int is_buffer;  //是否为BUFF/DEBUFF;
	public SkillBufferInfo buffer;
}