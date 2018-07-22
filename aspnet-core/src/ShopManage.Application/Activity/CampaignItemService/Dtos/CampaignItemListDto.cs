using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManage.Activity.CampaignItemService.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(CampaignItem))]
    public class CampaignItemListDto: FullAuditedEntity
    {

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 活动价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public bool IsDetele { get; set; }
    }
}
