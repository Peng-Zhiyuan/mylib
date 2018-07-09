using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SSM 
{
    public ChunkPort port = new ChunkPort();

    Dictionary<string, object> variablesDic = new Dictionary<string, object>();
    UInt16 maxResovedCallId;

    enum ReservedCallID
    {
        RemoteSetVariable = 1,
        MAX,
    }

    public SSM()
    {
        port.call.RegisterMethod((UInt16)ReservedCallID.RemoteSetVariable, OnRemoteSetVariable);
        maxResovedCallId = (UInt16)ReservedCallID.MAX;
    }

    public void Set(string name, object value)
    {
        variablesDic[name] = value;
        port.call.Send((UInt16)ReservedCallID.RemoteSetVariable, name, value);
    }

    public object Get(string name)
    {
        object v;
        variablesDic.TryGetValue(name, out v);
        return v;
    }

    public object this[string name]
    {
        get
        {
            return Get(name);
        }
        set
        {
            Set(name, value);
        }
    }

    private void OnRemoteSetVariable(object[] args)
    {
        var name = args[0] as string;
        var value = args[1];
        variablesDic[name] = value;
    }

    public void RegisterType(Type type)
    {
        port.call.RegisterType(type);
    }

    public void RegisterCall(UInt16 id, Action<object[]> handler)
    {
        if(id < maxResovedCallId)
        {
            throw new Exception(string.Format("[SSM] call id can not less than {0}",maxResovedCallId));
        }
        port.call.RegisterMethod(id, handler);
    }

    public void Call(UInt16 id, params object[] arg)
    {
        if(id < maxResovedCallId)
        {
            throw new Exception(string.Format("[SSM] call id can not less than {0}",maxResovedCallId));
        }
        var localHanler = port.call.TryGetEventHandler(id);
        if(localHanler != null)localHanler.Invoke(arg);
        port.call.Send(id, arg);
    }

}
