//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:灵魂图鉴 Sheet:灵魂图鉴
using System.Collections.Generic;

public partial class JDsoul
{
	public int id;  //ID;
	public int stage;  //章节;
	public int pos;  //位置;
	public string name;  //怪物名称;
	public int key;  //灵魂石ID;
	public string soulName;  //灵魂石名称;
	public int num;  //需求数量;
	public int max;  //最大数量;
	public string icon;  //图片;
	public int model;  //模型;
	public string sound;  //收集完成音效;
	public int AttrEffectType;  //属性类型;
	public List<AttrEffect> attr;  //[,];
}