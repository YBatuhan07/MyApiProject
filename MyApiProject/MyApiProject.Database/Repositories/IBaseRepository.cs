using System.Linq.Expressions;

namespace MyApiProject.Database.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task AddAsync(T model);

    Task UpdateAsyn(T model);

    Task Delete(T model);

    Task<T> GetAsync(object id);

    IQueryable<T> Queryabla(Expression<Func<T, bool>> expression);
    IQueryable<T> Queryabla();
}