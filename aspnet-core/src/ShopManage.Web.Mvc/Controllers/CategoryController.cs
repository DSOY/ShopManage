using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using ShopManage.Controllers;
using ShopManage.Shop.Product;

namespace ShopManage.Web.Mvc.Controllers
{
    public class CategoryController : ShopManageControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _categoryAppService.GetAllCategoryAsync();
            return View(model);
        }

        public async Task<ActionResult> EditCategoryModal(int categoryId)
        {
            var input = new NullableIdDto() { Id = categoryId };
            var entity = await _categoryAppService.GetCategoryByIdAsync(input);
            return View("_EditCategoryModal", entity);
        }
    }
}