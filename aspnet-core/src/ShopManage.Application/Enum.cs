using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ShopManage
{
    /// <summary>
    /// 添加或减少
    /// </summary>
    public enum IsAdd
    {
        /// <summary>
        /// 添加
        /// </summary>
        True = 1,
        /// <summary>
        /// 减少
        /// </summary>
        False = 0
    }

    /// <summary>
    /// 订单流程状态
    /// </summary>
    public enum OrderStatus
    {
        [Description("待发货")]
        Wait = 0,
        [Description("待收货")]
        Deliver = 1,
        [Description("待评价")]
        Evaluate = 2,
        [Description("已完成")]
        Complete = 3,
        [Description("关闭")]
        Close = 4
    }
}
