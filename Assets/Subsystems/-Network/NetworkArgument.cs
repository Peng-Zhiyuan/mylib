using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


// network argument, field format will be generated from config file
public class NetworkArgument
{
	public static Dictionary<string,string> baseParam = new Dictionary<string, string>();
	private SortedDictionary<string, string> mParams = new SortedDictionary<string, string>();

	// return a boolean that whether the argument table is empty
	public bool isEmpty
	{
		get
		{
			return !(mParams.Count > 0);
		}
	}
	
	public bool HasKey(string key)
	{
		if ( mParams.ContainsKey(key) )
		{
			return true;
		}
		return false;
	}
	
	public string GetValue(string key)
	{
		if ( HasKey(key) ){
			return mParams[key];
		}
		return "";
	}

	public void Clear()
	{
		mParams.Clear ();
	}
	

	override public string ToString()
	{
		string ret="";
		foreach( KeyValuePair< string, string > keyVal in mParams)
		{
#if !UNITY_WINRT
			ret += keyVal.Key + " : " + keyVal.Value +"    ";
#else
			ret += keyVal.Key + "=" + keyVal.Value +"&";
#endif
		}
		return ret;
	}
	
	// ToString
	public string ToParamsString()
	{
		string queryStrings = "";
		IEnumerator<string> it = mParams.Keys.GetEnumerator();
		int index = 0;

		while(it.MoveNext()){
			
			string key = it.Current.ToString();
			if(key.Equals("media"))
			{
				continue;
			}
			if(index != 0){ queryStrings += "&"; }
			queryStrings += key + "=" + mParams[key];
			index++;
		}
		return queryStrings;

//			string ret = "";
//			foreach( KeyValuePair< string, string > keyVal in mParams )
//			{
//				ret += NetworkUtil.UrlEncode(keyVal.Key) + "=" +  NetworkUtil.UrlEncode(keyVal.Value) + "&";
//			}
//			return ret.Remove(ret.Length-1);
	}
	
	// Convert NetworkArgument to WWWForm
	public WWWForm ToWWWForm()
	{
		WWWForm form = new WWWForm();
		foreach( KeyValuePair< string, string > keyVal in mParams )
		{
			if(keyVal.Value != null)
			{
			   //form.AddField(  NetworkUtil.UrlEncode(keyVal.Key),  NetworkUtil.UrlEncode(keyVal.Value));
			//	Debug.Log(">>>>>>key:"+keyVal.Key);
				form.AddField(keyVal.Key, keyVal.Value);
			}
		}
		return form;
	}

	public WWWForm ToEncryptedWWWForm()
	{
		string jsonStr = CustomLitJson.JsonMapper.Instance.ToJson(mParams);
		byte[] encryptedBytes = EncryptionMgr.Instance.EncryptStringToBytes(jsonStr);
		string encryptedStr = System.Convert.ToBase64String(encryptedBytes);
		WWWForm form = new WWWForm();
		form.AddField("data", encryptedStr);
		return form;
	}
	
	// add field into argument table
	public void AddParam( string key, string val )
	{
		mParams[ key ] = val;
	}

	public void AddParam( string key, int val )
	{
		AddParam (key, val.ToString ());
	}
	
	// modify specified field value
	public void ModifyParam( string key, string val )
	{
		if ( mParams.ContainsKey( key ))
		{
			mParams[ key ] = val;
		}
		else
		{
			Debug.LogError("===> modifyField key: "+key);
		}
	}
	
	public void AddOrSetParam( string key, string val )
	{
		if ( mParams.ContainsKey( key ) )
		{
			mParams[ key ] = val;
		}
		else
		{
			mParams.Add( key, val );
		}
	}

    public string this [string key]
    {
        set
        {
            AddOrSetParam(key, value);
        }
        get
        {
            return GetValue(key);
        }
    }
	
	// remove specified field
	public void RemoveParam( string key )
	{
		if ( mParams.ContainsKey( key ))
		{
			mParams.Remove( key );
		}
	}
	
	// clone current object
	public NetworkArgument clone()
	{
		NetworkArgument arg = new NetworkArgument();
		foreach( KeyValuePair< string, string > keyVal in mParams )
		{
			arg.mParams[keyVal.Key] = keyVal.Value;
		}
		return arg;
	}
}

public class NetworkCommandInfo
{
	public delegate string NetworkUrlArg ();

	public uint mId;
	public string url;

    public Type runtimeClass;
	public bool isBlock = true;
	public bool isBackGround = false; 

}
	
