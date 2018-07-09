//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:护符系统 Sheet:词缀组
using System.Collections.Generic;

public partial class JDruneRandGroupSub
{
	public int rand;  //词缀id;
	public int rate;  //概率;
	public int zhiye;  //职业限制;

}
public partial class JDruneRandGroup
{
	public int id;  //组ID;
	public List<JDruneRandGroupSub> Coll;
}