using Autofac;
using PriceConfigurator.DataAccess.Models.CategoryModel;
using PriceConfigurator.DataAccess.Models.ProductModel;

namespace PriceConfigurator.DataAccess
{
    /// <summary>
    /// Represents an assembly dependency registration <see cref="Module"/>.
    /// </summary>
    public sealed class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().SingleInstance().InstancePerLifetimeScope();
            builder.RegisterType<ProductContext>().As<IProductContext>();
            builder.RegisterType<CategoryContext>().As<ICategoryContext>();
        }
    }
}
