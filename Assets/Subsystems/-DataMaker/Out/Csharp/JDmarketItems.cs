//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:商城系统 Sheet:商城道具
using System.Collections.Generic;

public partial class JDmarketItemsSub
{
	public int ulv;  //玩家等级;
	public List<int> items;  //[格子1,格子2,格子3,格子4,格子5,格子6,格子7,格子8,格子9,格子10,格子11,格子12];

}
public partial class JDmarketItems
{
	public int id;  //商城ID;
	public List<JDmarketItemsSub> Coll;
}