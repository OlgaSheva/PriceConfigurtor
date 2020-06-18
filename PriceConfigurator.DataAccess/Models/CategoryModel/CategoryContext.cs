namespace PriceConfigurator.DataAccess.Models.CategoryModel
{
    /// <summary>
    /// A context for category domain.
    /// </summary>
    internal sealed class CategoryContext : DomainContextBase<ApplicationDbContext>, ICategoryContext
    {
        public CategoryContext(ApplicationDbContext context) : base(context)
        {
        }

        public IEntitySet<Category> Categories => GetDbSet<Category>();
    }
}
