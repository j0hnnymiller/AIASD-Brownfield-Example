# Work Item: JWT Token Service Guardrail Tests (T5)

## Priority

Medium

## Goal

Expand `JwtTokenServiceTests` to validate guardrails around invalid user input and required claim fields.

## Target Test File

- `PostHubAPI.Tests/Services/JwtTokenServiceTests.cs`

## Implementation Guidance

1. Add null-user input test:

- Passing null user to token generation should throw `ArgumentNullException` (or the service-defined guardrail exception).

2. Add missing-claim-field tests for required claim sources:

- Missing user id.
- Missing username/email if required by implementation.

3. For each missing-field case, assert deterministic failure behavior (exception type and message contract where stable).
4. Keep tests aligned with `JwtSettingsResolver` configuration expectations.
5. Avoid brittle string comparisons unless message text is intentionally part of API contract.

## Verification Steps

1. Run focused tests:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo --filter "FullyQualifiedName~JwtTokenServiceTests"`
2. Verify all guardrail tests fail before implementation and pass after implementation.
3. Run `JwtSettingsResolverTests` to ensure config guardrail compatibility:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo --filter "FullyQualifiedName~JwtSettingsResolverTests"`
4. Run full suite.

## Completion Criteria

1. Null-input and missing-claim-field paths are covered.
2. Guardrail behavior is explicit and deterministic.
3. Related JWT tests continue to pass.
