using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using ShopManage.Activity.CampaignService;
using ShopManage.Activity.CampaignService.Dtos;
using ShopManage.Controllers;
using ShopManage.Shop.Product;

namespace ShopManage.Web.Mvc.Controllers
{
    public class CampaignController : ShopManageControllerBase
    {
        private readonly ICampaignAppService _campaignAppService;
        private readonly IProductAppService _productAppService;

        public CampaignController(ICampaignAppService campaignAppService, IProductAppService productAppService)
        {
            _campaignAppService = campaignAppService;
            _productAppService = productAppService;
        }

        public async Task<IActionResult> Index(GetCampaignInput input)
        {
            var list = await _campaignAppService.GetPagedCampaignAsync(input);
            return View(list);
        }

        public async Task<ActionResult> EditCampaignModal(int Id)
        {
            var input = new NullableIdDto() { Id = Id };
            var entity = await _campaignAppService.GetCampaignByIdAsync(input);
            return View("_EditCampaignModal", entity);
        }

        public async Task<ActionResult> GetCampaignItemModal(int Id)
        {
            var input = new NullableIdDto() { Id = Id };
            var entity = await _campaignAppService.GetCampaignByIdAsync(input);
            ViewBag.Product = await _productAppService.GetAllAsnyc();
            
            return View("_GetCampaignItemModal", entity);
        }
    }
}