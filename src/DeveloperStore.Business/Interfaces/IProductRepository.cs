using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllWithCategoryBySellerAsync(Guid Id);
        Task<List<Product>> GetAllByCategory(Guid id);
        Task<List<Product>> GetAllWithCategoryAsync();
        Task<Product> GetByIdAsync(Guid? id);
        Task<Product> GetByIdAsync(Guid? id, Guid? sellerId);
        Task<bool> GetAnyAsync(Guid id);
    }
}