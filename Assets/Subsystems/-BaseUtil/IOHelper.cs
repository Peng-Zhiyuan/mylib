using UnityEngine;
using GameCore;
using System;
using System.Security.Cryptography;
using System.Text;
using  System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

public class IOHelper:Single<IOHelper>  {
		//public static IOHelper Instance = new IOHelper();
		public  void WriteStringToBytesFile(string name, string privateKey)
		{
			string fileName ="Resources/LocalConfig/"+name+".bytes";
			byte[] bytes = Encoding.UTF8.GetBytes(privateKey); 
			File.WriteAllBytes(UnityEngine.Application.dataPath + "/" + fileName, bytes);

		}
		//
		public void WriteBytesFile(string name,byte[] bytes)
		{
			string fileName ="Resources/LocalConfig/"+name+".bytes";
			//string privateKey = "37eefa6a14d4f3071b1";
			//Debug.Log("input:"+BitConverter.ToString(bytes).Replace("-","").ToLower());
			File.WriteAllBytes(UnityEngine.Application.dataPath + "/" + fileName, bytes);
			//UnityEditor.AssetDatabase.ImportAsset("Assets/Resources/Config/"+name);


		}
		public  void WriteStringToETUFile(string name, string privateKey)
		{
			string fileName ="ETU/CodeWrap/"+name+".bytes";
			byte[] bytes = Encoding.UTF8.GetBytes(privateKey); 
			if(!Directory.Exists(UnityEngine.Application.dataPath+"/ETU/CodeWrap"))Directory.CreateDirectory(UnityEngine.Application.dataPath+"/ETU/CodeWrap");
			File.WriteAllBytes(UnityEngine.Application.dataPath + "/" + fileName, bytes);

		}
		public  void WriteString(string name, string content)
		{
			string fileName ="Resources/LocalConfig/"+name+".json";
			byte[] bytes = Encoding.UTF8.GetBytes(content); 
			File.WriteAllBytes(UnityEngine.Application.dataPath + "/" + fileName, bytes);

		}


		static public bool WriteTexture(byte[] bytes,string filePath)
		{
			string fileName = Path.GetFileName(filePath);
			string directoryName = Path.GetDirectoryName(filePath);
			if(!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			string extension = Path.GetExtension(filePath);
			using (FileStream fs = File.OpenWrite (filePath))
			{
				fs.Write (bytes, 0, bytes.Length);
				fs.Close();
				fs.Dispose();
			}
			return true;

		}


		//
		//		public bool CheckKey(string data, string key)
		//		{
		//			string md5 = NetworkFrame.NetworkSign.Instance.SimpleMD5CryptoServiceProvider(data);
		//			if(key != md5)
		//			{
		//				//				Debug.LogError("ClearLocalData");
		//				Config.ClearOldLocalData();
		//				ResourceLoad.AssetHandler.Instance.Release(true);
		//				//
		//				UIHandler.Instance.ShowDialog(DialogStyle.DS_ConfirmOnly,"",Localization.Get("staticDataCheckError"),delegate(string s) {
		//					GameLogical.Instance.Relogin();
		//				});	
		//				return false;
		//			}
		//			return true;
		//		}

		public byte[] ReadBytesFile(string name)
		{
			string fileName ="LocalConfig/"+name;
			TextAsset asset = Resources.Load(fileName) as TextAsset;
			//			Stream s = new MemoryStream(asset.bytes);
			//			BinaryReader br = new BinaryReader(s);
			//Debug.Log("output:"+BitConverter.ToString(asset.bytes).Replace("-","").ToLower());
			//			Debug.Log("result:"+Encoding.UTF8.GetString(asset.bytes));
			return asset.bytes;


		}


		public  string ReadStringFromBytesFile(string name)
		{
			string fileName ="LocalConfig/"+name;
			TextAsset asset = Resources.Load(fileName) as TextAsset;
			//			Stream s = new MemoryStream(asset.bytes);
			//			BinaryReader br = new BinaryReader(s);
			//Debug.Log("output:"+BitConverter.ToString(asset.bytes).Replace("-","").ToLower());
			Debug.Log("result:"+Encoding.UTF8.GetString(asset.bytes));
			return Encoding.UTF8.GetString(asset.bytes);


		}

	}
