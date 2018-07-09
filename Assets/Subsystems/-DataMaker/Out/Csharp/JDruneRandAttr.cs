//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:护符系统 Sheet:词缀属性
using System.Collections.Generic;

public partial class JDruneRandAttr
{
	public int id;  //词缀id;
	public string name;  //詞綴名;
	public string icon;  //ICON;
	public List<int> skill_list;  //[战士激活技能ID,骑士激活技能ID,盗贼激活技能ID,猎人激活技能ID,法师激活技能ID,牧师激活技能ID];
	public List<AttrEffect> attr;  //[];
	public List<int> subAttr;  //[随机组1,随机组2,随机组3,随机组4];
}