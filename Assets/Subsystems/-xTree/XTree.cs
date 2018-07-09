using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomLitJson;
using System;
using System.Text;
using System.Reflection;

public static class XTree
{
    public static object root;

    public static void Init(Type rootType)
    {
        root = Activator.CreateInstance(rootType);
    }

    public static XChangeLog Update(string path, string value)
    {
        var log = PathMover.Update(root, path, value);
        XChangeLogBank.GiveBack(log);
        return log;
    }

    public static List<XChangeLog> UpdateAll(List<XTransaction> list)
    {
        var ret = new List<XChangeLog>();
        foreach(var t in list)
        {
            var log = PathMover.Update(root, t.path, t.val);
            ret.Add(log);
        }
        foreach(var log in ret)
        {
            XChangeLogBank.GiveBack(log);
        }
        return ret;
    }
}


