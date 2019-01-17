using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Text;
using System.Reflection;

namespace NativeBuilder
{

	public delegate void ProcessHandller(float percent, string title, string verbos);

	public class NativeBuilderUtility{

		public static string[] ListBuildScenes()
		{
			List<string> EditorScenes = new List<string>();
			foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) 
			{
				if (!scene.enabled)
					continue;
				EditorScenes.Add(scene.path);
			}
			return EditorScenes.ToArray();
		}
		
		public static void Build(string target_dir, BuildTarget build_target, BuildOptions build_options)
		{
			string[] scenes = ListBuildScenes ();
			EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
            EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
			var report = BuildPipeline.BuildPlayer(scenes, target_dir, build_target, build_options);
			// report.
			// if (res.steps.Length > 0)
			// {
			// 	throw new Exception("BuildPlayer failure: " + res);
			// }
		}

		public static string BuildAPK(string projectPath, ProcessHandller process = null)
		{
			if(process == null)
			{
				process = (percent, title, verbos) => {};
			}
			UnityEngine.Debug.Log(" -> BuildAPK...");
			
			//----------------------------------------------------------
			//Detect Paths
			//----------------------------------------------------------
			process(0.1f, "Detect paths", "detect Android project path...");
			var project = new EclipseProject(projectPath);//new EclipseProject(BaseProjectPath + "/" + gameProjectName);
			
			process(0.1f, "Detect path", "detect tools path...");
			var local = Configuration.Local;
			var android_sdk = local["android.sdk"];
			var ant_sdk = local["ant.sdk"];
			
			process(0.1f, "Detect path", "detect target apk path...");
			var conf = Configuration.Gloable;
			var target_path = conf["android.apk"];
			
			// log
			UnityEngine.Debug.Log("android sdk: " + android_sdk);
			UnityEngine.Debug.Log("ant: " + ant_sdk);
			UnityEngine.Debug.Log("apk target: " + target_path);
			//----------------------------------------------------------
			//excute command
			//----------------------------------------------------------
			process(0.2f, "Build Apk", "excute android update...");
			project.Antlize(android_sdk);
			
			process(0.3f, "Build Apk", "excute android clean...");
			Ant.ant_clean(project.Path, ant_sdk);
			
			process(0.4f, "Build Apk", "detect Ant mod...");
			var antMod = DecideAntMod(project);
			if(antMod == AntMod.Debug)
			{
				process(0.4f, "Build Apk", "excute ant debug...");
				Ant.ant_debug(project.Path, ant_sdk);
			}
			else if(antMod == AntMod.Release)
			{
				//process(0.4f, "Build Apk", "set keystore to Anroid project...");
				//SetKeystoreToProject(project);
				
				process(0.45f, "Build Apk", "execute ant release...");
				Ant.ant_release(project.Path, ant_sdk);
			}
			
			process(0.95f, "Build Apk", "copy apk...");
			var f = Android.FindAntBuiltAPK(project.Path, antMod);
			f.CopyTo(target_path, true);
			return target_path;
		}
		
		

		public static AntMod DecideAntMod(EclipseProject project)
		{
			//string keystore = PlayerSettings.Android.keyaliasName;
			//return string.IsNullOrEmpty(keystore) ? AntMod.Debug : AntMod.Release;

			if(project.KeystoreExists) return AntMod.Release;
			return AntMod.Debug;
		}

		
		public static void SetKeystoreToProject(EclipseProject project)
		{
			string keystore = PlayerSettings.Android.keystoreName;
			if(string.IsNullOrEmpty(keystore)) return;
			FileInfo fi = new FileInfo(keystore);
			if(!fi.Exists)
			{
				throw new Exception("keysotre '" + fi.FullName + "' not exsits!");
			}
			DirectoryInfo di = new DirectoryInfo(project.Path + "/nativebuilder/keystore");
			if(!di.Exists)
			{
				di.Create();
			}
			fi.CopyTo(di.FullName + "/" + fi.Name);
			var keystore_path = "./nativebuilder/keystore/" + fi.Name;
			var keystore_pass = PlayerSettings.Android.keystorePass;
			var keyalis_name = PlayerSettings.Android.keyaliasName;
			var keyalis_pass = PlayerSettings.Android.keyaliasPass;
			project.SetKeystore(keystore_path, keystore_pass, keyalis_name, keyalis_pass);
		}

		public static void SetKeystoreToProject(EclipseProject project, string key_store_path)
		{
			var keystore_path = key_store_path;
			var keystore_pass = "android";
			var keyalis_name = "androiddebugkey";
			var keyalis_pass = "android";
			project.SetKeystore(keystore_path, keystore_pass, keyalis_name, keyalis_pass);
		}

		
		
		public static void RunAPK(string apkPath, string package)
		{
			UnityEngine.Debug.Log(" -> RunAPK...");
			var android_sdk = Configuration.Local["android.sdk"];
			while(!Android.HasDevices(android_sdk))
			{
				bool b = EditorUtility.DisplayDialog("Device Not Found", "Please connect devices.", "Done", "Cancel");
				if(!b)
				{
					throw new UserCancelException("User Canceled.");
				}

			}
			Android.RunAPK(apkPath, package, android_sdk);
		}

		public static string UnityProjectPath =  Application.dataPath.Remove(Application.dataPath.LastIndexOf('/'));

		// Eval > Evaluates C# sourcelanguage
		public static object Eval(string sCSCode) {
			
			CSharpCodeProvider c = new CSharpCodeProvider();
			ICodeCompiler icc = c.CreateCompiler();
			CompilerParameters cp = new CompilerParameters();
			
			cp.ReferencedAssemblies.Add("system.dll");
			cp.ReferencedAssemblies.Add("system.xml.dll");
			cp.ReferencedAssemblies.Add("system.data.dll");
			cp.ReferencedAssemblies.Add("system.windows.forms.dll");
			cp.ReferencedAssemblies.Add("system.drawing.dll");
			
			cp.CompilerOptions = "/t:library";
			cp.GenerateInMemory = true;
			
			StringBuilder sb = new StringBuilder("");
			sb.Append("using System;\n" );
			sb.Append("using UnityEngine;\n");
			sb.Append("using UnityEditor;\n");
			sb.Append("using System.Collections.Generic;\n");
			sb.Append("using System.Collections;\n");
			
			sb.Append("namespace CSCodeEvaler{ \n");
			sb.Append("public class CSCodeEvaler{ \n");
			sb.Append("public object EvalCode(){\n");
			sb.Append("return "+sCSCode+"; \n");
			sb.Append("} \n");
			sb.Append("} \n");
			sb.Append("} \n");
			
			
			CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
			if( cr.Errors.Count > 0 ){
				throw new Exception("Error evaluating cs code: " + cr.Errors[0].ErrorText);
			}
			
			
			System.Reflection.Assembly a = cr.CompiledAssembly;
			object o = a.CreateInstance("CSCodeEvaler.CSCodeEvaler");
			
			Type t = o.GetType();
			MethodInfo mi = t.GetMethod("EvalCode");
			
			object s = mi.Invoke(o, null);
			return s;
			
		}
	}
}
