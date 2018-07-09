using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using NativeBuilder.XCodeEditor;
using NativeBuilder.EclipseEditor;
using System.IO;
using System;
using System.Linq;

namespace NativeBuilder 
{

	public class NativeBuilderUI {

		static string unityProjectPath =  Application.dataPath.Remove(Application.dataPath.LastIndexOf('/'));
		#if UNITY_ANDROID
        [MenuItem("NativeBuilderLight/Build/Android (AndroidStudio Project)")]
		#endif
		public static void Build_Android()
		{
			AndroidWindow.Show();
		}

		#if UNITY_IPHONE
        [MenuItem("NativeBuilderLight/Build/iOS (Export xCode)")]
		#endif
		public static void Builder_iOS()
		{
			IOSWindow.Show();
		}

        [MenuItem("NativeBuilderLight/Generate Conf Folder")]
		public static void GenerateConfFolder()
		{
			Configuration.GenerateConfFolder();
		}

        [MenuItem("NativeBuilderLight/Android/Open User Conf.xml")]
		public static void OpenAndroidConfFile()
		{
			var path = unityProjectPath + "/NativeBuilderConf/src/user.eupe/conf.xml";
			Debug.Log(path);
			EditorUtility.OpenWithDefaultApp(path);
		}

        [MenuItem("NativeBuilderLight/Android/Open Conf")]
		public static void OpenAndroidConf()
		{
			var path = unityProjectPath + "/NativeBuilderConf";
			Debug.Log(path);
			EditorUtility.OpenWithDefaultApp(path);
		}

        [MenuItem("NativeBuilderLight/Android/Open Product")]
		public static void OpenAndroidProduct()
		{
			var path = unityProjectPath + "/NativeBuilderProduct";
			Debug.Log(path);
			EditorUtility.OpenWithDefaultApp(path);
		}

	}
}


