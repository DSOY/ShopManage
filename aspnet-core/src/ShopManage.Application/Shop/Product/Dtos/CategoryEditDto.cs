using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopManage.Shop.Product.Dtos
{
    [AutoMap(typeof(Category))]
    public class CategoryEditDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 品类名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 品类路径
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Path { get; set; }
    }
}
