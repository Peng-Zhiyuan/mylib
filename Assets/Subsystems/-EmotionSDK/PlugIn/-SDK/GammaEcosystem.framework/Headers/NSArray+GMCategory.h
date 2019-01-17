//
//  NSArray+GMCategory.h
//  GammaLiveDetect
//
//  Created by Chris on 2018/10/23.
//  Copyright © 2018 Chris. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "GMDetResultItem.h"

NS_ASSUME_NONNULL_BEGIN

@interface NSArray (GMCategory)

#pragma mark - Log Related

/* 转化成"@[@(),@()...@(),]"的字符串格式 */
- (NSString *)gmOcNumArrayStr;

/* 转化成"0 val1\n1 val2...\nn valn"的字符串格式 */
- (NSString *)gmSingleTagStr;

/* 转化成Pythons格式 */
- (NSString *)gmPythonStr;

#pragma mark - Calc

/** 计算该Array和另一个Number Array的欧氏距离,
 * 无法计算时候返回-1 */
- (float)gmODistance:(NSArray<NSNumber *> *)anotherArray;

/** 使用Sigmoid算法归一化每一个值
 * 算法：1/(1+e^-x) */
- (NSArray<NSNumber *> *)gmSigmoidArray;

/** 进行Normalize归一化计算
 * L1 : xi / (|x1| + |x2| + ... + |xn|)
 * L2 : xi / sqrt(|x1|^2 + |x2|^2 + ... + |xn|^2)
 * Loo : xi / max|xn|
 */
- (NSArray<NSNumber *> *)gmNormalizeL1Array;
- (NSArray<NSNumber *> *)gmNormalizeL2Array;
- (NSArray<NSNumber *> *)gmNormalizeLooArray;

/** 进行SoftMax归一化计算
 * xi = e^xi / e^x0 + e^x1 + ... + e^xn
 */
- (NSArray<NSNumber *> *)gmSoftMaxArray;
- (NSArray<NSNumber *> *)gmSoftMaxArrayWithRange:(NSRange)subArrayRange;

/** 选择数组中最大的五个值，将其按照大小排列成新的数组返回 */
- (NSArray<GMDetResultItem *> *)gmTopN:(NSInteger)nNum;

/** 选择数组中输入范围中的最大值 */
- (GMDetResultItem *)gmRangeMax:(NSRange)range;

@end

NS_ASSUME_NONNULL_END
