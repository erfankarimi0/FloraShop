using FloraShop.Domain.Entities;

namespace FloraShop.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        Task<Product?> GetByIdAsync(int id);

        Task<IReadOnlyList<Product>> GetAllAsync();

        Task UpdateAsync(Product product);
    }
}
