using Microsoft.EntityFrameworkCore;
using MyApiProject.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
