//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:竞技场机器人 Sheet:Sheet1
using System.Collections.Generic;
public partial class WingInfo
{
	public int id;  //翅膀id;
	public int lv;  //翅膀等级;
	public int exp;  //翅膀经验;
}

public partial class JDarenaRobot
{
	public int id;  //机器人ID;
	public int arena_point;  //分数;
	public int occ;  //职业;
	public int lv;  //等级;
	public WingInfo wing;
	public List<int> equip_list;  //[武器ID,头部ID,肩膀ID,衣服ID,手套ID,裤子ID,鞋子ID,戒指ID,项链ID,饰品ID];
	public List<int> att_list;  //[属性ID,属性值,属性ID,属性值,属性ID,属性值,属性ID,属性值,属性ID,属性值,属性ID,属性值,属性ID,属性值];
}