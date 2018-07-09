using UnityEngine;
using System.Collections.Generic;
public enum QualityColor
{
	QC_Grey = 0,
	QC_White = 1,
	QC_Green,
	QC_Blue,
	QC_Purple,
	QC_Orange,

	QC_Red,
	QC_Yellow,
	QC_Dark,
}

public class ColorHelper 
{

	static public string GetQualityColorStr (QualityColor color)
	{
		switch (color) {
			case QualityColor.QC_Grey:
				return "adbbc0";
			case QualityColor.QC_White:
				return "FFFFFF";
			case QualityColor.QC_Green:
				return "12FF00";//green
			case QualityColor.QC_Blue:
				return "1ea5ff";//blue
			case QualityColor.QC_Purple:
				return "DC4BFF";//purple
			case QualityColor.QC_Orange:
				return "FFA014";//orange
			case QualityColor.QC_Red:
				return "EE2C2C";//red
			case QualityColor.QC_Yellow:
				return "FFFF00";//yellow
			case QualityColor.QC_Dark:
				return "F3E597";//dark
			default :
				return "ffffff";//white
		}		
	}
	public enum FONT_COLOR
	{
		RED,
		WHITE,
		BLACK,
		ORANGE,

		GREEN,
		YELLOW,
		BLUE,
		PURPLE,
		GREY
	}
	static public string GetColor(FONT_COLOR color)
	{
		switch(color)
		{
			case FONT_COLOR.RED: return"[ee2c2c]";
			case FONT_COLOR.WHITE: return"[ffffff]";
			case FONT_COLOR.BLACK: return"[404040]";
			case FONT_COLOR.ORANGE: return"[ffa500]";
			case FONT_COLOR.GREEN: return"[64c680]";
			case FONT_COLOR.YELLOW: return"[FFFF00]";
			case FONT_COLOR.BLUE: return"[7cd5ff]";
			case FONT_COLOR.PURPLE: return"[A020F0]";
			case FONT_COLOR.GREY: return"[696969]";

		}
		return "";
	}

	static public string SwitchColor(string str, FONT_COLOR old_color, FONT_COLOR new_color)
	{
		return str.Replace(GetColor(old_color), GetColor(new_color));
	}

	static public string QualityColorFonts(string str, int q)
	{
		switch(q)
		{
			default:
			case 0: return GreyColor(str);
			case 1: return WhiteColor(str);
			case 2: return GreenColor(str);
			case 3: return BlueColor(str);
			case 4: return PurpleColor(str);
			case 5: return OrangeColor(str);
		}
	}
	static public string GreyColor(string str)
	{
		return string.Format ("[{0}]{1}[-]",GetQualityColorStr (QualityColor.QC_Grey), str);
	}
	static public string WhiteColor(string str)
	{
		return string.Format ("[{0}]{1}[-]",GetQualityColorStr (QualityColor.QC_White), str);
	}

	static public string OrangeColor(string str)
	{
		return string.Format ("[{0}]{1}[-]",GetQualityColorStr (QualityColor.QC_Orange), str);
	}

	static public string RedColor(string str)
	{
		return string.Format ("[{0}]{1}[-]",GetQualityColorStr (QualityColor.QC_Red), str);
	}
	static public string YellowColor(string str)
	{
		return string.Format ("[{0}]{1}[-]",GetQualityColorStr (QualityColor.QC_Yellow), str);
	}

	static public string DarkColor(string str)
	{
		return string.Format ("[{0}]{1}[-]",GetQualityColorStr (QualityColor.QC_Dark), str);
	}
	static public int GetCharCount(string s, int l)
	{
		int length = 0;
		int count = 0;
		foreach (char c in s) 
		{
			if(c!='\n')
			{
				if (c >= '\u4e00' && c <= '\u9fa5')
					length += 2;
				else
					length += 1;
				count++;
			}
			if(length >= l)return count;
		}
		return count;
	}

	static public string GreenColor(string str)
	{
		return string.Format ("[{0}]{1}[-]",GetQualityColorStr (QualityColor.QC_Green), str);
	}

	static public string BlueColor(string str)
	{
		return string.Format ("[{0}]{1}[-]",GetQualityColorStr (QualityColor.QC_Blue), str);
	}

	static public string PurpleColor(string str)
	{
		return string.Format ("[{0}]{1}[-]",GetQualityColorStr (QualityColor.QC_Purple), str);
	}

	public static Color GetQualityColor(QualityColor q)
	{
		return GetColorFrom16 (GetQualityColorStr(q));
	}

	public static Color GetColorFrom16(string _str,float _alpha =1)
	{
		if(_str==null||_str.Length<4)
		{
			return Color.white;
		}
		Color temp_color;
		temp_color.a = _alpha;
		string _temp=_str.Substring(0,2);
		temp_color.r = (float)System.Convert.ToInt32(_temp, 16)/255.0f;
		_temp = _str.Substring(2, 2);
		temp_color.g = (float)System.Convert.ToInt32(_temp, 16) / 255.0f;
		_temp = _str.Substring(4, 2);
		temp_color.b = (float)System.Convert.ToInt32(_temp, 16) / 255.0f;
		return temp_color;
	}

	public static string Convert255toString(int _r,int _g,int _b)
	{
		string color = "[";
		color+= _r.ToString("x8").Substring(6,2);
		color+= _g.ToString("x8").Substring(6,2);
		color+= _b.ToString("x8").Substring(6,2);
		color+="]";
		return color;
	}	

	public static Color GetColorFrom255(int _r,int _g,int _b,int _a)
	{
		Color temp_color;
		temp_color.r = _r / 255.0f;
		temp_color.g = _g / 255.0f;
		temp_color.b= _b / 255.0f;
		temp_color.a = _a / 255.0f;
		return temp_color;
	}	

	public static Color Gray (Color color)
	{
		color *= Color.gray;
		color = new Color (color.r, color.g, color.b, color.a);
		return color;
	}


//	public static Color GetUIColor (QualityColor color)
//	{
//		switch (color) {
//			case QualityColor.QC_Green:
//				return new Color(1f,255f,9f,255f)/255;
//			case QualityColor.QC_Blue:
//				return new Color(48f,184f,233f,255f)/255;		
//			default :
//				return Color.white;
//		}		
//	}
	static public string RemoveColor(string m)
	{
		return System.Text.RegularExpressions.Regex.Replace(m.Replace("[","<").Replace("]",">"), "(<{1})(.{0,6})(>{1})", "");
	}

	static public string DevalidColor(string m)
	{

		return m.Replace("[","(").Replace("]",")");
	}


}
