using Microsoft.EntityFrameworkCore;
using MyApiProject.Database.Context;
using MyApiProject.DomainLayer;

namespace MyApiProject.Database.Repositories;

public class CityRepository : BaseRepository<City>, ICityRepository
{
    public CityRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<City> GetCityByName(string cityName)
    {
        var result = await base.Queryabla(i =>
        i.Name == cityName).FirstOrDefaultAsync();

        return result;
    }
}