//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:女武神 Sheet:女武神基础
using System.Collections.Generic;
public partial class ValkyrjaUnlockCond
{
	public int type;  //解锁条件;
	public int para1;  //解锁参数;
	public int para2;  //解锁参数;
}

public partial class JDpetBase
{
	public int id;  //职业;
	public string icon;  //icon;
	public string name;  //女武神名字;
	public string title;  //女武神称号;
	public int npcid;  //NPCID;
	public List<ValkyrjaUnlockCond> unlock;  //[,];
	public int maxLv;  //最大等级;
	public int maxRank;  //最大星级;
	public string ani;  //出场动画名;
}