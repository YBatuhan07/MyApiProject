using Microsoft.EntityFrameworkCore;
using MyApiProject.Database.Context;
using MyApiProject.DomainLayer;

namespace MyApiProject.Database.Repositories;

public class DistrictRepository : BaseRepository<District> , IDistrictRepository
{

    public DistrictRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<District> GetDistrictByCityAndName(string cityName, string districtName)
    {
        var result = await Queryabla(i =>
        i.City.Name == cityName && i.Name == districtName).FirstOrDefaultAsync();

        return result;
    }
}