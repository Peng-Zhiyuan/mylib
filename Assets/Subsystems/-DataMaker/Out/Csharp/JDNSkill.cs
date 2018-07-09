//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:技能系统 Sheet:技能列表
using System.Collections.Generic;
public partial class NSkillTakeLimit
{
	public int l;  //释放限制;
	public int a1;  //限制参数;
	public int a2;  //限制参数;
}
public partial class SkillEffectInfo
{
	public int e;  //技能效果0;
	public int t;  //播放类型;
	public int a;  //参数;
}

public partial class JDNSkillSub
{
	public string n;  //名称;
	public int b_s;  //起手式;
	public int o;  //职业;
	public int r_p;  //符文位置;
	public int i;  //技能ICON;
	public int p;  //父子技能;
	public int p_t;  //父技能时间;
	public string d;  //技能描述;
	public int t_t;  //释放类型;
	public List<int> t_a;  //[类型参数1,类型参数2,类型参数3];
	public int rlt;  //转向锁定时间;
	public int qy;  //前摇;
	public int hy;  //后摇;
	public int b_m;  //是否可移动施法;
	public int b_d_u;  //死亡后是否可以施法;
	public int b_t_d;  //是否可以对死亡单位释放;
	public int c_r;  //消耗战斗资源;
	public int r_f;  //资源不足能否释放;
	public int b_c_a;  //是否全部消耗;
	public int c_m;  //消耗最小值;
	public int c_ma;  //消耗最大值;
	public int a_t;  //表现类型;
	public int a_a;  //攻击范围;
	public int s_a;  //检索范围;
	public int cd;  //充能时间;
	public int s_cd;  //触发公共CD;
	public int b_s_cd;  //是否受公共CD影响;
	public int li;  //高光能量;
	public List<NSkillTakeLimit> t_l_c;  //[,,];
	public List<int> c_e;  //[释放该技能会移除效果类型,释放该技能会移除效果类型,释放该技能会移除效果类型,释放该技能会移除效果类型,释放该技能会移除效果类型,释放该技能会移除效果类型];
	public List<SkillEffectInfo> s_e_c;  //[,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,];
	public int ha;  //技能仇恨比例;

}
public partial class JDNSkill
{
	public int id;  //技能ID;
	public List<JDNSkillSub> Coll;
}