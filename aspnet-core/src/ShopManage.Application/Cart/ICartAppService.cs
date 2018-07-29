using Abp.Application.Services;
using ShopManage.Cart.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopManage.Cart
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICartAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateCartAsync(CartInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isAdd"></param>
        /// <returns></returns>
        Task UpdateQtyAsync(int id, IsAdd isAdd);
    }
}
