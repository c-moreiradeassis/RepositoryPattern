using Domain.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Repository.Database.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
