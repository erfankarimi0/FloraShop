using FloraShop.Domain.Entities;
using FloraShop.Domain.Enums;
using FloraShop.Domain.Interfaces;
using FloraShop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FloraShop.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FloraContext _context;

        public ProductRepository(FloraContext context)
        {
            _context = context;
        }

        // Create
        public async Task AddAsync(Product product)
        {
            var dbProduct = new FloraShop.Infra.Data.Models.Product
            {
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock,
                Price = product.Price,
                Status = product.Status.ToString()
            };

            await _context.Products.AddAsync(dbProduct);
            await _context.SaveChangesAsync();
        }

        // Read All
        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var dbProducts = await _context.Products
                .AsNoTracking()
                .ToListAsync();

            return dbProducts.Select(p => Product.Reconstitute(
                p.Id,
                p.Name,
                p.Description,
                p.Stock,
                p.Price,
                p.InsertDate,
                p.UpdateDate,
                Enum.Parse<ProductStatus>(p.Status)
            )).ToList();
        }

        // Read By Id
        public async Task<Product?> GetByIdAsync(int id)
        {
            var p = await _context.Products.FindAsync(id);

            if (p == null)
                return null;

            return Product.Reconstitute(
                p.Id,
                p.Name,
                p.Description,
                p.Stock,
                p.Price,
                p.InsertDate,
                p.UpdateDate,
                Enum.Parse<ProductStatus>(p.Status)
            );
        }

        // Update
        public async Task UpdateAsync(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.Id);

            if (dbProduct == null)
                throw new Exception("Product not found.");

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Stock = product.Stock;
            dbProduct.Price = product.Price;
            dbProduct.Status = product.Status.ToString();
            dbProduct.UpdateDate = product.UpdateDate;

            await _context.SaveChangesAsync();
        }
    }
}