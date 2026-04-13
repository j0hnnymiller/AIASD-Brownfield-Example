# Work Item: Program Configuration Behavior Tests (T6)

## Priority

Medium

## Goal

Add startup/configuration tests for JWT required settings and environment-specific database provider behavior.

## Target Test File

- `PostHubAPI.Tests/Configuration/ProgramConfigurationTests.cs`

## Implementation Guidance

1. Build host-level tests using `WebApplicationFactory<Program>` or minimal-host composition used by the project.
2. Add missing-required-JWT-setting tests:

- Omit one required setting at a time (for example secret, issuer, audience).
- Assert startup fails fast with clear configuration error.

3. Add environment-specific DB provider behavior tests:

- Development environment resolves expected in-memory provider behavior.
- Non-development environment resolves configured provider strategy (or explicit fail-fast if provider not configured).

4. Isolate each test’s configuration using in-memory configuration sources.
5. Dispose hosts/factories per test to avoid cross-test leakage.

## Verification Steps

1. Run focused tests:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo --filter "FullyQualifiedName~ProgramConfigurationTests"`
2. Validate missing-setting tests produce clear and actionable error details.
3. Run full suite and confirm no shared-host contamination.

## Completion Criteria

1. Startup guardrails for JWT configuration are covered.
2. Environment/provider behavior is explicitly verified.
3. Tests are isolated and deterministic.
