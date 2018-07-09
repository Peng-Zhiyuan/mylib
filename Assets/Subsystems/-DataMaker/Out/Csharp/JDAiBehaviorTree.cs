//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:怪物列表 Sheet:怪物AI
using System.Collections.Generic;

public partial class JDAiBehaviorTreeSub
{
	public string name;  //怪物名称;
	public int aiId;  //AI编号;
	public int state;  //怪物状态;
	public int init;  //初始激活;
	public string conditional;  //AI条件;
	public string action;  //AI行为;
	public string path;  //巡逻;
	public int times;  //执行次数;
	public int period;  //AI间隔;
	public int probability;  //AI概率;
	public int priority;  //AI优先级;
	public int interrupt;  //是否被其他行为打断;

}
public partial class JDAiBehaviorTree
{
	public int id;  //怪物ID;
	public List<JDAiBehaviorTreeSub> Coll;
}