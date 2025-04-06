using AutoMapper;
using DeveloperStore.App.ViewModels;
using DeveloperStore.Business.Models;

namespace DeveloperStore.App.Configuration;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {

        CreateMap<Category, CategoryViewModel>().ReverseMap();
        CreateMap<Product, ProductViewModel>().ReverseMap();
    }
}