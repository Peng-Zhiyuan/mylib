using UnityEngine;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System;
using CustomLitJson;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MaxVerInfo
{
	public int dataVer = 0;
	public int hotVer = 0;
	public int packVer = 0;
}


public class EtuBuildResult
{
	public List<string> done_list=new List<string>();
	public List<string> error_file_list=new List<string>();
	public List<string> error_sheet_list=new List<string>();
	public List<string> skip_sheet_list=new List<string>();
	public JsonData json_str = new JsonData();
	public string client_total_info;
	public string server_total_info;
}

public class DataMakerEdit : MonoBehaviour
{
	private string m_data_ver="";
	//FTP.FTPHelper ftphelper;
	string ftp_client_url;
	string ftp_server_url;
	MaxVerInfo max_ver;
	//public string mask;
	SFTPHelper ftphelper;
	void Start ()
	{


		m_data_inputer.value=DataMakerConf.Instance.m_excel_dir;
		m_out_inputer.value=DataMakerConf.Instance.m_client_dir;
		m_server_inputer.value = DataMakerConf.Instance.m_server_dir;
		m_csharp_tog.value=false;
		m_debug_tog.value=false;
		m_net_tog.value=false;

		m_game_version_inputer.value = DataMakerConf.Instance.curGameVer;
	
		m_data_ver = DataMakerConf.Instance.curGameVer;

		//languageToggle[DataMakerConf.Instance.LanguageIndex].value = true;

		//SwitchLanguage();
	
	}




	private DataMaker Maker
	{
		get
		{
			if(m_maker == null)
			{
				m_maker=new DataMaker();
			}
			return m_maker;

		}
	}


   



   





   
	void Update()
	{

		if(m_show_time>0.0f)
		{
			m_show_time-=Time.deltaTime;
			if(m_show_time<=0.0f)
			{
				m_show_time=-1.0f;
				m_info_label.gameObject.SetActive(false);
			}
			if(m_char_fly_time>0.0f)
			{
				m_char_fly_time-=Time.deltaTime;
				if(m_char_fly_time<=0.0f)
				{
					m_char_index++;
					if(m_char_index>m_current_str.Length)
					{
						m_char_fly_time=-1.0f;
					}
					else
					{
						m_char_fly_time=m_fly_speed;
						m_info_label.text=m_current_str.Substring(0,m_char_index);
					}
				}
			}
		}

		if(m_upload_bar.isActiveAndEnabled)
		{
			if(m_cur_pross<m_max_pross)
			{
				m_cur_pross+=Time.deltaTime*m_pross_speed;
			}
			if(m_cur_pross>=1.0f)
			{
				m_upload_bar.gameObject.SetActive(false);
				m_cur_pross=0.0f;
			}
			else
			{
				m_upload_bar.value=m_cur_pross;
			}
		}

	}

	public void OnReset()
	{
		DataMakerConf.Instance.Reset();
		m_data_inputer.value=DataMakerConf.Instance.m_excel_dir;
		m_out_inputer.value = DataMakerConf.Instance.m_client_dir;
		m_server_inputer.value = DataMakerConf.Instance.m_server_dir;
//		m_server_inputer.value=DataMakerConf.Instance.m_server_url;
		SayInfo("目录重置为程序当前目录了。",Color.black);
	}
	public void OnBuild()
	{
		
		Build();
	}


	private SFTPHelper SFTPHelperInstance {
		get 
		{
			if(ftphelper == null) {
				#if UNITY_EDITOR
				ftphelper = new SFTPHelper("101.132.126.33","root","szmzbzbzlp@123");
				ftphelper.Connect();
				#endif
			}
			return ftphelper;
		}
	}
	void OnApplicationQuit() {
		if(SFTPHelperInstance.Connected)
			SFTPHelperInstance.Disconnect();
	}

	void Build()
	{

		m_repoter_root.SetActive(false);

		FileSelecter.GetSingle().Show(Maker.GetFileListDetail(DataMakerConf.Instance.m_excel_dir),BuildQueue);
	
	}
	private List<string> m_input_files_all ;
	void BuildQueue(List<string> _input_files_all = null)
	{
		
		if(_input_files_all!=null)
		{
			m_input_files_all = _input_files_all;
		}

		//if(workQuque.Count >0)
		//{
			//DataMakerConf.Instance.CurLocalName = workQuque.Dequeue();
			if(_input_files_all!=null)
			{
				RealBuild(m_input_files_all,m_csharp_tog.value);
			}
			else 
			{
				RealBuild(m_input_files_all,false);
			}
		//}
		m_input_files_all = _input_files_all;

	}
	void RealBuild(List<string> _input_files_all,bool genCShap)
	{
		


		//bool _youhua=true;//m_youhua_tog.value;
		//bool md5 = true;//m_md5_tog.value;



		if(!Directory.Exists(DataMakerConf.Instance.m_excel_dir))
		{
			SayInfo("数据目录貌似不存在？",Color.red);
			return;
		}

		if (!Directory.Exists(DataMakerConf.Instance.m_client_dir)) 
		{
			SayInfo("客户端目录不存在？", Color.red);
			return;
		}
		if (!Directory.Exists(DataMakerConf.Instance.m_server_dir)) 
		{
			SayInfo("服务器目录不存在？", Color.red);
			return;
			
		}
		EtuBuildResult _result=new EtuBuildResult();




		try
		{
			bool _debug_mode=false;
			if((m_debug_tog.gameObject.activeSelf)&&(m_debug_tog.value))
			{
				_debug_mode=true;
			}

			if(_input_files_all.Count>0)
			{

				Maker.Build(_input_files_all,false,genCShap,_debug_mode,_result);
			}
			else
			{
				m_repoter_root.SetActive(false);
				SayInfo("没有检查到任何数据修改，勾选完整选项可以强制制作",Color.black);
				return;
			}

		}
		catch(UnityException _ue)
		{
			Debug.Log(_ue.Message);
		}
		//_result.client_total_info = _result.client_total_info.Substring(0, _result.client_total_info.Length - 1);

		string _info = JsonMapper.Instance.ToJson(_result.json_str);
		File.WriteAllText(DataMakerConf.Instance.m_client_dir + "/ClientData.json",_info,Encoding.UTF8);


        //TODO 压缩包模式
		//byte[] compass_cdata = Ionic.Zlib.GZipStream.CompressString(_info);
		//File.WriteAllBytes(DataMakerConf.Instance.m_client_dir + "/ClientData.zip", compass_cdata);


		m_repoter_label.text="[000000]"+string.Format("久等了，总共生成了{0}份数据。",_result.done_list.Count);
		int _err_num=_result.error_file_list.Count+_result.error_sheet_list.Count;
		if(_err_num==0)
		{
			m_repoter_label.text+="真是厉害啊，没有发生任何错误。";
		}
		else
		{
			m_repoter_label.text+=string.Format("很遗憾，其中有{0}份数据生成失败了。",_err_num);
		}
		m_repoter_label.text+=("\n"+"下面是详细列表（太长的话可以拖动）"+"\n");
		m_repoter_label.text+="[-]";
		for(int i=0;i<_result.done_list.Count;++i)
		{
			m_repoter_label.text+=("[000000] "+_result.done_list[i]+" [-]");
			m_repoter_label.text+="\n";
		}
		m_repoter_label.text+="\n";

		for(int i=0;i<_result.error_file_list.Count;++i)
		{
			m_repoter_label.text+=("[ff0000] "+_result.error_file_list[i]+" All Fail!![-]");
			m_repoter_label.text+="\n";
		}
		m_repoter_label.text+="\n";

		for(int i=0;i<_result.error_sheet_list.Count;++i)
		{
			m_repoter_label.text+=("[ff0000] "+_result.error_sheet_list[i]+" ==> Fail[-]");
			m_repoter_label.text+="\n";
		} 
		m_repoter_label.text+="\n";

		for(int i=0;i<_result.skip_sheet_list.Count;++i)
		{
			m_repoter_label.text+=("[555555] "+_result.skip_sheet_list[i]+" ==> Skip[-]");
			m_repoter_label.text+="\n";
		}



		m_repoter_label.text+=("\n"+"开始上传静态数据到服务器，请稍后。");

//		if (!Directory.Exists(DataMakerConf.Instance.m_pak_path+"/StaticData/"))
//		{
//			Directory.CreateDirectory(DataMakerConf.Instance.m_pak_path+"/StaticData/");
//		}
			//			if(File.Exists(Application.dataPath+"/../StaticData/DataVer.txt"))
			//			{
			//				System.IO.StreamReader _reader=File.OpenText(Application.dataPath+"/../StaticData/DataVer.txt");
			//				string _ver_info_txt=_reader.ReadToEnd();
			//				_ver_info=NbaLitJson.JsonMapper.Instance.ToObject<StaticDataVesoinInfo>(_ver_info_txt);
			//				_reader.Close();
			//			}
//			if(_ver_info==null)
//			{
//		
//			}

			//client


			//if(!Directory.Exists(DataMakerConf.Instance.m_pak_path))
			//{
			//	Directory.CreateDirectory(DataMakerConf.Instance.m_pak_path);
			//}



			//_out_dir=Application.dataPath+"/ETU/Out/";

//



			//byte[] cdata= System.Text.Encoding.UTF8.GetBytes(_client_total_info);
			//byte[] compass_cdata=Ionic.Zlib.GZipStream.CompressString(_client_total_info);

			//GameVesoinData _ver_info=new GameVesoinData();

			
			//_ver_info.pfcode=new Dictionary<string, JDcodepf>();
//			foreach(JDPlatform plat in StaticDatar.GetSingle().m_Platform_list)
//			{
//				StaticDataVesoinUnitInfo _unit_info=new StaticDataVesoinUnitInfo();
//				_unit_info.head=plat.id;
//
//				_unit_info.hotver = int.Parse(m_hot_version_inputer.value);
//				_unit_info.ver=int.Parse(ServerVerLabel.value);
//
//				_unit_info.gver = GameCore.Config.VersionCode;
//				_unit_info.packver =  int.Parse(m_pack_version_inputer.value);
//				_ver_info.coll.Add(_unit_info);
//			}
//			_ver_info.pfcode = StaticDatar.GetSingle().m_codepf_dic.DataDic;
//			_ver_info.timezone = int.Parse(StaticDatar.GetSingle ().m_base_dic["timeZone"].val);
//			_ver_info.AndroidLowMem = int.Parse(StaticDatar.GetSingle ().m_base_dic["AndroidLowMem"].val);
			//_ver_info.upk_ver  = int.Parse(GameCore.Utility.Instance.ReadStringFromBytesFile("upk_ver"));

			

//			if(File.Exists(DataMakerConf.Instance.packagelist_md5_path))
//			{
//				string pack_md5 = File.ReadAllText(DataMakerConf.Instance.packagelist_md5_path);
//				if(!string.IsNullOrEmpty(pack_md5))_ver_info.pack_md5 = pack_md5;
//				else Debug.LogError(DataMakerConf.Instance.packagelist_md5_path+" is empty");
//			}
//			else
//			{
//				Debug.LogWarning("cant't find "+DataMakerConf.Instance.packagelist_md5_path);
//			}
//			Debug.Log("_ver_info.md5:"+_ver_info.md5);
//			foreach(StaticDataVesoinUnitInfo verInfo in _ver_info.coll)
//			{	
//				m_sdata= System.Text.Encoding.UTF8.GetBytes(_server_total_info);
//			}
//			foreach(StaticDataVesoinUnitInfo verInfo in _ver_info.coll)
//			{
//				verInfo.size=compass_cdata.Length/1024;
//			}


			//string game_ver = GameInfo.Version.ToString();
			//int static_data_size = compass_cdata.Length/1024;

			//_ver_info.data_ver = int.Parse(ServerVerLabel.value);
			//_ver_info.data_md5 = Util.Instance.SimpleMD5CryptoServiceProvider(_client_total_info);
			//_ver_info.hot_ver =  int.Parse(m_hot_version_inputer.value);
			//if(File.Exists(DataMakerConf.Instance.hot_md5_path))
			//{
			//	string hot_md5 = File.ReadAllText(DataMakerConf.Instance.hot_md5_path);
			//	if(!string.IsNullOrEmpty(hot_md5))_ver_info.hot_md5 = hot_md5;
			//	else Debug.LogError(DataMakerConf.Instance.hot_md5_path+" is empty");
			//}
			//else
			//{
			//	Debug.LogWarning("cant't find "+DataMakerConf.Instance.hot_md5_path);
			//}
			//_ver_info.pack_ver =  int.Parse(m_pack_version_inputer.value);
			//if(File.Exists(DataMakerConf.Instance.packagelist_md5_path))
			//{
			//	string pack_md5 = File.ReadAllText(DataMakerConf.Instance.packagelist_md5_path);
			//	if(!string.IsNullOrEmpty(pack_md5))_ver_info.pack_md5 = pack_md5;
			//	else Debug.LogError(DataMakerConf.Instance.packagelist_md5_path+" is empty");
			//}
			//else
			//{
			//	Debug.LogWarning("cant't find "+DataMakerConf.Instance.packagelist_md5_path);
			//}
			//_ver_info.data_size = static_data_size;
			//_ver_info.branches=new List<BranchData>();
			
			//TODO 写到本地
			
			//if(!string.IsNullOrEmpty(ServerVerLabel.value))m_data_ver = ServerVerLabel.value;
			//if(!string.IsNullOrEmpty(m_game_version_inputer.value))game_ver = m_game_version_inputer.value;

			//File.WriteAllText( DataMakerConf.Instance.m_pak_path+"DataVer"+game_ver+".txt",JsonMapper.Instance.ToJson(_ver_info));
			//File.WriteAllBytes( DataMakerConf.Instance.m_pak_path+"StaticData"+"_"+DataMakerConf.Instance.CurLocalName+"_"+m_data_ver+".gz",compass_cdata);
			//File.WriteAllBytes( DataMakerConf.Instance.m_pak_path+"StaticData"+"_"+DataMakerConf.Instance.CurLocalName+"_"+_ver_info.coll[0].ver+"_Sever.gz",m_sdata);
			//File.WriteAllText( DataMakerConf.Instance.m_pak_path+"MaxVer.txt",JsonMapper.Instance.ToJson(max_ver));




			//m_repoter_label.text+="\n";
			//m_repoter_label.text+=DataMakerConf.Instance.CurLocalName+"静态数据打包完毕，大小为:+"+static_data_size+"k,版本号为[ff0000] "+m_data_ver+"[-]";
			//m_repoter_label.text+="\n";

//		string[] maskArray= mask.Split(',');
//		List<string> maskList=new List<string>();
//		for(int i=0; i<maskArray.Length; i++)
//		{
//			maskList.Add(maskArray[i]);
//		}
//		Debug.LogError("_net:"+_net);
//		if(_net)
//		{

//			//if(!maskList.Contains(DataVer))
//			//{
//			//	Debug.LogError("准备上传数据队列");
//				downLoadQuque.Enqueue(delegate() {
//					m_repoter_label.text+="\n";
//					m_repoter_label.text+=DataMakerConf.Instance.CurLocalName+"数据开始上传，请耐心等候";
//					m_repoter_label.text+="\n";
//					UpLoadData("StaticData"+"_"+DataMakerConf.Instance.CurLocalName+"_"+m_data_ver+".gz");
//				});
//				downLoadQuque.Enqueue(delegate() {
//					m_repoter_label.text+="\n";
//					m_repoter_label.text+=DataMakerConf.Instance.CurLocalName+"客户端数据上传完成！";
//					m_repoter_label.text+="\n";
//					UpLoadData("DataVer"+game_ver+".txt");
//				});
//				downLoadQuque.Enqueue(delegate() {
//					m_repoter_label.text+="\n";
//					m_repoter_label.text+=DataMakerConf.Instance.CurLocalName+"DataVer上传完成！";
//					m_repoter_label.text+="\n";
//					UpLoadData("MaxVer.txt");
//				});

//				m_max_count = downLoadQuque.Count;
//				m_upload_bar.gameObject.SetActive(true);
//				if(downLoadQuque.Count >0)
//				{
//					Action _action = downLoadQuque.Dequeue();
//					_action();
//				}
////			}
////			else
////			{
////				m_repoter_label.text+="\n";
////				m_repoter_label.text+="QA专属版本号!不能做远端数据，请联系俊男！";
////				m_repoter_label.text+="\n";
////				Debug.LogError("QA专属版本号!不能做远端数据，请联系俊男！");
////			}
		//}


		m_repoter_root.SetActive(true);

	}
	public void OnSaySomething()
	{
		int _r= UnityEngine.Random.Range(0,info_coll.Length);
		if(_r!=m_current_chat_index)
		{
			m_current_chat_index=_r;
		}else
		{
			m_current_chat_index++;
			if(m_current_chat_index>=info_coll.Length)
			{
				m_current_chat_index=0;
			}
		}
		SayInfo(info_coll[m_current_chat_index],Color.black);
	}
	private void SayInfo(string _str,Color _color,bool exten=false)
	{
		//m_info_label.text=_str;
		if(exten)
		{
			m_current_str+=_str;
		}
		else
		{
			m_current_str=_str;
		}
		m_info_label.gameObject.SetActive(true);
		m_show_time=m_base_show_time+m_unit_show_time*_str.Length;
		m_char_index=1;
		m_info_label.text=m_current_str.Substring(0,m_char_index);
		m_char_fly_time=m_fly_speed;
		m_info_label.color=_color;
		m_repoter_root.SetActive(false);
	}

	public void OnExcelPath()
	{
		if(Application.isEditor)
		{
			#if UNITY_EDITOR
			string _data=EditorUtility.OpenFolderPanel("Load Excel Directory", DataMakerConf.Instance.m_excel_dir, "");
			if(!string.IsNullOrEmpty(_data))
			{
				DataMakerConf.Instance.m_excel_dir = _data;
				m_data_inputer.value=DataMakerConf.Instance.m_excel_dir;
			}
			#endif	
		}

	}

	public void OnOutPath()
    {
        if (Application.isEditor)
        {
#if UNITY_EDITOR
			string _data = EditorUtility.OpenFolderPanel("Load Client Directory", DataMakerConf.Instance.m_client_dir, "");
            if (!string.IsNullOrEmpty(_data))
            {
				DataMakerConf.Instance.m_client_dir = _data;
				m_out_inputer.value = DataMakerConf.Instance.m_client_dir;
            }
#endif
        }

    }

	public void OnSerPath()
    {
        if (Application.isEditor)
        {
#if UNITY_EDITOR
			string _data = EditorUtility.OpenFolderPanel("Load Server Directory", DataMakerConf.Instance.m_server_dir, "");
            if (!string.IsNullOrEmpty(_data))
            {
				DataMakerConf.Instance.m_server_dir = _data;
				m_server_inputer.value = DataMakerConf.Instance.m_server_dir;
            }
#endif
        }

    }



	private DataMaker m_maker;

	public UILabel m_data_label;
	public UILabel m_out_label;
	public UILabel m_info_label;
	public UILabel m_server_label;

	public UIInput m_data_inputer;
	public UIInput m_out_inputer;
	public UIInput m_server_inputer;
	private string[] info_coll=new string[6]{"需要一杯咖啡么？","程序员真是一种艰苦而荣耀的职业啊","字符'`'和 '｜'是默认分隔符，全角半角都不能在数据中使用哦。","光荣与梦想，雷电与宝剑。","十年生死两茫茫，写程序，到天亮。","抹茶拿铁有一股青团的味道，啊~，好棒。"};
	public UIInput m_game_version_inputer;
	public UIInput m_hot_version_inputer;
	public UIInput m_pack_version_inputer;
	int m_current_chat_index=-1;

	float m_show_time=-1.0f;
	public float m_unit_show_time=1.0f;
	public float m_base_show_time=2.0f;
	public float m_fly_speed=0.1f;

	int m_char_index;
	float m_char_fly_time;
	string m_current_str;

	public GameObject[] EditorOnlyList;

	public UILabel m_repoter_label;
	public GameObject m_repoter_root;

	public UIToggle m_csharp_tog;
	public UIToggle m_debug_tog;
	public UIToggle m_net_tog;
	public List<UIToggle> languageToggle;
	private Queue<Action> downLoadQuque = new Queue<Action>();
	public UISlider m_upload_bar;

	float m_max_pross;
	float m_cur_pross=0.0f;
	float m_pross_speed=1f;
	int m_max_count;
	int curUpLoadIndex = 0;

	int m_net_ver=0;

	byte[] m_sdata;

	public UIInput ServerVerLabel;


}
