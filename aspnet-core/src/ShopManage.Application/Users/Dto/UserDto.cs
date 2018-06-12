using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using ShopManage.Authorization.Users;

namespace ShopManage.Users.Dto
{
    /// <summary>
    /// 用户
    /// </summary>
    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
        
        /// <summary>
        /// 是否使用
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 全称
        /// </summary>
        public string FullName { get; set; }
        

        /// <summary>
        /// 角色名称
        /// </summary>

        public string[] RoleNames { get; set; }
        
        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }

        private DateTime birthDay;
        /// <summary>
        /// 生日
        /// </summary>
        public string BirthDay {
            get { return birthDay.ToString("yyyy-MM-dd");}
            set { birthDay = Convert.ToDateTime(value); }
        }

    }
}
