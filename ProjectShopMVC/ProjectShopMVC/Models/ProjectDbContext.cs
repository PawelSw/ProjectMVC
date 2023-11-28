
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace ProjectShopMVC.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
