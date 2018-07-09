//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:装备系统 Sheet:随机属性组
using System.Collections.Generic;

public partial class JDattrGroupSub
{
	public int attrId;  //随机属性ID;
	public int rate;  //概率;

}
public partial class JDattrGroup
{
	public int id;  //组ID;
	public List<JDattrGroupSub> Coll;
}