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
#import <YZTEmotionSdk/YZTEmotionManager.h>
#import "NativeEmotion.h"
#import <JSONMatcher/JSONMatcher.h>


@implementation NativeEmotion : NSObject

+ (UIImage*) Base64ToImage:(NSString*) base64String
{
    if(base64String == nil)
    {
        NSLog(@"[Base64ToImage] base64String is nil");
        return nil;
    }
    NSData *decodedData = [[NSData alloc] initWithBase64EncodedString:base64String options:NSDataBase64DecodingIgnoreUnknownCharacters];

    if(decodedData == nil)
    {
        NSLog(@"[Base64ToImage] data is nil");
        return nil;
    }
    
    UIImage *image = [UIImage imageWithData:decodedData];
    if(image == nil)
    {
        NSLog(@"[Base64ToImage] image is nil");
        return nil;
    }
    return image;
}



+ (NSDictionary*) FaceItemToDictionary:(YZTFaceItem*) face
{
    id dic = [[NSMutableDictionary alloc] init];
    id faceRect = [NativeEmotion CGRectToDictionary:face.faceRect];
    id isMaxFace = face.isMaxFace ? @1 : @0;
    id leftEyesPos = [NativeEmotion CGPointToDictionary:face.leftEyesPos];
    id rightEyesPos = [NativeEmotion CGPointToDictionary:face.rightEyesPos];
    id leftMouthCornerPos = [NativeEmotion CGPointToDictionary:face.leftMouthCornerPos];
    id rightMouthCornerPos = [NativeEmotion CGPointToDictionary:face.rightMouthCornerPos];
    id emotion = face.emotion;
    id direction = face.direction;
    
    [dic setObject:faceRect forKey:@"faceRect"];
    [dic setObject:isMaxFace forKey:@"isMaxFace"];
    [dic setObject:leftEyesPos forKey:@"leftEyesPos"];
    [dic setObject:rightEyesPos forKey:@"rightEyesPos"];
    
    [dic setObject:leftMouthCornerPos forKey:@"leftMouthCornerPos"];
    [dic setObject:rightMouthCornerPos forKey:@"rightMouthCornerPos"];
    if(emotion != nil)
    {
        [dic setObject:emotion forKey:@"emotion"];
    }
    if(direction != nil)
    {
        [dic setObject:direction forKey:@"direction"];
    }

    return dic;
}

+ (NSDictionary*) CGRectToDictionary:(CGRect) rect
{
    id dic = [[NSMutableDictionary alloc] init];
    id origin = [NativeEmotion CGPointToDictionary:rect.origin];
    id size = [NativeEmotion CGSizeToDictionary:rect.size];
    [dic setObject:origin forKey:@"origin"];
    [dic setObject:size forKey:@"size"];
    return dic;
}

+ (NSDictionary*) CGSizeToDictionary:(CGSize) size
{
    id dic = [[NSMutableDictionary alloc] init];
    id width = [NSNumber numberWithDouble:size.width];
    id height = [NSNumber numberWithDouble:size.height];
    [dic setObject:width forKey:@"width"];
    [dic setObject:height forKey:@"height"];
    return dic;
}

+ (NSDictionary*) CGPointToDictionary:(CGPoint) point
{
    id dic = [[NSMutableDictionary alloc] init];
    id x = [NSNumber numberWithDouble:point.x];
    id y = [NSNumber numberWithDouble:point.y];
    [dic setObject:x forKey:@"x"];
    [dic setObject:y forKey:@"y"];
    return dic;
}

+ (NSArray<NSDictionary*>*) FaceListToDictionaryList:(NSArray<YZTFaceItem *>*) list
{
    id ret = [[NSMutableArray alloc] init];
    for(int i = 0; i < list.count; i++)
    {
        id face = [list objectAtIndex:i];
        id faceDic = [NativeEmotion FaceItemToDictionary:face];
        [ret addObject:faceDic];
    }
    return ret;
}

+ (void)SetEmotionCheck:(NSString*)callId arg:(NSString*)arg
{
    bool b = [arg isEqualToString:@"true"];
    [YZTEmotionManager shareInstance].hasEmotionCheck = b;
}

+ (void)SetDirectionCheck:(NSString*)callId arg:(NSString*)arg
{
    bool b = [arg isEqualToString:@"true"];
    [YZTEmotionManager shareInstance].hasDirectionCheck = b;
}

// arg: base64ImageData
+ (void)Check:(NSString*)callId arg:(NSString*)arg
{
    NSLog(@"[OC] NativeEmotion.Check");
    NSLog(@"[OC] data: %@", arg);
    UIImage* image = [NativeEmotion Base64ToImage:arg];
    NSLog(@"[OC] image: %@", image);
    
    [[YZTEmotionManager shareInstance] startCheckWithImg:image faceInfo:^(NSArray<YZTFaceItem *> * _Nonnull faceItems, ResultType result) {
        
        // 如果 sdk 报告检测失败，或者图片中没有人脸
        if (result != ResultTypeOfSuccess || faceItems.count == 0)
        {
            gateCallReturn(callId, @"{\"list\":[]}");
            return;
        }
        
        // NSLog(@"startCheckWithImg --- faceItems : %@ --result : %d\n", faceItems, result);
        id dic = [[NSMutableDictionary alloc] init];
        id faceList = [NativeEmotion FaceListToDictionaryList:faceItems];
        [dic setObject:faceList forKey:@"list"];
        id json = [dic toJSONString];
        
        //NSLog(@"dic: %@", dic);
        NSLog(@"%@", json);
        gateCallReturn(callId, json);
    }];
 
}

@end

