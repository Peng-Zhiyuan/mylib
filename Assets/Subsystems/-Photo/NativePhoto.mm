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

// select photo
// =======================

NSString* select_saveCallId;

// arg: base64ImageData
+ (void)Select:(NSString*)callId arg:(NSString*)arg
{
    NSLog(@"[OC] Photo.Select");
    select_saveCallId = callId;
    
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
        gateCallReturn(select_saveCallId, @"");
    }
    else
    {
        NSData* imageData = UIImagePNGRepresentation(image);
        NSString* base64 =  [imageData base64EncodedStringWithOptions: 0];
        //NSLog(@"[OC] Photo data: %@", base64);
        gateCallReturn(select_saveCallId, base64);
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


// save image
// =======================

NSString* save_saveCallId;

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

+ (void) imageSaved: (UIImage*) image didFinishSavingWithError:(NSError*)error contextInfo:(void*) contextInfo
{
    if (error != nil)
    {
        NSLog(@"[imageSaved] error");
        gateCallReturn(save_saveCallId, @"false");
    }
    else
    {
        gateCallReturn(save_saveCallId, @"true");
    }
}


+ (void)Save:(NSString*)callId arg:(NSString*)base64
{
    save_saveCallId = callId;
    UIImage *img = [NativePhoto Base64ToImage:base64];
    UIImageWriteToSavedPhotosAlbum(img,  [NativePhoto class],
                                   @selector(imageSaved:didFinishSavingWithError:contextInfo:), nil);
}


@end
