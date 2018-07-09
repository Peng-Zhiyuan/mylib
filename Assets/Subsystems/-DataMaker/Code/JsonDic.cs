using UnityEngine;
using System.Collections.Generic;
using CustomLitJson;
using System.Collections.ObjectModel;
using System.Collections;
using System;
using GameCore;
//class IterationEnumerator<T> : IEnumerator<T>
//{
//	private int position;
//	JsonDic<T> parent;//迭代的对象  #1
//	internal IterationEnumerator(JsonDic<T> parent)
//	{
//		this.parent = parent;
//		position = -1;// 数组元素下标从0开始，初始时默认当前游标设置为 -1，即在第一个元素之前， #3
//	}
//
//	public bool MoveNext()
//	{
//		if (position != parent.Count) //判断当前位置是否为最后一个，如果不是游标自增 #4
//		{
//			position++;
//		}
//		return position < parent.Count;
//	}
//
////	public T Current
////	{
////		get
////		{
////			if (position == -1 || position == parent.Count)//第一个之前和最后一个自后的访问非法 #5
////			{
////				throw new InvalidOperationException();
////			}
////			return parent[position];
////		}
////	}
//	public object Current
//	{
//		get
//		{
//			if (position == -1 || position == parent.Count)//第一个之前和最后一个自后的访问非法 #5
//			{
//				throw new InvalidOperationException();
//			}
//			return (object)parent[position];
//		}
//	}
//	public void Reset()
//	{
//		position = -1;//将游标重置为-1  #7
//	}
//
//
//
//	public void Dispose()
//	{
//
//	}
//
//
//}

public class JsonDic<T>//:IEnumerable<T>,IEnumerable 
{
	

	private int _size;
	//init data
	private List<string> jsonKeyList= new List<string>();
	private Dictionary<string, string> jsonStringDic = new Dictionary<string, string>(); 


	private Dictionary<string, T> jsonDataDic = new Dictionary<string, T>(); 
	private List<T> jsonDataList;//= new List<T>();

//	public IEnumerator<T> GetEnumerator()
//	{
//		return new IterationEnumerator<T>(this);
//	}
//
//	IEnumerator  IEnumerable.GetEnumerator()
//	{
//		for (int index = 0; index < _size; index++)
//		{
//			yield return this[index];
//		}
//	}
//	public IEnumerator<T> GetEnumerator()
//	{
//		for (int index = 0; index < _size; index++)
//		{
//			yield return this[index];
//		}
//	}

	public List<T> DataList
	{
		get
		{
			if(jsonDataList == null)
			{
				Debug.Log("DataList>>>>>:"+this.GetType().ToString());
				jsonDataList= new List<T>();
				for(int i=0; i< _size; i++)
				{
					jsonDataList.Add( ElementAt(i));
				}
			}
			return jsonDataList;
		}
	}

	public Dictionary<string, T> DataDic
	{
		get
		{
			if(DataList !=null) return jsonDataDic;
			return jsonDataDic;
		}
	}


	public Dictionary<string, string> StringDic
	{
		get
		{
			return jsonStringDic;
		}
	}

//	public string FormatStringElement(string key)
//	{
//		if( jsonStringDic.ContainsKey(key))return jsonStringDic[key].Replace("\\n","\n");
//		else return "";
//	}
	public string ToString()
	{

		string data="";
		foreach(KeyValuePair<string,T> kv in DataDic)
		{
			data+=kv.Key+"`"+JsonMapper.Instance.ToJson(kv.Value)+"|";
		}
		data = data.Remove(data.Length-1,1);
		return data;

	}



//	public int CompareTo(T t)
//	{
//		{
//			return -1;
//		}
//		//return Age.CompareTo(student.Age);
//	}
//	public int Compare(T t1, T t2)
//	{
//		return (new CaseInsensitiveComparer()).Compare(t1, t2);
//	}
		

//	public static IEnumerable<T> Where<T>(IEnumerable<T> source, Predicate<T> predicate)
//	{
//		if (source == null || predicate == null)
//			throw new ArgumentNullException();
//		return WhereImpl(source, predicate);
//	}
//
//	private static IEnumerable<T> WhereImpl<T>(IEnumerable<T> source, Predicate<T> predicate)
//	{
//		foreach (T item in source)
//		{
//			if (predicate(item))
//				yield return item;
//		}
//	}
//	public void Sort(IComparer<T> comparer) {
//		DataList.Sort(comparer);
//	}
//
//	public void Sort(Comparison<T> comparison) {
//		DataList.Sort(comparison);
//	}
//
//	public void Sort()
//	{
//		DataList.Sort();
//	}
//
//	public void RemoveAt(int index)
//	{
//		DataList.RemoveAt(index);
//	}
//		
		
//
//	public static IEnumerable Where(IEnumerable source, Predicate<T> predicate)
//	{
//		if (source == null || predicate == null)
//			throw new ArgumentNullException();
//		return WhereImpl(source, predicate);
//	}
//
//	private static IEnumerable WhereImpl(IEnumerable source, Predicate<T> predicate)
//	{
//		foreach (T item in source)
//		{
//			if (predicate(item))
//				yield return item;
//		}
//	}
	//IEnumerable<String> lines = ReadLines("FakeLinq.cs");
//	Predicate<String> predicate = delegate(String line)
//	{
//		return line.StartsWith("using");
//	};
	public int Count
	{
		get
		{
			return _size;
		}
	}
	public List<string> Keys
	{
		get
		{
			return jsonKeyList;
		}
	}
		
	public  JsonDic(string data)
	{
		string[] info = data.Split('|');
		for(int i =0; i< info.Length ; i++)
		{
			string[] item = info[i].Split('`');

			if(item.Length==2 && !string.IsNullOrEmpty(item[0]) &&  !string.IsNullOrEmpty(item[1]))
			{
				jsonStringDic[item[0]] = item[1];
				jsonKeyList.Add(item[0]);
			}
		}
		_size = jsonStringDic.Count;

	}
	public T GetElement(int key)
	{
		#if UNITY_EDITOR && ETU_LOG
		Debug.Log("GetElement:"+key);
		#endif 
		return GetElement(key.ToString());
	}

	public T ElementAt(int index)
	{

		if(jsonKeyList.Count <= index)
		{
			return default(T);
		}
		return GetElement(jsonKeyList[index]);
	}

	public T GetElement(string key)
	{
		if(jsonDataDic.ContainsKey(key))
		{
			return jsonDataDic[key];
		}
		if(jsonStringDic.ContainsKey(key))
		{
			#if UNITY_EDITOR && ETU_LOG
			Debug.Log("key:"+key);
			#endif 
			string val = jsonStringDic[key];
			#if UNITY_EDITOR && ETU_LOG
			Debug.Log(" jsonString:"+ jsonStringDic[key]);
			#endif 
			T t = JsonMapper.Instance.ToObject<T>(val);
			jsonDataDic.Add(key,t);
			jsonStringDic[key]=null;
			return t;
		}
		if(_size >0)return ElementAt(0);
		return default(T);
	}

    public T TryGet(string key)
    {
        if (ContainsKey(key))
        {
            return this[key];
        }
        return default(T);
    }
		

	public bool ContainsKey(string key)
	{
		return jsonStringDic.ContainsKey(key);
	}
	public bool ContainsKey(int key)
	{
		return jsonStringDic.ContainsKey(key.ToString());
	}

	public T this[int index] 
	{
		get 
		{
			return GetElement(index.ToString()); 
		}
	}

	public T this[string key] 
	{
		get 
		{
			return GetElement(key); 
		}
	}
		


}
