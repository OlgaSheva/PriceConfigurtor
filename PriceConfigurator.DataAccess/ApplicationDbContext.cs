using Microsoft.EntityFrameworkCore;
using PriceConfigurator.DataAccess.Models.CategoryModel;
using PriceConfigurator.DataAccess.Models.ProductModel;
using System;

namespace PriceConfigurator.DataAccess
{
    /// <summary>
    /// Represents an application database context.
    /// </summary>
    internal sealed class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={AppContext.BaseDirectory}/price_configurator.db");
    }
}
