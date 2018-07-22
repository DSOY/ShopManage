using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopManage.Activity.CampaignService.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Campaign))]
    public class CampaignEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int? Id{get;set;}

        /// <summary>
        /// 活动名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        [Required]
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        [Required]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        public PlanState Status { get; set; }
        
    }
}
