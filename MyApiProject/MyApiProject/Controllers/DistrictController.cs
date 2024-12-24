using Microsoft.AspNetCore.Mvc;
using MyApiProject.ApplicationLayer;

namespace MyApiProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DistrictController : ControllerBase
{
    private readonly IDistrictService _districtService;

    public DistrictController(IDistrictService districtService)
    {
        _districtService = districtService;
    }
    [HttpGet("GetDistrictsPersonnel")]
    public async Task<IActionResult> GetDistrictsPersonnel()
    {
        return Ok(await _districtService.GetAllDistrictWithPersonnel());
    }
    [HttpGet("GetDistrictsGroup")]
    public async Task<IActionResult> GetDistrictsGroup()
    {
        return Ok(await _districtService.GetDistrictGroups());
    }
}