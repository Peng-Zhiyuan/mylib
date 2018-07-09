//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:荣誉系统 Sheet:荣誉等级
using System.Collections.Generic;

public partial class JDhonor
{
	public int id;  //荣誉等级;
	public int exp;  //荣誉经验;
	public int point;  //巅峰点数;
	public int rank;  //军衔;
	public string rankName;  //军衔名称;
	public int lv;  //军衔等级;
	public int title;  //激活称号;
	public List<AttrEffect> attr;  //[,];
}