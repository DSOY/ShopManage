using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using ShopManage.Authorization.Users;

namespace ShopManage.Users.Dto
{
    /// <summary>
    /// �û�
    /// </summary>
    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        /// <summary>
        /// �û���
        /// </summary>
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
        
        /// <summary>
        /// �Ƿ�ʹ��
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// ȫ��
        /// </summary>
        public string FullName { get; set; }
        

        /// <summary>
        /// ��ɫ����
        /// </summary>

        public string[] RoleNames { get; set; }
        
        /// <summary>
        /// ͷ��
        /// </summary>
        public string Portrait { get; set; }

        private DateTime birthDay;
        /// <summary>
        /// ����
        /// </summary>
        public string BirthDay {
            get { return birthDay.ToString("yyyy-MM-dd");}
            set { birthDay = Convert.ToDateTime(value); }
        }

    }
}
