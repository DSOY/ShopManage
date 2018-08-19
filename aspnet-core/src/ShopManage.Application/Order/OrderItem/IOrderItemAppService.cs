using Abp.Application.Services;
using ShopManage.Order.OrderItem.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopManage.Order.OrderItem
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrderItemAppService: IApplicationService
    {
        Task CreateOrderItemAsync(OrderItemInputDto input);
    }
}
