//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:抽奖展示 Sheet:Sheet1
using System.Collections.Generic;

public partial class JDDrawGroupViewSub
{
	public int key;  //道具ID;
	public string name;  //道具名称;
	public int count;  //数量;

}
public partial class JDDrawGroupView
{
	public int id;  //类型;
	public List<JDDrawGroupViewSub> Coll;
}