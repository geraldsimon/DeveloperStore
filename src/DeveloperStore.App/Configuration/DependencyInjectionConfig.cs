using DeveloperStore.Business.Interfaces;
using DeveloperStore.Business.Services;
using DeveloperStore.Data.Repository;

namespace DeveloperStore.App.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        // Data
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();

        // Business
        services.AddScoped<ISellerService, SellerService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IUser, AspNetUser>();


        return services;
    }
}