using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using NativeBuilder;

namespace NativeBuilder.XCodeEditor
{
    public partial class XCProject : System.IDisposable
    {
        Properties native_builder;
        public string path;

        public string BuildTime
        {
            get
            {
                var str = this.native_builder.TryGet("BuildTime", null);
				if (str == null) return DateTime.MinValue.ToString();
				return str;
            }
            set
            {
                this.native_builder["BuildTime"] = value;
                this.native_builder.Save();
            }
        }

        void CopyFolders(XUPEMod mods)
        {
            //ext.copyFolder
            Debug.Log("Adding copyied folders...");
            PBXGroup modGroup = this.GetGroup(mods.xcmod.group);
            foreach (string copiedFolderPath in mods.copiedFolder)
            {
                string sourceFloderPath = mods.path + "/" + copiedFolderPath;

                DirectoryInfo souceDirector = new DirectoryInfo(sourceFloderPath);
                DirectoryInfo targetDirector;
                //crate director in xcode project folder
                if (modGroup != null)
                {
                    targetDirector = this.CreateDirectorInRootDir(modGroup.path);
                }
                else
                {
                    targetDirector = new DirectoryInfo(this.projectRootPath);
                }
                //copy "coyied folder" into target folder
                Debug.Log("copy '" + souceDirector.FullName + "' to '" + targetDirector.FullName + "'.");
                PShellUtil.CopyInto(souceDirector, targetDirector);

                //add target folder reference to project
                this.AddFolder(targetDirector.FullName + "/" + souceDirector.Name, modGroup, (string[])mods.xcmod.excludes.ToArray(typeof(string)));
            }
        }
		void TranslateFiles(XUPEMod mods)
		{
			Debug.Log("TranslateFiles...");
			foreach (string files in mods.translate)
			{
				string targetFile= this.projectRootPath + "/" + files;
				if(File.Exists(targetFile ))
				{
					XClass xc = new XClass(targetFile);
					foreach(string key in mods.vars.Keys)
					{
						xc.Replace("${" + key + "}", mods.vars[key]);
					}
				}
			}
		}


        void ModifyCode(XUPEMod mods)
        {
            //modify code
            Debug.Log("Modify code...");
            ArrayList codeList = mods.extCode;
            foreach (var code in codeList)
            {
                var item = (Hashtable)code;
                XClass xclass = new XClass(this.projectRootPath + item["file"]);
                if (item["type"].Equals("writeBelow"))
                {
                    xclass.WriteBelow((string)item["target"], (string)item["code"]);
                }
                else if (item["type"].Equals("writeHead"))
                {
                    xclass.WriteHead((string)item["code"]);
                }
				else if (item["type"].Equals("writeEnd"))
				{
					xclass.WriteHead((string)item["code"]);
				}
                else if (item["type"].Equals("replace"))
                {
                    xclass.Replace((string)item["target"], (string)item["code"]);
                }
            }
        }

        void SetProperty(XUPEMod mods)
        {
            //table init
            Dictionary<string, string> table = new Dictionary<string, string>();
            //table.Add("codeSigningEntitlements", "CODE_SIGN_ENTITLEMENTS");
            table.Add("enableBitcode", "ENABLE_BITCODE");
            table.Add("deploymentTarget", "IPHONEOS_DEPLOYMENT_TARGET");
            table.Add("productName", "PRODUCT_NAME");
			//table.Add("productName", "PRODUCT_NAME");
            //set property
            Debug.Log("set property...");
            Hashtable propertyList = mods.property;
            if (propertyList != null)
            {
                foreach (string sKey in propertyList.Keys)
                {

                    string key = "";
                    if (!table.TryGetValue(sKey, out key))
                    {
                        key = sKey;
                    }
                    if (key == sKey)
                    {
                        var logMsg = "override properties: " + key + " => " + (string)propertyList[sKey];
                        logMsg += " (Unknown Key)";
                        Debug.Log(logMsg);
                    }
					this.overwriteBuildSetting(key, ((string)propertyList[sKey]).Replace("${project}",path), "Debug");
					this.overwriteBuildSetting(key, ((string)propertyList[sKey]).Replace("${project}",path), "Release");
					//his.overwriteBuildSetting(key, ((string)propertyList[sKey]).Replace("${conf}",path), "Debug");
					//this.overwriteBuildSetting(key, ((string)propertyList[sKey]).Replace("${conf}",path), "Release");
//					Debug.LogError(  ((string)propertyList[sKey]).Replace("${conf}",path));

                }
            }
        }

        void CopyPlainFile(XUPEMod mods)
        {
            //copy file
            Debug.Log("Copy files...");
            PShellUtil.CopyAll(new DirectoryInfo(Path.Combine(mods.path, "file")), new DirectoryInfo(this.projectRootPath));
        }

        void Execute(XUPEMod mods)
        {
            Debug.Log("Execute...");
            var path = mods.execute;
            if (string.IsNullOrEmpty(path)) return;
            Exec.Run(path, mods.path + " " + this.path);
        }

        public void ApplyXupemod(XUPEMod mods)
        {

            CopyFolders(mods);

            //此方法必须放在"Adding copyied folders..."之后以保证添加动态库方法的正确运行!
            //native xcmod
            this.ApplyMod(mods.xcmod);
			TranslateFiles(mods);
            ModifyCode(mods);

            SetProperty(mods);

            CopyPlainFile(mods);

            Execute(mods);

        }

        public void ApplyXupemod(string path)
        {
            XUPEMod mod = new XUPEMod(path);
            this.ApplyXupemod(mod);
        }

        public DirectoryInfo CreateDirectorInRootDir(string name)
        {
            DirectoryInfo d = new DirectoryInfo(this.projectRootPath);
            d.CreateSubdirectory(name);
            return d;
        }
    }



}