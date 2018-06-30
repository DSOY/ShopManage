using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopManage.Activity
{
    [Table("AbpActivity")]
    public class Activity : FullAuditedEntity
    {
        /// <summary>
        /// 租户ID
        /// </summary>
        [Required]
        public int TenantID { set; get; }

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

        /// <summary>
        /// 活动明细
        /// </summary>
        public List<ActivityItem> ActivityItem { get; set; }
    }
}
