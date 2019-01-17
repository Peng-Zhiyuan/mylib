//
//  GMFaceDetector.h
//  GammaLiveDetect
//
//  Created by Chris on 2018/10/12.
//  Copyright © 2018 Chris. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "GMFaceItem.h"

NS_ASSUME_NONNULL_BEGIN

@interface GMFaceDetector : NSObject

- (void)loadModels;

/* 获取所有人脸信息（含图片：普通/校准） */
- (NSArray<GMFaceItem *> *)fetchFacesInfo:(UIImage *)image withMode:(GMFaceDetectMode)detectMode;

/* 获取最大人脸信息（含图片：普通/校准） */
- (GMFaceItem *)fetchMaxFaceInfo:(UIImage *)image withMode:(GMFaceDetectMode)detectMode;

#pragma mark -

/* 直接获取人脸图片（忽略其他信息） */
- (UIImage *)faceImageWithImage:(UIImage *)sourceImage faceItem:(GMFaceItem *)faceItem;

/* 直接获取校准人脸图片（忽略其他信息） */
- (UIImage *)alignFaceImageWithImage:(UIImage *)sourceImage faceItem:(GMFaceItem *)faceItem;

@end

NS_ASSUME_NONNULL_END
