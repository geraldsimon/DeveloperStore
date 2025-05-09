﻿using DeveloperStore.Business.Models;
using DeveloperStore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace DeveloperStore.App.Configuration;

public static class DbMigrationHelperExtension
{
    public static void UseDbMigrationHelper(this WebApplication app)
    {
        DbMigrationHelpers.EnsureSeedData(app).Wait();
    }
}

public static class DbMigrationHelpers
{
    public static async Task EnsureSeedData(WebApplication serviceScope)
    {
        var services = serviceScope.Services.CreateScope().ServiceProvider;
        await EnsureSeedData(services);
    }

    public static async Task EnsureSeedData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (env.IsDevelopment())
        {
            await context.Database.MigrateAsync();


            await EnsureSeedProducts(context, serviceProvider);
        }
    }

    private static async Task EnsureSeedProducts(AppDbContext context, IServiceProvider serviceProvider)
    {
        if (await context.Sellers.AnyAsync())
            return;

        var _email = "joaomelo@gmail.com";
        var _password = "Teste@123";


        var idUser = await CreateUserAsync(serviceProvider.CreateScope().ServiceProvider, _email, _password);

        await context.Sellers.AddAsync(new Seller()
        {
            Id = idUser,
            Name = "Joao Melo",
            CreatedAt = DateTime.UtcNow,
        });

        await context.SaveChangesAsync();

        await context.Categories.AddAsync(new Category()
        {
            Id = Guid.NewGuid(),
            Name = "LapTop",
            Description = "LapTop",
        });

        await context.SaveChangesAsync();

        Guid guidCategory = await context.Categories.Where(c => c.Name == "LapTop").Select(c => c.Id).FirstOrDefaultAsync();

        await CreateProducts(context, idUser, guidCategory);
        await CreateProducts(context, idUser, guidCategory);
        await CreateProducts(context, idUser, guidCategory);
        await CreateProducts(context, idUser, guidCategory);
    }

    private static async Task CreateProducts(AppDbContext context, Guid idUser, Guid guidCategory)
    {
        await context.Products.AddAsync(new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Amazon Fire Max 11 tablet",
            Price = 229.99M,
            Description = "Amazon Fire Max 11 tablet (newest model) vivid 11” display, all-in-one for streaming, reading, and gaming, 14-hour battery life, optional stylus and keyboard, 64 GB, Gray",
            SellerId = idUser,
            Stock = 10,
            Image = "71troH2aUJL._AC_SX679_.jpg",
            CategoryId = guidCategory
        });

        await context.SaveChangesAsync();

        await context.Products.AddAsync(new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Lenovo IdeaPad 15.6”",
            Price = 229.99M,
            Description = "Lenovo IdeaPad 15.6” FHD Touchscreen Laptop, 40GB RAM 2.5TB Storage (2TB SSD+512GB Docking Station Set), 6-Cores Intel Core i3, Windows 11 Pro with Microsoft Office Included, Plusera Earphones",
            SellerId = idUser,
            Stock = 10,
            Image = "71S+P-5tdpL._AC_SL1500_.jpg",
            CategoryId = guidCategory
        });

        await context.SaveChangesAsync();

        await context.Products.AddAsync(new Product()
        {
            Id = Guid.NewGuid(),
            Name = "HP 14\" Ultral Light Laptop",
            Price = 229.99M,
            Description = "HP 14\" Ultral Light Laptop for Students and Business, Intel Quad-Core, 8GB RAM, 192GB Storage(64GB eMMC+128GB Ghost Manta SD Card), 1 Year Office 365, USB C, Win 11 S",
            SellerId = idUser,
            Stock = 10,
            Image = "81divYKpeTL._AC_SL1500_.jpg",
            CategoryId = guidCategory
        });

        await context.SaveChangesAsync();

        await context.Posts.AddAsync(new Post()
        {
            Id = Guid.NewGuid(),
            Title = "Sample Post",
            Content = "This is a sample post content.",
            SellerId = idUser,
            CreatedAt = DateTime.UtcNow,
            Comments = new List<Comment>()
            {
                new Comment()
                {
                    Id = Guid.NewGuid(),
                    Content = "This is a sample comment.",
                    CreatedAt = DateTime.UtcNow,
                    SellerId = idUser
                },
                new Comment()
                {
                    Id = Guid.NewGuid(),
                    Content = "This is a sample comment 2.",
                    CreatedAt = DateTime.UtcNow,
                    SellerId = idUser
                }
            }
        });

        await context.Posts.AddAsync(new Post()
        {
            Id = Guid.NewGuid(),
            Title = "Sample Post",
            Content = "This another sample post content kkkk.",
            SellerId = idUser,
            CreatedAt = DateTime.UtcNow,
            Comments = new List<Comment>()
            {
                new Comment()
                {
                    Id = Guid.NewGuid(),
                    Content = "This is a sample comment kkk.",
                    CreatedAt = DateTime.UtcNow,
                    SellerId = idUser
                },
                new Comment()
                {
                    Id = Guid.NewGuid(),
                    Content = "This is a sample comment 2. kk",
                    CreatedAt = DateTime.UtcNow,
                    SellerId = idUser
                }
            }
        });

        await context.SaveChangesAsync();
    }

    private static async Task<Guid> CreateUserAsync(IServiceProvider services, string email, string passsword)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
        };

        await userManager.CreateAsync(user, passsword);
        Guid userId = userManager.Users.FirstOrDefault(x => x.Email == email).Id;

        return userId;
    }
}