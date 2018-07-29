using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ShopManage.Authorization.Roles;
using ShopManage.Authorization.Users;
using ShopManage.MultiTenancy;
using ShopManage.Shop.Product;
using ShopManage.Activity;
using ShopManage.Cart;

namespace ShopManage.EntityFrameworkCore
{
    public class ShopManageDbContext : AbpZeroDbContext<Tenant, Role, User, ShopManageDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ShopManageDbContext(DbContextOptions<ShopManageDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<CampaignItem> CampaignItem { get; set; }
        public DbSet<CartModel> CartModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("AbpProduct");
            modelBuilder.Entity<Category>().ToTable("AbpCategory");
            modelBuilder.Entity<Campaign>().ToTable("AbpCampaign");
            modelBuilder.Entity<CampaignItem>().ToTable("AbpCampaignItem");
            modelBuilder.Entity<CartModel>().ToTable("AbpCart");

            base.OnModelCreating(modelBuilder);
        }
    }
}
