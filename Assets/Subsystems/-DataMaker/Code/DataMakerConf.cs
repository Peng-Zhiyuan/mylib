using UnityEngine;
using System.Collections.Generic;

public class DataMakerConf : Single<DataMakerConf> 
{

	//public  string m_code_out_dir = "Assets/[Subsystems]/-DataMaker/Out";
	public  string m_client_dir
	{
		get
        {
			return PlayerPrefs.GetString(m_out_key, "");
        }
        set
        {
            string path = value.Replace("\\", "/");
            if (path[path.Length - 1] != '/')
            {
                path += "/";
            }
			PlayerPrefs.SetString(m_out_key, path);
            PlayerPrefs.Save();
        }
	}
	public  string m_server_dir
	{
		get
        {
			return PlayerPrefs.GetString(m_server_key, "");
        }
        set
        {
            string path = value.Replace("\\", "/");
            if (path[path.Length - 1] != '/')
            {
                path += "/";
            }
			PlayerPrefs.SetString(m_server_key, path);
            PlayerPrefs.Save();
        }
	}

	public string m_excel_dir
    {
        get
        {
            return PlayerPrefs.GetString(m_excel_key, "");
        }
        set
        {
            string path = value.Replace("\\", "/");
            if (path[path.Length - 1] != '/')
            {
                path += "/";
            }
            PlayerPrefs.SetString(m_excel_key, path);
            PlayerPrefs.Save();
        }
    }



    


	public string m_excel_key
	{
		get
		{
			return "EtuExcel"+Application.dataPath;
		}
	}
	public string m_out_key
	{
		get
		{
			return "EtuOut_"+Application.dataPath;
		}
	}

	public string m_server_key
	{
		get
		{
			return "EtuServer_"+Application.dataPath;
		}
	}

      

   

//	public string m_server_url_path 
//	{
//		get
//		{
//			return PlayerPrefs.GetString(m_server_key,"http://192.168.2.250:8081/")+CurServerDocument+"/";
//		}
//	}

	public void Reset()
	{
		DataMakerConf.Instance.m_excel_dir="";
	}

    private string _curLocalName;
	public string CurLocalName
	{
        get
        {
            if (string.IsNullOrEmpty(_curLocalName))
            {
                return  GameManifestFinal.Get("region", "");
            }
            return _curLocalName;
        }
        set
        {
            _curLocalName = value;
        }
	}


	public string curGameVer
	{
		get
		{
			return  GameManifestFinal.Get("version", "1");
		}
	}
		


	public enum REMOTE_SERVER
	{
		DEV_CLIENT,
		DEV_SERVER,
	}



	public string GetRemotePath(REMOTE_SERVER serverMode)
	{
		#if UNITY_EDITOR
		switch(serverMode)
		{
			case REMOTE_SERVER.DEV_CLIENT: return "/usr/share/nginx/html/"+CurServerDocument;
			case REMOTE_SERVER.DEV_SERVER: return "/usr/share/nginx/html/"+CurServerDocument;
		}
		#endif
		return "";

	}

	public string CurServerDocument
	{
		get
		{
			return Application.productName+"_"+CurLocalName;
		}
	}

}
