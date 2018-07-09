//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:公会系统 Sheet:悬赏分组
using System.Collections.Generic;
public partial class TaskGroupInfo
{
	public int group;  //悬赏组;
	public int ratio;  //概率;
}

public partial class JDClubTaskGroup
{
	public int id;  //日期;
	public List<TaskGroupInfo> groups;  //[,,];
}