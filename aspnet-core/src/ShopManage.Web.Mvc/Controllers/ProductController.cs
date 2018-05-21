using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using ShopManage.Controllers;
using ShopManage.Shop.Product;
using ShopManage.Shop.Product.Dtos;
using ShopManage.Web.Models.Product;

namespace ShopManage.Web.Mvc.Controllers
{
    public class ProductController : ShopManageControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;

        public ProductController(IProductAppService productAppService,
            ICategoryAppService categoryAppService)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index(GetProductInput input)
        {
            var dto = await _productAppService.GetPagedProductAsync(input);

            ViewBag.Category = await _categoryAppService.GetAllCategoryAsync();
            return View(dto);
        }

        public async Task<ActionResult> EditProductModal(int productId)
        {
            var input = new NullableIdDto() { Id=productId};
            var productDto = await _productAppService.GetProductByIdAsync(input);
            ViewBag.Category = await _categoryAppService.GetAllCategoryAsync();
            return View("_EditProductModal", productDto);
        }
    }
}