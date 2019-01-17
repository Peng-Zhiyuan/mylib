//
//  gm_mat.hpp
//  GmesTest
//
//  Created by Chris on 2018/11/19.
//  Copyright © 2018 杨一凡. All rights reserved.
//

#ifndef gm_mat_hpp
#define gm_mat_hpp

#include <stdio.h>

namespace GMLab {

    /* 该Mat与Gamma应用中的具体应用场景结合，
     * 故做了一些功能的简化（降低实现成本，针对应优化效率）
     * 具体包含：
     * 1. 使用unsigned char 作为数据数组的基本元素（不支持其他数据类型)
     * 2. 通道数写死为4个，分别为RGBA，输入由外界保证，其中A部分可做优化
     */
    class Mat {
        
    public:
        Mat();
        Mat(int width, int height);
        ~Mat();
        
    public:
        /* 重置Mat */
        void reset(int width, int height);
        
        /* 数据信息操作 */
        inline int data_index(int idx_x, int idx_y, int idx_c);
        void data_set(unsigned char value, int idx_x, int idx_y, int idx_c);
        unsigned char data_get(int idx_x, int idx_y, int idx_c);
        
        /* 清理Mat */
        void clearMat(void);
        
    public:
        unsigned char * img_data;       /* 图片数据，排序: RGBA RGBA RGBA ... */
        unsigned char * img_setbuf;     /* [暂不使用] 图片设置缓存区 */
        
        int img_w;                      /* 图片宽 */
        int img_h;                      /* 图片高 */
        int img_c;                      /* 图片通道数量，写死为4 */
        
        int items_per_row;              /* 每行项目数：img_w * img_c */
        int bytes_per_row;              /* 每行比特数：img_w * img_c * 1 */
        
        int size_one_channel;           /* 数据区大小（单通道）*/
        int size_all_channels;          /* 数据区大小（所有通道）*/
    };
    
} // End GMLab

#endif /* gm_mat_hpp */
