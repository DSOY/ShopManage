using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using ShopManage.Cart.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopManage.Cart
{
    /// <summary>
    /// 
    /// </summary>
    public class CartAppService : ShopManageAppServiceBase, ICartAppService
    {
        #region 注入
        private readonly IRepository<CartModel> _cartAppService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartAppService"></param>
        public CartAppService(IRepository<CartModel> cartAppService)
        {
            _cartAppService = cartAppService;
        }
        #endregion

        #region 获取购物车
        /// <summary>
        /// 获取购物车
        /// </summary>
        public async Task<ListResultDto<CartListDto>> GetByUserAsync(int id)
        {
            var query = await _cartAppService.GetAllListAsync(x => x.UserID == id);
            //var query = await _campaignItemAppService.GetAllListAsync();
            return new ListResultDto<CartListDto>(ObjectMapper.Map<List<CartListDto>>(query));
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateCartAsync(CartInput input)
        {
            var productId = input.ProductId;
            var model = input.MapTo<CartModel>();
            await _cartAppService.InsertAsync(model);
        }
        #endregion

        #region 修改购物车商品数量
        /// <summary>
        /// 修改购物车商品数量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isAdd">添加：1  减少：0</param>
        /// <returns></returns>
        public async Task UpdateQtyAsync(int id, IsAdd isAdd)
        {
            var model = await _cartAppService.GetAsync(id);
            if (model == null)
            {
                throw new UserFriendlyException("商品不存在，操作失败");
            }
            if (Convert.ToBoolean(isAdd))
            {
                model.Qty += 1;
                await _cartAppService.UpdateAsync(model);
            }
            else
            {
                if (model.Qty <= 1)
                {
                    await _cartAppService.DeleteAsync(id);
                }
            }
        }
        #endregion
        
    }
}
