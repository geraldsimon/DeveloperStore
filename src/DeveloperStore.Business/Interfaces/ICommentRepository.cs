using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<List<Comment>> GetAllAsync(Guid sellerId);
    }
}