using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByIdWithProductAsync(Guid id);
    }
}