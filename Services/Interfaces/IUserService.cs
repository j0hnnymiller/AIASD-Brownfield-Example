using PostHubAPI.Dtos.User;

namespace PostHubAPI.Services.Interfaces;

public interface IUserService
{
    Task<string> Register(RegisterUserDto dto);
    Task<string> Login(LoginUserDto dto);
}