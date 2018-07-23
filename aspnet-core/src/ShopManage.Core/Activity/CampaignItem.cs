using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopManage.Activity
{
    [Table("AbpCampaignItem")]
    public class CampaignItem : Entity<int>
    {

        /// <summary>
        /// 商品ID
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [MaxLength(120)]
        public string ProductName { get; set; }

        /// <summary>
        /// 活动价格
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        [Required]
        public bool IsDetele { get; set; }

        public int CampaignId { get; set; }
        //public Campaign Campaign { get; set; }
    }
}
