using Microsoft.CSharp;

namespace iTOSeunm
{
    public enum ActionCode
    {
        /// <summary>
        /// bool，VE/SE单机运行，当VE_SESolo 为TRUE 时，只是SE部分转动，并且没有烟支显示，其他开关状态和阀门状态 不起作用	
        /// </summary>
        VE_SESolo,
        /// <summary>
        /// bool，当MAX_Solo 为TRUE 时，只是MAX部分转动，并且没有烟支显示，其他开关状态和阀门状态 不起作用	
        /// </summary>
        MAX_Solo,
        /// <summary>
        /// bool，当 Machine_solo 为TRUE时，整个机器都在转动，但是没有烟支显示，其他开关状态和阀门状态 不起作用	
        /// </summary>
        Machine_solo,
        /// <summary>
        /// bool，当 Machine_run 为 TRUE时，整个机器都在转动，其他开关状态和阀门状态起作用
        /// </summary>
        Machine_run,
        /// <summary>
        /// bool,TRUE表示B21S检测到纸接头
        /// B21S_Splice为TRUE时，检测到卷烟纸接头，此时B21S开关，应该出现状态变化
        /// </summary>
        B21S_Splice,
        /// <summary>
        /// bool,TRUE表示烟条外观传感器检测到相应废品
        /// ORIS_Waste 为TRUE时，ORIS检测到烟条外观废品，此时ORIS器件，应该出现状态变化
        /// </summary>
        ORIS_Waste,
        /// <summary>
        /// bool,TRUE表示微波检测到与重量相关的废品
        /// SRM_Waste 为TRUE时，SRM检测到重量废品，此时SRM器件，应该出现状态变化
        /// </summary>
        SRM_Waste,
        /// <summary>
        /// bool,TRUE表示直径检测装置检测到直径废品（备用）
        /// ODM_Waste 为TRUE时，ODM检测到直径废品，此时ODM器件，应该出现状态变化（备用）
        /// </summary>
        ODM_Waste,
        /// <summary>
        /// bool,TRUE表示正常生产过程中，有烟条经过SES组合式传感器，ORIS，微波，直径检测都已经投入
        /// SRM_Monitor 为TRUE时，有烟条经过SES组合式传感器
        /// </summary>
        SRM_Monitor,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，B1M检测到双长烟条；Flase表示没有检测到双长烟条，动画中应做相应处理
        /// B1M_Status 为TRUE 时，有烟条经过B1M				
        /// </summary>
        B1M_Status,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，B1M检测到双长烟条；Flase表示没有检测到双长烟条，动画中应做相应处理
        /// B41M_Status为TRUE时，滤嘴经过，并且和烟条汇合
        /// </summary>
        B41M_Status,
        /// <summary>
        /// bool,TRUE表示Y2M进行了一次打开阀门动作
        /// Y2M_Status 为FALSE时，烟条能够通过Y2阀门，为TRUE 时，需要有烟支被Y2M阀门剔除的动画				
        /// </summary>
        Y2M_Status,
        /// <summary>
        /// bool,TRUE表示Y3M进行了一次打开阀门动作
        /// Y3M_Status 为FALSE时，烟条能够通过Y3阀门，为TRUE 时，需要有烟支被Y3M阀门剔除的动画				
        /// </summary>
        Y3M_Status,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，B14M检测到前排烟条；Flase表示没有检测到烟条，动画中应做相应处理
        /// B14M_Status为TRUE时，前排烟条通过B14M，为False 时，需要有烟支空缺的动画				
        /// </summary>
        B14M_Status,
        /// <summary>
        /// bool, TRUE表示在正常生产过程中，B42M检测到双长滤嘴；Flase表示没有检测到双长滤嘴，动画中应做相应处理
        /// B42M_Status为TRUE时，滤嘴通过B42M，为False 时，需要有滤嘴空缺的动画				
        /// </summary>
        B42M_Status,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，B15M检测到后排烟条；Flase表示没有检测到烟条，动画中应做相应处理
        /// B15M_Status为TRUE时，后排烟条通过B15M，为False 时，需要有烟条空缺的动画
        /// </summary>
        B15M_Status,
        /// <summary>
        /// bool,True表示Y4M进行了一次打开阀门动作
        /// Y4M_Status 为FALSE时，烟条能够通过Y4M阀门，为TRUE 时，需要有烟支被Y4M阀门剔除的动画				
        /// </summary>
        Y4M_Status,
        /// <summary>
        /// bool,True表示Y16M进行了一次打开阀门动作
        /// Y16M_Status 为FALSE时，烟条能够通过Y16M阀门，为TRUE 时，需要有烟支被Y16M阀门剔除的动画				
        /// </summary>
        Y16M_Status,
        /// <summary>
        /// bool,True表示Y5M进行了一次打开阀门动作
        /// Y5M_Status 为FALSE时，烟条能够通过Y5M阀门，为TRUE 时，需要有烟支被Y5M阀门剔除的动画				
        /// </summary>
        Y5M_Status,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，B24M检测到双长烟条；Flase表示没有检测到双长烟条，动画中应做相应处理
        /// B24M_Status为TRUE时，有烟条通过B24M，为False 时，需要有烟条空缺的动画
        /// </summary>
        B24M_Status,
        /// <summary>
        /// bool,TRUE表示B22M检测到水松纸接头
        /// B22M_Status为TRUE时，检测到水松纸接头，此时B22M开关，应该出现状态变化				
        /// </summary>
        B22M_Status,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，前排烟支全外观检测系统，检测到相应废品
        /// cigs_ALLPicture_Front 为TRUE时，烟支全外观检测系统在前排检测到外观废品，此时烟支全外观系统，应该出现状态变化
        /// </summary>
        cigs_ALLPicture_Front,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，后排排烟支全外观检测系统，检测到相应废品
        /// cigs_ALLPicture_Rear 为TRUE时，烟支全外观检测系统在后排检测到外观废品，此时烟支全外观系统，应该出现状态变化				
        /// </summary>
        cigs_ALLPicture_Rear,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，B2M检测到前排烟支；Flase表示没有检测到前排烟支，动画中应做相应处理
        /// B2M_Status为TRUE时，有前排烟支通过B2M，为False 时，需要有烟条空缺的动画
        /// </summary>
        B2M_Status,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，B3M检测到后排烟支；Flase表示没有检测到后排烟支，动画中应做相应处理
        /// B3M_Status为TRUE时，有后排烟支通过B3M，为False 时，需要有烟条空缺的动画	
        /// </summary>
        B3M_Status,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，B4M检测到前排烟支正常；Flase表示检测到前排烟支缺少滤嘴，动画中应做相应处理
        /// B4M_Status为TRUE时，滤嘴正常的前排烟支通过B4M，为False 时，需要有缺嘴烟支通过的动画				
        /// </summary>
        B4M_Status,
        /// <summary>
        /// bool,TRUE表示在正常生产过程中，B5M检测到后排烟支正常；Flase表示检测到后排烟支缺少滤嘴，动画中应做相应处理
        /// B5M_Status为TRUE时，滤嘴正常的后排烟支通过B5M，为False 时，需要有缺嘴烟支通过的动画				
        /// </summary>
        B5M_Status,
        /// <summary>
        /// bool,TRUE表示LEO传感器检测到空头废品烟支
        /// LES_WASTE 为TRUE时，空头检测系统检测到到空头废品，此时空头检测器件，应该出现状态变化				
        /// </summary>
        LES_WASTE,
        /// <summary>
        /// bool,TRUE表示LEO传感器检测到烟支外观废品烟支
        /// OTIS_Waste 为TRUE时，烟支外观检测系统检测到烟支外观废品，此时烟支外观检测器件，应该出现状态变化				
        /// </summary>
        OTIS_Waste,
        /// <summary>
        /// bool,TRUE表示HID传感器检测到气密性废品烟支
        /// HID_Waste 为TRUE时，气密性检测系统检测到烟支气密性废品，此时气密性检测器件，应该出现状态变化				
        /// </summary>
        HID_Waste,
        /// <summary>
        /// bool,True表示Y7M进行了一次打开阀门动作
        /// Y7M_Status 为FALSE时，前排烟支能够通过Y7M阀门，为TRUE 时，需要有烟支被Y7M阀门剔除的动画				
        /// </summary>
        Y7M_Status,
        /// <summary>
        /// bool,True表示Y8M进行了一次打开阀门动作
        /// Y8M_Status 为FALSE时，后排烟支能够通过Y8M阀门，为TRUE 时，需要有烟支被Y8M阀门剔除的动画				
        /// </summary>
        Y8M_Status,
        /// <summary>
        /// bool,True表示Y9M进行了一次打开阀门动作
        /// Y9M_Status 为FALSE时，前排烟支能够通过Y9M阀门，为TRUE 时，需要有烟支被Y9M阀门剔除的动画				
        /// </summary>
        Y9M_Status,
        /// <summary>
        /// bool,True表示Y10M进行了一次打开阀门动作
        /// Y10M_Status 为FALSE时，后排烟支能够通过Y10M阀门，为TRUE 时，需要有烟支被Y10M阀门剔除的动画
        /// </summary>
        Y10M_Status,
        /// <summary>
        /// bool,True表示有正品烟支通过B6M，为False，应有相应烟支缺少动画
        /// B6M_Status为TRUE时，正品烟支通过B6M，进入出烟通道，为False 时，需要有烟支缺少的动画				
        /// </summary>
        B6M_Status,
        /// <summary>
        /// int16,烟条外观废品计数值
        /// </summary>
        Counter_ORISWaste,
        /// <summary>
        /// int16,重量废品计数值
        /// </summary>
        Counter_SRMWaste,
        /// <summary>
        /// int16,烟支直径废品计数值（备用）
        /// </summary>
        Counter_ODMWaste,
        /// <summary>
        /// int16,吹拢烟支数
        /// </summary>
        Counter_B42MWaste,
        /// <summary>
        /// int16,卷烟纸纸接头次数
        /// </summary>
        Counter_B21SWaste,
        /// <summary>
        /// int16,水松纸纸接头次数
        /// </summary>
        Counter_B22MWaste,
        /// <summary>
        /// int16,前排缺少滤嘴烟支数
        /// </summary>
        Counter_B4MWaste,
        /// <summary>
        /// int16,后排缺少滤嘴烟支数
        /// </summary>
        Counter_B5MWaste,
        /// <summary>
        /// int16,空头烟支计数值
        /// </summary>
        Counter_LESWaste,
        /// <summary>
        /// int16,烟支外观废品计数值
        /// </summary>
        Counter_OTISWaste,
        /// <summary>
        /// int16,气密性废品计数值
        /// </summary>
        Counter_HIDWaste,
        /// <summary>
        /// int16,烟支全外观检测废品计数值
        /// </summary>
        Counter_ALLPhotoWaste,
        /// <summary>
        /// int32,生产成品烟支数
        /// </summary>
        Counter_ProductCigs,
        None
    }
}
