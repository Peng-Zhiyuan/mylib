//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:职业角色 Sheet:角色职业
using System.Collections.Generic;
public partial class InitAttrInfo
{
	public int id;  //属性ID;
	public float initValue;  //初始属性值;
	public float grow;  //成长属性值;
}

public partial class JDNClass
{
	public int id;  //职业ID;
	public string name;  //職業名稱;
	public string endes;  //英文描述;
	public int model;  //模型;
	public string des;  //描述;
	public int main_att_id;  //主属性ID;
	public int cost_res;  //主要资源;
	public int res_max;  //资源最大值;
	public int res_init;  //资源初始值;
	public int res_recove_time;  //资源恢复间隔;
	public int res_recove_unit;  //资源恢复值;
	public int res_unit;  //消耗基本单位;
	public int defence_type;  //防具类型;
	public List<int> weapon_type;  //[武器类型,武器类型];
	public float move_speed;  //移动速度;
	public List<int> base_model_list;  //[基本套装 头,脸,肩,胸,手,腿,脚,双手武器,单手武器,盾牌];
	public List<int> show_model_list;  //[展示套装 头,脸,肩,胸,手,腿,脚,双手武器,单手武器,盾牌];
	public List<int> show_skill;  //[招牌技能1,招牌技能2,招牌技能3];
	public List<InitAttrInfo> initAttr;  //[,,,,,,,,,];
	public string CreateAnim;  //创建动画;
	public float delay;  //0.5;
	public string sound;  //DZ_hit_12;
	public float delay2;  //延迟2;
	public string sound2;  //技能音效;
	public float delay3;  //延迟3;
	public string sound3;  //技能音效;
	public float delay4;  //延迟4;
	public string sound4;  //技能音效;
	public string wqPoint;  //武器偏移;
	public string wqRotation;  //武器旋转;
	public int wqScale;  //武器缩放;
	public List<int> atkid;  //[普攻1段id,普攻2段id,普攻3段id];
}