using DeveloperStore.Business.Interfaces;
using DeveloperStore.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Data.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context) : base(context) => _context = context;


    public async Task<Category> GetByIdWithProductAsync(Guid id)
    {
        return await _context.Categories
            .AsNoTracking()
            .Include(c => c.Products)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}