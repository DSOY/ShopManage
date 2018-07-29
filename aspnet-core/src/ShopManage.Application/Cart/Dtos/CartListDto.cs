using Abp.AutoMapper;
using ShopManage.Shop.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManage.Cart.Dtos
{
    [AutoMap(typeof(CartModel))]
    public class CartListDto
    {
        /// <summary>
        /// 租户ID
        /// </summary>
        public int TenantID { set; get; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
    }
}
