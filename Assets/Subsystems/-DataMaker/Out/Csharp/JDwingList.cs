//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:翅膀系统 Sheet:翅膀列表
using System.Collections.Generic;
public partial class WinModel
{
	public string mode_id;  //模型ID;
	public int defaultTexture;  //默认贴图;
	public string mode_mat;  //模型材质;
}

public partial class JDwingList
{
	public int id;  //翅膀ID;
	public string name;  //翅膀名称;
	public string icon;  //icon;
	public int hide;  //列表隐藏;
	public string eff_double;  //双翼特效;
	public string eff_single;  //单翼特效;
	public int scale;  //缩放%;
	public int open;  //激活条件;
	public int param;  //参数;
	public string open_des;  //开启条件;
	public int q;  //品质;
	public List<WinModel> models;  //[,,];
}