using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using ShopManage.Shop.Product.Dtos;

namespace ShopManage.Shop.Product
{
    public class CategoryAppService : ShopManageAppServiceBase, ICategoryAppService
    {
        //注入
        private readonly IRepository<Category> _categoryRepository;
        public CategoryAppService(IRepository<Category> categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateCategoryAsync(CategoryEditDto input)
        {
            if (input.Id.HasValue)
            {
                await UpdateCategoryAsync(input);
            }
            else
            {
                await CreateCategoryAsync(input);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeteleCategoryAsync(EntityDto input)
        {
            var entity = _categoryRepository.GetAsync(input.Id);
            if (entity == null)
            {
                throw new UserFriendlyException("该品类不存在，删除失败");
            }
            await _categoryRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<CategoryListDto>> GetAllCategoryAsync()
        {
            var query = await _categoryRepository.GetAllListAsync();
            return new ListResultDto<CategoryListDto>(ObjectMapper.Map<List<CategoryListDto>>(query));
        }

        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CategoryListDto> GetCategoryByIdAsync(NullableIdDto input)
        {
            var entity = await _categoryRepository.GetAsync(input.Id.Value);
            return entity.MapTo<CategoryListDto>();
        }

        protected async Task CreateCategoryAsync(CategoryEditDto input)
        {
            await _categoryRepository.InsertAsync(input.MapTo<Category>());
        }
        protected async Task UpdateCategoryAsync(CategoryEditDto input)
        {
            var model = await _categoryRepository.GetAsync(input.Id.Value);
            await _categoryRepository.UpdateAsync(input.MapTo(model));
        }
    }
}
