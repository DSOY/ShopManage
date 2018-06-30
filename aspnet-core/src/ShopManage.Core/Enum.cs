using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ShopManage
{
    public enum Whether
    {
        True =1,
        False =0
    }

    public enum PlanState
    {
        [Description("创建")]
        Creat = 1,
        [Description("审核")]
        Audit = 2,
        [Description("注销")]
        Logout = -1
    }
}
