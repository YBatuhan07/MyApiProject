using MyApiProject.Database.Repositories;
using MyApiProject.Database.UnitOfWork;
using MyApiProject.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiProject.ApplicationLayer
{
    public class CityService : ICityService
    {
        //private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCity(City city)
        {
            await _unitOfWork.CityRepository.AddAsync(city);
            await _unitOfWork.CompleteAsync();
        }
    }
}
