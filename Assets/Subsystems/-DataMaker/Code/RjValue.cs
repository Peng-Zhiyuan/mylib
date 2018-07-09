using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
public class RjValue:RjElement
{
	public RjValue(string _key,object _value,RjValueType _value_type,string _des)
	{
		m_class_type=RjClassType.VALUE;
		m_key=_key;
		m_value=_value;
		m_value_type=_value_type;
		m_des=_des;
	}
	public override void AddElement (RjElement _element)
	{
		throw new System.NotImplementedException ();
	}
	public override string ToCSharpCode()
	{
		string _class="\tpublic ";
		switch(m_value_type)
		{
		case RjValueType.STRING:
			_class+="string";
			break;
		case RjValueType.INT:
			_class+="int";
			break;
		case RjValueType.FLOAT:
			_class+="float";
			break;
		}

		string _final_des=m_des;
		if(!string.IsNullOrEmpty(_final_des))
		{
			if(_final_des.Contains("<")&&_final_des.Contains(">"))
			{
//				int _b=_final_des.IndexOf("<");
				int _e=_final_des.IndexOf(">");
				_final_des=_final_des.Substring(_e+1);
			}
		}
		string _info=_class+" "+m_key+";  //"+_final_des;
//		Debug.Log(_info);
		return _info;
	}
	public override string ToJson()
	{
		string _v="";
		switch(m_value_type)
		{
		case RjValueType.STRING:
			_v="\""+m_value.ToString().Replace("\\\"","\"").Replace("\"","\\\"")+"\"";
			break;
		case RjValueType.INT:
			int _out=0;
			if(int.TryParse(m_value.ToString(),out _out))
			{
				_v=_out.ToString();
			}
			else
			{
				_v="0";
			}
			break;
		case RjValueType.FLOAT:
			_v=m_value.ToString();
			break;
		}
		if(string.IsNullOrEmpty(m_key))
		{
			return _v;
		}
		else
		{
			return "\""+m_key+"\":"+_v;
		}
	}
	public override string GetDes ()
	{
		return m_des;
	}
	public override string GetTypeStr ()
	{
		switch(m_value_type)
		{
		case RjValueType.STRING:
		default:
			return "string";
		case RjValueType.INT:
			return "int";
		case RjValueType.FLOAT:
			return "float";
		}
	}
	string m_key;
	object m_value;
	string m_des;
	RjValueType m_value_type;
}
