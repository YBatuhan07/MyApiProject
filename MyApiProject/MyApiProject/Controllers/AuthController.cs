using Microsoft.AspNetCore.Mvc;
using MyApiProject.ApplicationLayer.Auths;
using MyApiProject.ViewModel;

namespace MyApiProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Auth(LoginRequest model)
    {
        return Ok(await _authService.AuthenticateAsync(model));
    }
}