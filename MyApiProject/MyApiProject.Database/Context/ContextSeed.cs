using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApiProject.DomainLayer;

namespace MyApiProject.Database.Context;

public static class ContextSeed
{
    public static void Seed(this ModelBuilder builder)
    {
        builder.Entity<City>().HasData(
            new City
            {
                Id = 58,
                Name = "Sivas",
            },
            new City
            {
                Id = 07,
                Name = "Antalya",
            },
             new City
             {
                 Id = 14,
                 Name = "Bolu",
             },
              new City
              {
                  Id = 34,
                  Name = "İstanbul",
              }
            );
        builder.Entity<District>().HasData(
            new District
            {
                Id = 1,
                Name = "Kangal",
                CityId = 58,
            },
            new District
            {
                Id = 2,
                Name = "Yıldızeli",
                CityId = 58,
            },
            new District
            {
                Id = 3,
                Name = "Suşehri",
                CityId = 58,
            },
            new District
            {
                Id = 4,
                Name = "Muratpaşa",
                CityId = 07,
            },
            new District
            {
                Id = 5,
                Name = "Alanya",
                CityId = 07,
            },
            new District
            {
                Id = 6,
                Name = "Gerede",
                CityId = 14,
            },
            new District
            {
                Id = 7,
                Name = "Kemer",
                CityId = 07,
            }
            );
    }
    public static async Task CreateIdmAdminUser(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roles = { "Admin", "User" };
        foreach ( var role in roles)
        {
            if(!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        var adminUserName = "admin@example.com";
        if (await userManager.FindByNameAsync(adminUserName) == null)
        {
            var adminUser = new IdentityUser
            {
                UserName = adminUserName,
                Email = adminUserName,
            };
            var result = await userManager.CreateAsync(adminUser,"Admin123.");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
