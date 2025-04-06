using DeveloperStore.Business.Interfaces;
using DeveloperStore.Business.Models;

namespace DeveloperStore.Business.Services;

public class SellerService(ISellerRepository sellerRepository) : ISellerService
{
    private readonly ISellerRepository _sellerRepository = sellerRepository;

    public async Task AddAsync(Seller seller)
    {
        await _sellerRepository.AddAsync(seller);
    }
}