using Microsoft.EntityFrameworkCore;
using MyApiProject.Database.Context;
using MyApiProject.DomainLayer;
using System.Linq.Expressions;
using System.Linq;

namespace MyApiProject.Database.Repositories;

public class DistrictRepository : IDistrictRepository
{
    private readonly MyDbContext _context;

    public DistrictRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<District> GetDistrictByCityAndName(string cityName, string districtName)
    {
        var result = await _context.Set<District>().Where(i => 
        i.City.Name == cityName && i.Name == districtName).FirstOrDefaultAsync();

        return result;
    }

    public async Task AddAsync(District district)
    {
        await _context.Set<District>().AddAsync(district);
        await _context.SaveChangesAsync();
    }
    public IQueryable<District> GetDistrictQueryable()
    {
        var query = _context.Set<District>();
        
        return query;
    }
}