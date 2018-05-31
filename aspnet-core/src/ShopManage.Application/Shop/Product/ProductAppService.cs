using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using ShopManage.Shop.Product.Dtos;

namespace ShopManage.Shop.Product
{
    /// <summary>
    /// 商品服务层
    /// </summary>
    public class ProductAppService : ShopManageAppServiceBase, IProductAppService
    {
        #region 注入
        private readonly IRepository<Product> _productRepository;

        /// <summary>
        /// 商品逻辑层
        /// </summary>
        /// <param name="productRepository"></param>
        public ProductAppService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region 创建或新增商品
        /// <summary>
        /// 创建或新增商品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateProductAsync(CreateOrUpdateProductInput input)
        {
            if (input.ProductEditDto.Id.HasValue)
            {
                await UpdateProductAsync(input.ProductEditDto);
            }
            else
            {
                await CreateProductAsync(input.ProductEditDto);
            }
        }

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected async Task UpdateProductAsync(ProductEditDto input)
        {
            var entity = await _productRepository.GetAsync(input.Id.Value);
            await _productRepository.UpdateAsync(input.MapTo(entity));
        }

        /// <summary>
        /// 创建商品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected async Task CreateProductAsync(ProductEditDto input)
        {
            var model = input.MapTo<Product>();
            await _productRepository.InsertAsync(model);
        }
        #endregion

        #region 根据ID删除商品
        /// <summary>
        /// 根据ID删除商品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeteleProductAsync(EntityDto input)
        {
            var entity = await _productRepository.GetAsync(input.Id);
            if (entity == null)
            {
                throw new UserFriendlyException("商品不存在，删除失败");
            }

            await _productRepository.DeleteAsync(input.Id);
        }
        #endregion

        #region 获取商品分页数据
        /// <summary>
        /// 获取商品分页数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<ProductListDto>> GetPagedProductAsync(GetProductInput input)
        {
            var query = _productRepository.GetAllIncluding(p => p.Category);
            var productCount = await query.CountAsync();
            var products = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = products.MapTo<List<ProductListDto>>();

            return new PagedResultDto<ProductListDto>(productCount, dtos);
        }
        #endregion

        #region 根据品类获取商品分页数据
        /// <summary>
        /// 根据品类获取商品分页数据
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns></returns>
        public async Task<PagedResultDto<ProductListDto>> GetPagedProductByCategory(GetProductByCategoryInput input)
        {
            var query = _productRepository.GetAllIncluding(p => p.Category).Where(p => p.CategoryId == input.CategoryId);

            var count = await query.CountAsync();
            var products =await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = products.MapTo<List<ProductListDto>>();

            return new PagedResultDto<ProductListDto>(count, dtos);
        }
        #endregion

        #region 根据ID获取商品
        /// <summary>
        /// 根据ID获取商品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ProductListDto> GetProductByIdAsync(NullableIdDto input)
        {
            var entity = await _productRepository.GetAllIncluding(p=>p.Category).FirstOrDefaultAsync(x=>x.Id==input.Id.Value);
            return entity.MapTo<ProductListDto>();
            //var entity = await _productRepository.GetAsync(input.Id.Value);
            //return entity.MapTo<ProductListDto>();
        }
        #endregion
    }
}
