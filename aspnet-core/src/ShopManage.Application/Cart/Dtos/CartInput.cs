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
        /// 商品ID
        /// </summary>
        [Required]
        public int ProductId { get; set; }
    }
}
