//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:装备系统 Sheet:远古随机组
using System.Collections.Generic;

public partial class JDequipAdvGroupSub
{
	public int attrId;  //词缀id;
	public int rate;  //概率;

}
public partial class JDequipAdvGroup
{
	public int id;  //组ID;
	public List<JDequipAdvGroupSub> Coll;
}