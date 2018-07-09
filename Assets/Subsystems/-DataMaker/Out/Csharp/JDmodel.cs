//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:模型 Sheet:模型
using System.Collections.Generic;
public partial class ModelFxInfo
{
	public string bone;  //;
	public string fx;  //;
}

public partial class JDmodel
{
	public int id;  //ID;
	public string name;  //模型名字;
	public int mtype;  //类型lei'xing;
	public string path;  //模型路径mo'xing;
	public float model_offset;  //模型缩放比例mo'xingsuo'fangbi'li;
	public float radius;  //半径;
	public float cheat_y;  //胸部高度xiong'bugao'du;
	public float shadow_offset;  //投影缩放tou'yingsuo'fang;
	public float weight;  //重量;
	public float ui_offset;  //界面展示缩放比jie'mianzhan'shisuo'fangbi;
	public float soulbook_offset;  //图鉴界面展示缩放比jie'mianzhan'shisuo'fangbi;
	public float wtree_offset;  //世界树界面展示缩放比jie'mianzhan'shisuo'fangbi;
	public float wtree_rotation;  //世界树展示旋转;
	public float mini_world_offset;  //小世界缩放比例;
	public float mini_world_x;  //小世界偏移xxiao'shi'jiepian'yi;
	public float mini_world_y;  //小世界偏移yxiao'shi'jiepian'yi;
	public float mini_world_z;  //小世界偏移zxiao'shi'jiepian'yi;
	public float jdOffset;  //角斗场比例;
	public string body_node;  //身体节点;
	public string model_texture;  //模型（身体）贴图;
	public string weapon_node;  //武器节点wu'qijie'dian;
	public string weapon_texture;  //武器贴图wu'qitie'tu;
	public float hp_y;  //血条高度;
	public float head_y;  //头部高度tou'bugao'du;
	public string mat;  //材质cai'zhi;
	public string mat1;  //材质2cai'zhi;
	public List<ModelFxInfo> fx_list;  //[,,,,,];
	public string tagName;  //;
}