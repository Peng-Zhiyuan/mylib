using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class XChangeLog  
{
    public string path;
    public Type type;
    public object before;
    public object after;
    public double delta;

    public override string ToString()
    {
        var _path = ToStirng(path);
        var _type = ToStirng(type?.Name);
        var _before = ToStirng(before);
        var _after = ToStirng(after);
        var _delta = ToStirng(delta);
        return "[XChangeLog] path: " + _path + ", type: " + _type + ",  " + _before + " -> " + _after + ", delta: " + delta;
    }

    private static string ToStirng(object o)
    {
        if(o == null)
        {
            return "null";
        }
        return o.ToString();
    }
}
