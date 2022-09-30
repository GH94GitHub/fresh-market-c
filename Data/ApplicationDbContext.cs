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

        public DbSet<Product> products { get; set; }
        public DbSet<User> users{ get; set; }
    }
}
