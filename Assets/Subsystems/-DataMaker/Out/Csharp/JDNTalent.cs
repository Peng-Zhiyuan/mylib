//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:职业角色 Sheet:角色天赋
using System.Collections.Generic;

public partial class JDNTalent
{
	public int id;  //标识;
	public string name;  //天赋名称;
	public string des;  //天赋描述;
	public string icon;  //天赋icon;
	public List<int> skill;  //[解锁技能,解锁技能,解锁技能];
	public List<int> transfer;  //[X点,A属性转换成,Y点,B属性];
	public List<AttrEffect> attr;  //[,,];
}