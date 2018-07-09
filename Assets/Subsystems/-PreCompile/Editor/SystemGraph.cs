using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CustomLitJson;
using UnityEditor;
using System.IO;
using System;

public static class SystemGraph  
{
    private static string SYSTEMS_ROOT = "Assets/[Subsystems]";

    [MenuItem("PreCompile/SystemGraph")]
    public static void ShowSystemGraph()
    {
        {
            var list = FindAllSystemsName(SYSTEMS_ROOT);
            nameToInfo.Clear();
            // create name to info mapping
            foreach (var info in list)
            {
                //Debug.Log(info.name + ": " + info.cachedPath);
                nameToInfo[info.name] = info;
            }
        }

        // check erver dependency in dic
        {
            foreach (var kv in nameToInfo)
            {
                var name = kv.Key;
                var info = kv.Value;
                foreach (var d in info.dependency)
                {
                    if (!nameToInfo.ContainsKey(d))
                    {
                        throw new Exception("dependency: " + d + " not found in " + name);
                    }
                }
            }
        }

        // create chached user
        {
            foreach (var kv in nameToInfo)
            {
                var info = kv.Value;
                foreach (var dependentName in info.dependency)
                {
                    var dependentInfo = nameToInfo[dependentName];
                    dependentInfo.cachedUser.Add(info.name);
                }
            }
        }

        // find no dependency system
        {
            var one = FindNoDependencySystem();
            var nextLayerList = new List<string>();
            var nextLayer = 0;
            while(one.Count > 0)
            {
                foreach(var name in one)
                {
                    var info = nameToInfo[name];
                    info.cachedLayer = nextLayer;
                    foreach (var d in info.cachedUser)
                    {
                        nextLayerList.Add(d);
                    }
                }
                var temp = one;
                one = nextLayerList;
                nextLayerList = temp;
                nextLayerList.Clear();
                nextLayer++;
                if (nextLayer >= 100)
                {
                    new Exception("I think some is wrong");
                }
            }
        }
       
        // print
//        foreach (var kv in nameToInfo)
//        {
//            var name = kv.Key;
//            var info = kv.Value;
//            Debug.Log( name + ": " + info.cachedLayer + " ->" + string.Join(",", info.dependency.ToArray()));
//        }

        SystemGraphWindow.Show(nameToInfo);

    }

    public static List<SystemNodeInfo> FindAllSystemsName(string root)
    {
        var subDirList = Directory.GetDirectories(SYSTEMS_ROOT, "*", SearchOption.TopDirectoryOnly);
        var systemInfoList = new List<SystemNodeInfo>();
        foreach(var path in subDirList)
        {
            var name = Path.GetFileName(path);
            if (!name.StartsWith("-"))
            {
                continue;
            }
            var info = CreateSystemInfo(path, name);
            systemInfoList.Add(info);

        }
        return systemInfoList;
    }

    private static SystemNodeInfo CreateSystemInfo(string systemPath, string name)
    {
        var ret = new SystemNodeInfo();
        ret.name = name;
        ret.cachedPath = systemPath;
        var manifestPath = systemPath + "/system-manifest.json";
        if (File.Exists(manifestPath))
        {
            var text = File.ReadAllText(manifestPath);
            var jo = JsonMapper.Instance.ToObject(text);
            var dependencyJD = jo.TryGet<JsonData>("dependency", null);
            if (dependencyJD != null)
            {
                if (dependencyJD.IsArray)
                {
                    foreach (JsonData item in dependencyJD)
                    {
                        if (item.IsString)
                        {
                            ret.dependency.Add(item.ToString());
                        }
                    }
                }
                else if (dependencyJD.IsString)
                {
                    ret.dependency.Add(dependencyJD.ToString());
                }
            }
        }
        return ret;

    }

    private static Dictionary<string, SystemNodeInfo> nameToInfo = new Dictionary<string, SystemNodeInfo>();

    private static List<string> FindNoDependencySystem()
    {
        var ret = new List<string>();
        foreach (var kv in nameToInfo)
        {
            var name = kv.Key;
            var info = kv.Value;
            if (info.dependency.Count == 0)
            {
                ret.Add(name);
            }
        }
        if (nameToInfo.Count != 0 && ret.Count == 0)
        {
            throw new Exception("every system has dependency, is here a circal refrence?");
        }
        return ret;
    }
}
    
public class SystemNodeInfo
{
    public string name;
    public List<string> dependency = new List<string>();
    public string cachedPath;

    public List<string> cachedUser = new List<string>();
    public int cachedLayer = -1;
}
