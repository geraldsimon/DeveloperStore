using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<List<Post>> GetAllAsync(Guid sellerId);
    }
}