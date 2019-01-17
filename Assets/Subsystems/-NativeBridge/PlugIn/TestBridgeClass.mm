//
//  NSObject_a.h
//  Unity-iPhone
//
//  Created by zhiyuan.peng on 2017/10/9.
//
//

#import <Foundation/Foundation.h>
#import "TestBridgeClass.h"
#import "Gate.h"

@implementation TestBridgeClass : NSObject

+ (void)OnTestNotify:(NSString*)arg
{
    NSLog(@"Test Notify SUCCESS!");
}

+ (void)TestCall:(NSString*)callId arg:(NSString*)arg
{
    NSLog(@"Test Call arrival native");
    gateCallReturn(callId, @"[TestCallResult]");
}

+ (void)OnTestUpstreamNotify:(NSString*)arg
{
    gateUpstreamNotify(@"TestBridgeClass", @"OnTestNotify", @"[TestNotifyArg]");
}

+ (void)OnTestUpstreamCall:(NSString*)arg
{
    gateUpstreamCall(@"TestBridgeClass", @"TestUpstreamCall", @"[TestUpstreamCallArg]", ^(NSString *result) {
        NSLog(@"Test UpstreamCall Success, result is %@", result);
    });
}

+ (NSString*)TestSynCall:(NSString*)arg
{
    NSLog(@"Test SynCall arrival native");
    return @"[TestSynCallResult]";
}

@end

