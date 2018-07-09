//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:技能系统 Sheet:8.飞行效果
using System.Collections.Generic;
public partial class SefFlyInfo
{
	public int fly_type;  //飞行道具类型;
	public int arg;  //飞行类型参数1;
	public int arg1;  //飞行类型参数2;
	public int init_num;  //初始数量;
	public int init_max_num;  //飞行道具召唤次数;
	public int indev;  //召唤间隔;
}
public partial class SefInitInfo
{
	public int pos;  //初始位置;
	public List<int> arg;  //[参数,参数,参数];
	public int base_rotate;  //基本角度;
	public int add_rotate;  //乘角;
	public int random_int_rotate;  //初始随机角;
	public int speed;  //移动速度;
	public int length;  //移动长度;
	public int random_lenght;  //移动长度随机;
	public int box_z;  //碰撞盒长度;
	public int box_y;  //碰撞盒高度;
	public int box_x;  //碰撞盒宽度;
}
public partial class SefFinishInfo
{
	public int ftype;  //移动结束方式;
	public List<int> effect;  //[移动结束效果,移动结束效果];
}

public partial class JDNSkillEffectFly
{
	public int id;  //效果ID;
	public string name;  //飞行道具名称;
	public int fx_id;  //飞行道具特效ID1;
	public int fx2_id;  //飞行道具特效ID2;
	public int fly_mode;  //飞行类型;
	public int hit_pos;  //打击目标点;
	public SkillTargetInfo target_info;
	public SefFlyInfo fly_info;
	public SefInitInfo init_info;
	public List<int> hit_effect;  //[路径碰撞敌方效果,路径碰撞敌方效果,路径碰撞敌方效果];
	public List<int> hit_team_effect;  //[路径碰撞友方效果,路径碰撞友方效果];
	public List<int> back_effect;  //[回归路径碰撞敌方效果,回归路径碰撞敌方效果];
	public List<int> back_team_effect;  //[回归路径碰撞友方效果,回归路径碰撞友方效果];
	public List<SefFinishInfo> finish_list;  //[,,移动结束效果];
}