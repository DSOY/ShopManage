using Abp.Runtime.Validation;
using ShopManage.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopManage.Shop.Product.Dtos
{
    /// <summary>
    /// 分页条件
    /// </summary>
    public class GetProductInput : PagedAndSortedInputDto, IShouldNormalize
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "CreationTime";
            } 
        }
    }

    /// <summary>
    /// 根据品类获取商品输入条件
    /// </summary>
    public class GetProductByCategoryInput : PagedAndSortedInputDto, IShouldNormalize
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "CreationTime";
            }
        }

        /// <summary>
        /// 品类ID
        /// </summary>
        [Required]
        public int CategoryId { get; set; }
    }
}
