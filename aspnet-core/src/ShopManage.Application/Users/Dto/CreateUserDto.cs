using System;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using ShopManage.Authorization.Users;

namespace ShopManage.Users.Dto
{
    /// <summary>
    /// 创建用户
    /// </summary>
    [AutoMapTo(typeof(User))]
    public class CreateUserDto : IShouldNormalize
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
        /// 是否启用
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string[] RoleNames { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(512)]
        public string Portrait { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirtherDay { get; set; }

        public void Normalize()
        {
            if (RoleNames == null)
            {
                RoleNames = new string[0];
            }
        }
    }
}
