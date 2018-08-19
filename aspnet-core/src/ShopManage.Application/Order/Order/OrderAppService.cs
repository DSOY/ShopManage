using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using ShopManage.Order.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManage.Order
{
    /// <summary>
    /// 订单
    /// </summary>
    [AbpAuthorize]
    public class OrderAppService : ShopManageAppServiceBase, IOrderAppService
    {
        #region 注入
        private readonly IRepository<OrderModel> _orderAppService;
        private readonly IRepository<OrderItemModel> _orderItemAppService;
        public IAbpSession AbpSession { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartAppService"></param>
        public OrderAppService(IRepository<OrderModel> orderAppService, IRepository<OrderItemModel> orderItemAppService)
        {
            _orderAppService = orderAppService;
            _orderItemAppService = orderItemAppService;
            AbpSession = NullAbpSession.Instance;
        }
        #endregion

        #region 获取客户订单
        /// <summary>
        /// 获取客户订单
        /// </summary>
        public async Task<ListResultDto<OrderListDto>> GetByUserAsync(int? userId)
        {
            var currentUserId = userId.HasValue? userId.Value:AbpSession.UserId;

            var query = _orderAppService.GetAllIncluding(p => p.AddressModel).Where(x => x.UserID == currentUserId);
            return new ListResultDto<OrderListDto>(ObjectMapper.Map<List<OrderListDto>>(query));
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrderAsync(OrderInputDto input)
        {
            if(input.OrderItem.Count == 0)
            {
                throw new UserFriendlyException("请选择商品");
            }

            var carrier = System.Configuration.ConfigurationSettings.AppSettings["Carrier"];
            var ticks = DateTime.Now.Ticks.ToString();
            var model = input.MapTo<OrderModel>();
            model.UserID = Convert.ToInt32(AbpSession.UserId);
            model.TenantID = AbpSession.TenantId.HasValue ? AbpSession.TenantId.Value : 1;
            model.Carrier = carrier;
            model.OrderNo = model.TenantID + ticks.Substring(ticks.Length-6);
            model.Status = (int)OrderStatus.Wait;
            model.FreightPoint = 0;
            model.OrderItemModel = new List<OrderItemModel>();
            foreach (var item in input.OrderItem)
            {
                var Itemmodel = item.MapTo<OrderItemModel>();
                model.OrderItemModel.Add(Itemmodel);
            }
            await _orderAppService.InsertAndGetIdAsync(model);

            //foreach (var item in input.OrderItem)
            //{
            //    var Itemmodel = item.MapTo<OrderItemModel>();
            //    Itemmodel.OrderId = orderId;
            //    await _orderItemAppService.InsertAsync(Itemmodel);
            //}

        }
        #endregion

        #region 关闭订单
        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task CloseOrderAsync(int id)
        {
            var model = await _orderAppService.GetAsync(id);
            if (model == null)
            {
                throw new UserFriendlyException("订单不存在，操作失败");
            }
            model.Status = (int)OrderStatus.Close; ;
            await _orderAppService.UpdateAsync(model);
        }
        #endregion
    }
}
