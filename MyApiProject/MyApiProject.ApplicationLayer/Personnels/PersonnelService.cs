using MyApiProject.Database.UnitOfWork;
using MyApiProject.DomainLayer;
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
                BirtDate = model.BirtDate,
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
                result.BirtDate = model.BirtDate;

                var updated = _unitOfWork.PersonelRepository.Update(result);
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
}