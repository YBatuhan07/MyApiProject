using MyApiProject.DomainLayer;
using MyApiProject.ViewModel;

namespace MyApiProject.Database.Repositories;

public interface IPersonelRepository
{
    Task<Personnel> AddAsync(Personnel personnel);
    Task<Personnel> GetAsync(int id);
    Personnel Update(Personnel model);
}
