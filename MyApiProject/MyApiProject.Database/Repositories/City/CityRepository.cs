﻿
using MyApiProject.Database.Context;
using MyApiProject.DomainLayer;

namespace MyApiProject.Database.Repositories;

public class CityRepository : ICityRepository
{
    private readonly MyDbContext _context;

    public CityRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(City city)
    {
        await _context.Set<City>().AddAsync(city);
        await _context.SaveChangesAsync();
    }
}
