using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
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
    public class OrderItemAppService : ShopManageAppServiceBase, IOrderItemAppService
    {
        #region 注入
        private readonly IRepository<OrderItemModel> _orderItemAppService;
        public IAbpSession AbpSession { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartAppService"></param>
        public OrderItemAppService(IRepository<OrderItemModel> orderItemAppService)
        {
            _orderItemAppService = orderItemAppService;
            AbpSession = NullAbpSession.Instance;
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrderItemAsync(OrderItemInputDto input)
        {
            var model = input.MapTo<OrderItemModel>();

            await _orderItemAppService.InsertAsync(model);
        }
        #endregion
    }
}
