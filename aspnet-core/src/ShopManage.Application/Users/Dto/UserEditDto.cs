using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopManage.Users.Dto
{
    /// <summary>
    /// 修改用户
    /// </summary>
    public class UserEditDto
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [Required]
        public DateTime BirthDay { get; set; }
    }
}
