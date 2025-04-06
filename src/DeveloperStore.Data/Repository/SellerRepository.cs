using DeveloperStore.Business.Interfaces;
using DeveloperStore.Business.Models;

namespace DeveloperStore.Data.Repository;

 public class SellerRepository : Repository<Seller>, ISellerRepository
{
    public SellerRepository(AppDbContext context) : base(context)
    {
    }
}