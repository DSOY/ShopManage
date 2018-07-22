using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ShopManage.Activity.CampaignItemService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopManage.Activity.CampaignItemService
{
    /// <summary>
    /// 活动明细（IApplicationService生成接口）
    /// </summary>
    public interface ICampaignItemAppService : IApplicationService
    {
        Task<ListResultDto<CampaignItemListDto>> GetAllAsync();

        Task CreateOrUpdateAsync(CampaignItemEditDto input);

        Task DeleteAsync(EntityDto input);
    }
}
