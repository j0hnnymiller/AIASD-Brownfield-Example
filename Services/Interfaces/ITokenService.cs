using System.Security.Claims;

namespace PostHubAPI.Services.Interfaces;

public interface ITokenService
{
    string CreateToken(IEnumerable<Claim> claims);
}
