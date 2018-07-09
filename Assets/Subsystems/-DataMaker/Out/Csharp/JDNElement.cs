//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:职业角色 Sheet:元素之力
using System.Collections.Generic;
public partial class CostResource
{
	public int id;  //消耗道具;
	public int num;  //数量;
}

public partial class JDNElement
{
	public int id;  //ID;
	public int zhiye;  //职业;
	public int elv;  //等级;
	public int eid;  //元素;
	public int ulv;  //角色等级限制;
	public CostResource sub;
	public List<AttrEffect> attr;  //[,];
}