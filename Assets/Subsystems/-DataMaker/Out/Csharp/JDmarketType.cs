//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:商城系统 Sheet:商城类型
using System.Collections.Generic;

public partial class JDmarketType
{
	public int id;  //ID;
	public string name;  //名稱;
	public int ulv;  //开启等级;
	public List<int> refTime;  //[刷新时间,刷新时间,刷新时间];
	public int modelId;  //模型名称;
	public string posPrefab;  //位置信息;
	public List<int> dispos;  //[折扣格子,折扣格子];
	public List<int> discount;  //[0折,1折,2折,3折,4折,5折,6折,7折,8折,9折,10折];
}