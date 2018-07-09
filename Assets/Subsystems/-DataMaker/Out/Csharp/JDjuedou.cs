//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:奇遇系统 Sheet:角斗场配置
using System.Collections.Generic;
public partial class ButffItem
{
	public int id;  //buff属性ID;
	public int val;  //参数;
	public int type;  //参数;
	public int sub;  //参数;
	public string des;  //属性描述;
	public int item;  //消耗道具;
	public int num;  //消耗数量;
}

public partial class JDjuedou
{
	public int id;  //ID;
	public int level;  //难度;
	public int num;  //轮数;
	public int ogre;  //怪物组;
	public int hp_offset;  //血量系数;
	public int attack_offset;  //攻击系数;
	public int rbox;  //结算宝箱;
	public int rbox_name;  //宝箱名字;
	public List<ItemGroupInfo> item;  //[,,];
	public List<ButffItem> buff;  //[,,];
}