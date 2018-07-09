using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class OCGateProxy  {
    #if UNITY_IOS
    [DllImport("__Internal")]
    #endif
    public static extern void gateOnNotify(string clazzName, string msg, string arg);

    #if UNITY_IOS
    [DllImport("__Internal")]
    #endif
    public static extern void gateOnCall(string callId, string clazzName, string msg, string arg);

    #if UNITY_IOS
    [DllImport("__Internal")]
    #endif
    public static extern void gateOnRegisterCSharpMethod(string clazz, string method);

    #if UNITY_IOS
    [DllImport("__Internal")]
    #endif
    public static extern void gateOnUpstreamCallReturn(string callId, string result);

    #if UNITY_IOS
    [DllImport("__Internal")]
    #endif
    public static extern string gateOnSynCall(string clazzName, string method, string arg);
}
