using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopManage.Order.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(OrderModel))]
    public class OrderInputDto
    {
        /// <summary>
        /// 活动ID
        /// </summary>
        public int? ActivityID { set; get; }
        
        /// <summary>
        /// 地址信息
        /// </summary>
        public int AddressModelId { get; set; }

        /// <summary>
        /// 买家备注
        /// </summary>
        [MaxLength(500)]
        public string BuyerRemark { set; get; }
        
        /// <summary>
        /// 商品明细
        /// </summary>
        public List<Item> OrderItem { get; set; }
    }

    /// <summary>
    /// 商品明细
    /// </summary>
    [AutoMap(typeof(OrderItemModel))]
    public class Item
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
    }
}
