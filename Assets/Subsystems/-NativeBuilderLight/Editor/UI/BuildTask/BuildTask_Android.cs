using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using NativeBuilder.EclipseEditor;
using System.IO;
using System;
using System.Linq;
using NativeBuilder.XCodeEditor;

namespace NativeBuilder
{
	public enum BuildLevel
	{
		JustAndroidProject,
		UtilApplyNativeBuilder,
		UtilBuildApk,
		UtilRunApk
	}


	
	public class BuildTask_Android : BuildTask
	{
		DateTime startTime;
		string apkPath;
		Conf_Gloable global;
		Conf_Local local;
		Mod mod;
		string modName;
	
		public BuildLevel BuildLevel {get;set;}
		public string BackupName {get;set;}

		private enum TaskList
		{
			BuildAndroidProject,
			ApplyNativeBuilder,
			BuildApk,
			RunApk
		}

		public BuildTask_Android(BuildLevel level, string backupName, string modName)
		{
			this.BuildLevel = level;
			this.BackupName = backupName;
			this.modName = modName;
		}

		public bool UseBackup
		{
			get
			{
				return !string.IsNullOrEmpty(this.BackupName);
			}
		}

		 
		private bool ShouldDoTask(TaskList task)
		{
			List<TaskList> whatShouldDo = new List<TaskList>();

			switch(BuildLevel)
			{
			case BuildLevel.UtilRunApk:
				whatShouldDo.Add(TaskList.BuildAndroidProject);
				whatShouldDo.Add(TaskList.ApplyNativeBuilder);
				whatShouldDo.Add(TaskList.BuildApk);
				whatShouldDo.Add(TaskList.RunApk);
				break;
			case BuildLevel.UtilBuildApk:
				whatShouldDo.Add(TaskList.BuildAndroidProject);
				whatShouldDo.Add(TaskList.ApplyNativeBuilder);
				whatShouldDo.Add(TaskList.BuildApk);
				break;
			case BuildLevel.UtilApplyNativeBuilder:
				whatShouldDo.Add(TaskList.BuildAndroidProject);
				whatShouldDo.Add(TaskList.ApplyNativeBuilder);
				break;
			case BuildLevel.JustAndroidProject:
				whatShouldDo.Add(TaskList.BuildAndroidProject);
				break;
			default:
				new Exception("Interal Error: Unknow BuildLevel:" + this.BuildLevel);
				break;
			}
			if(whatShouldDo.Contains(task)) return true;
			return false;
		}


		private static void Process(float process, string title, string verbos)
		{
			if(EditorUtility.DisplayCancelableProgressBar(title, verbos, (float)process/40))
			{
				throw new Exception("Build Canneled by user.");
			}
		}
		
		public override void OnPreBuild ()
		{

			Process(1, "Detect Paths", "");
			this.startTime = DateTime.Now;
			this.global = Configuration.Gloable;
			this.local = Configuration.Local;
			this.global.Repaire();
			this.local.Repaire();
			//var modPath = global["android.conf"];
			// 根据ModName到Mod目录中寻找Mod的路径
			//Debug.LogError("this.modName;"+this.modName);

            /*
            if (!string.IsNullOrEmpty(this.modName))
            {
                this.mod = new Mod(Path.Combine(this.global.AndroidSrcDir, this.modName));

                // add lib Refenrence
                //DirectoryInfo lib_dir = new DirectoryInfo(global["android.lib.dir"]);
                //DirectoryInfo src_dir = new DirectoryInfo(global["android.src.dir"]);
                DirectoryInfo src_dir = new DirectoryInfo(this.mod.subModPath);
                var libs = src_dir.GetDirectories("*.eupe", SearchOption.TopDirectoryOnly);
                string[] libs_path = (from d in libs
                                     select d.FullName).ToArray();
                foreach (var lib in libs_path)
                {
                    this.mod.AddReference(lib);
                }
            }
            */
			
			Process(2, "Check asserts", "");
			var exceptionList = BuildTask_AndroidUtility.CheckAsserts(this.mod, this.local, UseBackup, this.global);
			
			if(exceptionList.Count > 0)
			{
				string msg = "Packaging can not start because of the following reasons:\n";
				int index = 1;
				foreach(AssertException e in exceptionList)
				{
					msg += "    " + index +"). " + e.Message +"\n";
					index++;
				}
				throw new Exception(msg);
			}

		}
		
		//build Eclipse Project
		public override void OnBuild ()
		{
            string solutionPath = global["android.project"];

			// Build Android Project
			if(ShouldDoTask(TaskList.BuildAndroidProject))
			{
				Process(5, "Build Android Project", "");


				//mod file path
				var task_buildAndroidProject = new ReportableTask();
				task_buildAndroidProject.name = "Build Android Studio Project";
				task_buildAndroidProject.processHandller = OnExportReport;
				task_buildAndroidProject.action = (process) => {
					
					//check parent dir
					process(0.1f, "Export Android Studio Project", "ensure dirs...");
					{
						var di = new DirectoryInfo(solutionPath).Parent;
						if(!di.Exists){
							di.Create();
						}
					}
					
					//if target Path exits, delete it!
					if (Directory.Exists (solutionPath)) {
						DirectoryInfo dir = new DirectoryInfo (solutionPath);
						dir.Delete (true);
					}

					if(!this.UseBackup)
					{
						// build eclipse project
						process(0.15f, "Export Android Project", "call unity to export android project...");
						UnityEngine.Debug.Log("Unity building eclipse project..."); 
						NativeBuilderUtility.Build(solutionPath, UnityEditor.BuildTarget.Android, UnityEditor.BuildOptions.AcceptExternalModificationsToPlayer);
						
						// change project name
                        /*
						DirectoryInfo projectDir = new DirectoryInfo(EclipsePath);
						DirectoryInfo[] childrenDir = projectDir.GetDirectories();
						if(childrenDir.Length != 1)
						{
							throw new Exception("multi child directories be found under the project!");
						}
						string oldGameName = childrenDir[0].Name;
                        */          
                        // rename project dir
                        string oldGameName = PlayerSettings.productName;
						string newGamename = "Game";
						string source = Path.Combine(solutionPath, oldGameName);
						string dest = Path.Combine(solutionPath, newGamename);
						Directory.Move(source, dest);

                        // rename obb
                        string ObbPath = solutionPath+"/"+PlayerSettings.productName+".main.obb";
                        if(File.Exists(ObbPath))
                        {

                            string targetObbPath = solutionPath + "/"+"main."+PlayerSettings.Android.bundleVersionCode+"."+PlayerSettings.applicationIdentifier+".obb";
                            File.Move(ObbPath, targetObbPath);
                        }

						// write info
						EclipseProject project = new EclipseProject(solutionPath + "/Game");
                        project.BuildTime = this.startTime.ToString();

						// write keystore
                        if(this.mod != null) NativeBuilderUtility.SetKeystoreToProject(project,this.mod.path+"/merge/edroity_debug.keystore");

						// backup pure eclips project
						PShellUtil.CopyTo(solutionPath, Configuration.Gloable.Eclipse_Project_Backup_Home + "/autosave", PShellUtil.FileExsitsOption.Override, PShellUtil.DirectoryExsitsOption.Override);
					}
					else if(this.UseBackup)
					{
						PShellUtil.CopyTo(Path.Combine(Configuration.Gloable.Eclipse_Project_Backup_Home, this.BackupName), solutionPath, PShellUtil.FileExsitsOption.Override, PShellUtil.DirectoryExsitsOption.Override);
					}

				};
				task_buildAndroidProject.Run();
				
				UnityEngine.Debug.Log("Build AndroidStudio Project success, Release At [" + solutionPath + "].");
				

			}

            /*
			// Apply NativeBuilder 
			if(ShouldDoTask(TaskList.ApplyNativeBuilder))
			{
				Process(0.8f, "Apply NativeBuilder Conf", "apply eupe...");
				ELProject project = new ELProject (solutionPath + "/Game");
				EUPE.ModEclipseProject(project, mod);
			}

			// Build Apk
			if(ShouldDoTask(TaskList.BuildApk))
			{
				Process(15, "Build APK", "");
				this.apkPath = NativeBuilderUtility.BuildAPK(solutionPath + "/Game", OnApkBuildReport);
				string target_dir = solutionPath + "/../TargetAndroid";
				string appName = PlayerSettings.productName +"_"+PlayerSettings.bundleVersion+"_"+System.DateTime.Now.ToString("MMdd_HHmm")+".apk";
				string target_path = target_dir+"/"+ appName;
				if (Directory.Exists(target_dir))
				{
					Directory.Delete(target_dir,true);
				}
				Directory.CreateDirectory(target_dir);
				File.Move(this.apkPath,target_path);
				this.apkPath = target_path;
				//main.42.tw.mobage.g22000016.obb
				string thisObbPath = solutionPath+"/"+PlayerSettings.productName+".main.obb";
				if(File.Exists(thisObbPath))
				{

					string targetObbPath = target_dir+"/"+"main."+PlayerSettings.Android.bundleVersionCode+"."+PlayerSettings.applicationIdentifier+".obb";
					File.Move(thisObbPath,targetObbPath);
				}

				UnityEngine.Debug.Log("Build Apk success, Release At [" + apkPath + "].");
			}

			// Run Apk
			if(ShouldDoTask(TaskList.RunApk))
			{
				NativeBuilderUtility.RunAPK(this.apkPath, PlayerSettings.applicationIdentifier);
			}
            */


		}
		
		private void OnExportReport(float percent, string title, string verbos)
		{
			Process(5 + percent * 10, title, verbos);
		}
		
		private void OnApkBuildReport(float percent, string title, string verbos)
		{
			Process(15 + percent * 20, title, verbos);
		}
		
		//build apk and run
		public override void OnPostBuild ()
		{
			PrintSuccessMsg();
		}

		private void PrintSuccessMsg()
		{
			DateTime endTime = DateTime.Now;
			var useTime = endTime - startTime;
			string msg = "[NativeBuilder] Build Success";
			if(this.BuildLevel == BuildLevel.UtilBuildApk)
			{
				msg += ", Apk release at [" + apkPath + "]";
			}
			else
			{
				msg += ", android project release at [" + global["android.project"] + "/Game]";
			}
			msg += ", in "  + FormatTime(useTime);
			Debug.Log(msg);
		}

		public override void OnException (Exception e)
		{
			Debug.LogException(e);
			if(e is UserCancelException)
			{
				PrintSuccessMsg();
			}
		}
		
		public override void OnFinally ()
		{
			EditorUtility.ClearProgressBar();
		}
		
		private static string FormatTime(TimeSpan span)
		{
			return string.Format("{0:F0} munutes {1:F0} seconds" ,span.TotalMinutes, span.Seconds);
		}

		
	}
}

