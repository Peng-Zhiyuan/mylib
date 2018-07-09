//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:奇遇系统 Sheet:排行榜奖励
using System.Collections.Generic;

public partial class JDbossRankAwardSub
{
	public int sort;  //排名;
	public List<ItemGroupInfo> item;  //[,,];

}
public partial class JDbossRankAward
{
	public int id;  //ID;
	public List<JDbossRankAwardSub> Coll;
}