//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:技能系统 Sheet:12.地面效果
using System.Collections.Generic;
public partial class NseTrapInfo
{
	public int fx;  //未触发特效;
	public int fx1;  //未触发特效2;
	public string model;  //陷阱模型;
	public int area;  //作用区域;
	public List<int> area_arg;  //[区域原点,区域参数,区域参数];
	public List<int> origin_offset;  //[原点偏移x,原点偏移y];
	public int action_type;  //触发方式;
	public int action_arg;  //触发参数;
	public int out_type;  //效果消失条件;
	public int out_arg;  //效果消失参数;
	public int out_effect;  //陷阱消失效果;
}
public partial class TegTargetInfo
{
	public int target;  //作用目标;
	public int action_type;  //作用方式;
	public int atction_arg;  //作用参数;
	public int effect;  //作用效果(伤害）;
}
public partial class TegDepInfo
{
	public int dep;  //效果消失条件;
	public int arg;  //效果消失参数;
	public int effect;  //效果消失触发效果;
}

public partial class JDNSkillEffectGround
{
	public int id;  //效果ID;
	public string name;  //效果名称;
	public int is_trap;  //是否为陷阱;
	public int delay_time;  //延迟时间;
	public NseTrapInfo trap;
	public int base_fx;  //未触发特效;
	public int fx;  //触发特效ID;
	public int se;  //触发音效ID;
	public int area;  //作用区域;
	public List<int> area_arg;  //[区域原点,区域参数,区域参数];
	public List<int> origin_offset;  //[原点偏移x,原点偏移y];
	public List<int> origin_random;  //[原点随机x,原点随机y];
	public List<TegTargetInfo> dtarget_info;  //[,];
	public List<TegDepInfo> dep_coll;  //[,];
}