using UnityEngine;
using System.Collections;

public class NativeBridgeSample : MonoBehaviour 
{
	// Use this for initialization
	void Start () {

        NativeBridge.SendNotify("NativeClass", "NotifyHandler");
        NativeBridge.InvokeCall("NativeClass", "CallHandler", null, ret =>
            {
                Debug.Log("ret is: " + ret);
            });
        var result = NativeBridge.SyncCall("NativeClass", "SynCallHandler");
        Debug.Log("Test Syn Call result is: " + result);
	}
	
}

namespace BrideClasses
{
    public static class NativeClass
    {
        public static void NotifyHandler(string args)
        {
            Debug.Log("NativeMethod run");
        }

        public static void CallHandler(string id, string args)
        {
            Debug.Log("call SUCCESS!");
            Gate.CallReturn(id, "result");
        }
        public static string SynCallHandler(string args)
        {
            Debug.Log("syncall SUCCESS!");
            return "SUCCESS";
        }
    } 
}

namespace UpstreamClasses
{
    public static class UpstreamClasse
    {
        public static void UpstreamCallHandler(string id, string args)
        {
            Debug.Log("up stream call SUCCESS!");
            NativeBridge.UpstreamCallReturn(id, "result");
        }
    }

}