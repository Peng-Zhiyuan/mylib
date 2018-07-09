//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:装备系统 Sheet:强化大师
using System.Collections.Generic;
public partial class BuffEffect
{
	public int i;  //属性;
	public int a;  //属性值;
	public int n;  //屬性描述;
}

public partial class JDequipAch
{
	public int id;  //装备强化等级;
	public string name;  //名稱;
	public int effect;  //特效ID;
	public List<BuffEffect> attr;  //[,,,,];
}