using Microsoft.EntityFrameworkCore;

namespace PriceConfigurator.Model.Database
{
    public class PriceConfiguratorContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=product.db");
    }
}
