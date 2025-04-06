using AutoMapper;
using DeveloperStore.Api.ViewModels;
using DeveloperStore.Business.Models;
using DeveloperStore.Shared.ViewModels;

namespace DeveloperStore.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductLoggedOutViewModel>().ReverseMap();
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
        }
    }
}