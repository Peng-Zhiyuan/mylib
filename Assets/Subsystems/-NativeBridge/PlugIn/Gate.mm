//
//  GateC.cpp
//  Unity-iPhone
//
//  Created by zhiyuan.peng on 2017/9/21.
//
//

#include "Gate.h"
#include "Util.h"

NSMutableDictionary* upstreamCallDic = [[NSMutableDictionary alloc] init];
int upstreamCallCount = 0;
NSMutableArray* csharpMethodList = [[NSMutableArray alloc] init];

extern "C"
{
    void gateOnNotify(const char* clazzName, const char* msg, const char* arg)
    {
        NSString* ocClassName = CStringToOCString(clazzName);
        NSString* ocMsg = CStringToOCString(msg);
        NSString* ocArg = CStringToOCString(arg);
        //[Gate onNotify:ocClassName msg:ocMsg arg:ocArg];
        id clazz = NSClassFromString(ocClassName);
        NSString* selectorStirng = [NSString stringWithFormat:@"%@:", ocMsg];
        SEL selector = NSSelectorFromString(selectorStirng);
        if([clazz respondsToSelector:selector])
        {
            [clazz performSelector:selector withObject:ocArg];
        }

        
    }
    
    void gateOnCall(const char* callId, const char* clazzName, const char* msg, const char* arg)
    {
        NSString* ocCallId = CStringToOCString(callId);
        NSString* ocClassName = CStringToOCString(clazzName);
        NSString* ocMsg = CStringToOCString(msg);
        NSString* ocArg = CStringToOCString(arg);
        //[Gate onCall:ocCallId clazzName:ocClassName msg:ocMsg arg:ocArg];
        id clazz = NSClassFromString(ocClassName);
        NSString* selectorStirng = [NSString stringWithFormat:@"%@:arg:", ocMsg];
        SEL selector = NSSelectorFromString(selectorStirng);
        if([clazz respondsToSelector:selector])
        {
            [clazz performSelector:selector withObject:ocCallId withObject:ocArg];
        }
        else
        {
            gateCallReturn(ocCallId, @"");
        }
    }
    
    void gateOnRegisterCSharpMethod(const char* clazz, const char* method)
    {
        NSString* ocClazz = CStringToOCString(clazz);
        NSString* ocMethod = CStringToOCString(method);
        //[Gate onRegisterCSharpMethod:ocClazz method:ocMethod];
        NSString* fullName = [NSString stringWithFormat:@"%@.%@", ocClazz, ocMethod];
        [csharpMethodList addObject:fullName];
    }
    
    void gateOnUpstreamCallReturn(const char* callId, const char* result)
    {
        NSString* ocCallId = CStringToOCString(callId);
        NSString* ocResult = CStringToOCString(result);
        //[Gate onUpstreamCallReturn:ocCallId result:ocResult];
        void(^callback)(NSString*) = [upstreamCallDic valueForKey:ocCallId];
        if(callback != nil)
        {
            [upstreamCallDic removeObjectForKey:ocCallId];
            callback(ocResult);
        }
    }
    
    const char* gateOnSynCall(const char* clazzName, const char* method, const char* arg)
    {
        NSString* ocClazzName = CStringToOCString(clazzName);
        NSString* ocMethod = CStringToOCString(method);
        NSString* ocArg = CStringToOCString(arg);
        id clazz = NSClassFromString(ocClazzName);
        NSString* selectorStirng = [NSString stringWithFormat:@"%@:", ocMethod];
        SEL selector = NSSelectorFromString(selectorStirng);
        const char* cResult = "";
        if([clazz respondsToSelector:selector])
        {
            id ret = [clazz performSelector:selector withObject:ocArg];
            NSString* ocResult = (NSString*)ret;
            cResult = copyNSStringToCString(ocResult);
        }
        NSLog(@"[Gate] <- SynCall returns: %s", cResult);
        return strdup(cResult);
    }
}

void gateCallReturn(NSString* callId, NSString* result)
{
    NSLog(@"[Gate] <- call [%@] returns %@", callId, result);
    const char* cCallId = copyNSStringToCString(callId);
    const char* cResult = copyNSStringToCString(result);
    UnitySendMessage("NativeBridgeReceiver", "OnCallReturnSetId", cCallId);
    UnitySendMessage("NativeBridgeReceiver", "OnCallReturnSetValue", cResult);
    UnitySendMessage("NativeBridgeReceiver", "OnCallReturnComplete", "");
}

void gateUpstreamNotify(NSString* clazz, NSString* method, NSString* arg)
{
    const char* cClazz = copyNSStringToCString(clazz);
    const char* cMethod = copyNSStringToCString(method);
    const char* cArg = copyNSStringToCString(arg);
    UnitySendMessage("NativeBridgeReceiver", "OnNotifySetClass", cClazz);
    UnitySendMessage("NativeBridgeReceiver", "OnNotifySetMethod", cMethod);
    UnitySendMessage("NativeBridgeReceiver", "OnNotifySetArg", cArg);
    UnitySendMessage("NativeBridgeReceiver", "OnNotifySend", "");
}

void gateUpstreamCall(NSString* clazz, NSString* method, NSString* arg, void(^callback)(NSString* result))
{
    upstreamCallCount++;
    NSString* callId = [NSString stringWithFormat:@"%d", upstreamCallCount];
    [upstreamCallDic setObject:callback forKey:callId];
    const char* cCallId = copyNSStringToCString(callId);
    const char* cClazz = copyNSStringToCString(clazz);
    const char* cMethod = copyNSStringToCString(method);
    const char* cArg = copyNSStringToCString(arg);
    if(gateCSharpHasMethod(clazz, method))
    {
        UnitySendMessage("NativeBridgeReceiver", "OnCallSetId", cCallId);
        UnitySendMessage("NativeBridgeReceiver", "OnCallSetClass", cClazz);
        UnitySendMessage("NativeBridgeReceiver", "OnCallSetMethod", cMethod);
        UnitySendMessage("NativeBridgeReceiver", "OnCallSetArg", cArg);
        UnitySendMessage("NativeBridgeReceiver", "OnCallInvoke", "");
    }
    else
    {
        NSLog(@"cahrp method %@.%@ not exsists.", clazz, method);
        gateOnUpstreamCallReturn(cCallId, "");
    }
    
}

BOOL gateCSharpHasMethod(NSString* clazz, NSString* method)
{
    NSString* fullName = [NSString stringWithFormat:@"%@.%@", clazz, method];
    return [csharpMethodList containsObject:fullName];
}

