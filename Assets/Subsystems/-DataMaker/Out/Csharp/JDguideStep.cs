//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:新手引导 Sheet:GuideStep

public partial class JDguideStep
{
	public int id;  //ID;
	public int group;  //引导步;
	public int sync;  //同步;
	public int sdkstep;  //同步sdk内容;
	public int delay;  //延时(毫秒));
	public string operation;  //操作;
	public int openlv;  //开始等级;
	public int pass_gkid;  //关卡通关触发;
	public int first_gkid;  //第一次挑战触发;
	public string arg0;  //参数0(click:按钮路径，jump:目标界面&参数);
	public string arg1;  //参数1;
	public string arg2;  //参数2;
	public string EndPoint;  //中断事件;
	public string tip;  //简单的tip;
	public string msg;  //提示信息;
	public string point;  //girl和tip偏移;
	public int scale;  //光圈缩放;
	public string offset;  //光圈偏移;
	public int TargetScale;  //目标缩放;
	public string sound;  //语音;
}