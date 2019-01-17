//
//  GMToolkitCpp.h
//  GammaLiveDetect
//
//  Created by Chris on 2018/10/9.
//  Copyright © 2018 Chris. All rights reserved.
//

#ifndef GMToolkitCpp_h
#define GMToolkitCpp_h

#include <stdio.h>

#if DEBUG
//#define GMLog(format, ...)  printf ("<%s:%d>" format, __FUNCTION__, __LINE__, ## __VA_ARGS__)
#define GMLog(format, ...) 
#else
#define GMLog(format, ...)
#endif

#define GMVecAppend(baseVec, apdVec) \
baseVec.insert(baseVec.end(), apdVec.begin(), apdVec.end())

/* ppoint的10个值的含义：
 * 0 左眼x坐标; 5 左眼y坐标
 * 1 右眼x坐标; 6 右眼y坐标
 * 2 鼻子x坐标; 7 鼻子y坐标
 * 3 左嘴角x坐标; 8 左嘴角y坐标
 * 4 右嘴角x坐标; 9 右嘴角y坐标
 */
struct Bbox {
    float score;
    int x1;
    int y1;
    int x2;
    int y2;
    float area;
    float ppoint[10];
    float regreCoord[4];
};

/* 获取当前时间戳(1970.01.01到现在的秒数) */
double gmCurTimestame(void);

/* 获取当前可用内存 */
double gmCurMemoryAvailable(void);

/* 获取当前占用内存 */
double gmCurMemoryUsed(void);

#endif /* GMToolkitCpp_h */
