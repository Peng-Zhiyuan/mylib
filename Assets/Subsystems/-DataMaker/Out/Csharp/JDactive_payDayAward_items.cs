//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:活动列表 Sheet:礼包随机组
using System.Collections.Generic;

public partial class JDactive_payDayAward_itemsSub
{
	public int val;  //概率;
	public List<ItemGroupInfo> item;  //[];

}
public partial class JDactive_payDayAward_items
{
	public int id;  //组ID;
	public List<JDactive_payDayAward_itemsSub> Coll;
}