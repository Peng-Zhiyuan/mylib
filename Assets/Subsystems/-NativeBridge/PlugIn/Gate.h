//
//  GateC.h
//  Unity-iPhone
//
//  Created by zhiyuan.peng on 2017/9/21.
//
//

#ifndef Gate_h
#define Gate_h

#include <stdio.h>

extern "C"
{
    void gateOnNotify(const char* clazzName, const char* msg, const char* arg);
    
    void gateOnCall(const char* callId, const char* clazzName, const char* msg, const char* arg);
    
    void gateOnRegisterCSharpMethod(const char* clazz, const char* method);
    
    void gateOnUpstreamCallReturn(const char* callId, const char* result);
    
    const char* gateOnSynCall(const char* clazzName, const char* method, const char* arg);
}

void gateCallReturn(NSString* callId, NSString* result);

void gateUpstreamNotify(NSString* clazz, NSString* method, NSString* arg);

void gateUpstreamCall(NSString* clazz, NSString* method, NSString* arg, void(^callback)(NSString* result));

BOOL gateCSharpHasMethod(NSString* clazz, NSString* method);

#endif /* GateC_h */
