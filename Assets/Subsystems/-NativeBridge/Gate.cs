using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

public class Gate {

    //static Dictionary<string, Type> bridgeClassDic = new Dictionary<string, Type>();

    // public static void RegisterBridgeClass(Type bridgeClass)
    // {
    //     bridgeClassDic[bridgeClass.Name] = bridgeClass;
    // }

    public static void OnNotify(string clazzName, string methodName, string arg)
    {
        Log("-> OnNotify " + clazzName + "." + methodName + " " + arg);
        String clazzPath = "BridgeClasses." + clazzName;
        Type clazz = typeof(Gate).Assembly.GetType(clazzPath);
        // Type clazz;
        // bridgeClassDic.TryGetValue(clazzName, out clazz);
        if (clazz != null)
        {
            var method = clazz.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
            if (method != null)
            {
                var argTypes = method.GetParameters();
                if (argTypes.Length == 1)
                {
                    method.Invoke(null, new object[] { arg });
                }
                else if (argTypes.Length == 0)
                {
                    method.Invoke(null, new object[] { });
                }
                else
                {
                    Log(clazzName + "." + methodName + " has " + argTypes.Length + " arguments, invalid.");
                }
            }
            else
            {
                Log("method " + methodName + " not found in " + clazzName);
            }
        }
        else
        {
            Log("clazz " + clazzPath + " not found");
        }
    }

    public static void Log(string msg)
    {
        Debug.Log("[Gate] " + msg);
    }

    public static void OnCall(string callId, string clazzName, string methodName, string arg)
    {
        Log("-> OnCall " + clazzName + "." + methodName + " " + arg);
        // Type clazz;
        // bridgeClassDic.TryGetValue(clazzName, out clazz);
        String clazzPath = clazzName;
        Type clazz = typeof(Gate).Assembly.GetType(clazzPath);
        if (clazz != null)
        {
            var method = clazz.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
            if (method != null)
            {
                var argTypes = method.GetParameters();
                if (argTypes.Length == 2)
                {
                    method.Invoke(null, new object[] { callId, arg });
                }
                else if (argTypes.Length == 1)
                {
                    method.Invoke(null, new object[] { callId });
                }
                else
                {
                    Log(clazzName + "." + methodName + " has " + argTypes.Length + " arguments, invalid.");
                    CallReturn(callId, "");
                }
            }
            else
            {
                Log("method " + methodName + " not found in " + clazzName);
                CallReturn(callId, "");
            }
        }
        else
        {
            Log("clazz " + clazzPath + " not found");
            CallReturn(callId, "");
        }
    }

    public static void CallReturn(string callId, string result)
    {
        Log("-> call [" + callId + "] returns " + result);
        NativeBridge.OnCallReturn(callId, result);
    }

    public static void UpstreamNotify(string clazz, string method, string arg = null)
    {
        Log("-> upstream notify " + clazz + "." + method + " " + arg);
        NativeBridge.OnNotify(clazz, method, arg);
    }

    static int upstreamCallCount = 0;
    static Dictionary<string, Action<string>> upstreamCallDic = new Dictionary<string, Action<string>>();

    public static void UpstreamCall(string clazz, string method, string arg = null, Action<string> callback = null)
    {
        upstreamCallCount++;
        var callId = "d" + upstreamCallCount.ToString();
        Log("-> upstream call [" + callId + "] " + clazz + "." + method + " " + arg);
        upstreamCallDic[callId] = callback;
        NativeBridge.OnUpstreamCall(callId, clazz, method, arg);
    }

    public static void OnUpstreamCallReturn(string callId, string result)
    {
        Log("-> upstream call [" + callId + "] returns " + result);
        Action<string> callback;
        upstreamCallDic.TryGetValue(callId, out callback);
        if (callback != null)
        {
            upstreamCallDic.Remove(callId);
            callback(result);
        }
    }

    public static string OnSyncCall(string clazzName, string methodName, string arg)
    {
        Log("-> OnSyncCall " + clazzName + "." + methodName + " " + arg);
        // Type clazz;
        // bridgeClassDic.TryGetValue(clazzName, out clazz);
        String clazzPath = "BridgeClasses." + clazzName;
        Type clazz = typeof(Gate).Assembly.GetType(clazzPath);
        if (clazz != null)
        {
            var method = clazz.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
            if (method != null)
            {
                var argTypes = method.GetParameters();
                if (argTypes.Length == 1)
                {
                    return method.Invoke(null, new object[] { arg }) as string;
                }
                else if (argTypes.Length == 0)
                {
                    return method.Invoke(null, new object[] { }) as string;
                }
                else
                {
                    Log(clazzName + "." + methodName + " has " + argTypes.Length + " arguments, invalid.");
                }
            }
            else
            {
                Log("method " + methodName + " not found in " + clazzName);
            }
        }
        else
        {
            Log("clazz " + clazzPath + " not found");
        }
        return "";
    }
}