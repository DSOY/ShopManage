using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopManage.Order.OrderItem.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(OrderItemModel))]
    public class OrderItemInputDto
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        [Required]
        public int OrderId { set; get; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        public int Qty { set; get; }
    }
}
