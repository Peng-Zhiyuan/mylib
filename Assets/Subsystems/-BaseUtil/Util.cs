using UnityEngine;
using GameCore;
using System;
using System.Security.Cryptography;
using System.Text;
using  System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
public class Util:Single<Util>
{

	//public static Util Instance = new Util();
	public  string FormatNumber(int val,int len)
	{
		string result = val.ToString();
		int index = result.Length;
		while(index <len)
		{
			index++;
			result="0"+result;
		}
		return result;
	}

	public string SimpleMD5CryptoServiceProvider(byte[] result)
	{
		//byte[] result = Encoding.UTF8.GetBytes(plaintext);    //tbPass为输入密码的文本框  
		MD5 md5 = new MD5CryptoServiceProvider();  
		byte[] output = md5.ComputeHash(result);  
		return BitConverter.ToString(output).Replace("-","").ToLower();;
	}

	public string SimpleMD5CryptoServiceProvider(string plaintext)
	{
		byte[] result = Encoding.UTF8.GetBytes(plaintext);    //tbPass为输入密码的文本框  
		MD5 md5 = new MD5CryptoServiceProvider();  
		byte[] output = md5.ComputeHash(result);  
		return BitConverter.ToString(output).Replace("-","").ToLower();;
	}

	public Vector3  ParsePoint(string point)
	{
		string[] pts = point.Replace("{","").Replace("}","").Split(',');
		if(pts.Length!=3)
		{
			return Vector3.zero;
		}
		return new Vector3(float.Parse(pts[0]),float.Parse(pts[1]),float.Parse(pts[2]));
	}
		
	public static void SetLayer(Transform trans, string layerName)
	{
		trans.gameObject.layer=LayerMask.NameToLayer (layerName);
		foreach (Transform child in trans) {
			child.gameObject.layer = LayerMask.NameToLayer (layerName);
			SetLayer (child, layerName);
		}
	}

	public byte[] StreamToBytes(Stream stream)
	{
		byte[] bytes = new byte[stream.Length];
		stream.Read(bytes, 0, bytes.Length);
		// 设置当前流的位置为流的开始
		stream.Seek(0, SeekOrigin.Begin);
		return bytes;
	}

	public Stream BytesToStream(byte[] bytes)
	{
		Stream stream = new MemoryStream(bytes);
		return stream;
	}
	public string GetPoints(int count)
	{
		switch(count)
		{
			default:
			case 0: return "";
			case 1: return ".";
			case 2: return "..";
			case 3: return "...";
		}
	}
	public string GetX(int count)
	{
		switch(count)
		{
			default:
			case 0: return "／";
			case 1: return "－";
			case 2: return "\\";
			case 3: return "－";
		}
	}

	public void ChangeMat(Renderer _r,Material _mat,string _main_tex_pro="_MainTex")
	{
		Material[] _mas=new Material[_r.materials.Length];
		for(int i=0;i<_r.materials.Length;++i)
		{
			Texture _tex=_r.materials[i].mainTexture;
			Material _new_mat=new Material(_mat);
			_new_mat.SetTexture(_main_tex_pro,_tex);
			_mas[i]=_new_mat;
		}
		_r.materials=_mas;

	}

	public int Random(int num)
	{
		long date= ServerTime.Instance.GetDayIndex(ServerTime.Now,false);
		long rand = ((date *9301) +49297)%65535;
		return Mathf.FloorToInt(rand * num/65535f);
	}

	public int RandomRange(int min, int max)
	{
		long date= ServerTime.Instance.GetDayIndex(ServerTime.Now,false);
		long rand = ((date *9301) +49297)%65535;
		return min+Mathf.FloorToInt(rand * (max-min)/65535f);
	}
		
	static public Vector3 GetIntVector(string vector_string)
	{
		if(string.IsNullOrEmpty(vector_string))return Vector3.zero;
		vector_string=vector_string.Remove(vector_string.Length-1,1).Remove(0,1);
		string[] points= vector_string.Split(',');
		return new Vector3(int.Parse(points[0]),int.Parse(points[1]),int.Parse(points[2]));
	}

	static public Vector3 GetFloatVector(string vector_string)
	{
		if(string.IsNullOrEmpty(vector_string))return Vector3.zero;
		vector_string=vector_string.Remove(vector_string.Length-1,1).Remove(0,1);
		string[] points= vector_string.Split(',');
		return new Vector3(float.Parse(points[0]),float.Parse(points[1]),float.Parse(points[2]));
	}


	static public int RoundToInt(float f)
	{
		return Mathf.FloorToInt(f+0.5f);
	}

	static public int RoundToInt(double d)
	{
		return Mathf.FloorToInt((float)d+0.5f);
	}
	static public string FormatDate(long time)
	{
		DateTime date = ServerTime.Instance.FromMillSecond (time);
		int t= (int)(time/1000);
		if (ServerTime.Instance.IsTodayBySecond(t,true)) {
			return date.ToString ("HH:mm");
		} 
		else if(ServerTime.Instance.IsYesTodayBySecond(t,true))
		{
			return Localization.Get (4306) + "  " + date.ToString ("HH:mm");
		}
		else
		{
			return date.ToString("MM-dd HH:mm");
		}
	}

	static public string FormatTime(long time)
	{
		DateTime date = ServerTime.Instance.FromMillSecond (time);
		return date.ToString ("HH:mm");
	}
}
