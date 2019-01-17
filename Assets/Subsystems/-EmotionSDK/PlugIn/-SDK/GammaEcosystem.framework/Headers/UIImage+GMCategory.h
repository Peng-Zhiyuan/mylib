//
//  UIImage+GMCategory.h
//  GammaLiveDetect
//
//  Created by Chris on 2018/10/10.
//  Copyright © 2018 Chris. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <CoreMedia/CoreMedia.h>

NS_ASSUME_NONNULL_BEGIN

namespace cv {
    class Mat;
}

namespace GMLab {
    class Mat;
}

@class GMFaceItem;

@interface UIImage (GMCategory)

#pragma mark - Image Edit

- (UIImage *)gmResize:(CGSize)newSize;              /* 简单缩放 */
- (UIImage *)gmResizeWithScale:(CGFloat)scale;      /* 简单缩放 */
- (UIImage *)gmSubImage:(CGRect)subRect;            /* 简单剪裁 */
- (UIImage *)gmScaleFillResize:(CGSize)newSize;     /* 通过Scale Fill方式将图片等宽高比缩放 */
- (UIImage *)gmUpOrientationImage;                  /* 生成Up方向的图像 */

/** 将FaceItem的信息在人脸原图上进行标识(人脸框，眼睛鼻子嘴) */
- (UIImage *)gmMarkedImage:(NSArray<GMFaceItem *> *)itemArray;

#pragma mark - Image Compress

/** 压缩图片到目标大小 */
- (NSData *)gmCompressToKb:(NSInteger)tarKb;

#pragma mark - Image Data Transfer

/* UIImage <--> GMLab::Mat */
+ (UIImage *)gmImageFromGmMat:(GMLab::Mat *)cvMat;
- (void)gmGmMatData:(GMLab::Mat &)tarMat;

/* UIImage --> ncnn::Mat RGB or BGR */
- (void)fillNcnnMat:(ncnn::Mat &)tarMat isRgb:(BOOL)isRgb;

@end

NS_ASSUME_NONNULL_END
