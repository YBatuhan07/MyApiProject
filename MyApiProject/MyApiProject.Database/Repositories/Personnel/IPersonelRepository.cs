using MyApiProject.DomainLayer;
using System.Linq.Expressions;

namespace MyApiProject.Database.Repositories;

public interface IPersonelRepository : IBaseRepository<Personnel>
{
    Task<Personnel> AddAsync(Personnel personnel);
    Task<Personnel> Update(Personnel model);
    IQueryable<Personnel> GetPersonnelQueryable(Expression<Func<Personnel, bool>>? expression = null);
}
