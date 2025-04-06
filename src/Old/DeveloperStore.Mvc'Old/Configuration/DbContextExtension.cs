using DeveloperStore.Data.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Mvc.Configuration
{
    public static class DBContextExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
