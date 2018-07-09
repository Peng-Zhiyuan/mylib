//===========Code Maker By ETU=============
//===========Gool Luck===========
//Excel:系统配置 Sheet:战斗效果配置

public partial class JDBattleEfect
{
	public int id;  //id;
	public int type;  //0=playerui,1=enemy,2=playgd;
	public int rate;  //万分比以下;
	public float shake_time;  //震动时间(秒);
	public float shake_size;  //震动幅度(Unity米);
	public float shake_frequency;  //震动频率(次/秒);
	public float red_dec_span;  //红血衰减用时(秒);
	public float yellow_dec_span;  //黄血衰减用时(秒);
}