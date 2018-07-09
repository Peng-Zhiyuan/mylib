using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace Edroity
{
    public enum GateType
    {
        None,
        Android,
        iOS,
        DotNet,
    }

    public class NativeBridge
    {
        private static AndroidJavaClass javaGateProxy;
        private static int callCount;
        private static Dictionary<string, Action<string>> callReturnListenerDic;
        private static Dictionary<string, Type> brigeClassDic;
        private static bool isInited;

        public static bool IsInited
        {
            get
            {
                return isInited;
            }
        }

        public static void Init()
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                javaGateProxy = new AndroidJavaClass("com.edroity.nativebrige.Gate");
            }
            callCount = 0;
            callReturnListenerDic = new Dictionary<string, Action<string>>();
            brigeClassDic = new Dictionary<string, Type>();
            var root = new GameObject();
            root.name = "NativeBridgeReceiver";
            GameObject.DontDestroyOnLoad(root);
            root.AddComponent<NativeBridgeReceiver>();
            isInited = true;
        }

        static public GateType PlatformGate
        {
            get
            {
                switch (Application.platform)
                {
                    case RuntimePlatform.Android:
                        return GateType.Android;
                    case RuntimePlatform.IPhonePlayer:
                        return GateType.iOS;
                    case RuntimePlatform.WindowsEditor:
                    case RuntimePlatform.OSXEditor:
                        return GateType.DotNet;
                    default:
                        throw new Exception("unsupport platform: " + Application.platform);
                }
            }
        }
            
        public static void SendNotify(String clazz, String method, String args = null, params GateType[] gateTypeList)
        {
            SendNotify(new Notify{ clazz = clazz, method = method, arg = args }, gateTypeList);
        }
 
        public static void SendNotify(Notify notify, params GateType[] gateTypeList)
        {
            if (gateTypeList.Length == 0)
            {
                gateTypeList = new GateType[]{ PlatformGate };
            }
            foreach (var gate in gateTypeList)
            {
                switch (gate)
                {
                    case GateType.Android:
                        javaGateProxy.CallStatic("onNotify", new object[]{ notify.clazz, notify.method, notify.arg });
                        break;
                    case GateType.iOS:
                        OCGateProxy.gateOnNotify(notify.clazz, notify.method, notify.arg);
                        break;   
                    case GateType.DotNet:
                        Gate.OnNotify(notify.clazz, notify.method, notify.arg);
                        break;
                }
            }
        }

        public static void InvokeCall(string clazz, string method, string arg = null, Action<string> callback = null, GateType gate = GateType.None)
        {
            InvokeCall(new Call{ clazz = clazz, method = method, arg = arg }, callback, gate);
        }

        public static void InvokeCall(Call call, Action<string> onReturn = null, GateType gate = GateType.None)
        {
            if (gate == GateType.None)
            {
                gate = PlatformGate;
            }
            callCount++;
            string callId = callCount.ToString();
            if (onReturn != null)
            {
                callReturnListenerDic[callId] = onReturn;
            }
            switch (gate)
            {
                case GateType.Android:
                    javaGateProxy.CallStatic("onCall", new object[]{ callId, call.clazz, call.method, call.arg });
                    break;
                case GateType.iOS:
                    OCGateProxy.gateOnCall(callId, call.clazz, call.method, call.arg);
                    break;
                case GateType.DotNet:
                    Gate.OnCall(callId, call.clazz, call.method, call.arg);
                    break;
            }
        }

        public static void OnCallReturn(string id, string ret)
        {
            Action<string> listenr;
            callReturnListenerDic.TryGetValue(id, out listenr);
            if (listenr != null)
            {
                callReturnListenerDic.Remove(id);
                listenr(ret);
            }
        }

        public static void RegisterBrigeClass(Type type, params GateType[] gateList)
        {
            if (!NativeBridgeUtil.HasAttribute<UpstreamBridgeClassAttribute>(type))
            {
                Debug.LogError("[NativeBridge] type [" + type + "] is not a UpstreamBridgeClass");
                return;
            }

            brigeClassDic[type.Name] = type;

            var methodList = type.GetMethods(BindingFlags.Static | BindingFlags.Public);

            if (gateList.Length == 0)
            {
                gateList = new GateType[]{ PlatformGate };
            }
            foreach (var gate in gateList)
            {
                switch (gate)
                {
                    case GateType.Android:
                        foreach (var method in methodList)
                        {
                            if (NativeBridgeUtil.HasAttribute(method, typeof(UpstreamCallAttribute)))
                            {
                                javaGateProxy.CallStatic("onRegisterCSharpMethod", new object[]{ type.Name, method.Name });
                            }
                        }
                        break;
                    case GateType.iOS:
                        foreach (var method in methodList)
                        {
                            if (NativeBridgeUtil.HasAttribute(method, typeof(UpstreamCallAttribute)))
                            {
                                OCGateProxy.gateOnRegisterCSharpMethod(type.Name, method.Name);
                            }
                        }
                        break;
                    case  GateType.DotNet:
                    // 编辑器环境Gate不进行方法检查
                        break;
                }
            }
                    
        }

        public static void OnNotify(string clazzName, string methodName, string arg)
        {
            Type type;
            brigeClassDic.TryGetValue(clazzName, out type);
            if(type == null)
            {
                Debug.LogWarning("[NativeBrige] BrigeClass: " + clazzName + " not registered.");
                return;
            }
            var method = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);
            if (method == null)
            {
                Debug.LogWarning("[NativeBrige] BrigeNotify method: " + methodName + " not fountd int class: " + clazzName);
                return;
            }

            var argTypeList = method.GetParameters();
            if (argTypeList.Length == 1)
            {
                method.Invoke(null, new object[]{ arg });
            }
            else if (argTypeList.Length == 0)
            {
                method.Invoke(null, new object[]{ });
            }
            else
            {
                Debug.LogWarning("[NativeBrige] " + clazzName + "." + methodName + " has " + argTypeList.Length + " arguments, invalid" );
            }
               
        }

        public static void OnUpstreamCall(string callId, string clazzName, string methodName, string arg)
        {
            Type type;
            brigeClassDic.TryGetValue(clazzName, out type);
            if(type == null)
            {
                Debug.LogWarning("[NativeBrige] BrigeClass: " + clazzName + " not registered.");
                UpstreamCallReturn(callId, "");
                return;
            }
            var method = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);
            if (method == null)
            {
                UpstreamCallReturn(callId, "");
                Debug.LogWarning("[NativeBrige] BrigeNotify method: " + methodName + " not fountd int class: " + clazzName);
                return;
            }
           

            var argTypeList = method.GetParameters();
            if (argTypeList.Length == 2)
            {
                method.Invoke(null, new object[]{ callId, arg });
            }
            else if (argTypeList.Length == 1)
            {
                method.Invoke(null, new object[]{ callId });
            }
            else
            {
                Debug.LogWarning("[NativeBrige] " + clazzName + "." + methodName + " has " + argTypeList.Length + " arguments, invalid" );
            }
        }

        public static void UpstreamCallReturn(string callId, string result)
        {
            GateType gate;
            if (callId.StartsWith("d"))
            {
                gate = GateType.DotNet;
            }
            else
            {
                gate = PlatformGate;
            }
            switch (gate)
            {
                case GateType.Android:
                    javaGateProxy.CallStatic("onUpstreamCallReturn", new object[]{ callId, result });
                    break;
                case GateType.iOS:
                    OCGateProxy.gateOnUpstreamCallReturn(callId, result);
                    break;
                case GateType.DotNet:
                    Gate.OnUpstreamCallReturn(callId, result);
                    break;
            }
        }

        public static string SyncCall(string clazz, string method, string arg = null, GateType gate = GateType.None)
        {
            if (gate == GateType.None)
            {
                gate = PlatformGate;
            }
            switch (gate)
            {
                case GateType.Android:
                    return javaGateProxy.CallStatic<string>("onSynCall", clazz, method, arg);
                    break;
                case GateType.iOS:
                    //OCGateProxy.gateCOnCall(callId, call.clazz, call.method, call.arg);
                    return OCGateProxy.gateOnSynCall(clazz, method, arg);
                    break;
                case GateType.DotNet:
                    return Gate.OnSyncCall(clazz, method, arg);
                    break;
            }
            return "";
        }

 
    }



    public struct Notify
    {
        public string clazz;
        public string method;
        public string arg;
    }

    public struct Call
    {
        public string clazz;
        public string method;
        public string arg;
    }
}

