//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:商城系统 Sheet:资源购买
using System.Collections.Generic;

public partial class JDmarketMoney
{
	public int id;  //次数;
	public List<int> power;  //[体力价格,体力数量];
	public List<int> gold;  //[金币价格,金币数量,总金币,金币购买暴击几率,最小暴击倍率,最大暴击倍率];
	public List<int> ladder;  //[战神殿次数价格,战神殿次数,战神殿总次数];
	public int stage0;  //普通关卡次数价格;
	public int stage1;  //精英关卡次数价格;
}