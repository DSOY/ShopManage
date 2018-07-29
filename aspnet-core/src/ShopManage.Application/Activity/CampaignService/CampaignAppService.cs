using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using ShopManage.Activity.CampaignService.Dtos;
using System;
using System.Collections.Generic;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace ShopManage.Activity.CampaignService
{
    /// <summary>
    /// 活动
    /// </summary>
    public class CampaignAppService:ShopManageAppServiceBase,ICampaignAppService
    {
        #region 注入
        private readonly IRepository<Campaign> _campaignAppService;

        public CampaignAppService(IRepository<Campaign> campaignAppService)
        {
            _campaignAppService = campaignAppService;
        }
        #endregion

        #region 创建或修改活动
        /// <summary>
        /// 创建或修改活动
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateCampaignAsync(CampaignEditDto input)
        {
            if (input.Id.HasValue)
            {
                await UpdateCampaignAsync(input);
            }
            else
            {
                input.Status = PlanState.Creat;
                await CreateCampaignAsync(input);
            }
        }

        /// <summary>
        /// 修改活动信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected async Task UpdateCampaignAsync(CampaignEditDto input)
        {
            var entity = await _campaignAppService.GetAsync(input.Id.Value);
            await _campaignAppService.UpdateAsync(input.MapTo(entity));
        }

        /// <summary>
        /// 创建活动
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected async Task CreateCampaignAsync(CampaignEditDto input)
        {
            var model = input.MapTo<Campaign>();
            await _campaignAppService.InsertAsync(model);
        }
        #endregion

        #region 根据ID删除活动
        /// <summary>
        /// 根据ID删除活动
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeteleCampaignAsync(EntityDto input)
        {
            var entity = await _campaignAppService.GetAsync(input.Id);
            if (entity == null)
            {
                throw new UserFriendlyException("活动不存在，删除失败");
            }

            await _campaignAppService.DeleteAsync(input.Id);
        }
        #endregion

        #region 获取活动分页数据
        /// <summary>
        /// 获取活动分页数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<CampaignListDto>> GetPagedCampaignAsync(GetCampaignInput input)
        {
            var query = _campaignAppService.GetAllIncluding(a=>a.CampaignItem);
            var campaignCount = await query.CountAsync();
            var campaigns = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = campaigns.MapTo<List<CampaignListDto>>();

            return new PagedResultDto<CampaignListDto>(campaignCount, dtos);
        }
        #endregion

        #region 根据ID获取活动
        /// <summary>
        /// 根据ID获取活动
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CampaignListDto> GetCampaignByIdAsync(NullableIdDto input)
        {
            //var id = input.Id.HasValue ? input.Id.Value : 1;
            var entity = await _campaignAppService.GetAllIncluding(p => p.CampaignItem).FirstOrDefaultAsync(x => x.Id == input.Id.Value);
            return entity.MapTo<CampaignListDto>();
        }
        #endregion
    }
}
