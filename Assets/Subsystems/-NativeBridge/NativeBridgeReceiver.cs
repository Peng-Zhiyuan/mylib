using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeBridgeReceiver : MonoBehaviour {

    string id;
    string value;

    void OnCallReturnSetId(string id)
    {
        this.id = id;
    }

    void OnCallReturnSetValue(string value)
    {
        this.value = value;
    }

    void OnCallReturnComplete()
    {
        NativeBridge.OnCallReturn(this.id, this.value);
    }

    string clazz;
    string method;
    string arg;
    void OnNotifySetClass(string clazz)
    {
        this.clazz = clazz;
    }

    void OnNotifySetMethod(string method)
    {
        this.method = method;
    }

    void OnNotifySetArg(string arg)
    {
        this.arg = arg;
    }


    void OnNotifySend()
    {
        NativeBridge.OnNotify(clazz, method, arg);
    }

    string callId;
    string callClazz;
    string callMethod;
    string callArg;

    void OnCallSetId(string callId)
    {
        this.callId = callId;
    }

    void OnCallSetClass(string clazz)
    {
        this.callClazz = clazz;
    }

    void OnCallSetMethod(string method)
    {
        this.callMethod = method;
    }

    void OnCallSetArg(string arg)
    {
        this.callArg = arg;
    }

    void OnCallInvoke()
    {
        NativeBridge.OnUpstreamCall(this.callId, this.callClazz, this.callMethod, this.callArg);
    }


}
