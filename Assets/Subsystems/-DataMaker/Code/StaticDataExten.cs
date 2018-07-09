//ybzuo
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class StaticDatar
{
	static StaticDatar instance=null;
	bool loaded=false;
	public static StaticDatar Instance
	{
		get
		{
			if(instance==null)
			{
				instance=new StaticDatar();
			}
			return instance;
		}
	}

	public  bool IsLoaded
	{
		get
		{
			return loaded;
		}
	}


	StaticDatar()
	{

	}

	//	public List<System.Object> ListList = new List<System.Object> ();
	//	public List<System.Object> DicList = new List<System.Object> ();


	string LoadFile(string _file,bool _remove = false)
	{
		#if UNITY_EDITOR
		Debug.Log("===Load "+_file);
		#endif
		if(m_raw_dic.Count==0)
		{
			#if UNITY_EDITOR
			return System.IO.File.ReadAllText(Application.dataPath+"/ETU/Out/Client/"+_file+".json");
			#else
			return "";//Resources.LoadFile ("ETU/Out/Client/"+_file+".json");
			#endif

		}
		else
		{
			if(m_raw_dic.ContainsKey(_file))
			{
				string result = m_raw_dic[_file];
				if(_remove)
				{
					m_raw_dic.Remove (_file);
				}
				return result;
			}
			return null;
		}
	}
	public void Init(string _info)
	{
		m_raw_dic.Clear();
		if (_info != null) {
			string[] _str_coll = _info.Split('｜');//全角｜
			foreach(string _s in _str_coll)
			{
				if(_s.Length<=5)
				{
					continue;
				}
				string[] _ss_coll= _s.Split('｀');//全角｀
				if(_ss_coll.Length>=2)
				{
					string _name=_ss_coll[0];
					//Debug.LogError("_name:"+_name);
					#if UNITY_EDITOR
					if(m_raw_dic.ContainsKey(_name))
					{
						Debug.LogError("The key is exist:"+_name);
					}
					#endif 
					m_raw_dic[_name]=_ss_coll[1];
				}
			}
		}
		loaded = true;
	}


	Dictionary<string,string> m_raw_dic=new Dictionary<string, string>();	

	public static void Release ()
	{
		instance = null;
	}
}
