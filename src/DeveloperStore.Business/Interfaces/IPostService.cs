using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllAsync(Guid sellerId);
        Task<Post> GetByIdAsync(Guid id);
        Task AddAsync(Post post);
        Task UpdateAsync(Post post, Guid sellerId);
        Task DeleteAsync(Guid id, Guid sellerId);
    }
}