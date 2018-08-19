using Abp.Domain.Entities.Auditing;
using ShopManage.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopManage.Order
{
    [Table("AbpOrder")]
    public class OrderModel : FullAuditedEntity
    {
        /// <summary>
        /// 租户ID
        /// </summary>
        public int? TenantID { set; get; }

        /// <summary>
        /// 会员ID
        /// </summary>
        [Required]
        public int UserID { set; get; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [Required]
        public string OrderNo { set; get; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [Required]
        public int Status { set; get; }

        /// <summary>
        /// 活动ID
        /// </summary>
        public int? ActivityID { set; get; }

        /// <summary>
        /// 商品合计
        /// </summary>
        [Required]
        public int Qty { set; get; }

        /// <summary>
        /// 实付总额
        /// </summary>
        [Required]
        public int PayPoint { set; get; }

        /// <summary>
        /// 运费
        /// </summary>
        public int FreightPoint { set; get; }

        /// <summary>
        /// 正价货款总额
        /// </summary>
        public int ProductPrice { set; get; }

        /// <summary>
        /// 地址信息
        /// </summary>
        public AddressModel AddressModel { get; set; }

        /// <summary>
        /// 买家备注
        /// </summary>
        [MaxLength(500)]
        public string BuyerRemark { set; get; }
        
        /// <summary>
        /// 运单ID
        /// </summary>
        public string ExpressID { set; get; }

        /// <summary>
        /// 运单号
        /// </summary>
        public string ExpressNO { set; get; }

        /// <summary>
        /// 承运公司
        /// </summary>
        [MaxLength(50)]
        public string Carrier { set; get; }

        public List<OrderItemModel> OrderItemModel { get; set; }
    }
}
