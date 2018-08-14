using Abp.Domain.Entities;
using ShopManage.Shop.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopManage.Order
{
    [Table("AbpOrderItem")]
    public class OrderItemModel : Entity<Guid>
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        [Required]
        public int OrderId { set; get; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public Product Product { get; set; }

        public int ProductId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        public int Qty { set; get; }
    }
}
