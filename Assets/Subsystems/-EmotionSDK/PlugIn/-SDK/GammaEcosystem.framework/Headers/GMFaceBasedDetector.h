//
//  GMFaceBasedDetector.h
//  GammaLiveDetect
//
//  Created by Chris on 2018/10/12.
//  Copyright © 2018 Chris. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "GMImgAiModel.hpp"
#import "GMDetResultItem.h"

NS_ASSUME_NONNULL_BEGIN

@interface GMFaceBasedDetector : NSObject {
    GMImgAiModel *_pDetector;           /* 基于Cpp的检测器 */
}

@property (nonatomic, strong) NSArray<NSString *> *confModelNameArray;          /* 待加载模型的名字数组 */
@property (nonatomic, strong) NSString *confResultMapFileName;                  /* 结果映射的名字数组 */

@property (nonatomic, assign) int confImageWidth;       /* C++模型的 conf_img_width */
@property (nonatomic, assign) int confImageHeight;      /* C++模型的 conf_img_height */
@property (nonatomic, assign) BOOL confPreProcess;      /* C++模型的 conf_pre_process */
@property (nonatomic, strong) NSString *confInputKey;   /* C++模型的 conf_input_key */
@property (nonatomic, strong) NSString *confOutputKey;  /* C++模型的 conf_output_key */

#pragma mark - Base Func

/*
 * 加载一个模型的.param 和 .bin 文件
 * pairName，模型的文件名（不含后缀）
 * 举例：有模型文件a.param, a.bin, 则输入pairName为@"a"
 */
- (void)loadModelPair:(NSString *)pairName;

/* 根据配置加载模型文件 */
- (void)loadModels;

/* 进行检测 */
- (NSArray<NSNumber *> *)detect:(UIImage *)faceImage;

#pragma mark - Support

@property (nonatomic, strong) NSArray<GMDetResultItem *> *resultMap;  /* 结果描述映射 */

- (NSString *)summaryResult:(NSArray<NSNumber *> *)resultArray;
- (NSString *)detailResult:(NSArray<NSNumber *> *)resultArray;

#pragma mark - For Test

- (GMImgAiModel *)pDetector;
- (NSArray<GMDetResultItem *> *)loadMapItems:(NSString *)fileName;

@end

NS_ASSUME_NONNULL_END
