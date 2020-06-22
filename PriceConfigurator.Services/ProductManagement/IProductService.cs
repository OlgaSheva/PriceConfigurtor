using PriceConfigurator.DataAccess.Models.ProductModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceConfigurator.Services.ProductManagement
{
    /// <summary>
    /// Represents a product service.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets a products list.
        /// </summary>
        /// <returns>A <see cref="Task{List{Product}}"/>.</returns>
        Task<List<Product>> GetProductsAsync();

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">A <see cref="Product"/>.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task CreateProductAsync(Product product);

        /// <summary>
        /// Updates an existed product.
        /// </summary>
        /// <param name="product">A <see cref="Product"/>.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task UpdateProductAsync(Product product);

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">A product identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteProductAsync(int id);
    }
}