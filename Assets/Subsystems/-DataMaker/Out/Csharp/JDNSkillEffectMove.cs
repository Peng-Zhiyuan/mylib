//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:技能系统 Sheet:4.移动效果
using System.Collections.Generic;
public partial class SkeMoveEndInfo
{
	public int end_type;  //移动结束方式;
	public List<int> end_effect;  //[移动结束效果,移动结束效果];
}

public partial class JDNSkillEffectMove
{
	public int id;  //效果ID;
	public string name;  //名字;
	public int target1;  //施法对象;
	public int target2;  //目标对象;
	public int move_type;  //移动类型;
	public int speed;  //移动速度;
	public int time;  //时间;
	public int apper_pos;  //出现位置;
	public int random_range;  //随机范围;
	public int speed_y;  //移动速度Y;
	public int length;  //移动长度;
	public int height;  //移动高度;
	public int col_width;  //碰撞宽度;
	public int hit_enemy_effect;  //路径碰撞敌方效果;
	public int hit_teammate_effect;  //路径碰撞友方效果;
	public List<SkeMoveEndInfo> end_dep;  //[,,移动结束效果];
}