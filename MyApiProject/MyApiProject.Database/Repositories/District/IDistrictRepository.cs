using MyApiProject.DomainLayer;

namespace MyApiProject.Database.Repositories;

public interface IDistrictRepository
{
    Task<District> GetDistrictByCityAndName(string cityName, string districtName);
    Task AddAsync(District district);
    IQueryable<District> GetDistrictQueryable();
}
