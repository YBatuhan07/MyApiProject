﻿using Microsoft.EntityFrameworkCore;
using MyApiProject.Database.Context;
using MyApiProject.DomainLayer;
using System.Linq.Expressions;

namespace MyApiProject.Database.Repositories;

public class PersonelRepository : IPersonelRepository
{
    private readonly MyDbContext _context;

    public PersonelRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Personnel> AddAsync(Personnel personnel)
    {
        var result = await _context.Set<Personnel>().AddAsync(personnel);

        return result.Entity;
    }
    public async Task<Personnel> GetAsync(int id)
    {
        var result = await _context.Set<Personnel>().FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
    public Personnel Update(Personnel model)
    {
        var result = _context.Set<Personnel>().Update(model);

        return result.Entity;
    }
    public IQueryable<Personnel> GetPersonnelQueryable(Expression<Func<Personnel, bool>>? expression= null)
    {
        var query = _context.Set<Personnel>();
        if(expression != null)
            return query.Where(expression);
        return query;
    }
}
