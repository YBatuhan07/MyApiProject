using MyApiProject.ViewModel;

namespace MyApiProject.ApplicationLayer.Personnels;

public interface IPersonnelService
{
    Task<AddPersonnelModel> AddAsync(AddPersonnelModel model);
    Task<AddPersonnelModel> UpdateAsync(AddPersonnelModel model);
}
