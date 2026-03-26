using PostHubAPI.Models;

namespace PostHubAPI.Services.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}
