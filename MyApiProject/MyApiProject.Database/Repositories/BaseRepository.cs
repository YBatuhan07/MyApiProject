using Microsoft.EntityFrameworkCore;
using MyApiProject.Database.Context;
using MyApiProject.DomainLayer;
using MyApiProject.DomainLayer.Shared;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace MyApiProject.Database.Repositories;

public class BaseRepository<T> where T : class
{
    protected readonly MyDbContext _context;
    private DbSet<T> _dbSet => _context.Set<T>();

    public BaseRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T model)
    {
        await _dbSet.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsyn(T model)
    {
        _dbSet.Update(model);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T model)
    {
        PropertyInfo status = model.GetType().GetProperty(nameof(BaseClass.Status));
        if (status != null)
        {
            status.SetValue(model, DataStatus.Deleted);
            await UpdateAsyn(model);
        }
    }
    public async Task<T> GetAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }
    public IQueryable<T> Queryabla(Expression<Func<T,bool>> expression)
    {
        return _dbSet.Where("Status ==" + (int)DataStatus.Deleted).Where(expression);
    }
    public IQueryable<T> Queryabla()
    {
        return _dbSet.Where("Status ==" + (int)DataStatus.Active);
    }
}