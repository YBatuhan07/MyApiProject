using Microsoft.AspNetCore.Mvc;
using MyApiProject.ApplicationLayer;

namespace MyApiProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DistrictController : ControllerBase
{
    //private readonly IDistrictService _districtService;

    //public DistrictController(IDistrictService districtService)
    //{
    //    _districtService = districtService;
    //}

    //[HttpGet("GetDistrict")]
    //public IActionResult GetDistrictById(string cityCode)
    //{
    //    var result = _districtService.GetDistrictByCityCode(cityCode);

    //    return Ok(result);
    //}

    //[HttpGet("GetAllDistrict")]
    //public IActionResult GetAllDistricts()
    //{
    //    var result = _districtService.GetAllDistricts();

    //    return Ok(result);
    //}
}