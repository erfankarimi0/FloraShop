using FloraShop.Application.DTOs.Products;
using FloraShop.Application.Interfaces;
using FloraShop.Domain.Entities;
using FloraShop.Domain.Interfaces;

namespace FloraShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Create
        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = new Product(
                dto.Name,
                dto.Description,
                dto.Stock,
                dto.Price
            );

            await _productRepository.AddAsync(product);
        }

        // Read All
        public async Task<IReadOnlyList<GetAllProductResultDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(p => new GetAllProductResultDto
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock,
                Price = p.Price,
                Status = p.Status.ToString()
            }).ToList();
        }

        // Read By Id
        public async Task<GetProductResultDto?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return null;

            return new GetProductResultDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock,
                Price = product.Price,
                InsertDate = product.InsertDate,
                UpdateDate = product.UpdateDate,
                Status = product.Status.ToString()
            };
        }

        // Update
        public async Task UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new Exception("محصول موردنظر یافت نشد.");

            product.Update(
                dto.Name,
                dto.Description,
                dto.Stock,
                dto.Price
            );

            await _productRepository.UpdateAsync(product);
        }
    }
}