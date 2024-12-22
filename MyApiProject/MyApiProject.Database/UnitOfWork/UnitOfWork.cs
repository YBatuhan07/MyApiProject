﻿using MyApiProject.Database.Context;
using MyApiProject.Database.Repositories;

namespace MyApiProject.Database.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyDbContext _context;
    public ICityRepository CityRepository { get; private set; }
    public IPersonelRepository PersonelRepository { get; private set; }

    public UnitOfWork(MyDbContext context)
    {
        _context = context;
        CityRepository = new CityRepository(_context);
        PersonelRepository = new PersonelRepository(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
}