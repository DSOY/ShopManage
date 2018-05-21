using System.ComponentModel;

namespace ShopManage.Shop
{
    public enum ProductStatus
    {
        [Description("已兑馨")]
        SellOut = -1,
        [Description("下架")]
        LowerFrame = 0,
        [Description("上架")]
        UpFrame = 1
    }
}
