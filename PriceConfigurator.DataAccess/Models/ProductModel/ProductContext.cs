namespace PriceConfigurator.DataAccess.Models.ProductModel
{
    /// <summary>
    /// A context for product domain.
    /// </summary>
    internal sealed class ProductContext : DomainContextBase<ApplicationDbContext>, IProductContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductContext"/> class.
        /// </summary>
        public ProductContext(ApplicationDbContext context) : base(context)
        { }

        /// <inheritdoc/>
        public IEntitySet<Product> Products => GetDbSet<Product>();
    }
}
