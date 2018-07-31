using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopManage.Cart.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(CartModel))]
    public class CartInput
    {
        /// <summary>
        /// 租户ID
        /// </summary>
        [Required]
        public int TenantID { set; get; }
        
        /// <summary>
        /// 商品ID
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        public int Qty { get; set; }
    }
}
