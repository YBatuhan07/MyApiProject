using MyApiProject.ViewModel;

namespace MyApiProject.ApplicationLayer.Auths;

public interface IAuthService
{
    Task<string> AuthenticateAsync(LoginRequest loginRequest);
}
