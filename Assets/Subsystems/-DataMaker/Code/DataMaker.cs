using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System;
using GameCore;
using Excel;
using System.Data;
using CustomLitJson;
#if UNITY_EDITOR
using UnityEditor;
#endif
public  class DmHelper
{
	public static List<RjData> DataBankList=new List<RjData>();
	public static List<string> DataNameBankList=new List<string>();
	public static List<string> DataNameGlobaList=new List<string>();
	public static int MagicNum=0;
}





public class DataMaker
{


	enum JsonDataType
	{
		NORMAL,
		ARRAY,
		KEY_VALUE,
		NEW_KEY_VALUE,
	}


	enum DataType
	{
		NULL,
		STRING,
		INT,
		FLOAT,
	}

   
	public static int _FileSeLineCompass(FileSeLineInfo _l,FileSeLineInfo _r)
	{
		if(_l.tick>_r.tick)
		{
			return -1;
		}
		else if(_l.tick>_r.tick)
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}
	
	public DataMaker ()
	{



	}

	public List<string> GetDitryFileList()
	{
//		Debug.LogError("GetDitryFileList");
		List<string> NeedRefreshList=new List<string>();

//		string _modif_str="";
		string[] _input_files=Directory.GetFiles(DataMakerConf.Instance.m_excel_dir,"*.xlsx");
		//string[] _input_files=Directory.GetFiles(m_data_path);
		foreach(string _if in _input_files)
		{
			if(_if.Contains("~"))
			{
				continue;
			}
			if(_if.Contains("机器人"))
			{
				continue;
			}
			int _lindex=_if.LastIndexOf('/');
			string _file_name=_if.Substring(_lindex+1);
			//Debug.Log(_file_name);
			//Debug.Log(File.GetLastWriteTime(_if));

			long _tick=long.Parse(PlayerPrefs.GetString(_file_name,"0"));
		

			if(File.GetLastWriteTime(_if).Ticks!=_tick)
			{
				Debug.Log("File.GetLastWriteTime(_if).Ticks:"+File.GetLastWriteTime(_if).Ticks+"!=_tick:"+_tick);
				//need refresh
				NeedRefreshList.Add(_if);
			}
		}
		return NeedRefreshList;
	}
	public List<FileSeLineInfo> GetFileListDetail(string _data_path)
	{
//		Debug.LogError("_data_path:"+_data_path);
		List<FileSeLineInfo> NeedRefreshList=new List<FileSeLineInfo>();

//		string _modif_str="";
		string[] _input_files=Directory.GetFiles(_data_path,"*.xlsx");
		//string[] _input_files=Directory.GetFiles(m_data_path);
		foreach(string _if in _input_files)
		{
			if(_if.Contains("~"))
			{
				continue;
			}
			FileSeLineInfo _file=new FileSeLineInfo();
			_file.lname=_if;
			int _lindex=_if.LastIndexOf('/');
			string _file_name=_if.Substring(_lindex+1);
			_file.name=_file_name;
			_file.time=File.GetLastWriteTime(_if).ToString();
			FileInfo _fi=new FileInfo(_if);
			_file.size=(_fi.Length/(1024.0f*1024.0f));
			long _tick=long.Parse(PlayerPrefs.GetString(_file_name,"0"));
			_file.tick=File.GetLastWriteTime(_if).Ticks;
			if(File.GetLastWriteTime(_if).Ticks!=_tick)
			{
				_file.ditry=true;
			}
			NeedRefreshList.Add(_file);
		}
		NeedRefreshList.Sort(_FileSeLineCompass);
		return NeedRefreshList;
	}

	public void Build (List<string> _input_files_all,bool quick ,bool _maker_csharp,bool debug,EtuBuildResult _result=null,string _total_info=null)
	{
//		if(_youhua)
//		{
//			FileFilter();
//		}

//		
//		if(!string.IsNullOrEmpty(_data))
//		{
//			m_data_path=_data;
//		}
//		if(!string.IsNullOrEmpty(_client))
//		{
//		 	m_client_path =_client;
//		}
//
//		if(_maker_csharp)
//		{
//			if(!string.IsNullOrEmpty(_csharp))
//			{
//				m_csharp_path =_csharp;
//			}
//		}
//		else
//		{
//			m_csharp_path=null;
//		}
//
//
//		if(!string.IsNullOrEmpty(_server))
//		{
//			m_server_path =_server;
//		}






//		string _ver_str="";
	


		DmHelper.MagicNum=1;

		DmHelper.DataNameGlobaList.Clear();

		foreach(string _if in _input_files_all)
		{

			if(_if.Contains("~"))
			{
				continue;
			}

			int _index=_if.LastIndexOf('/');
			string _excel_name=_if.Substring(_index+1,_if.Length-_index-6);
			if(debug)
			{

				if(TryParse(_if,_excel_name,quick,_result))
				{
					continue;
				}
			}
			else
			{
				try
				{

					if(TryParse(_if,_excel_name,quick,_result))
					{
						continue;
					}
				}
				catch(Exception e)
				{
					Debug.LogError("error:"+e.Message);
				}
			}


			int _lindex=_if.LastIndexOf('/');
			string _file_name=_if.Substring(_lindex+1);
			PlayerPrefs.SetString(_file_name,File.GetLastWriteTime(_if).Ticks.ToString());
		}

		PlayerPrefs.Save();





		#if UNITY_EDITOR
		if(Application.isEditor)
		{
			UnityEditor.AssetDatabase.Refresh();
		}
		#endif

	}

	bool TryParse(string _if,string _excel_name,bool quick,EtuBuildResult _result)
	{
		

		#if !RELEASE
		DataSet _data_set = ExcelUtility (_if);
//		Debug.Log("_excel_name:"+_excel_name);
		ConvertToJsonNew(_excel_name,quick,_data_set,_result);
		#endif
		return false;
	}
	#if !RELEASE
	
	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="excelFile">Excel file.</param>
	/// 
	DataSet ExcelUtility (string excelFile)
	{
		if(!File.Exists(excelFile))
		{
			Debug.LogError("can't find excelFile"+excelFile);
		}
		FileStream mStream = File.Open (excelFile, FileMode.Open, FileAccess.Read);
		IExcelDataReader mExcelReader = ExcelReaderFactory.CreateOpenXmlReader(mStream);
		DataSet result = null;
//		Debug.LogError("excelFile: "+mExcelReader==null);
//		do{
//			// sheet name
//			//Debug.Log(mExcelReader.Name);
//			while (mExcelReader.Read()) {
//				for (int i = 0; i < mExcelReader.FieldCount; i++) {
//					string value = mExcelReader.IsDBNull(i) ? "" : mExcelReader.GetString(i);
//					Debug.Log(value);
//				}
//			}
//		}while(mExcelReader.NextResult());

	
//			try
//			{
//
//				if (excelFile.Equals("xls"))
//				{
//					//1. Reading from a binary Excel file ('97-2003 format; *.xls)
//					mExcelReader = ExcelReaderFactory.CreateBinaryReader(mStream);
//				}
//				else
//				{
//					//2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
//					mExcelReader = ExcelReaderFactory.CreateOpenXmlReader(mStream);
//					// excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
//				}
//
//				mExcelReader.IsFirstRowAsColumnNames = false;
//				result = mExcelReader.AsDataSet();
//			}
//			catch (Exception ex)
//			{
//				throw ex;
//			}
//			if(result == null)
//			{
//				Debug.LogError("exel convert to data set error!!!");
//			}
		//IExcelDataReader mExcelReader = ExcelReaderFactory.CreateOpenXmlReader (mStream);
//		IExcelDataReader mExcelReader = ExcelReaderFactory.CreateBinaryReader(mStream);
//
//
//		mExcelReader.IsFirstRowAsColumnNames = true;
//		Debug.LogError(mExcelReader.Name);
//		Debug.LogError(mExcelReader.AsDataSet ().DataSetName);
		return  mExcelReader.AsDataSet();
	}

	public void ConvertToJsonNew(string _excel_name,bool _quick, DataSet mResultSet,EtuBuildResult _result=null)
	{
//		Debug.LogError("mResultSet!=null->"+mResultSet!=null);
//		Debug.LogError("_result!=null->"+_result!=null);
//		Debug.LogError("mResultSet!=null->"+mResultSet.Tables!=null);
//

		if (mResultSet ==null || mResultSet.Tables == null || mResultSet.Tables.Count < 1)
		{
			return;
		}
			




		foreach(DataTable mSheet in mResultSet.Tables)
		{

	
			if (mSheet.Rows.Count < mc_row_min_num)
			{
				if(_result!=null)
				{
					_result.skip_sheet_list.Add(_excel_name+"."+mSheet.TableName);
				}
				continue;
			}

		
			string _file_name=mSheet.Rows[0][0].ToString();	

			if(string.IsNullOrEmpty(_file_name))
			{
				if(_result!=null)
				{
					_result.skip_sheet_list.Add(_excel_name+"."+mSheet.TableName);
				}
				continue;
			}
			if(mSheet.Columns.Count>2)
			{
				if(!string.IsNullOrEmpty(mSheet.Rows[0][2].ToString()))
				{
					if(_result!=null)
					{
						_result.skip_sheet_list.Add(_excel_name+"."+mSheet.TableName);
					}
					continue;
				}
			}
		
			DmHelper.DataBankList.Clear();
			DmHelper.DataNameBankList.Clear();
			string _csharp_info=null;
			JsonDataType m_json_type=JsonDataType.NORMAL;

			if(!string.IsNullOrEmpty(mSheet.Rows[0][1].ToString()))
			{
				if(mSheet.Rows[0][1].ToString()=="kv")
				{
					m_json_type=JsonDataType.KEY_VALUE;
				}
				else if(mSheet.Rows[0][1].ToString()=="array")
				{
					m_json_type=JsonDataType.ARRAY;
				}
				else if(mSheet.Rows[0][1].ToString()=="nkv")
				{
					m_json_type=JsonDataType.NEW_KEY_VALUE;
				}
				else
				{
					m_json_type=JsonDataType.NORMAL;
				}
			}
			List<string> keys = new List<string>();
			for(int i=mSheet.Columns.Count-1; i >=0 ; i--)
			{
				string key = mSheet.Rows[mc_key_row][i].ToString();
				keys.Add(key);
			}

//			string tag = "_"+DataMakerConf.Instance.CurLocalName;
//			//Debug.Log("SheetName:"+mSheet.TableName+" colums count:"+mSheet.Columns.Count);
//			for(int i=mSheet.Columns.Count-1; i >=0 ; i--)
//			{
//				string _type = mSheet.Rows[mc_key_type_row][i].ToString();
			
//				if(string.IsNullOrEmpty(_type))
//				{
////					Debug.LogError("empty head");
//					mSheet.Columns.RemoveAt(i);
//					continue;
//				}
//				else
//				{
////					Debug.Log("type:"+_type);
//				}

//				string key = mSheet.Rows[mc_key_row][i].ToString();
//				if(string.IsNullOrEmpty(key))continue;
//				if( key.EndsWith("_cn")|| 
//					key.EndsWith("_tw")||
//					key.EndsWith("_en")||
//					key.EndsWith("_eu"))
//				{

//					if(key.EndsWith(tag))
//					{
//						mSheet.Rows[mc_key_row][i] = key.Substring(0,key.Length - tag.Length);
//					}
////					else if(tag=="_eu" && key.EndsWith("_en") && !keys.Contains(key.Replace("_en","_eu")))
////					{
////						mSheet.Rows[mc_key_row][i] = key.Substring(0,key.Length - "_en".Length);
////					}
			//		else
			//		{
			//			mSheet.Columns.RemoveAt(i);
			//		}
			//	}
			//}
//			Debug.Log("SheetName:"+mSheet.TableName+" colums count after filter:"+mSheet.Columns.Count);
			int rowCount = mSheet.Rows.Count;
			int colCount = mSheet.Columns.Count;
			
			
			
			int _real_num=0;
			string _info="";
			string _sinfo="";
			string m_id_key_type=mSheet.Rows[mc_key_type_row][0].ToString();


			List<string> _id_list=new List<string>(); 
			Dictionary<string,List<string>> _dic=new Dictionary<string, List<string>>();
			try
			{
				for (int i = mc_value_begin_row; i < rowCount; i++)
				{	
					if(string.IsNullOrEmpty(mSheet.Rows[i][0].ToString()))
					{
						continue;
					}
					
					if(!_id_list.Contains(mSheet.Rows[i][0].ToString()))
					{
						_id_list.Add(mSheet.Rows[i][0].ToString());
					}
				}
				
			




				for (int i = mc_value_begin_row; i < rowCount; i++)
				{	
					if(string.IsNullOrEmpty(mSheet.Rows[i][0].ToString()))
					{
						continue;
					}



					
					
					
					
					RjData _data=new RjData(null);
					Parse(_data,mSheet,mSheet.Rows[i],0,mSheet.Rows[mc_key_row][0].ToString(),colCount);


					switch(m_json_type)
					{
						case JsonDataType.ARRAY:
						{
							string _dd=_data.ToJson();
							int _bindex=_dd.IndexOf("\"id\":");
							int _eindex=_dd.IndexOf(",");
							//Debug.Log(_dd);
							//Debug.Log(_bindex+" "+_eindex);
							string _temp_id=_dd.Substring(_bindex+5,_eindex-_bindex-5);
							if(!_dic.ContainsKey(_temp_id))
							{
								List<string> _ttt=new List<string>();
								_dic.Add(_temp_id,_ttt);
							}
							_dic[_temp_id].Add("{"+_dd.Substring(_eindex+1,_dd.Length-_eindex-1));
						}
						break;
					case JsonDataType.NORMAL:
					default:
						{

							
							
							string _dd=_data.ToJson();

							int _bindex=_dd.IndexOf("\"id\":");
							int _eindex=_dd.IndexOf(",");
							string _id=_dd.Substring(_bindex+5,_eindex-_bindex-5);
//							Debug.Log(_dd);
							//Debug.Log(_bindex+" "+_eindex);
							_info+=_id.Replace("\"","")+"`"+_dd;
							_info+="|";//TODO zhaolei

							if(!_quick)
							{
								//string _id=_dd.Substring(_bindex+5,_eindex-_bindex-5);
								if(!_id.Contains("\""))
								{
									_sinfo+="\""+_id+"\":"+_dd;
								}
								else
								{
									_sinfo+=_id+":"+_dd;
								}
								_sinfo+=",";
							}
						}
						break;
						case JsonDataType.NEW_KEY_VALUE:
						{

								_info+=_data.ToKeyValue().Replace("=","`");
								_info+="|";//TODO zhaolei

								if(!_quick)
								{
									string _dd=_data.ToJson();
									int _bindex=_dd.IndexOf("\"id\":");
									int _eindex=_dd.IndexOf(",");
									string _id=_dd.Substring(_bindex+5,_eindex-_bindex-5);
									if(!_id.Contains("\""))
									{
										_sinfo+="\""+_id+"\":"+_dd;
									}
									else
									{
										_sinfo+=_id+":"+_dd;
									}
									_sinfo+=",";
								}
						}
						break;
						case JsonDataType.KEY_VALUE:
						{
							string _ii=_data.ToJson();
							int _bindex=_ii.IndexOf("\"id\":");
							int _eindex=_ii.IndexOf(",");
							string _id=_ii.Substring(_bindex+5,_eindex-_bindex-5);
							_info+=_id.Replace("\"","")+"`"+_ii;
							_info+="|";

							if(!_quick)
							{
								_sinfo+=_data.ToKeyValueString();
								_sinfo+=",";
							}
						}
						break;
					}
					_real_num++;
				}
				if(_result!=null)
				{
					_result.done_list.Add(_excel_name+"."+mSheet.TableName+"==>"+_file_name+"   success!!!");
				}
			}

			catch
			{
				if(_result!=null)
				{
					_result.error_sheet_list.Add(_excel_name+"."+mSheet.TableName);
				}
				continue;
			}


			if(m_json_type==JsonDataType.ARRAY)
			{
				foreach(KeyValuePair<string,List<string>> _kv in _dic)
				{
					string _tinfo="{\"id\":"+_kv.Key+",\"Coll\":[";
					foreach(string _kk in _kv.Value)
					{
						_tinfo+=_kk;
						_tinfo+=",";
					}
					_tinfo=_tinfo.Remove(_tinfo.Length-1);
					_tinfo+="]}";

					string _dd=_tinfo;
					int _bindex=_dd.IndexOf("\"id\":");
					int _eindex=_dd.IndexOf(",");
					string _id = _dd.Substring(_bindex+5,_eindex-_bindex-5);
					_info+=_id.Replace("\"","")+"`"+_dd;
					_info+="|";
					if(!_quick)
					{
						_sinfo+="\""+_id+"\":"+_dd;
						_sinfo+=",";
					}
				}
			}

			_info=_info.Remove(_info.Length-1);
			if(!_quick)
			{
				_sinfo=_sinfo.Remove(_sinfo.Length-1);
				_sinfo="{"+_sinfo+"}";
			}
		

			//client
			if(_result!=null)
			{
				_info=_info.Replace('\n',' ');
			}


			//----------youhua--------------//
			//_info=InfoTail(_file_name,_info);

			_result.json_str[_file_name] = JsonMapper.Instance.ToObject(_sinfo);
            

			File.WriteAllText(DataMakerConf.Instance.m_server_dir + _file_name + ".json", _sinfo, Encoding.UTF8);
         
		}



	}
	
	public static void Parse(RjElement _parent,DataTable _sheet,DataRow _row,int _index,string _key,int _max_num,bool _need_take_value=true)
	{
		
		if(string.IsNullOrEmpty(_key)&&(_parent.GetClassType()!=RjClassType.COLL))
		{
			if(_index<_max_num-1)
			{
				Parse(_parent,_sheet,_row,_index+1,_sheet.Rows[mc_key_row][_index+1].ToString(),_max_num);
			}
			return;
		}
		// filter " and :
		_key=_key.Replace("\"","");
		_key=_key.Replace(":","");
		
		for(int i=0;i<_key.Length;++i)
		{
			if(_key[i]=='[')
			{
				//before
				string _key_before=_key.Substring(0,i);
				//after
				string _key_after=_key.Substring(i+1,_key.Length-i-1);
				
				RjColl _coll=new RjColl(_key_before);
				_coll.SetParent(_parent);
				_parent.AddElement(_coll);
				if(string.IsNullOrEmpty(_key_after))
				{
					//must add the value
					AddElement(_coll,_sheet,_row,_index,null);
					Parse(_coll,_sheet,_row,_index+1,_sheet.Rows[mc_key_row][_index+1].ToString(),_max_num);
				}
				else
				{
					Parse(_coll,_sheet,_row,_index,_key_after,_max_num);
				}
				return;
			}else if(_key[i]=='{')
			{
				string[] _kks=_key.Split('{');
				RjData _coll=new RjData(_kks[0]);
				_coll.SetParent(_parent);
				_parent.AddElement(_coll);
				Parse(_coll,_sheet,_row,_index,_kks[1],_max_num);
				return; 
			}
			else if(_key[i]==']')
			{
				//string _raw_key=_sheet.Rows[mc_key_row][_index];
				
				if(_need_take_value)
				{
					AddElement(_parent,_sheet,_row,_index,null);
				}
				_parent=_parent.GetPerent();
				if(_key.Length==1)
				{
					if(_index<_max_num-1)
					{
						Parse(_parent,_sheet,_row,_index+1,_sheet.Rows[mc_key_row][_index+1].ToString(),_max_num);
					}
				}
				else
				{
					string _key_after=_key.Substring(i+1,_key.Length-i-1);
					Parse(_parent,_sheet,_row,_index,_key_after,_max_num);
				}
				return;
			}else if(_key[i]=='}')
			{
				string _key_before=_key.Substring(0,i);
				string _key_after=_key.Substring(i+1,_key.Length-i-1);
				//				Debug.Log("before:"+_key_before+" after:"+_key_after);
				bool _need_take=true;
				if(!string.IsNullOrEmpty(_key_before))
				{
					AddElement(_parent,_sheet,_row,_index,_key_before);
					_need_take=false;
				}
				_parent=_parent.GetPerent();
				if(string.IsNullOrEmpty(_key_after))
				{
					if(_index<_max_num-1)
					{
						Parse(_parent,_sheet,_row,_index+1,_sheet.Rows[mc_key_row][_index+1].ToString(),_max_num);
					}
				}
				else
				{
					Parse(_parent,_sheet,_row,_index,_key_after,_max_num,_need_take);
				}
				return;
			}
		}
		
		AddElement(_parent,_sheet,_row,_index,_key);
		
		
		if(_index<_max_num-1)
		{
			Parse(_parent,_sheet,_row,_index+1,_sheet.Rows[mc_key_row][_index+1].ToString(),_max_num);
		}
	}
	public static void AddElement(RjElement _parent,DataTable _sheet,DataRow _row,int _index,string _key)
	{
		string _type_info=_sheet.Rows[mc_key_type_row] [_index].ToString();
		RjValueType _value_type=RjValueType.INT;
		if(_type_info=="int")
		{
			_value_type=RjValueType.INT;
		}else if(_type_info=="float")
		{
			_value_type=RjValueType.FLOAT;
		}
		else
		{
			_value_type=RjValueType.STRING;
		}
		_parent.AddElement(new RjValue(_key,_row[_index],_value_type,_sheet.Rows[mc_des_type_row][_index].ToString()));
	}


	#endif
	void FileFilter()
	{
		
	}









	static int mc_mskill_id_begin=80000;
	
	const int mc_row_min_num=5;
	const int mc_key_row=2;
	const int mc_key_type_row=1;
	const int mc_value_begin_row=4;
	const int mc_des_type_row=3;
	
//	string m_data_path = "";
////	string m_input_save_key = "ExcelPath";
//	string _out_dir=Application.dataPath+"/ETU/Out/";
//	string m_client_path 
//	{
//		get
//		{
//			return _out_dir+"Client_"+local+"/";
//		}
//	}
//	string m_output_save_key = "JsonPath";
	
//	string m_csharp_path = "";
//	string m_csharp_save_key = "C#Path";


//	string m_code_frame_path="";
//	string m_code_wrap_path="";
//	string m_server_path = "";
	
	TextAsset m_text_asset;
//
//	string m_data_key
//	{
//		get
//		{
//			return "EtuData_"+Application.dataPath;
//		}
//	}
//	string m_csharp_key
//	{
//		get
//		{
//			return "EtuCsharp_"+Application.dataPath;
//		}
//	}
//	string m_server_key
//	{
//		get
//		{
//			return "EtuServer_"+Application.dataPath;
//		}
//	}

	List<int> m_unused_skill_list=new List<int>();

	public void TryRefresh()
	{
//		Debug.LogError("TryRefresh");
		#if UNITY_EDITOR
		if(string.IsNullOrEmpty(DataMakerConf.Instance.m_excel_dir))
		{
			if(Application.isEditor)
			{

				string _data=EditorUtility.OpenFolderPanel("Load Data Directory", DataMakerConf.Instance.m_excel_dir, "");
				if(!string.IsNullOrEmpty(_data))
				{
					DataMakerConf.Instance.m_excel_dir = _data;
				}
			}
		}

		List<string> NeedRefreshList=GetDitryFileList();


		if(NeedRefreshList.Count>0)
		{
			EtuBuildResult _rbr=new EtuBuildResult();

			Build(NeedRefreshList,true,false,false,_rbr);

			Debug.LogWarning("AutoRefresh----Suc:"+_rbr.done_list.Count+",FailSheet:"+_rbr.error_sheet_list.Count+",FailExcel:"+_rbr.error_file_list.Count+",Skip:"+_rbr.skip_sheet_list.Count);
			//		Debug.Log("=========== DataRefresh ===========");
			//			string _info="File Has Updated:";
			foreach(string _if in NeedRefreshList)
			{
				int _lindex=_if.LastIndexOf('/');
				string _file_name=_if.Substring(_lindex+1);
				Debug.Log("RefreshFilie:"+_file_name);
				//				PlayerPrefs.SetString(_file_name,File.GetLastWriteTime(_if).Ticks.ToString());
				//				_info+=_file_name;
				//				_info+=",";
			}
			//GameCore.UIHandler.Instance.ShowDialog(GameCore.DialogStyle.DS_ConfirmOnly,"",_info);
			PlayerPrefs.Save();
		}
		#endif
	
	}
}
