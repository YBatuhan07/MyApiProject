using Microsoft.AspNetCore.Mvc;
using MyApiProject.ApplicationLayer.Personnels;
using MyApiProject.ViewModel;

namespace MyApiProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonnelController : ControllerBase
{
    private readonly IPersonnelService _personnelService;

    public PersonnelController(IPersonnelService personnelService)
    {
        _personnelService = personnelService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPersonnel(AddPersonnelModel model)
    {
        var result = await _personnelService.AddAsync(model);
        return Ok(result);
    }
    [HttpPut("UpdatePersonnel")]
    public async Task<IActionResult> UpdatePersonnel(AddPersonnelModel model)
    {
        var result = await _personnelService.UpdateAsync(model);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> DeletePersonel(int id)
    {
        var result = await _personnelService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpPut("UpdateName")]
    public async Task<IActionResult> AddPersonnelName(AddPersonnelInfoModel model)
    {
        var result = await _personnelService.AddPersonnelAsync(model);
        return Ok(result);
    }
    [HttpPost("GetPersonnel")]
    public async Task<IActionResult> GetPersonnel(PersonelFilterModel model)
    {
        var result = await _personnelService.GetPersonelList(model);

        return Ok(result);
    }
    [HttpGet("GetPersonnelWithDistrictList")]
    public async Task<IActionResult> GetPersonnelWithDistrictList()
    {
        var result = await _personnelService.GetPersonnelDistrictJoin();

        return Ok(result);
    }
    [HttpGet("GetPersonnelDistinct")]
    public async Task<IActionResult> GetPersonnelDistinct()
    {
        var result = await _personnelService.GetPersonnelDistinct();

        return Ok(result);
    }
    [HttpGet("GetPersonnelSingleOrFirst")]
    public async Task<IActionResult> GetPersonnelSingleOrFirst(string name)
    {
        var result = await _personnelService.GetPersonnel(name);
        return Ok(result);
    }

}