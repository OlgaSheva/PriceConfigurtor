using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PriceConfigurator.DataAccess.Models.ProductModel;
using PriceConfigurator.Services.Exceptions;

namespace PriceConfigurator.Services.ProductManagement
{
    /// <summary>
    /// Represents a product service.
    /// </summary>
    internal class ProductService : IProductService
    {
        private readonly IProductContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class with specified <see cref="IProductContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductContext"/>.</param>
        public ProductService(IProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<Product>> GetProductsAsync()
        {
            var dbProducts = await _context.Products.AsQueryable().OrderBy(p => p.Id).ToArrayAsync();
            return dbProducts.ToList();
        }

        /// <inheritdoc/>
        public async Task CreateProductAsync(Product product)
        {
            var dbProducts = await _context.Products.Where(p => p.Name == product.Name || p.Code == product.Code).ToArrayAsync();
            if (dbProducts.Length > 0)
            {
                throw new RequestedResourceHasConflictException("name or code");
            }

            _context.Products.Add(product);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateProductAsync(Product product)
        {
            var dbProducts = await _context.Products.Where(p => p.Name == product.Name || p.Code == product.Code).ToArrayAsync();
            if (dbProducts.Length > 0)
            {
                throw new RequestedResourceHasConflictException("name or code");
            }

            dbProducts = await _context.Products.Where(p => p.Id == product.Id).ToArrayAsync();
            if (dbProducts.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbProduct = dbProducts[0];
            dbProduct = product;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteProductAsync(int id)
        {
            var dbProducts = await _context.Products.Where(p => p.Id == id).ToArrayAsync();
            if (dbProducts.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbProduct = dbProducts[0];
            _context.Products.Remove(dbProduct);

            await _context.SaveChangesAsync();
        }
    }
}
