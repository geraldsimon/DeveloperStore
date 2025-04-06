using DeveloperStore.Business.Models;
using Microsoft.AspNetCore.Identity;

namespace DeveloperStore.App.Configuration;

public static class UserIdentityMigrationHelper
{
    public static async Task<Guid> CreateUserAsync(IServiceProvider services, string email,  string         passsword   )   
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
        };

        await userManager.CreateAsync(user, passsword);
        Guid userId =  userManager.Users.FirstOrDefault(x => x.Email == email).Id;

        return userId;
    }
}