using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.ApplicationLayer.Personnels;
using MyApiProject.ViewModel;

namespace MyApiProject.Controllers
{
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
            var result = _personnelService.UpdateAsync(model);
            return Ok(result);
        }
    }
}
