using Microsoft.AspNetCore.Mvc;
using MyApiProject.ApplicationLayer;
using MyApiProject.DomainLayer;

namespace MyApiProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpPost("AddCity")]
    public async Task<IActionResult> AddCity(City model)
    {
        await _cityService.AddCity(model);

        return Ok();
    }
}
