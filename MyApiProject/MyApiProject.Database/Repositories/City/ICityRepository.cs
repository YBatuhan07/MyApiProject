﻿using MyApiProject.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiProject.Database.Repositories
{
    public interface ICityRepository
    {
        Task AddAsync(City city);
        Task<City> GetCityByName(string cityName);
    }
}
