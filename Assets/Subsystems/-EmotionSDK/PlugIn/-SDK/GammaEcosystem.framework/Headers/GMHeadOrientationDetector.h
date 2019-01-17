//
//  GMHeadOrientationDetector.h
//  GmesTest
//
//  Created by Chris on 2018/12/6.
//  Copyright © 2018 杨一凡. All rights reserved.
//

#import "GMFaceBasedDetector.h"

NS_ASSUME_NONNULL_BEGIN

@interface GMHeadOrientationDetector : GMFaceBasedDetector

/** 加载模型 */
- (void)loadModels;

/** 进行检测
 * 返回转头三个方向的参考角度，分别为：
 * 摇头方向，点头方向，侧头方向
 */
- (NSArray<NSNumber *> *)detect:(UIImage *)faceImage;

@end

NS_ASSUME_NONNULL_END
