using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ShopManage.Shop.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopManage.Shop.Product
{
    /// <summary>
    /// 品类（IApplicationService生成接口）
    /// </summary>
    public interface ICategoryAppService : IApplicationService
    {
        /// <summary>
        /// 获取所有品类数据
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<CategoryListDto>> GetAllCategoryAsync();

        /// <summary>
        /// 根据ID获取商品
        /// </summary>
        /// <returns></returns>
        Task<CategoryListDto> GetCategoryByIdAsync(NullableIdDto input);

        /// <summary>
        /// 新增或修改品类信息
        /// </summary>
        /// <returns></returns>
        Task CreateOrUpdateCategoryAsync(CategoryEditDto input);

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeteleCategoryAsync(EntityDto input);
    }
}
