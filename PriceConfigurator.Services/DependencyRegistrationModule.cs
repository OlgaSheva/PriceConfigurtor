using Autofac;
using PriceConfigurator.Services.CategoryManagement;
using PriceConfigurator.Services.ProductManagement;

namespace PriceConfigurator.Services
{
    /// <summary>
    /// Represents an assembly dependency registration <see cref="Module"/>.
    /// </summary>
    public sealed class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
        }
    }
}
