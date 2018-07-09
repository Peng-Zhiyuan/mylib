using UnityEngine;
using System.Collections;
using Edroity;

public class DownstreamCall : CustomYieldInstruction {

    private bool wait;
    public string result;

    public DownstreamCall(string clazz, string method, string arg = null)
    {
        this.wait = true;
        NativeBridge.InvokeCall(clazz, method, arg, OnResult);
    }

    private void OnResult(string result)
    {
        this.result = result;
        this.wait = false;
    }

    public override bool keepWaiting
    {
        get
        {
            return wait;
        }
    }
}

