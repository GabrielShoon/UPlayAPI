using UPlayAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UPlayAPI
{
    public class MyDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public MyDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        {
            string? connectionString = _configuration.GetConnectionString(
            "MyConnection");
            if (connectionString != null)
            {
                optionsBuilder.UseMySQL(connectionString);
            }
        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<UserBudget> UserBudget { get; set; }
    }
}
