using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using NativeBuilder;
using NativeBuilder.XCodeEditor;

namespace NativeBuilder
{
	public class BuildTask_iOS : BuildTask 
	{
		private enum TaskList
		{
			BuildXCodeProject,
			ApplyNativeBuilder,
			BuildIpa
		}

		IOSBuildLevel BuildLevel;
		string BackupName;
		string modName;

		public BuildTask_iOS(IOSBuildLevel level, string backupName)
		{
			this.BuildLevel = level;
			this.BackupName = backupName;
		}

		private bool UseBackup
		{
			get
			{
				return !string.IsNullOrEmpty(this.BackupName);
			}
		}
		
		private bool ShouldDoTask(TaskList task)
		{
			List<TaskList> whatShouldDo = new List<TaskList>();
			switch(this.BuildLevel)
			{
			case IOSBuildLevel.UtilBuildIpa: 
				whatShouldDo.Add(TaskList.BuildXCodeProject);
				whatShouldDo.Add(TaskList.ApplyNativeBuilder);
				whatShouldDo.Add(TaskList.BuildIpa);
				break;
			case IOSBuildLevel.UtilApplyNativeBuilder: 
				whatShouldDo.Add(TaskList.BuildXCodeProject);
				whatShouldDo.Add(TaskList.ApplyNativeBuilder);
				break;
			case IOSBuildLevel.JustXCodeProject:
				whatShouldDo.Add(TaskList.BuildXCodeProject);
				break;
			}
			if(whatShouldDo.Contains(task)) return true;
			return false;
		}

		Conf_Gloable global = null;
		string modPath = null;
		string xCodePath = null;

		public override void OnPreBuild ()
		{
			this.global = Configuration.Gloable;
			this.global.Repaire();
			// get my xupe file path
			//this.modPath = gloabal["ios.conf"];
            if (!string.IsNullOrEmpty(this.modName))
            {
                this.modPath = Path.Combine(this.global.IOSSrcDir, this.modName);
            }
			// set a target xCode path 
			this.xCodePath = global["ios.project"];
			// export!
			//NativeBuilderCore.ExportIOS (xCodePath, modPath);
			
			if(EditorUserBuildSettings.activeBuildTarget != BuildTarget.iOS)
			{
				throw new Exception("Current platform must be iOS! (now is " + EditorUserBuildSettings.activeBuildTarget + ")");
			}
			//check mod exist
			{
                if (!string.IsNullOrEmpty(this.modName))
                {
                    if (!(new DirectoryInfo(modPath).Exists))
                    {
                        throw new Exception("xupe package not exists! (" + modPath + ")");
                    }
                }
			}
		}
		
		public override void OnBuild ()
		{

			if(this.ShouldDoTask(TaskList.BuildXCodeProject))
			{
				Debug.Log("Unity building xCode..."); 

				// check parent dir exsits
				DirectoryInfo directory =  new DirectoryInfo(xCodePath);
				var parent = directory.Parent;
				if(!parent.Exists){
					parent.Create();
				}
				if(directory.Exists)
				{
					directory.Delete(true);
				}

			
				if(!this.UseBackup)
				{
					// build
					//NativeBuilderUtility.Build(this.xCodePath, UnityEditor.BuildTarget.iOS, UnityEditor.BuildOptions.ConnectWithProfiler | UnityEditor.BuildOptions.Development);
					NativeBuilderUtility.Build(this.xCodePath, UnityEditor.BuildTarget.iOS, UnityEditor.BuildOptions.None);


					// write build time
					XCProject project = new XCProject(this.xCodePath);
					project.BuildTime = DateTime.Now.ToString();

					//back up pure xCode Project
					PShellUtil.CopyTo(this.xCodePath, this.global.XCode_Project_Backup_Home + "/autosave", PShellUtil.FileExsitsOption.Override, PShellUtil.DirectoryExsitsOption.Override);
				}
				else
				{
					// use last version

					PShellUtil.CopyTo(Path.Combine(this.global.XCode_Project_Backup_Home, this.BackupName), this.xCodePath, PShellUtil.FileExsitsOption.Override, PShellUtil.DirectoryExsitsOption.Override);
				}

			}

			if(this.ShouldDoTask(TaskList.ApplyNativeBuilder))
			{
				Debug.Log("Apply NativeBuilder..."); 
				XUPE.ModXCodeProject(this.xCodePath, this.modPath);
				UnityEngine.Debug.Log("[NativeBuilder]: generate xCode project success, xCode Project release at [" + xCodePath + "].");

                // 检查 Mod 根目录下是否包含shell脚本，如果包含就执行
                string shellPath = this.modPath + "/code.sh";
                if (File.Exists (shellPath)) {
                    int ret = Exec.Run (shellPath, this.xCodePath);
                    if (ret != 0)
                    {
                        throw new UnityException("[NativeBuilder] Error in execute code.sh, returns: " + ret);
                    }
                }
			}

			if(this.ShouldDoTask(TaskList.BuildIpa))
			{

				DirectoryInfo tar_di = new DirectoryInfo(this.xCodePath + "/export");
				Debug.Log("Build IPA");
				DirectoryInfo assets = new DirectoryInfo(Application.dataPath);
				var sh = assets.GetFiles("build_xcode.sh", SearchOption.AllDirectories)[0];

				var ret = Exec.Run(sh.FullName, this.xCodePath);
				//var ret = Exec.Run("/bin/bash", sh.FullName + " " + this.xCodePath);
				if(ret != 0) throw new Exception("Error in Build IPA. return code: " + ret + ". xCode Project at [" + this.xCodePath + "].");

				// copy to output path
				DirectoryInfo di = new DirectoryInfo(this.xCodePath + "/export");

				var ipa = di.GetFiles("*.ipa", SearchOption.AllDirectories)[0];
				ipa.CopyTo(this.global["ios.ipa"], true);

				UnityEngine.Debug.Log("[NativeBuilder]: Build success, ipa At [" + this.global["ios.ipa"] + "].");
			}
				
		}
		
		public override void OnPostBuild ()
		{


		}
	}

	public enum IOSBuildLevel
	{
		JustXCodeProject,
		UtilApplyNativeBuilder,
		UtilBuildIpa
	}

}

