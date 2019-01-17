//
//  GMAuDetector.h
//  GammaLiveDetect
//
//  Created by Chris on 2018/10/17.
//  Copyright © 2018 Chris. All rights reserved.
//

#import "GMFaceBasedDetector.h"

NS_ASSUME_NONNULL_BEGIN

@interface GMAuDetector : GMFaceBasedDetector

/** 加载模型 */
- (void)loadModels;

/** 进行检测 */
- (NSArray<NSNumber *> *)detect:(UIImage *)faceImage;

@end

NS_ASSUME_NONNULL_END
