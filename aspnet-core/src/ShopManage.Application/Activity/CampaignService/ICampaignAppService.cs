using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ShopManage.Activity.CampaignService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopManage.Activity.CampaignService
{
    public interface ICampaignAppService: IApplicationService
    {
        /// <summary>
        /// 创建或新增活动
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateCampaignAsync(CampaignEditDto input);

        /// <summary>
        /// 根据ID删除活动
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeteleCampaignAsync(EntityDto input);

        /// <summary>
        /// 获取活动分页数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CampaignListDto>> GetPagedCampaignAsync(GetCampaignInput input);

        /// <summary>
        /// 根据ID获取活动
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CampaignListDto> GetCampaignByIdAsync(NullableIdDto input);
    }
}
