using MyApiProject.DomainLayer;

namespace MyApiProject.ApplicationLayer;

public interface ICityService
{
    Task AddCity(City city);
}
