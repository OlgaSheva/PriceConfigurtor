using PriceConfigurator.DataAccess.Models.CategoryModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceConfigurator.Services.CategoryManagement
{
    /// <summary>
    /// Represents a category service.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Gets a categories list.
        /// </summary>
        /// <returns>A <see cref="Task{List{Category}}"/>.</returns>
        Task<List<Category>> GetCategoriesAsync();

        /// <summary>
        /// Gets a category names list.
        /// </summary>
        /// <returns>A <see cref="Task{List{string}}"/>.</returns>
        Task<List<string>> GetCategoryNamesAsync();

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="category">A <see cref="Category"/>.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task CreateCategoryAsync(Category category);

        /// <summary>
        /// Deletes an existed category.
        /// </summary>
        /// <param name="category">A <see cref="Category"/>.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteCategoryAsync(int id);

        /// <summary>
        /// Updates an existed category.
        /// </summary>
        /// <param name="category">A <see cref="Category"/>.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task UpdateCategoryAsync(Category category);
    }
}