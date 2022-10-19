using FreshMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace FreshMarket.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        // public DbSet<Product> products { get; set; }
        public DbSet<User> users{ get; set; }
        public DbSet<Dish> dishes{ get; set; }
        public DbSet<Tier> tiers { get; set; }
        public DbSet<Subscription> subscriptions{ get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Allergy> allergies { get; set; }
        
    }
}
