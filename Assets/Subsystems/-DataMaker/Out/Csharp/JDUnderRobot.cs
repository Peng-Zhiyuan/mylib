//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:地下城机器人 Sheet:Sheet1
using System.Collections.Generic;

public partial class JDUnderRobot
{
	public int id;  //机器人ID;
	public int under_id;  //地下城ID;
	public int occ;  //职业;
	public int lv;  //等级;
	public WingInfo wing;
	public List<int> equip_list;  //[武器ID,头部ID,肩膀ID,衣服ID,手套ID,裤子ID,鞋子ID,戒指ID,项链ID,饰品ID];
	public List<int> att_list;  //[属性ID,属性值,属性ID,属性值,属性ID,属性值,属性ID,属性值,属性ID,属性值,属性ID,属性值,属性ID,属性值];
}