using DeveloperStore.Business.Models;
using Microsoft.AspNetCore.Identity;

namespace DeveloperStore.Business.Interfaces
{
    public interface ISellerRepository : IRepository<Seller>
    {
        //Task<IdentityResult> CreateSellerAsync(Seller seller, string password);
        //Task<SignInResult> Login(Login login);
        //Task<bool> Logout();
    }
}
