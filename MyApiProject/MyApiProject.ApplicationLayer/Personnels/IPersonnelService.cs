﻿using MyApiProject.ViewModel;

namespace MyApiProject.ApplicationLayer.Personnels;

public interface IPersonnelService
{
    Task<AddPersonnelModel> AddAsync(AddPersonnelModel model);
    Task<AddPersonnelModel> UpdateAsync(AddPersonnelModel model);
    Task<bool> DeleteAsync(int id);
    Task<AddPersonnelInfoModel> AddPersonnelAsync(AddPersonnelInfoModel model);
    Task<dynamic> GetPersonelList(PersonelFilterModel filter);
    Task<dynamic> GetPersonnelDistrictJoin();
    Task<dynamic> GetPersonnelDistinct();
    Task<dynamic> GetPersonnel(string name);
}
