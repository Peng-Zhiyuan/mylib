//
//  GMToolkitOcMisc.h
//  GammaEcosystem
//
//  Created by Chris on 2018/12/13.
//  Copyright © 2018 杨一凡. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <ncnn/net.h>
#import "GMFaceItem.h"

/* 基本支持 */
/* Safe Object */
#define gmSafeStr(inputStr)         ((YES == [inputStr isKindOfClass:[NSString class]]) ? inputStr : @"")
#define gmSafeArray(inputArray)     ((YES == [inputArray isKindOfClass:[NSArray class]]) ? inputArray : @[])
#define gmSafeDic(inputDic)         ((YES == [inputDic isKindOfClass:[NSDictionary class]]) ? inputDic : @{})
#define gmSafeDecimal(inputNum)     \
((YES == [inputNum isKindOfClass:[NSDecimalNumber class]]) \
&& (NO == isnan(inputNum.doubleValue))  \
? inputNum \
: [NSDecimalNumber decimalNumberWithString:@"0"])

/* Safe Check */
#define gmIsEmptyStr(inputStr)          (0 == inputStr.length)
#define gmIsEmptyArray(inputArray)      (0 == inputArray.count)
#define gmIsEmptyDic(inputDic)          (0 == inputDic.allKeys.count)
#define gmIsZeroDecimal(inputNum)       (nil == inputNum || isnan(inputNum.doubleValue) || 0 == inputNum.doubleValue)

/* Safe Callback */
#define gmSafeCallback(cb, para...) \
do { \
if (nil != cb) { \
cb(para); \
} \
} while(0)

/* Weak Self */
#define gmWeakSelf(weakSelf)    __weak __typeof(&*self) weakSelf = self


/* ******************************** 打印输出 ********************************
 * gmPrintNcnnMatAll : 打印ncnn:Mat的所有数据
 * gmPrintNcnnMat100 : 打印大型ncnn:Mat离散的100个数据
 * gmPrintNcnnMatTopN : 打印ncnn:Mat的排序数据的最大N个值，0代表全部值
 * gmPrintNcnnNetInfo : 打印ncnn:Net的基本信息(含Layer & Blobs)
 */
void gmPrintNcnnMatAll(ncnn::Mat inputMat);
void gmPrintNcnnMat100(ncnn::Mat inputMat);
void gmPrintNcnnMatTopN(ncnn::Mat inputMat, int topN);
void gmPrintNcnnNetInfo(ncnn::Net inputNet);

/* 人脸框 & 五官绘制
 * rect的边缘需要和人脸检测图完全贴合
 * faceInfo所有项目的检测图应为同一张图
 */
void gmDrawFaceItem(CGRect rect, GMFaceItem *faceItem, UIColor *color);
void gmDrawFaceItems(CGRect rect, NSArray<GMFaceItem *> *faceInfo, UIColor *color);

/* DES 加密解密 */
NSData *desEncrypt(NSData *inputData, NSString *inputKey);
NSData *desDecrypt(NSData *inputData, NSString *inputKey);

/* DES 文件加密解密 */
void desEncryptFile(NSString *dstFilePath, NSString *srcFilePath, NSString *secKey);
void desDecryptFile(NSString *dstFilePath, NSString *srcFilePath, NSString *secKey);

/* 获取解密文件 */
NSString *getdecryptedFile(NSString *encryptFilePath, BOOL forceUpdate);

/* 清理缓存（使模型可以即刻更新） */
void clearCaches();
