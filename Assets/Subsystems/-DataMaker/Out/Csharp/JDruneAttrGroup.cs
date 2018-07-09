//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:护符系统 Sheet:随机属性组
using System.Collections.Generic;

public partial class JDruneAttrGroupSub
{
	public int rate;  //概率;
	public int attrId;  //属性id;
	public int zhiye;  //职业限制;
	public int lv;  //等级;

}
public partial class JDruneAttrGroup
{
	public int id;  //组ID;
	public List<JDruneAttrGroupSub> Coll;
}