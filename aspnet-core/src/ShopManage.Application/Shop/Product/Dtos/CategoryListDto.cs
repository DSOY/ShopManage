using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManage.Shop.Product.Dtos
{
    [AutoMap(typeof(Category))]
    public class CategoryListDto : FullAuditedEntity
    {
        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 品类名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 品类路径
        /// </summary>
        public string Path { get; set; }
    }
}
