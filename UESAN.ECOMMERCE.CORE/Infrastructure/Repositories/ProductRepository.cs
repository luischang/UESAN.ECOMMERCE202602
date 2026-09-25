using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UESAN.ECOMMERCE.CORE.Core.Entities;
using UESAN.ECOMMERCE.CORE.Core.Interfaces;
using UESAN.ECOMMERCE.CORE.Infrastructure.Data;

namespace UESAN.ECOMMERCE.CORE.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _dbContext
                                .Product
                                .Where(p => p.IsActive == true)
                                .Include(c => c.Category)                                
                                .ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _dbContext
                                .Product
                                .Where(p => p.Id == id && p.IsActive == true)
                                .Include(c => c.Category)
                                .FirstOrDefaultAsync();
            return product;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            product.IsActive = true;
            await _dbContext.Product.AddAsync(product);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var existing = await _dbContext
                                .Product
                                .Where(p => p.Id == product.Id)
                                .FirstOrDefaultAsync();
            if (existing != null)
            {
                existing.Description = product.Description;
                existing.ImageUrl = product.ImageUrl;
                existing.Stock = product.Stock;
                existing.Price = product.Price;
                existing.Discount = product.Discount;
                existing.CategoryId = product.CategoryId;

                var rows = await _dbContext.SaveChangesAsync();
                return rows > 0;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var existing = await _dbContext
                               .Product
                               .Where(p => p.Id == id)
                               .FirstOrDefaultAsync();
            if (existing != null)
            {
                existing.IsActive = false;
                var rows = await _dbContext.SaveChangesAsync();
                return rows > 0;
            }
            return false;
        }
    }
}
