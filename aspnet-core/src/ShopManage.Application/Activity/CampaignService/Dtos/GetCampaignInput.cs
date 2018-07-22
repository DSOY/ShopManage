using Abp.Runtime.Validation;
using ShopManage.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManage.Activity.CampaignService.Dtos
{
    public class GetCampaignInput : PagedAndSortedInputDto, IShouldNormalize
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
}
