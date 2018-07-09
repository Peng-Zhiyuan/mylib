using System;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Diagnostics;

public static class HandlerManager
{
	static Dictionary<Type, Handler> dic = new Dictionary<Type, Handler>();

	public static void CreateHandlers()
	{
        var sw = new Stopwatch();
        sw.Start();

        var list = HandlerManagerInternal.ReflectionHelper.GetSubClasses<Handler>();
		foreach(var type in list)
		{
			var system = Activator.CreateInstance(type) as Handler;
            dic.Add(type, system);
            UnityEngine.Debug.Log("[HandlerManager]: " + type.Name + " 已创建.");
            // 赋值instance变量
            var instanceField = type.GetField("instance", BindingFlags.Public | BindingFlags.Static);
            if(instanceField != null)
            {
                instanceField.SetValue(null, system);
            }
        } 

        sw.Stop();
        UnityEngine.Debug.Log("[HandlerManager]: "+ list.Count + " handler(s) created, use : " + sw.ElapsedMilliseconds + "ms");

        foreach (var kv in dic)
        {
            kv.Value.OnCreate();
        }
    }

	public static T Get<T>() where T: Handler
    {
		return dic[typeof(T)] as T;
	}

	private static void Log(string msg)
	{
		
	}
        
}

public class Handler
{
	public virtual void OnCreate(){}
}
