//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:职业角色 Sheet:属性显示
using System.Collections.Generic;

public partial class JDNCharacterAttrSub
{
	public int category;  //属性类别;
	public int attrId;  //属性ID;

}
public partial class JDNCharacterAttr
{
	public int id;  //职业ID;
	public List<JDNCharacterAttrSub> Coll;
}