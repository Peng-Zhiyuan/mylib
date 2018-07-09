//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:动画 Sheet:动画
using System.Collections.Generic;

public partial class JDaniSub
{
	public string name;  //动画名;
	public List<float> spec_time;  //[长度,打击点1（秒）,打击点2（秒）,打击点3（秒）,位移开始点1,位移结束点1,位移开始点2,位移结束点2];

}
public partial class JDani
{
	public int id;  //模型ID;
	public List<JDaniSub> Coll;
}