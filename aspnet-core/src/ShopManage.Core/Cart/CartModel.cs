using Abp.Domain.Entities;
using ShopManage.Shop.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopManage.Cart
{
    [Table("AbpCart")]
    public class CartModel : Entity<int>
    {
        /// <summary>
        /// 租户ID
        /// </summary>
        [Required]
        public int TenantID { set; get; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [Required]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        public int Qty { get; set; }
        
    }
}
