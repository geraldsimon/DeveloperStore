using DeveloperStore.Data.DbContexts;
using DeveloperStore.Data.Domain;
using Microsoft.AspNetCore.Identity;

namespace DeveloperStore.Mvc.Configuration
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentityStore(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            return services;
        }
    }
}
