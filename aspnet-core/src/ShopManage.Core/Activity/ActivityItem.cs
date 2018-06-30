using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopManage.Activity
{
    [Table("AbpActivityItem")]
    public class ActivityItem : FullAuditedEntity
    {
        /// <summary>
        /// 活动ID
        /// </summary>
        [Required]
        public int OrderId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// 活动价格
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }
}
