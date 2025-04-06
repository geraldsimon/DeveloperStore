using DeveloperStore.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Mvc.Configuration
{
    public static class DBContextExtension
    {
        public static IServiceCollection AddDbContextStore(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}