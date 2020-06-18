namespace PriceConfigurator.DataAccess.Models.CategoryModel
{
    /// <summary>
    /// Represents a context for category domain.
    /// </summary>
    public interface ICategoryContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Category"/> entities.
        /// </summary>
        IEntitySet<Category> Categories { get; }
    }
}
