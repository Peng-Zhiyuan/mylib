using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Text;
public class RjColl:RjElement
{
	public RjColl(string _key)
	{
		m_class_type=RjClassType.COLL;
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
//		Debug.Log(m_type+" "+m_key);
		m_list=new List<RjElement>();
	}
	public override void AddElement(RjElement _element)
	{
		m_list.Add(_element);
		_element.SetParent(this);
		if(m_type==null)
		{
			if(_element is RjData)
			{
				m_type=_element.GetTypeStr();
			}
		}
	}
	public override string ToCSharpCode()
	{


		if(m_type!=null)
		{
//			if(m_type=="LEESAN_")
//			{
//				//m_type="LEESAN_";//+DmHelper.DataNameBankList.Count;
//				_str="\tpublic "+m_type+" "+m_key;
//				DmHelper.DataNameBankList.Add(m_type);
//				RjData _rj=new RjData(null);
//				for(int i=0;i<m_element_list.Count;++i)
//				{
//					_rj.AddElement(m_element_list[i]);
//				}
//				DmHelper.DataBankList.Add(_rj);
//			}
//			else
//			{
//				if(!DmHelper.DataNameBankList.Contains(m_type))
//				{
//					if(!string.IsNullOrEmpty(m_type))
//					{
//						DmHelper.DataNameBankList.Add(m_type);
//					}
//					RjData _rj=new RjData(null);
//					for(int i=0;i<m_element_list.Count;++i)
//					{
//						_rj.AddElement(m_element_list[i]);
//					}
//					DmHelper.DataBankList.Add(_rj);
//				}
//			}

			if(!DmHelper.DataNameBankList.Contains(m_type))
			{
				DmHelper.DataNameBankList.Add(m_type);
				DmHelper.DataBankList.Add(m_list[0] as RjData);
			}
		}
		m_des="[";
		for(int i=0;i<m_list.Count;++i)
		{
			m_des+=m_list[i].GetDes();
			if(i<m_list.Count-1)
			{
				m_des+=",";
			}
		}
		m_des+="]";

		if(string.IsNullOrEmpty(m_type))
		{
			return "\tpublic List<"+m_list[0].GetTypeStr()+"> "+m_key+";  //"+m_des;
		}
		else
		{
			return "\tpublic List<"+m_type+"> "+m_key+";  //"+m_des;
		}
	}
	public override string ToJson()
	{
		string _v="";
		for(int i=0;i<m_list.Count;++i)
		{
			_v+=m_list[i].ToJson();
			if(i<m_list.Count-1)
			{
				_v+=",";
			}
		}
		return "\""+m_key+"\":["+_v+"]";
	}
	public override string GetDes ()
	{
		return m_des;
	}
	public override string GetTypeStr ()
	{
		return "List<"+m_list[0].GetTypeStr()+">";
	}
	string m_key;
	string m_des="";
	string m_type=null;
	List<RjElement> m_list;
}
