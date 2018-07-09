//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:公会系统 Sheet:公会战点
using System.Collections.Generic;

public partial class JDUnionPoint
{
	public int id;  //序号;
	public string name;  //名字;
	public string icon;  //图标;
	public int qlv;  //品质;
	public int ui_x;  //坐标点1;
	public int ui_y;  //坐标点2;
	public string s_map;  //缩略图;
	public string scene;  //公会战地图;
	public string map;  //地图;
	public int maxPoint;  //占领分数;
	public List<ItemGroupInfo> item;  //[,,,];
}