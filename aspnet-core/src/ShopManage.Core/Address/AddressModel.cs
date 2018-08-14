using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopManage.Address
{
    [Table("AbpAddress")]
    public class AddressModel : Entity<int>
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        [Required]
        public int UserID { set; get; }

        /// <summary>
        /// 地区编码
        /// </summary>
        [Required]
        public int Area { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [Phone]
        public string Phone { set; get; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }

        /// <summary>
        /// 街道门牌
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string StreetHouse { set; get; }

        /// <summary>
        /// 是否默认        ///   0=否        ///   1=是
        /// </summary>
        [Required]
        public int IsDefault { set; get; }

        /// <summary>
        /// 是否使用        ///   0=使用        ///   1=不使用
        /// </summary>
        [Required]
        public bool IsDetele { get; set; }
    }
}
