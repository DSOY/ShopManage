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
    /// 
    /// </summary>
    public interface IProductAppService: IApplicationService
    {
        /// <summary>
        /// 获取商品分页数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ProductListDto>> GetPagedProductAsync(GetProductInput input);

        /// <summary>
        /// 根据品类获取商品分页数据
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<ProductListDto>> GetPagedProductByCategory(GetProductByCategoryInput input);

        /// <summary>
        /// 根据ID获取商品
        /// </summary>
        /// <returns></returns>
        Task<ProductListDto> GetProductByIdAsync(NullableIdDto input);

        /// <summary>
        /// 新增或修改商品信息
        /// </summary>
        /// <returns></returns>
        Task CreateOrUpdateProductAsync(CreateOrUpdateProductInput input);

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeteleProductAsync(EntityDto input);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAllAsnyc();
    }
}
