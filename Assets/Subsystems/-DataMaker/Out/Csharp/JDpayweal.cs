//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:商业系统 Sheet:月卡系统
public partial class CostRes
{
	public int id;  //立即返还道具ID;
	public int num;  //立即返还道具数量;
}

public partial class JDpayweal
{
	public int id;  //月卡ID;
	public string name;  //月卡名稱;
	public string desc;  //月卡描述;
	public float rmb;  //充值金额;
	public CostRes PItem;
	public CostRes DItem;
	public int ttl;  //返还持续时间;
	public int q;  //品阶色;
}