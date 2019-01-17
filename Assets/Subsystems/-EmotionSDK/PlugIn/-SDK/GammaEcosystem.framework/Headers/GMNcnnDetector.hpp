//
//  GMNcnnDetector.hpp
//  GammaEcosystem
//
//  Created by Chris on 2018/11/14.
//  Copyright © 2018 杨一凡. All rights reserved.
//

#ifndef GMNcnnDetector_hpp
#define GMNcnnDetector_hpp

#include <stdio.h>
#include <ncnn/net.h>

class GMNcnnDetector {
    
public: /* 网络 & 基本配置 */
    ncnn::Net ncnn_net;
    
    bool conf_extrator_lightmode = true;        /* 提取器 是否使用轻便模式 */
    int conf_extrator_threadnum = 4;            /* 提取器 执行线程数 */

public: /* 构造 & 析构 */
    GMNcnnDetector();
    ~GMNcnnDetector();

public: /* 实例方法 */
    
    /* 加载模型 */
    int loadModel(const char *fpathdata_param, const char *fpathdata_model);
    int loadModel(const std::string fpath_param, const std::string fpath_model);
    int loadModels(std::vector<std::string> fpaths_param, const std::vector<std::string> fpaths_model);

    /* 清理模型 */
    void clearModels(void);
    
    /* 获取提取器 */
    ncnn::Extractor *getExExtractor(void);
    
    /* 初始化配置检测器 */
    void initialExtractor(ncnn::Extractor *pInputExt);

public: /* 类方法 */
    
    /* 加载模型 */
    static int loadExModel(ncnn::Net *pInput_net, const char *fpathdata_param, const char *fpathdata_model);
    static int loadExModel(ncnn::Net *pInput_net, const std::string fpath_param, const std::string fpath_model);
    static int loadExModels(ncnn::Net *pInput_net, std::vector<std::string> fpaths_param, const std::vector<std::string> fpaths_model);
    
    /* 清理模型 */
    static void clearExModels(ncnn::Net *pInput_net);
};

#endif /* GMNcnnDetector_hpp */
