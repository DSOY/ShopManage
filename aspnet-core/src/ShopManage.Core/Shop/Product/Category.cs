using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShopManage.Shop.Product
{
    public class Category : Entity<int>
    {
        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 品类名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 品类路径
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Path { get; set; }
    }
}
