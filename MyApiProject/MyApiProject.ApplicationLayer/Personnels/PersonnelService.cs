using MyApiProject.Database.UnitOfWork;
using MyApiProject.DomainLayer;
using MyApiProject.DomainLayer.Shared;
using MyApiProject.ViewModel;

namespace MyApiProject.ApplicationLayer.Personnels;

public class PersonnelService : IPersonnelService
{
    private readonly IUnitOfWork _unitOfWork;

    public PersonnelService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddPersonnelModel> AddAsync(AddPersonnelModel model)
    {
        try
        {
            var personnel = new Personnel
            {
                BirthDate = model.BirthDate,
                DistrictId = model.DistrictId,
                Gender = model.Gender,
                FullName = model.FullName,
            };
            await _unitOfWork.PersonelRepository.AddAsync(personnel);
            await _unitOfWork.CompleteAsync();
            model.Id = personnel.Id;
            return model;
        }
        catch (Exception e)
        {
            throw new Exception(e?.Message);
        }
    }

    public async Task<AddPersonnelModel> UpdateAsync(AddPersonnelModel model)
    {
        try
        {
            var result = await _unitOfWork.PersonelRepository.GetAsync(model.Id);
            if (result != null)
            {
                result.FullName = model.FullName;
                result.Gender = model.Gender;
                result.DistrictId = model.DistrictId;
                result.BirthDate = model.BirthDate;

                _unitOfWork.PersonelRepository.Update(result);
                await _unitOfWork.CompleteAsync();
                return model;
            }
            return new AddPersonnelModel();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var result = await _unitOfWork.PersonelRepository.GetAsync(id);
            if (result != null)
            {
                result.Status = DataStatus.Deleted;
                _unitOfWork.PersonelRepository.Update(result);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<AddPersonnelInfoModel> AddPersonnelAsync(AddPersonnelInfoModel model)
    {
        try
        {
            var personel = new Personnel();
            personel.Gender = model.Gender;
            personel.BirthDate = model.BirthDate;
            personel.FullName = model.FullName;

            var district = await _unitOfWork.DistrictRepository.GetDistrictByCityAndName(model.CityName, model.DistrictName);
            if (district != null)
            {
                personel.DistrictId = district.Id;
                await _unitOfWork.PersonelRepository.AddAsync(personel);
                await _unitOfWork.CompleteAsync();
                model.Id = personel.Id;
                return model;
            }

            var city = await _unitOfWork.CityRepository.GetCityByName(model.CityName);
            if (city != null)
            {
                var newDistrictForCity = new District()
                {
                    CityId = city.Id,
                    Name = model.DistrictName,
                    Personnels = new List<Personnel>()
                };
                newDistrictForCity.Personnels.Add(personel);
                await _unitOfWork.DistrictRepository.AddAsync(newDistrictForCity);
                await _unitOfWork.CompleteAsync();
                model.Id = personel.Id;
                return model;
            }

            var newCity = new City()
            {
                Name = model.CityName,
            };
            var newDistrict = new District()
            {
                Name = model.DistrictName
            };
            newDistrict.Personnels.Add(personel);
            newCity.Districts.Add(newDistrict);

            await _unitOfWork.CityRepository.AddAsync(newCity);
            await _unitOfWork.CompleteAsync();
            model.Id = personel.Id;
            return model;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}