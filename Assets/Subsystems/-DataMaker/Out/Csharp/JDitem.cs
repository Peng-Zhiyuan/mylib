//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:物品列表 Sheet:道具
using System.Collections.Generic;
public partial class FunctionEntrance
{
	public int id;  //道具获取条件，关卡1;
	public string arg;  //道具获取参数;
}

public partial class JDitem
{
	public int id;  //ID;
	public string name;  //名称;
	public string achieve;  //[成就]是否统计获得总数;
	public int qlv;  //品质;
	public int type;  //类型;
	public string icon;  //icon;
	public string usage;  //道具作用描述;
	public string desc;  //道具说明;
	public string extraDesc;  //额外描述;
	public int price;  //出售价格;
	public int isUse;  //是否可使用;
	public int lv;  //等级;
	public int useMinLv;  //使用最小等级;
	public int useMaxLv;  //使用最大等级;
	public string useSubItem;  //使用消耗道具;
	public int useSubNum;  //使用消耗道具数量;
	public int useType;  //使用效果;
	public string useArgs;  //参数;
	public List<FunctionEntrance> sources;  //[,,,,,,,,,];
}