using DeveloperStore.Business.Interfaces;
using DeveloperStore.Business.Notifications;
using DeveloperStore.Business.Services;
using DeveloperStore.Data;
using DeveloperStore.Data.Repository;
 

namespace DeveloperStore.Api.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        // Data
        services.AddScoped<AppDbContext>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        // Business
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISellerService, SellerService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ICommentService, CommentService>();

        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<INotifier, Notifier>();
        services.AddScoped<IUser, AspNetUser>();

        return services;
    }
}