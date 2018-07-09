using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System;
namespace GameCore
{
	public class ExportData : MonoBehaviour {

		[MenuItem ("Export/ExportHotfixGZip")]
		static public void ExportHotfixConfig ()
		{
			string[] path_list = Directory.GetFiles(Application.dataPath+"/ResourcesBak/HotfixScripts");
			List<TextAsset> assets = new List<TextAsset>();
			foreach(string path in path_list)
			{
				if(Path.GetExtension(path).Equals(".txt"))
					assets.Add(AssetDatabase.LoadAssetAtPath( "Assets/ResourcesBak/HotfixScripts/"+Path.GetFileName(path),typeof(TextAsset)) as TextAsset);
			}
			string info = ""; 
			foreach(TextAsset asset in assets)
			{
				info += asset.name + "｀" + asset.text + "｜";
			}
			Debug.Log("output:"+info);

			byte[] bytes = Ionic.Zlib.GZipStream.CompressString(info);
			string filePath = "Assets/StreamingAssetsBak/HotfixScripts/" + "Hotfix.gz";
			string directoryName = Path.GetDirectoryName(filePath);
			if(!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			using (FileStream fs = File.OpenWrite (filePath))
			{
				fs.Write (bytes, 0, bytes.Length);
				fs.Close();
				fs.Dispose();
			}
		}

		[MenuItem ("Assets/CompressStaticDataGZip")]
		static public void CompressStaticDataGZip ()
		{
			string info = "";
			string assetName = "";
			List<TextAsset> assets = new List<TextAsset> ();
			foreach (UnityEngine.Object ie in Selection.GetFiltered (typeof(UnityEngine.Object), SelectionMode.DeepAssets)) {
				TextAsset asset = ie as TextAsset;
				assetName= asset.name.Replace("txt","gz");
				info = asset.text;
				break;
			}

			Debug.Log("output:"+info);
			Debug.LogError("md5:"+Util.Instance.SimpleMD5CryptoServiceProvider(info));
			byte[] bytes = Ionic.Zlib.GZipStream.CompressString(info);
			string filePath = "Assets/StreamingAssetsBak/StaticData/" + assetName;
			string directoryName = Path.GetDirectoryName(filePath);
			if(!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			using (FileStream fs = File.OpenWrite (filePath))
			{
				fs.Write (bytes, 0, bytes.Length);
				fs.Close();
				fs.Dispose();
			}
		}



		[MenuItem ("Export/ExportStaticDataGZip")]
		static public void ExportStaticData ()
		{
			List<TextAsset> assets = new List<TextAsset> ();
			foreach (UnityEngine.Object ie in Selection.GetFiltered (typeof(UnityEngine.Object), SelectionMode.DeepAssets)) {
				TextAsset asset = ie as TextAsset;
				if (asset != null)
					assets.Add (asset);
			}
			string info = ""; 
			foreach(TextAsset asset in assets)
			{
				info += asset.name + "｀" + asset.text + "｜";
			}
			Debug.Log("output:"+info);
			byte[] bytes = Ionic.Zlib.GZipStream.CompressString(info);
			string filePath = "Assets/StreamingAssetsBak/StaticData/" + "StaticData.gz";
			string directoryName = Path.GetDirectoryName(filePath);
			if(!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			using (FileStream fs = File.OpenWrite (filePath))
			{
				fs.Write (bytes, 0, bytes.Length);
				fs.Close();
				fs.Dispose();
			}
		}
	}
}