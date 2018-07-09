//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:职业角色 Sheet:技能符文
public partial class SkillFwLockInfo
{
	public int id;  //技能ID;
	public int lv;  //解锁等级;
}

public partial class JDNSkillFw
{
	public int id;  //符文ID;
	public string name;  //符文名称;
	public string des;  //符文描述;
	public string icon;  //icon;
	public int pos;  //符文位置;
	public SkillFwLockInfo skill;
}