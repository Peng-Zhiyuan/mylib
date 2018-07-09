using UnityEngine;
using System.Collections.Generic;
public static partial class Localization
{
	static public string Get (int key)
	{
		return Localization.Get(key.ToString());
	}

	static public string Get (int key, object arg0)
	{
//		Debug.Log(">>>>>>>>>>>>>>>>>:"+key);
		return string.Format(Get (key), arg0);;
	}

	static public string Get (int key, object arg0,object arg1)
	{
		
		return string.Format(Get (key), arg0, arg1);
	}

	static public string Get (int key, object arg0,object arg1,object arg2)
	{
		
		return string.Format(Get (key), arg0, arg1, arg2);
	}
	static public string Get (string key, object arg0)
	{
		//		Debug.Log(">>>>>>>>>>>>>>>>>:"+key);
		return string.Format(Get (key), arg0);;
	}

	static public string Get (string key, object arg0,object arg1)
	{

		return string.Format(Get (key), arg0, arg1);
	}

	static public string Get (string key, object arg0,object arg1,object arg2)
	{

		return string.Format(Get (key), arg0, arg1, arg2);
	}
    static public string[] GetArray(params int[] keys)
    {
        if (keys == null || keys.Length == 0)
            return null;
        string[] returnArray = new string[keys.Length];
        for (int i = 0; i < keys.Length; i++)
        {
            returnArray[i] = Get(keys[i]);
        }
        return returnArray;
    }

    static public string[] GetArray(params string[] keys)
    {
        if (keys == null || keys.Length == 0)
            return null;
        string[] returnArray = new string[keys.Length];
        for (int i = 0; i < keys.Length; i++)
        {
            returnArray[i] = Get(keys[i]);
        }
        return returnArray;
    }

    static public void Append(TextAsset asset)
	{
//		Debug.Log("==============="+asset.name);
//		string _dd=asset.text.Replace("=","\t");
//		Debug.Log(_dd);
		ByteReader reader = new ByteReader(asset);
		Append(asset.name, reader.ReadDictionary());
	}

	static public void Append(string local, string info)
	{

		Dictionary<string, string> dictionarys = new Dictionary<string, string>();
		string[] msglist = info.Split('\n');
		foreach(string msg_unit in msglist)
		{
			string[] msg = msg_unit.Split('=');
			if(!string.IsNullOrEmpty(msg[0]) && msg.Length ==2)
			{
				dictionarys[msg[0]] = msg[1];
			}
		}
		Append (local, dictionarys);
	}

	static public void Append(string languageName, Dictionary<string, string> dictionarys)
	{
		mLanguage = languageName;
		PlayerPrefs.SetString("Language", mLanguage);
		foreach(KeyValuePair<string,string> kv in dictionarys)
		{
			mOldDictionary[kv.Key]= kv.Value;
		}
		localizationHasBeenSet = false;
		mLanguageIndex = -1;
		mLanguages = new string[] { languageName };
		UIRoot.Broadcast("OnLocalize");
	}
	
}

//public partial class UIWidget : UIRect
//{
//
//}
//
//public partial class UIGeometry
//{
//	public void ApplyShear(UIWidget.ShearDirection shearDirection, float shear)
//	{
//		switch (shearDirection) {
//		case UIWidget.ShearDirection.XAxis:
//			for (int i = 0; i < verts.size; ++i) {
//				Vector3 v3 = verts.buffer [i];
//				v3.y += shear * v3.x;
//				verts.buffer [i] = v3;
//			}
//			break;
//		case UIWidget.ShearDirection.YAxis:
//			for (int i = 0; i < verts.size; ++i) {
//				Vector3 v3 = verts.buffer [i];
//				v3.x += shear * v3.y;
//				verts.buffer [i] = v3;
//			}
//			break;
//		}
//	} 
//}

public partial class  UICamera:MonoBehaviour
{
	static public void Notify (GameObject go, string funcName, object obj)
	{
		if (mNotifying > 10) return;
		
		if (NGUITools.GetActive(go))
		{
			++mNotifying;

            /*
			string go_path = GameCore.Utility.GetPath(go);

			#if UNITY_EDITOR
			if(funcName.Equals("OnClick"))
			{
//				string method = "";
//				string target = "";
//				string className = "";
				
//				if(go.GetComponent<UIButton>() !=null && go.GetComponent<UIButton>().onClick != null && go.GetComponent<UIButton>().onClick.Count>0 && go.GetComponent<UIButton>().onClick[0].target!=null)
//				{
//					
//					target = GameCore.Utility.GetPath(go.GetComponent<UIButton>().onClick[0].target.gameObject);
//					className = go.GetComponent<UIButton>().onClick[0].target.GetType().ToString();
//					method = go.GetComponent<UIButton>().onClick[0].methodName;
//					GameCore.EventManager.Instance.SendEvent<string>("NotifyMsg",go_path+"&"+target+"&"+className+"/"+method);
//				}
			
				//	className = GameCore.Utility.GetPath(go.GetComponent<MonoBehaviour>().GetType().ToString());
					//className = go.GetComponent<UIButton>().onClick[0].target.GetType().ToString();
					//method = go.GetComponent<UIButton>().onClick[0].methodName;
				GameCore.EventManager.Instance.SendEvent<string>("NotifyMsg",go_path+"&"+funcName);
				//}
				//Debug.Log("OnClick"+mNotifying);

			}
           
			//Debug.Log("Notify"+mNotifying);

			#endif
   */          
    
//			if(funcName.Equals("OnClick") && !FunctionSwitcher.Instance.CheckInBtn(go_path))
//			{
//				//GameCore.UIHandler.Instance.ShowPopView("no tip");
//			}
//    
//			else go.SendMessage(funcName, obj, SendMessageOptions.DontRequireReceiver);
    

//			Debug.LogError("SendMessage"+funcName);
            go.SendMessage(funcName, obj, SendMessageOptions.DontRequireReceiver);
			if (mGenericHandler != null && mGenericHandler != go)
				mGenericHandler.SendMessage(funcName, obj, SendMessageOptions.DontRequireReceiver);
			--mNotifying;
		}
	}
}

public partial class EventDelegate
{
	static public void Execute (List<EventDelegate> list)
	{
		if (list != null)
		{
			for (int i = 0; i < list.Count; )
			{
				EventDelegate del = list[i];
				if (del != null)
				{
				

					//add hotfix script
					//if(del.target != null)Debug.Log(">>>>>>>"+del.target.GetType()+ "." + del.methodName);
					#if !UNITY_EDITOR 
					try
					{
						del.Execute();
					}
					catch (System.Exception ex)
					{
						if (ex.InnerException != null) Debug.LogError(ex.InnerException.Message);
						else Debug.LogError(ex.Message);
					}
					#else
					del.Execute();
					#endif


					if (i >= list.Count) break;
					if (!list[i].Equals (del)) continue;
					
					if (del.oneShot)
					{
						list.RemoveAt(i);
						continue;
					}
				}
				++i;
			}
		}
	}
}

