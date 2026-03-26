using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PostHubAPI.Dtos.User;
using PostHubAPI.Models;
using PostHubAPI.Services.Implementations;
using PostHubAPI.Services.Interfaces;

namespace PostHubAPI.Tests.Services;

public class UserServiceTests
{
    [Fact]
    public async Task Login_ReturnsTokenFromInjectedTokenService_WhenCredentialsAreValid()
    {
        User user = new()
        {
            UserName = "testuser",
            Email = "user@example.com"
        };

        FakeTokenService tokenService = new("fake-token");
        FakeUserManager userManager = new()
        {
            FindByNameHandler = _ => Task.FromResult<User?>(user),
            CheckPasswordHandler = (_, _) => Task.FromResult(true)
        };
        UserService service = new(userManager, tokenService);

        string token = await service.Login(new LoginUserDto
        {
            Username = "testuser",
            Password = "Password123!"
        });

        Assert.Equal("fake-token", token);
        Assert.Same(user, tokenService.LastUser);
    }

    [Fact]
    public async Task Register_UsesInjectedTokenService_WithoutChangingUserService()
    {
        User? createdUser = null;
        FakeTokenService tokenService = new("registered-token");
        FakeUserManager userManager = new()
        {
            FindByEmailHandler = _ => Task.FromResult<User?>(null),
            CreateHandler = (user, _) =>
            {
                createdUser = user;
                return Task.FromResult(IdentityResult.Success);
            },
            FindByNameHandler = _ => Task.FromResult(createdUser),
            CheckPasswordHandler = (_, _) => Task.FromResult(true)
        };
        UserService service = new(userManager, tokenService);

        string token = await service.Register(new RegisterUserDto
        {
            Email = "user@example.com",
            Username = "testuser",
            Password = "Password123!",
            ConfirmPassword = "Password123!"
        });

        Assert.Equal("registered-token", token);
        Assert.Same(createdUser, tokenService.LastUser);
    }

    private sealed class FakeTokenService(string token) : ITokenService
    {
        public User? LastUser { get; private set; }

        public string CreateToken(User user)
        {
            LastUser = user;
            return token;
        }
    }

    private sealed class FakeUserManager : UserManager<User>
    {
        public Func<string, Task<User?>> FindByEmailHandler { get; init; } = _ => Task.FromResult<User?>(null);
        public Func<User, string, Task<IdentityResult>> CreateHandler { get; init; } = (_, _) => Task.FromResult(IdentityResult.Success);
        public Func<string, Task<User?>> FindByNameHandler { get; init; } = _ => Task.FromResult<User?>(null);
        public Func<User, string, Task<bool>> CheckPasswordHandler { get; init; } = (_, _) => Task.FromResult(false);

        public FakeUserManager()
            : base(
                new FakeUserStore(),
                Microsoft.Extensions.Options.Options.Create(new IdentityOptions()),
                new PasswordHasher<User>(),
                Array.Empty<IUserValidator<User>>(),
                Array.Empty<IPasswordValidator<User>>(),
                new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(),
                new ServiceCollection().BuildServiceProvider(),
                new Logger<UserManager<User>>(new LoggerFactory()))
        {
        }

        public override Task<User?> FindByEmailAsync(string email)
        {
            return FindByEmailHandler(email);
        }

        public override Task<IdentityResult> CreateAsync(User user, string password)
        {
            return CreateHandler(user, password);
        }

        public override Task<User?> FindByNameAsync(string userName)
        {
            return FindByNameHandler(userName);
        }

        public override Task<bool> CheckPasswordAsync(User user, string password)
        {
            return CheckPasswordHandler(user, password);
        }
    }

    private sealed class FakeUserStore : IUserStore<User>
    {
        public void Dispose()
        {
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string?> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetUserNameAsync(User user, string? userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<string?> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task SetNormalizedUserNameAsync(User user, string? normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<User?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        public Task<User?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}
