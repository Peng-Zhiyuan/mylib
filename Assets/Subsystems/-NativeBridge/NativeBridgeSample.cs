using UnityEngine;
using System.Collections;
using Edroity;

public class NativeBridgeSample : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NativeBridge.Init();
       
        NativeBridge.RegisterBrigeClass(typeof(TestBridgeClass));
        NativeBridge.SendNotify("TestBridgeClass", "OnTestNotify");
        NativeBridge.InvokeCall("TestBridgeClass", "TestCall", null, ret =>
            {
                Debug.Log("ret is: " + ret);
            });
        NativeBridge.SendNotify("TestBridgeClass", "OnTestUpstreamNotify");
        NativeBridge.SendNotify("TestBridgeClass", "OnTestUpstreamCall");
        var result = NativeBridge.SyncCall("TestBridgeClass", "TestSynCall");
        Debug.Log("Test Syn Call result is: " + result);
       
	}

    [UpstreamBridgeClass]
    public static class TestBridgeClass
    {
        [UpstreamNotify]
        public static void OnTestNotify(string args)
        {
            Debug.Log("onTestNotify");
        }

        [UpstreamCall]
        public static void TestUpstreamCall(string id, string args)
        {
            Debug.Log("up stream call SUCCESS!");
            NativeBridge.UpstreamCallReturn(id, "result");
        }
            
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
