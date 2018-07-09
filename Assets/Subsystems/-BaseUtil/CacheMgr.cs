using UnityEngine;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
	public static class CacheMgr
	{
		private  static string catchFilePath="";
		public static string FilePath//主线程必须先调用一次初始化后，方可在子线程调用
		{
			get
			{
				if(string.IsNullOrEmpty(catchFilePath))
				{
					string filePath = "";
					#if UNITY_IPHONE
					filePath = Application.temporaryCachePath;
					#else
					filePath = Application.persistentDataPath;
					#endif
					if(!string.IsNullOrEmpty(filePath))catchFilePath = filePath+"/";
				}
				return catchFilePath;
			}
		}


		public static void Save()
		{
			PlayerPrefs.Save();
		}
		#if UNITY_EDITOR	
		[MenuItem ("Tools/ClearLocalDataAndPrefs")] 
		#endif
		public static void ClearLocalDataAndPrefs ()
		{
			PlayerPrefs.DeleteAll ();
			Caching.ClearCache ();
			ClearLocalData();
			Save();

		}
		#if UNITY_EDITOR	
		[MenuItem ("Tools/ClearLocalData")] 
		#endif
		public static void ClearLocalData()
		{
			string filePath = FilePath;
			if (Directory.Exists (filePath)) 
			{
				Directory.Delete (filePath, true);
			}	
		}


		public static void ClearOldLocalData()
		{
			Caching.ClearCache ();
			string filePath = FilePath;
			if(Directory.Exists(FilePath))
			{
				string[] files =Directory.GetFiles(FilePath);
				foreach(string file in files)
				{
					string file_path =FilePath+file;
					if(file.EndsWith(".byte")||file.EndsWith(".txt"))
					{
						if(File.Exists(file_path))
						{
							File.Delete(file_path);
						}
					}

				}
			}

		}
	}

