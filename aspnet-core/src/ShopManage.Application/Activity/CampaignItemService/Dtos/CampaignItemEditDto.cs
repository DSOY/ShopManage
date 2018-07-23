using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopManage.Activity.CampaignItemService.Dtos
{
    /// <summary>
    /// 活动明细新增修改模型
    /// </summary>
    [AutoMap(typeof(CampaignItem))]
    public class CampaignItemEditDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
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
    }
}
