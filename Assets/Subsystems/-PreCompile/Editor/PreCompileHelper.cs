using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEditor;
using System.Diagnostics;
using System.Linq;


namespace PreCompileInternal 
{

    public class Exec  {

        /// <summary>
        /// Run the specified exec, argument, ignoreError and output.
        /// </summary>
        /// <param name="exec">Exec.</param>
        /// <param name="argument">Argument.</param>
        /// <param name="ignoreError">treat error log as normal log</param>
        /// <param name="output">all normal log and error log</param>
        /// 
        public static int Run(string exec, string argument, out string output, bool ignoreError = false, bool hasOutput = true)
        {
            string s = "";
            System.Diagnostics.Process p = new System.Diagnostics.Process ();
            p.StartInfo.FileName = exec;
            p.StartInfo.Arguments = argument;
            UnityEngine.Debug.Log("execute:  " + exec + " " + argument);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;

            p.OutputDataReceived += (object sender, DataReceivedEventArgs e) => 
                {
                    if(e.Data == null) return;
                    // print log
                    UnityEngine.Debug.Log(e.Data);
                    //export log
                    //string path = "/Users/mengmin.duan/Project/LCM/core/unity/dev/nativebuilder_log/build.log";


                    // get output
                    if(hasOutput)
                    {
                        s += e.Data.ToString() + "\n";
                    }
                };
            p.ErrorDataReceived += (object sender, DataReceivedEventArgs e) => 
                {
                    if(e.Data == null) return;
                    // print log
                    if(!ignoreError)
                    {
                        UnityEngine.Debug.LogError(e.Data);
                    }
                    else
                    {
                        UnityEngine.Debug.Log(e.Data);
                    }
                    // get output
                    if(hasOutput)
                    {
                        s += e.Data.ToString() + "\n";
                    }

                };
            p.Start ();


            p.BeginOutputReadLine ();
            p.BeginErrorReadLine();

            var temp = Application.stackTraceLogType;
            Application.stackTraceLogType = StackTraceLogType.None;
            p.WaitForExit();
            Application.stackTraceLogType = temp;

            output = s;
            return p.ExitCode;

        }

        public static int Run(string exec, string argument, bool ignoreError = false)
        {
            string ret = null;
            return Run(exec, argument, out ret, ignoreError, false);
        }

        //  public static int RunEx(string Exec, bool ignoreError, params string[] arguments)
        //  {
        //      var enumator = from arg in arguments select EscapeBlank(arg);
        //      var escapedArgument = string.Join(" ", enumator.ToArray());
        //      return Run(Exec, escapedArgument, ignoreError);
        //  }

        public static string RunGetOutput(string exec, string argument, bool ignoreError = false)
        {
            string ret = "";
            Run(exec, argument, out ret, ignoreError, true);
            return ret;
        }

        //  public static string EscapeBlank(string origin)
        //  {
        //      return origin.Replace(" ", @"\ ");
        //      //return origin;
        //
        //  }
    }



    public static class PShellUtil
    {
        
        public static void DeleteEmptyDirectory(String rootPath)
        {
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            var subdirs = dir.GetDirectories("*.*", SearchOption.AllDirectories).ToList<DirectoryInfo>();
            subdirs.Insert(0, dir);
            for (int i = subdirs.Count - 1; i >= 0; i--)
            {
                var subdir = subdirs[i];
                FileSystemInfo[] subFiles = subdir.GetFileSystemInfos();
                if (subFiles.Count() == 0)
                {
                    subdir.Delete();
                    var dirMeta = subdir.FullName + ".meta";
                    if (File.Exists(dirMeta))
                    {
                        File.Delete(dirMeta);
                    }
                }
            }

        }

        public enum FileExsitsOption{
            Override,
            NotCopy
        }

        public enum DirectoryExsitsOption{
            Override,
            Merge,
            NotCopy
        }
            
        public static void MoveTo(string source, string target, FileExsitsOption fileOption = PShellUtil.FileExsitsOption.Override, DirectoryExsitsOption directoryOption = PShellUtil.DirectoryExsitsOption.Merge, string[] exclude = null, string[] fileNameEndInclude = null)
        {
            DirectoryInfo s = new DirectoryInfo(source);
            DirectoryInfo t = new DirectoryInfo(target);
            MoveTo(s, t, fileOption, directoryOption, exclude, fileNameEndInclude);
        }

        // copy whatever in a dir to anothr dir
        public static void MoveTo(DirectoryInfo source, DirectoryInfo target, FileExsitsOption fileOption = PShellUtil.FileExsitsOption.Override, DirectoryExsitsOption directoryOption = PShellUtil.DirectoryExsitsOption.Merge, string[] endExclude = null, string[] fileNameEndInclude = null)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            // Check if the source directory exists, if not, return
            if (Directory.Exists(source.FullName) == false)
            {
                return;
            }

            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                //if(exclude != null && Array.IndexOf(exclude, fi.Name) != -1) continue;
                if (endExclude != null)
                {
                    bool find = false;
                    foreach (var e in endExclude)
                    {
                        if (fi.Name.EndsWith(e))
                        {
                            find = true;
                            break;
                        }
                    }
                    if (find)
                    {
                        continue;
                    }
                }

                if (fileNameEndInclude != null)
                {
                    bool find = false;
                    foreach (var e in fileNameEndInclude)
                    {
                        if (fi.Name.EndsWith(e))
                        {
                            find = true;
                            break;
                        }
                    }
                    if (!find)
                    {
                        continue;
                    }
                }

                //Debug.Log(@"Copying " + target.FullName + "\\" + fi.Name);
                //fi.CopyTo(Path.Combine(target.ToString(), fi.Name), fileOption == FileExsitsOption.Override ? true : false);
                var t = Path.Combine(target.ToString(), fi.Name);
                if (File.Exists(t))
                {
                    File.Delete(t);
                }
                fi.MoveTo(t);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                //if(exclude != null && Array.IndexOf(exclude, diSourceSubDir.Name) != -1) continue;
                if (endExclude != null)
                {
                    bool find = false;
                    foreach (var e in endExclude)
                    {
                        if (diSourceSubDir.Name.EndsWith(e))
                        {
                            find = true;
                            break;
                        }
                    }
                    if (find)
                    {
                        continue;
                    }
                }

                bool exsits = Directory.Exists(target.FullName + "/" + diSourceSubDir.Name);
                bool hasEndFix = diSourceSubDir.Name.Contains(".");
                if (!hasEndFix)
                {
                    // treat as folder
                    if (directoryOption == DirectoryExsitsOption.Merge)
                    {
                        DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                        MoveTo(diSourceSubDir, nextTargetSubDir, fileOption, directoryOption, endExclude, fileNameEndInclude);
                    }
                    else if (directoryOption == DirectoryExsitsOption.Override)
                    {
                        DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                        nextTargetSubDir.Delete(true);
                        MoveTo(diSourceSubDir, nextTargetSubDir, fileOption, directoryOption, endExclude, fileNameEndInclude);

                    }
                    else if (directoryOption == DirectoryExsitsOption.NotCopy)
                    {
                        if (exsits)
                            return;
                        DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                        MoveTo(diSourceSubDir, nextTargetSubDir, fileOption, directoryOption, endExclude, fileNameEndInclude);
                    }
                }
                else
                {
                    // treat as file
                    if (fileOption == FileExsitsOption.Override)
                    {
                        DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                        nextTargetSubDir.Delete(true);
                        MoveTo(diSourceSubDir, nextTargetSubDir, fileOption, directoryOption, endExclude, fileNameEndInclude);
                    }
                    else if (fileOption == FileExsitsOption.NotCopy)
                    {
                        if (exsits)
                            return;
                        DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                        MoveTo(diSourceSubDir, nextTargetSubDir, fileOption, directoryOption, endExclude, fileNameEndInclude);

                    }
                }

            }
        }
    }
}