//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:奇遇系统 Sheet:角斗场怪物组
using System.Collections.Generic;

public partial class JDjuedouOgreSub
{
	public int ogre;  //怪物ID;
	public int val;  //出现概率;
	public int chapter;  //关卡限制;

}
public partial class JDjuedouOgre
{
	public int id;  //怪物组;
	public List<JDjuedouOgreSub> Coll;
}