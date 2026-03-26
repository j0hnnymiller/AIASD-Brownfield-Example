using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PostHubAPI.Services.Implementations;

namespace PostHubAPI.Tests.Services;

public class JwtTokenServiceTests
{
    private const string ValidIssuer = "https://localhost:5001";
    private const string ValidAudience = "https://localhost:4200";
    private const string Secret = "unit-test-secret-value-1234567890";

    [Fact]
    public void CreateToken_ReturnsNonEmptyString()
    {
        var service = CreateService();

        var token = service.CreateToken([new Claim(ClaimTypes.Name, "testuser")]);

        Assert.False(string.IsNullOrWhiteSpace(token));
    }

    [Fact]
    public void CreateToken_ReturnsValidJwtContainingProvidedClaims()
    {
        var service = CreateService();
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "testuser"),
            new Claim(ClaimTypes.Email, "test@example.com")
        };

        var tokenString = service.CreateToken(claims);

        var handler = new JwtSecurityTokenHandler();
        var parameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = ValidIssuer,
            ValidAudience = ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret))
        };
        var principal = handler.ValidateToken(tokenString, parameters, out _);

        Assert.Equal("testuser", principal.FindFirstValue(ClaimTypes.Name));
        Assert.Equal("test@example.com", principal.FindFirstValue(ClaimTypes.Email));
    }

    private static JwtTokenService CreateService()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["JWT:ValidIssuer"] = ValidIssuer,
                ["JWT:ValidAudience"] = ValidAudience,
                ["JWT:Secret"] = Secret
            })
            .Build();

        return new JwtTokenService(configuration);
    }
}
