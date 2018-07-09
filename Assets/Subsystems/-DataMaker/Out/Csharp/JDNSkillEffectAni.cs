//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:技能系统 Sheet:5.动画效果
public partial class NeaPauseInfo
{
	public int pause_time1;  //暂停时间1;
	public int pause_btime1;  //暂停开始帧数1;
	public int pause_etime1;  //暂停结束帧数1;
	public int pause_time2;  //暂停时间2;
	public int pause_btime2;  //暂停开始帧数2;
	public int pause_etime2;  //暂停结束帧数2;
	public int pause_time3;  //暂停时间3;
	public int pause_btime3;  //暂停开始帧数3;
	public int pause_etime3;  //暂停结束帧数3;
}

public partial class JDNSkillEffectAni
{
	public int id;  //效果ID;
	public string name;  //效果名;
	public string ani_name;  //动画名;
	public float speed;  //播放速度;
	public int time;  //播放时间;
	public int mode;  //播放方式;
	public int force_stop;  //强制结束;
	public NeaPauseInfo pause_info;
}