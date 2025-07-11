using CustomerApp.API.Shared.Models;
using Microsoft.EntityFrameworkCore;


namespace CustomerApp.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
