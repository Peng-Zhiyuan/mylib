using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PreCompileInternal;

public static class PreComileConfiger 
{
    public static string gmcs;
    public static string managed;

    private static Properties _properties;
    private static Properties properties
    {
        get
        {
            if (_properties == null)
            {
                _properties = new Properties("./PreCompile/LocalSettings.properties");
            }
            return _properties;
        }
    }

    public static void Save()
    {
        var p = properties;
        p["gmcs"] = gmcs;
        p["managed"] = managed;
        p.Save();
    }

    public static void Load()
    {
        var p = properties;
		p.Reload();
        gmcs = p["gmcs"];
        managed = p["managed"];
    }

}
