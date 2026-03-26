using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using PostHubAPI.Models;
using PostHubAPI.Services.Implementations;

namespace PostHubAPI.Tests.Services;

public class JwtTokenServiceTests
{
    [Fact]
    public void CreateToken_ReturnsJwtWithExpectedIssuerAudienceAndClaims()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["JWT:ValidIssuer"] = "https://localhost:5001",
                ["JWT:ValidAudience"] = "https://localhost:4200",
                ["JWT:Secret"] = "super-secret-key-for-tests-only-1234567890"
            })
            .Build();
        JwtTokenService tokenService = new(configuration);
        User user = new()
        {
            UserName = "testuser",
            Email = "user@example.com"
        };

        string tokenValue = tokenService.CreateToken(user);
        JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(tokenValue);

        Assert.Equal("https://localhost:5001", token.Issuer);
        Assert.Contains("https://localhost:4200", token.Audiences);
        Assert.Equal("testuser", token.Claims.Single(claim => claim.Type == ClaimTypes.Name).Value);
        Assert.Equal("user@example.com", token.Claims.Single(claim => claim.Type == ClaimTypes.Email).Value);
        Assert.True(token.ValidTo > DateTime.UtcNow);
    }
}
