﻿using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("ListPersonnel")]
    [Authorize(Roles ="User")]
    public async Task<IActionResult> GetPersonnel(PersonelFilterModel model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _personnelService.GetPersonelList(model);

        return Ok(result);
    }
    [HttpPost("AddNewPersonnel")]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> AddPersonnel(AddPersonnelModel model)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _personnelService.AddAsync(model);
        return Ok(result);
    }
    [HttpPost("AddNewPersonnelAndCityAndDistrict")]
    public async Task<IActionResult> AddPersonnelName(AddPersonnelInfoModel model)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _personnelService.AddPersonnelAsync(model);
        return Ok(result);
    }
    [HttpPut("UpdatePersonnel")]
    public async Task<IActionResult> UpdatePersonnel(AddPersonnelModel model)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _personnelService.UpdateAsync(model);
        return Ok(result);
    }
    [HttpDelete("DeletePersonnel")]
    public async Task<IActionResult> DeletePersonel(int id)
    {
        var result = await _personnelService.DeleteAsync(id);
        return Ok(result);
    }
    
    [HttpGet("list-with-districts")]
    public async Task<IActionResult> GetPersonnelWithDistrictList()
    {
        var result = await _personnelService.GetPersonnelDistrictJoin();

        return Ok(result);
    }
    [HttpGet("GetPersonnelDistinct")]
    [Authorize]
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