using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
//ybzuo


public enum RjClassType
{
	VALUE,
	COLL,
	STUCT,
}
public enum RjValueType
{
	STRING,
	INT,
	FLOAT,
}

public class RjClassInfo
{
	public string key;
	public RjClassType class_type;
	public RjValueType value_type;
	public int begin_index;
	public int end_index;
}


public class RjGlobalInfo
{
	public List<RjClassInfo> key_list=new List<RjClassInfo>();
}
public abstract class RjElement
{
	public abstract string ToJson();
	public abstract string ToCSharpCode();
	public abstract string GetDes();
	public abstract string GetTypeStr();
	public virtual string GetDesEnd()
	{
		return null;
	}
	public abstract void AddElement(RjElement _element);
	public void SetParent(RjElement _element)
	{
		m_parent=_element;
	}
	public RjElement GetPerent()
	{
		return m_parent;
	}
	public RjClassType GetClassType()
	{
		return m_class_type;
	}
	RjElement m_parent;
	protected RjClassType m_class_type;
}


public class RjData:RjElement
{
	public RjData(string _key)
	{

		m_key=_key;
		if(!string.IsNullOrEmpty(m_key))
		{
			string _kk=m_key;
			if(_kk.Contains("<")&&_kk.Contains(">"))
			{
				int _b=_kk.IndexOf("<");
				int _e=_kk.IndexOf(">");
				m_type=_kk.Substring(_b+1,_e-_b-1);
				m_key=m_key.Substring(_e+1);
			}
		}
		m_class_type=RjClassType.STUCT;
	}

	public override void AddElement(RjElement _element)
	{
		m_element_list.Add(_element);
		_element.SetParent(this);
	}
	public override string ToCSharpCode()
	{
		string _str="";
		if(!string.IsNullOrEmpty(m_key))
		{
			_str="\tpublic "+m_type+" "+m_key;

			if(m_type=="LEESAN_")
			{
				m_type="Dummy"+DmHelper.MagicNum;
				DmHelper.MagicNum++;
				//m_type="LEESAN_";//+DmHelper.DataNameBankList.Count;
				_str="\tpublic "+m_type+" "+m_key;
				DmHelper.DataNameBankList.Add(m_type);
				RjData _rj=new RjData(null);
				for(int i=0;i<m_element_list.Count;++i)
				{
					_rj.AddElement(m_element_list[i]);
				}
				DmHelper.DataBankList.Add(_rj);
			}
			else
			{
				if(!DmHelper.DataNameBankList.Contains(m_type))
				{
					if(!string.IsNullOrEmpty(m_type))
					{
						DmHelper.DataNameBankList.Add(m_type);
					}
					RjData _rj=new RjData(null);
					for(int i=0;i<m_element_list.Count;++i)
					{
						_rj.AddElement(m_element_list[i]);
					}
					DmHelper.DataBankList.Add(_rj);
				}
			}
		}
		else
		{

			for(int i=0;i<m_element_list.Count;++i)
			{
				_str+=m_element_list[i].ToCSharpCode();
				if(i<m_element_list.Count-1)
				{
					_str+=";\n";
				}
				else
				{
					_str+=";";
				}
			}
		}
//		string _des="";
//		for(int i=0;i<m_element_list.Count;++i)
//		{
//			_des+=m_element_list[i].GetDes();
//			if(i<m_element_list.Count-1)
//			{
//				_des+=",";
//			}
//		}
//		Debug.Log(_str);
//		return _str+"  //"+_des;
//		if(!_str.Contains(";"))
//		{
//			Debug.Log(_str);
//			//_str+=";";
//		}
		if(string.IsNullOrEmpty(m_des))
		{
			return _str;
		}
		else
		{
			return _str+"  //"+m_des;
		}
	}
	public override string ToJson()
	{
		string _str="";
		if(!string.IsNullOrEmpty(m_key))
		{
			_str+=("\""+m_key+"\":");
		}
		_str+="{";
		for(int i=0;i<m_element_list.Count;++i)
		{
			_str+=m_element_list[i].ToJson();
			if(i<m_element_list.Count-1)
			{
				_str+=",";
			}
		}
		return _str+"}";
	}
	public  string ToKeyValue()
	{
		string _str="";
//		if(!string.IsNullOrEmpty(m_key))
//		{
//			_str+=("\""+m_key+"\":");
//		}
//		_str+="{";
		for(int i=0;i<m_element_list.Count;++i)
		{
			string json = m_element_list[i].ToJson();
			int index= json.IndexOf(':')+1;
			_str+=json.Substring(index,json.Length-index).Replace("\"","");
			if(i==0)
			{
				_str+="=";
			}
			if(i>=1)break;
		}
		return _str;
	}

	public  string ToKeyValueString()
	{
		string _str="";
		//		if(!string.IsNullOrEmpty(m_key))
		//		{
		//			_str+=("\""+m_key+"\":");
		//		}
		//		_str+="{";
		for(int i=0;i<m_element_list.Count;++i)
		{
			string json = m_element_list[i].ToJson();
			int index= json.IndexOf(':')+1;
			_str+=json.Substring(index,json.Length-index);
			if(i==0)
			{
				_str+=":";
			}
			if(i>=1)break;
		}
		return _str;
	}

	public override string GetDes ()
	{
		return m_des;
	}
	public override string GetTypeStr ()
	{
		if(m_type=="LEESAN_")
		{
			m_type="Dummy"+DmHelper.MagicNum;
			DmHelper.MagicNum++;
		}
		return m_type;
	}
	public override string GetDesEnd()
	{
		if(m_element_list.Count>0)
		{
			if(!string.IsNullOrEmpty(m_element_list[0].GetDes()))
			{
				string _dd=m_element_list[0].GetDes();
				if(_dd.Contains("<")&&_dd.Contains(">"))
				{
					int _b=_dd.IndexOf("<");
					int _e=_dd.IndexOf(">");
					return _dd.Substring(_b+1,_e-_b-1);
				}
			}
		}
		return null;
	}
	string m_key;
	string m_des="";
	string m_type="LEESAN_";
	List<RjElement> m_element_list=new List<RjElement>();
}
