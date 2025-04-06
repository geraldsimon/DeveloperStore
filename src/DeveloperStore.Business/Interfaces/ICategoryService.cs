using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> GetByIdWithProductAsync(Guid id);
        Task<Category> GetByNameAsync(string name);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Guid id);
    }
}
