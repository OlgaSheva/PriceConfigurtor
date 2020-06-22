using Microsoft.EntityFrameworkCore;
using PriceConfigurator.DataAccess.Models.CategoryModel;
using System;
using System.Linq;
using System.Threading.Tasks;

using PriceConfigurator.Services.Exceptions;
using PriceConfigurator.DataAccess.Models.ProductModel;
using System.Collections.Generic;

namespace PriceConfigurator.Services.CategoryManagement
{
    /// <summary>
    /// Represents a category service.
    /// </summary>
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryContext _categoryContext;
        private readonly IProductContext _productContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class with specified <see cref="ICategoryContext"/> and <see cref="IProductContext"/>.
        /// </summary>
        /// <param name="categoryContext">A <see cref="ICategoryContext"/>.</param>
        /// <param name="productContext">A <see cref="IProductContext"/>.</param>
        public CategoryService(ICategoryContext categoryContext, IProductContext productContext)
        {
            _categoryContext = categoryContext ?? throw new ArgumentNullException(nameof(categoryContext));
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
        }

        /// <inheritdoc/>
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var dbCtegories = await _categoryContext.Categories.AsQueryable().OrderBy(p => p.Id).ToArrayAsync();
            return dbCtegories.ToList();
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetCategoryNamesAsync()
        {
            var dbCategoryNames = await _categoryContext.Categories.AsQueryable().Select(c => c.Name).OrderBy(n => n).ToArrayAsync();
            return dbCategoryNames.ToList();
        }

        /// <inheritdoc/>
        public async Task CreateCategoryAsync(Category category)
        {
            var dbCategories = await _categoryContext.Categories.Where(c => c.Name == category.Name).ToArrayAsync();
            if (dbCategories.Length > 0)
            {
                throw new RequestedResourceHasConflictException("name");
            }

            _categoryContext.Categories.Add(category);

            await _categoryContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateCategoryAsync(Category category)
        {
            var dbCategories = await _categoryContext.Categories.Where(c => c.Name == category.Name).ToArrayAsync();
            if (dbCategories.Length > 0)
            {
                throw new RequestedResourceHasConflictException("name");
            }

            dbCategories = await _categoryContext.Categories.Where(p => p.Id == category.Id).ToArrayAsync();
            if (dbCategories.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbCategory = dbCategories[0];
            dbCategory = category;

            await _categoryContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteCategoryAsync(int id)
        {
            var dbCategories = await _categoryContext.Categories.Where(c => c.Id == id).ToArrayAsync();
            if (dbCategories.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbCategory = dbCategories[0];

            // remove all products that belong to the category to be deleted
            var dbProducts = await _productContext.Products.Where(p => p.ProductCategory == dbCategory).ToArrayAsync();
            _productContext.Products.RemoveRange(dbProducts);

            await _productContext.SaveChangesAsync();

            _categoryContext.Categories.Remove(dbCategory);

            await _categoryContext.SaveChangesAsync();
        }
    }
}
