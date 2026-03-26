using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PostHubAPI.Configuration;
using PostHubAPI.Services.Interfaces;

namespace PostHubAPI.Services.Implementations;

public class JwtTokenService(IConfiguration configuration) : ITokenService
{
    public string CreateToken(IEnumerable<Claim> claims)
    {
        JwtSettings jwtSettings = JwtSettingsResolver.Resolve(configuration);
        SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));

        JwtSecurityToken token = new JwtSecurityToken
        (
            issuer: jwtSettings.ValidIssuer,
            audience: jwtSettings.ValidAudience,
            expires: DateTime.UtcNow.AddHours(3),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
