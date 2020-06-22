namespace PriceConfigurator.DataAccess.Models.CategoryModel
{
    /// <summary>
    /// A context for category domain.
    /// </summary>
    internal sealed class CategoryContext : DomainContextBase<ApplicationDbContext>, ICategoryContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryContext"/> class.
        /// </summary>
        public CategoryContext(ApplicationDbContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public IEntitySet<Category> Categories => GetDbSet<Category>();
    }
}
