using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using PreCompileInternal;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;


public class PreCompile  
{
    [MenuItem("PreCompile/Compile")]
    public static void Compile()
    {
        if (Application.platform != RuntimePlatform.OSXEditor)
        {
            EditorUtility.DisplayDialog("PreCompile", "Only Supported on Mac", "quit");
            return;
        }

        UnityEngine.Object[] arr=Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel);  

        // to path list
        List<string> pathList = new List<string>();
        foreach (var asset in arr)
        {
            var path = AssetDatabase.GetAssetPath(asset);
            pathList.Add(path);
        }
        OnlyKeepSystemDir(pathList);
        if (pathList.Count == 0)
        {
            return;
        }

        var gmcs = GetGmcs();
        if (gmcs == null)
        {
            return;
        }
        var managed = GetManaged();
        if (managed == null)
        {
            return;
        }

        foreach (var path in pathList)
        {
            var systemRoot = path;
            var systemName = Path.GetFileName(systemRoot);
            var unityEngine = managed + "/UnityEngine.dll";
            var unityEditor = managed + "/UnityEditor.dll";
            var recurse = systemRoot + "/*.cs";
            var o = systemRoot + "/" + systemName + ".dll"; 
            var define = "UNITY_EDITOR";
            var r = unityEngine + "," + unityEditor;
            var target = "library";
            var arg = @"-r:" + r + " -target:" + target + " -recurse:" + recurse + " -define:" + define + " -out:" + o;

            var ret = Exec.Run(gmcs, arg, true);
            if (ret == 0)
            {
                PShellUtil.MoveTo(path, "PreCompile/Compiled/" + systemName, PShellUtil.FileExsitsOption.Override, PShellUtil.DirectoryExsitsOption.Merge, null, new string[] { ".cs", ".cs.meta" });
                // delete out dll in codebase
                PShellUtil.DeleteEmptyDirectory(systemRoot);
            }
            else
            {
                Debug.LogError("[PreCompile] Error: " + ret);
            }
        }
        AssetDatabase.Refresh();
    }

    private static string GetGmcs()
    {
        PreComileConfiger.Load();
        var gmcs = PreComileConfiger.gmcs;
        if (string.IsNullOrEmpty(gmcs) || !File.Exists(gmcs))
        {
            EditorUtility.DisplayDialog("PreCompile", "Select gmcs", "select");
            string path = EditorUtility.OpenFilePanel("select gmcs", "/Applications/Unity/Unity.app/Contents/Mono/bin", "");
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("canceled");
                return null;
            }
            if (!Path.GetFileName(path).Contains("mcs"))
            {
                Debug.LogError("file name must be gmcs");
                return null;
            }
            gmcs = path;
            PreComileConfiger.gmcs = gmcs;
            PreComileConfiger.Save();
        }
        return gmcs;
    }

    private static string GetManaged()
    {
        PreComileConfiger.Load();
        var managed = PreComileConfiger.managed;
        if (string.IsNullOrEmpty(managed) || !Directory.Exists(managed))
        {
            EditorUtility.DisplayDialog("PreCompile", "Select dir: Managed", "select");
            string path = EditorUtility.OpenFolderPanel("select gmcs", "/Applications/Unity/Unity.app/Contents", "");
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("canceled");
                return null;
            }
            if (Path.GetFileName(path) != "Managed")
            {
                Debug.LogError("dir name must be Managed");
                return null;
            }
            managed = path;
            PreComileConfiger.managed = managed;
            PreComileConfiger.Save();
        }
        return managed;
    }

    private static void OnlyKeepSystemDir(List<string> pathList)
    {
        for (int i = pathList.Count - 1; i >= 0; i--)
        {
            var path = pathList[i];
            var name = Path.GetFileName(path);
            if (!name.StartsWith("-"))
            {
                pathList.RemoveAt(i);
            }
        }
    }
        
    [MenuItem("PreCompile/Restore")]
    public static void Restore()
    {
        UnityEngine.Object[] arr = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel);  

        // to path list
        List<string> pathList = new List<string>();
        foreach (var asset in arr)
        {
            var path = AssetDatabase.GetAssetPath(asset);
            pathList.Add(path);
        }
        OnlyKeepSystemDir(pathList);
        if (pathList.Count == 0)
        {
            return;
        }

        // remove systems which hasn't dll
        for (int i = pathList.Count - 1; i >= 0; i--)
        {
            var dir = pathList[i];
            var systemName = Path.GetFileName(dir);
            var dllName = systemName + ".dll";
            var dlls = Directory.GetFiles(dir, dllName, SearchOption.TopDirectoryOnly); 
            if (dlls.Length == 0)
            {
                pathList.RemoveAt(i);
            }
        }

        if (pathList.Count == 0)
        {
            return;
        }

        foreach (var path in pathList)
        {
            Debug.Log("[PreCompile] restore: " + path);
            var name = Path.GetFileName(path);
            PShellUtil.MoveTo("PreCompile/Compiled/" + name, path);
            var dll = path + "/" + name + ".dll";
            File.Delete(dll);
            PShellUtil.DeleteEmptyDirectory("PreCompile/Compiled/" + name);

        }
        AssetDatabase.Refresh();
    }

    [MenuItem("PreCompile/ViewCompiled")]
    public static void ViewCompiled()
    {
        EditorUtility.OpenWithDefaultApp("PreCompile/Compiled");
    }

    [MenuItem("PreCompile/ResetLocalSettings")]
    public static void ResetLocalSettings()
    {
        File.Delete("PreCompile/LocalSettings.properties");
    }
}

