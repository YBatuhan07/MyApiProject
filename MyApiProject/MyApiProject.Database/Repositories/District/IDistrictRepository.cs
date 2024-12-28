using MyApiProject.DomainLayer;

namespace MyApiProject.Database.Repositories;

public interface IDistrictRepository : IBaseRepository<District>
{
    Task<District> GetDistrictByCityAndName(string cityName, string districtName);
}
