﻿using MyApiProject.Database.Repositories;

namespace MyApiProject.Database.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ICityRepository CityRepository { get; }
    IPersonelRepository PersonelRepository { get; }
    IDistrictRepository DistrictRepository { get; }
    Task<int> CompleteAsync();
}
