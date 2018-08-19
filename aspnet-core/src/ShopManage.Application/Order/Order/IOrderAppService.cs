using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ShopManage.Order.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopManage.Order
{
    /// <summary>
    /// 订单
    /// </summary>
    public interface IOrderAppService : IApplicationService
    {
        Task<ListResultDto<OrderListDto>> GetByUserAsync(int? userId);

        Task CreateOrderAsync(OrderInputDto input);
    }
}
