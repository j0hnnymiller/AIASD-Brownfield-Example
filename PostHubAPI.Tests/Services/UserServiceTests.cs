using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostHubAPI.Data;
using PostHubAPI.Dtos.User;
using PostHubAPI.Models;
using PostHubAPI.Services.Implementations;
using PostHubAPI.Services.Interfaces;

namespace PostHubAPI.Tests.Services;

public class UserServiceTests
{
    [Fact]
    public void JwtTokenService_CreatesJwtWithConfiguredIssuerAudienceAndClaims()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["JWT:ValidIssuer"] = "https://issuer.example",
                ["JWT:ValidAudience"] = "https://audience.example",
                ["JWT:Secret"] = "unit-test-secret-value-1234567890"
            })
            .Build();
        var service = new JwtTokenService(configuration);

        string token = service.CreateToken(new User
        {
            UserName = "token-user",
            Email = "token@example.com"
        });

        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

        Assert.Equal("https://issuer.example", jwt.Issuer);
        Assert.Equal("https://audience.example", jwt.Audiences.Single());
        Assert.Equal("token-user", jwt.Claims.Single(claim => claim.Type == ClaimTypes.Name).Value);
        Assert.Equal("token@example.com", jwt.Claims.Single(claim => claim.Type == ClaimTypes.Email).Value);
    }

    [Fact]
    public async Task Login_ReturnsTokenFromInjectedTokenService()
    {
        using var identityContext = CreateIdentityContext();
        var user = new User
        {
            Email = "login@example.com",
            UserName = "login-user",
            SecurityStamp = Guid.NewGuid().ToString()
        };
        IdentityResult createResult = await identityContext.UserManager.CreateAsync(user, "Password123!");
        Assert.True(createResult.Succeeded);

        var tokenService = new CapturingTokenService("fake-login-token");
        var service = new UserService(tokenService, identityContext.UserManager);

        string token = await service.Login(new LoginUserDto
        {
            Username = "login-user",
            Password = "Password123!"
        });

        Assert.Equal("fake-login-token", token);
        Assert.NotNull(tokenService.LastUser);
        Assert.Equal("login-user", tokenService.LastUser!.UserName);
        Assert.Equal("login@example.com", tokenService.LastUser.Email);
    }

    [Fact]
    public async Task Register_ReturnsTokenFromInjectedTokenService()
    {
        using var identityContext = CreateIdentityContext();
        var tokenService = new CapturingTokenService("fake-register-token");
        var service = new UserService(tokenService, identityContext.UserManager);

        string token = await service.Register(new RegisterUserDto
        {
            Email = "register@example.com",
            Username = "register-user",
            Password = "Password123!",
            ConfirmPassword = "Password123!"
        });

        User? createdUser = await identityContext.UserManager.FindByNameAsync("register-user");

        Assert.Equal("fake-register-token", token);
        Assert.NotNull(createdUser);
        Assert.NotNull(tokenService.LastUser);
        Assert.Equal("register-user", tokenService.LastUser!.UserName);
        Assert.Equal("register@example.com", createdUser!.Email);
        Assert.True(await identityContext.UserManager.CheckPasswordAsync(createdUser, "Password123!"));
    }

    private static TestIdentityContext CreateIdentityContext()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
        services.AddIdentityCore<User>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        ServiceProvider rootProvider = services.BuildServiceProvider();
        IServiceScope scope = rootProvider.CreateScope();
        ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureCreated();

        return new TestIdentityContext(
            rootProvider,
            scope,
            scope.ServiceProvider.GetRequiredService<UserManager<User>>());
    }

    private sealed class CapturingTokenService(string token) : ITokenService
    {
        public User? LastUser { get; private set; }

        public string CreateToken(User user)
        {
            LastUser = user;
            return token;
        }
    }

    private sealed class TestIdentityContext(
        ServiceProvider rootProvider,
        IServiceScope scope,
        UserManager<User> userManager) : IDisposable
    {
        public UserManager<User> UserManager { get; } = userManager;

        public void Dispose()
        {
            scope.Dispose();
            rootProvider.Dispose();
        }
    }
}
