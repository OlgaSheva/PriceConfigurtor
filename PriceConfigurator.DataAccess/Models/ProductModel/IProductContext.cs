namespace PriceConfigurator.DataAccess.Models.ProductModel
{
    /// <summary>
    /// Represents a context for product domain.
    /// </summary>
    public interface IProductContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Product"/> entities.
        /// </summary>
        IEntitySet<Product> Products { get; }
    }
}
