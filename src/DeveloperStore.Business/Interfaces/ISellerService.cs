using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Interfaces
{
    public interface ISellerService
    {
        Task AddAsync(Seller seller);
    }
}
