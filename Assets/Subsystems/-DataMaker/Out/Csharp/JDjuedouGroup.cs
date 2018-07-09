//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:奇遇系统 Sheet:随机组
using System.Collections.Generic;

public partial class JDjuedouGroupSub
{
	public List<int> arr;  //[怪物组ID,怪物组ID,怪物组ID];
	public int val;  //怪物组概率;

}
public partial class JDjuedouGroup
{
	public int id;  //随机组ID;
	public List<JDjuedouGroupSub> Coll;
}