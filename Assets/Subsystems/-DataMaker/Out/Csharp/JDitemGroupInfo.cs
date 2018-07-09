//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:物品列表 Sheet:物品组信息
using System.Collections.Generic;

public partial class JDitemGroupInfo
{
	public int id;  //物品组ID;
	public string name;  //物品组名称;
	public string icon;  //物品组icon;
	public int bj;  //能不能看到裡面東西;
	public int qlv;  //物品组品质;
	public int type;  //类型;
	public string usage;  //道具作用描述;
	public string desc;  //道具说明;
	public string extraDesc;  //额外描述;
	public List<FunctionEntrance> sources;  //[,,,,,,,,,];
}