namespace PostHubAPI.Configuration;

public sealed record JwtSettings(string ValidIssuer, string ValidAudience, string Secret);

public static class JwtSettingsResolver
{
    public static JwtSettings Resolve(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        return new JwtSettings(
            GetRequiredValue(configuration, "JWT:ValidIssuer"),
            GetRequiredValue(configuration, "JWT:ValidAudience"),
            GetRequiredValue(configuration, "JWT:Secret"));
    }

    private static string GetRequiredValue(IConfiguration configuration, string key)
    {
        var value = configuration[key];
        if (!string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        var environmentVariableKey = key.Replace(":", "__", StringComparison.Ordinal);
        throw new InvalidOperationException(
            $"Missing required configuration '{key}'. Configure it via ASP.NET Core user secrets or the '{environmentVariableKey}' environment variable.");
    }
}
