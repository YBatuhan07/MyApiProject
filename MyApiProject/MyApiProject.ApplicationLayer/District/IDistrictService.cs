using MyApiProject.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiProject.ApplicationLayer
{
    public interface IDistrictService
    {
        Task<dynamic> GetAllDistrictWithPersonnel();
        Task<dynamic> GetDistrictGroups();
    }
}
