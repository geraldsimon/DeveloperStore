using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllAsync(Guid sellerId);
        Task<Comment> GetByIdAsync(Guid id);
        Task AddAsync(Comment comment);
        Task UpdateAsync(Comment comment, Guid sellerId);
        Task DeleteAsync(Guid id, Guid sellerId);
    }
}