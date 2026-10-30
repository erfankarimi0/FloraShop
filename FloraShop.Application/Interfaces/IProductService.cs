
using FloraShop.Application.DTOs.Products;

namespace FloraShop.Application.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(CreateProductDto dto);

        Task<GetProductResultDto?> GetByIdAsync(int id);

        Task<IReadOnlyList<GetAllProductResultDto>> GetAllAsync();

        Task UpdateAsync(int id, UpdateProductDto dto);
    }
}
