using MyApiProject.DomainLayer;
using MyApiProject.ViewModel;
using System.Linq.Expressions;

namespace MyApiProject.Database.Repositories;

public interface IPersonelRepository
{
    Task<Personnel> AddAsync(Personnel personnel);
    Task<Personnel> GetAsync(int id);
    Personnel Update(Personnel model);
    IQueryable<Personnel> GetPersonnelQueryable(Expression<Func<Personnel, bool>>? expression = null);
}
