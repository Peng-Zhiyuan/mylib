//
//  gm_imgproc.hpp
//  GmesTest
//
//  Created by Chris on 2018/11/19.
//  Copyright © 2018 杨一凡. All rights reserved.
//

#ifndef gm_imgproc_hpp
#define gm_imgproc_hpp

#include <stdio.h>
#include "gm_mat.hpp"

namespace GMLab {
    
    /* 进行仿射变换, 固定4通道（临近填充） */
    void warpAffine(Mat &dstMat, Mat &srcMat, float para[6]);
    
    /* 进行仿射变换, 固定4通道（双线性填充） */
    void warpAffine_bilinear(Mat &dstMat, Mat &srcMat, float para[6]);
    
    /* [暂不使用] 填充空数据数据(需要img_setbuf被同步设定) */
    void fillPixel(Mat &sdMat);    
}

#endif /* gm_imgproc_hpp */
