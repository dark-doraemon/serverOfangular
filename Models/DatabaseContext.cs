using Microsoft.EntityFrameworkCore;
using System.Data;

namespace webapi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<User> Users { get;set; }
        public DbSet<Role> Roles { get;set; }
    }
}
