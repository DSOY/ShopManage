using Abp.Application.Services.Dto;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopManage.Activity.CampaignItemService.Dtos;

namespace ShopManage.Activity.CampaignItemService
{
    /// <summary>
    /// 活动明细
    /// </summary>
    public class CampaignItemAppService: ShopManageAppServiceBase, ICampaignItemAppService
    {
        #region 注入
        private readonly IRepository<CampaignItem> _campaignItemAppService;
        public CampaignItemAppService(IRepository<CampaignItem> campaignItemAppService)
        {
            _campaignItemAppService = campaignItemAppService;
        }
        #endregion

        #region 查询明细
        /// <summary>
        /// 查询明细
        /// </summary>
        public async Task<ListResultDto<CampaignItemListDto>> GetAllAsync()
        {
            var query = await _campaignItemAppService.GetAllIncluding(x=>x.Product).ToDynamicListAsync();
            //var query = await _campaignItemAppService.GetAllListAsync();
            return new ListResultDto<CampaignItemListDto>(ObjectMapper.Map<List<CampaignItemListDto>>(query));
        }
        #endregion

        #region 新增/修改
        /// <summary>
        /// 新增/修改
        /// </summary>
        /// <param name="input"></param>
        public async Task CreateOrUpdateAsync(CampaignItemEditDto input)
        {
            if (input.Id.HasValue)
            {
                await UpdateItemAsync(input);
            }
            else
            {
                await CreateItemAsync(input);
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteAsync(EntityDto input)
        {
            var entity = _campaignItemAppService.GetAsync(input.Id);
            if (entity == null)
            {
                throw new UserFriendlyException("该明细不存在，删除失败");
            }
            await _campaignItemAppService.DeleteAsync(input.Id);
        }
        #endregion

        #region 执行新增/修改
        /// <summary>
        /// 新增明细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected async Task CreateItemAsync(CampaignItemEditDto input)
        {
            var model = input.MapTo<CampaignItem>();
            await _campaignItemAppService.InsertAsync(model);
        }

        /// <summary>
        /// 修改明细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected async Task UpdateItemAsync(CampaignItemEditDto input)
        {
            var model = await _campaignItemAppService.GetAsync(input.Id.Value);
            input.CampaignId = model.CampaignId;
            var dto = input.MapTo(model);
            await _campaignItemAppService.UpdateAsync(dto);
        }
        #endregion
    }
}
