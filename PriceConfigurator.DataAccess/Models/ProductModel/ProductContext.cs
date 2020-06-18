namespace PriceConfigurator.DataAccess.Models.ProductModel
{
    /// <summary>
    /// A context for product domain.
    /// </summary>
    internal sealed class ProductContext : DomainContextBase<ApplicationDbContext>, IProductContext
    {
        public ProductContext(ApplicationDbContext context) : base(context)
        { }

        public IEntitySet<Product> Products => GetDbSet<Product>();
    }
}
