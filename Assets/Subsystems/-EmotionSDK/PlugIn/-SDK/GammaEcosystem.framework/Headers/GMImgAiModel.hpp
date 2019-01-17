//
//  GMImgAiModel.hpp
//  GammaLiveDetect
//
//  Created by Chris on 2018/10/9.
//  Copyright © 2018 Chris. All rights reserved.
//

#ifndef GMImgAiModel_hpp
#define GMImgAiModel_hpp

#include "GMNcnnDetector.hpp"

using namespace std;

class GMImgAiModel : public GMNcnnDetector {
    
public:

    bool conf_pre_process = false;                                  /* 是否进行预处理 (x - 127.5 * 0.0078125) */
    float conf_mean_vals[3] = {127.5f, 127.5f, 127.5f};             /* 标准化参数 */
    float conf_norm_vals[3] = {0.0078125f, 0.0078125f, 0.0078125f}; /* 标准化参数 */
    
    int conf_img_width = 112;                                       /* 输入图片宽度要求 */
    int conf_img_height = 112;                                      /* 输入图片高度要求 */
    char conf_input_key[32] = "";                                   /* 输入数据标签 */
    char conf_output_key[32] = "";                                  /* 输出数据标签, 为detect使用 */
    
public:
    GMImgAiModel();
    ~GMImgAiModel();
    
    /******************* 自带 ncnn::Net 处理 *******************/
    void detect(ncnn::Mat &dstMat, ncnn::Mat &srcMat);  /* 可能进行归一化处理，所以srcMat可能被改变，不可重复使用 */
    
public:
    /* 分步处理，用以提取多层输出 */
    void detect_initExtractor(ncnn::Extractor &extractor);
    void detect_setInput(ncnn::Extractor &extractor, ncnn::Mat &srcMat, const char *inputKey);
    void detect_extractOutput(ncnn::Extractor &extractor, ncnn::Mat &dstMat, const char *outputKey);
};

#endif /* GMImgAiModel_hpp */
