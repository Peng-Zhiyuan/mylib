//
//  GMDetResultItem.h
//  GammaLiveDetect
//
//  Created by Chris on 2018/10/19.
//  Copyright © 2018 Chris. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface GMDetResultItem : NSObject

@property (nonatomic, assign) float value;                              /* 结果值 */

@property (nonatomic, assign) NSInteger index;                          /* 索引位置 */
@property (nonatomic, assign) NSString *itemId;                         /* 唯一标识（可能未设定） */
@property (nonatomic, strong) NSString *descEn;                         /* 英文描述 */
@property (nonatomic, strong) NSString *descCn;                         /* 中文描述 */
@property (nonatomic, strong, readonly) NSString *descDisplay;          /* 展示的描述（优先中文）*/

@end

NS_ASSUME_NONNULL_END
