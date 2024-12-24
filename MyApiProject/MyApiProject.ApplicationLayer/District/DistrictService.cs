using Microsoft.EntityFrameworkCore;
using MyApiProject.Database.UnitOfWork;
using MyApiProject.DomainLayer;

namespace MyApiProject.ApplicationLayer;

public class DistrictService : IDistrictService
{
    private readonly IUnitOfWork _unitOfWork;

    public DistrictService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<dynamic> GetAllDistrictWithPersonnel()
    {
        var personelQuery = _unitOfWork.PersonelRepository.GetPersonnelQueryable();
        var districtQuery = _unitOfWork.DistrictRepository.GetDistrictQueryable();

        //var letJoin = await districtQuery.GroupJoin(personelQuery, i => i.Id, p => p.DistrictId, (i, p) => new
        //{
        //    District = i,
        //    Personnel = p
        //}).SelectMany(i => i.Personnel.DefaultIfEmpty(), (d, p) => new
        //{
        //    districtName = d.District,
        //    Personnels = p != null ? p.FullName : string.Empty
        //}).ToListAsync();

        var letJoinWithRelation = await districtQuery.Select(s => new
        {
            s.Name,
            Personnel = s.Personnels.Select(a => a.FullName).ToList()
        }).ToListAsync();

        return letJoinWithRelation;
    }

    public async Task<dynamic> GetDistrictGroups()
    {
        var query = await _unitOfWork.DistrictRepository.GetDistrictQueryable()
            .GroupBy(s => s.Name)
            .Select(s => new
            {
                DistrictName = s.Key,
                Personnels = s.Select(c => c.Personnels.Select(p=>p.FullName)).ToList()
            }).ToListAsync();
        return query;
    }
    
}
