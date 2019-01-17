//
//  GMFaceItem.h
//  GammaLiveDetect
//
//  Created by Chris on 2018/10/9.
//  Copyright © 2018 Chris. All rights reserved.
//

#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSInteger, GMFaceDetectMode) {
    GMFaceDetectModeUnknown = -1,
    
    GMFaceDetectModeNone,           /* 不进行剪裁 */
    GMFaceDetectModeSingleCut,      /* 简单剪裁 */
    GMFaceDetectModeAlignCut,       /* 校准剪裁(CV API校准） */
};

@interface GMFaceItem : NSObject

@property (nonatomic, strong) UIImage *sourceImage;                 /* 原始检测图 */

@property (nonatomic, assign) GMFaceDetectMode detectMode;          /* 剪裁模式 */
@property (nonatomic, strong) UIImage *faceImage;                   /* 剪裁的人脸图片（根据detectMode选择 直接剪裁 或 校准剪裁 */

@property (nonatomic, assign) CGRect faceRect;                      /* 人脸位置 */
@property (nonatomic, assign) BOOL isMaxFace;                       /* 是否最大人脸项目 */

@property (nonatomic, assign) CGPoint leftEyesPos;                  /* 左眼位置 */
@property (nonatomic, assign) CGPoint rightEyesPos;                 /* 右眼位置 */
@property (nonatomic, assign) CGPoint nosePos;                      /* 鼻子位置 */
@property (nonatomic, assign) CGPoint leftMouthCornerPos;           /* 左嘴角位置 */
@property (nonatomic, assign) CGPoint rightMouthCornerPos;          /* 右嘴角位置 */

@end

NS_ASSUME_NONNULL_END
