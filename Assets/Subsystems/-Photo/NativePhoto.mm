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

@interface NativePhoto<UIImagePickerControllerDelegate> : NSObject
@end

@implementation NativePhoto : NSObject

NSString* saveCallId;

// arg: base64ImageData
+ (void)Select:(NSString*)callId arg:(NSString*)arg
{
    NSLog(@"[OC] Photo.Select");
    saveCallId = callId;
    
    // 初始化UIImagePickerController类
    UIImagePickerController * picker = [[UIImagePickerController alloc] init];
    // 设置数据来源为相册
    picker.sourceType = UIImagePickerControllerSourceTypeSavedPhotosAlbum;
    // 设置代理
    picker.delegate = [NativePhoto class];
    //打开相册
    UIViewController* view = UnityGetGLViewController();
    [view presentViewController:picker animated:YES completion:nil];
}

+ (void)complete:(UIImage*) image
{
    if(image == nil)
    {
        gateCallReturn(saveCallId, @"");
    }
    else
    {
        NSData* imageData = UIImagePNGRepresentation(image);
        NSString* base64 =  [imageData base64EncodedStringWithOptions: 0];
        NSLog(@"[OC] Photo data: %@", base64);
        gateCallReturn(saveCallId, base64);
    }
    
}

//选择完成回调函数
+ (void)imagePickerController:(UIImagePickerController *)picker didFinishPickingMediaWithInfo:(NSDictionary<NSString *,id> *)info
{
    //获取图片
    UIImage *image = info[UIImagePickerControllerOriginalImage];
    
    UIViewController* view = UnityGetGLViewController();
    [view dismissViewControllerAnimated:YES completion:nil];
    [NativePhoto complete:image];
}


//用户取消选择
+ (void)imagePickerControllerDidCancel:(UIImagePickerController *)picker
{
    UIViewController* view = UnityGetGLViewController();
    [view dismissViewControllerAnimated:YES completion:nil];
    [NativePhoto complete:nil];
}

@end

