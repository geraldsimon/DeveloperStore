using DeveloperStore.Data;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Api.Configuration
{
    public static class DatabaseSelectorExtension
    {
        public static void AddDatabaseSelector(this WebApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            }
            else
            {
                builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            }
        }
    }
}