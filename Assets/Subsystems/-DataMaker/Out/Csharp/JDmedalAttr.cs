//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:勋章系统 Sheet:属性加成
using System.Collections.Generic;

public partial class JDmedalAttrSub
{
	public int medal;  //勋章等级;
	public List<AttrEffect> attr;  //[,];

}
public partial class JDmedalAttr
{
	public int id;  //职业;
	public List<JDmedalAttrSub> Coll;
}