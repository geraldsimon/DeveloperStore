using DeveloperStore.Business.Interfaces;
using DeveloperStore.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Data.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context) : base(context) => _context = context;

        public async Task<List<Post>> GetAllAsync(Guid sellerId)
        {
            return await _context.Posts
                            .AsNoTracking()
                            .Where(p => p.SellerId == sellerId)
                            .Include(c => c.Comments)
                            .ToListAsync();
        }
    }
}