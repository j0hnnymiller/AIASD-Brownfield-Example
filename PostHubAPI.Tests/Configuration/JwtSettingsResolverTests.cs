using Microsoft.Extensions.Configuration;
using PostHubAPI.Configuration;

namespace PostHubAPI.Tests.Configuration;

public class JwtSettingsResolverTests
{
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
