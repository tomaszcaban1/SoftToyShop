using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftToyShop.Repository.Models;

namespace SoftToyShop.Repository.Services
{
    public class SoftToyShopDbContext : IdentityDbContext<IdentityUser>
    {
        public SoftToyShopDbContext(DbContextOptions<SoftToyShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<SoftToy> SoftToys { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
