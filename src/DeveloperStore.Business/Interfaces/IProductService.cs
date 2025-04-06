using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllByCategory(Guid id);
        Task<IEnumerable<Product>> GetAllWithCategoryAsync();
        Task<IEnumerable<Product>> GetAllWithCategoryBySellerAsync(Guid id);
        Task<Product> GetByIdAsync(Guid id, Guid sellerId);
        Task<Product> GetByIdAsync(Guid? id);
        Task<bool> GetAnyAsync(Guid id);
        Task<bool> AddAsync(Product product);
        Task<bool> DeleteAsync(Guid id);
        Task UpdateAsync(Product product);
    }
}