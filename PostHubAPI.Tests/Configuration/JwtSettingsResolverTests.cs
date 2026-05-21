using Microsoft.Extensions.Configuration;
using PostHubAPI.Configuration;

namespace PostHubAPI.Tests.Configuration;

public class JwtSettingsResolverTests
{
    [Fact]
    public void Resolve_ThrowsClearMessage_WhenValidIssuerIsMissing()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["JWT:ValidAudience"] = "https://localhost:4200",
                ["JWT:Secret"] = "test-secret-value"
            })
            .Build();

        var exception = Assert.Throws<InvalidOperationException>(() => JwtSettingsResolver.Resolve(configuration));

        Assert.Contains("JWT:ValidIssuer", exception.Message, StringComparison.Ordinal);
        Assert.Contains("JWT__ValidIssuer", exception.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void Resolve_ThrowsClearMessage_WhenValidAudienceIsMissing()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["JWT:ValidIssuer"] = "https://localhost:5001",
                ["JWT:Secret"] = "test-secret-value"
            })
            .Build();

        var exception = Assert.Throws<InvalidOperationException>(() => JwtSettingsResolver.Resolve(configuration));

        Assert.Contains("JWT:ValidAudience", exception.Message, StringComparison.Ordinal);
        Assert.Contains("JWT__ValidAudience", exception.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void Resolve_ThrowsClearMessage_WhenSecretIsMissing()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["JWT:ValidIssuer"] = "https://localhost:5001",
                ["JWT:ValidAudience"] = "https://localhost:4200"
            })
            .Build();

        var exception = Assert.Throws<InvalidOperationException>(() => JwtSettingsResolver.Resolve(configuration));

        Assert.Contains("JWT:Secret", exception.Message, StringComparison.Ordinal);
        Assert.Contains("JWT__Secret", exception.Message, StringComparison.Ordinal);
    }
}
