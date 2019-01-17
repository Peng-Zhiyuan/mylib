//
//  YZTEmotionManager.h
//  YZTEmotionTest
//
//  Created by apple on 2018/12/28.
//  Copyright © 2018年 apple. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(int, ResultType) {
    ResultTypeOfSuccess,   //成功
    ResultTypeOfNoneAutu,  //没有授权
    ResultTypeOfNoneImg,   //没有图片
    ResultTypeOfNoneFace,   //没有脸
    ResultTypeOfFail       //检测失败
};

@interface YZTFaceItem : NSObject

@property (nonatomic, assign) CGRect faceRect;                      /* 人脸位置 */
@property (nonatomic, assign) BOOL isMaxFace;                       /* 是否最大人脸项目 */
@property (nonatomic, assign) CGPoint leftEyesPos;                  /* 左眼位置 */
@property (nonatomic, assign) CGPoint rightEyesPos;                 /* 右眼位置 */
@property (nonatomic, assign) CGPoint nosePos;                      /* 鼻子位置 */
@property (nonatomic, assign) CGPoint leftMouthCornerPos;           /* 左嘴角位置 */
@property (nonatomic, assign) CGPoint rightMouthCornerPos;          /* 右嘴角位置 */
@property (nonatomic, strong) NSArray *emotion;          /* 表情信息,为nil则检测失败 */
@property (nonatomic, strong) NSArray *direction;        /* 摇头信息,为nil则检测失败 */
@end

//direct 方向数据
typedef void(^FaceHandle)(NSArray <YZTFaceItem *>*_Nonnull faceItems, ResultType result);

@interface YZTEmotionManager : NSObject


@property (nonatomic, assign) BOOL hasEmotionCheck;
@property (nonatomic, assign) BOOL hasDirectionCheck;

+ (instancetype)shareInstance;
/* 开始检查后，会根据handle配置情况，返回响应的数据回调 faceHandle 参数不能为空 */
- (void)startCheckWithImg:(UIImage *)tarImg faceInfo:(FaceHandle)faceHandle;

@end

NS_ASSUME_NONNULL_END
