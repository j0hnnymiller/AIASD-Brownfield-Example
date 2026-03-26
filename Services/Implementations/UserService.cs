using Microsoft.AspNetCore.Identity;
using PostHubAPI.Dtos.User;
using PostHubAPI.Models;
using PostHubAPI.Services.Interfaces;

namespace PostHubAPI.Services.Implementations;

public class UserService(ITokenService tokenService, UserManager<User> userManager)
    : IUserService
{
    public async Task<string> Register(RegisterUserDto dto)
    {
        User? userByEmail = await userManager.FindByEmailAsync(dto.Email);
        if (userByEmail != null)
        {
            throw new ArgumentException($"User with {dto.Email} already exists!!");
        }

        User user = new User()
        {
            Email = dto.Email,
            UserName = dto.Username,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        IdentityResult result = await userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            throw new ArgumentException(
                $"Unable to register user {dto.Username} errors: {GetErrorsText(result.Errors)}");
        }

        return await Login(new LoginUserDto { Username = dto.Username, Password = dto.Password });
    }

    public async Task<string> Login(LoginUserDto dto)
    {
        User? user = await userManager.FindByNameAsync(dto.Username);
        if (user == null)
        {
            throw new ArgumentException($"Name {dto.Username} is not registered!");
        }

        if (user == null || !await userManager.CheckPasswordAsync(user, dto.Password))
        {
            throw new ArgumentException($"Unable to authenticate user {dto.Username}!");
        }

        return tokenService.CreateToken(user);
    }

    private static string GetErrorsText(IEnumerable<IdentityError> errors)
    {
        return string.Join(", ", errors.Select(error => error.Description).ToArray());
    }
}
