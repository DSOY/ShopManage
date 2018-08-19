using Abp.AutoMapper;
using ShopManage.Address;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManage.Order.Dtos
{
    [AutoMap(typeof(OrderModel))]
    public class OrderListDto
    {

        /// <summary>
        /// 会员ID
        /// </summary>
        public int UserID { set; get; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { set; get; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { set; get; }

        /// <summary>
        /// 活动ID
        /// </summary>
        public int? ActivityID { set; get; }

        /// <summary>
        /// 商品合计
        /// </summary>
        public int Qty { set; get; }

        /// <summary>
        /// 实付总额
        /// </summary>
        public int PayPoint { set; get; }

        /// <summary>
        /// 运费
        /// </summary>
        public int FreightPoint { set; get; }

        /// <summary>
        /// 正价货款总额
        /// </summary>
        public int ProductPrice { set; get; }

        /// <summary>
        /// 地址信息
        /// </summary>
        public AddressModel AddressModel { get; set; }

        /// <summary>
        /// 明细
        /// </summary>
        public OrderItemModel OrderItemModel { get; set; }

        /// <summary>
        /// 买家备注
        /// </summary>
        public string BuyerRemark { set; get; }

        /// <summary>
        /// 运单ID
        /// </summary>
        public string ExpressID { set; get; }

        /// <summary>
        /// 运单号
        /// </summary>
        public string ExpressNO { set; get; }

        /// <summary>
        /// 承运公司
        /// </summary>
        public string Carrier{set; get;}
    }
}
