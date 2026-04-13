# Work Item: User Service Negative-Path Tests (T4)

## Priority

High

## Goal

Expand `UserServiceTests` to lock down authentication and identity failure scenarios.

## Target Test File

- `PostHubAPI.Tests/Services/UserServiceTests.cs`

## Implementation Guidance

1. Use mocks for identity dependencies (`UserManager<User>`, `SignInManager<User>`, token service).
2. Add duplicate-email registration test:

- Existing user by email is found.
- Service returns expected failure result or throws expected domain exception.

3. Add registration identity-failure test:

- `CreateAsync` returns failed `IdentityResult`.
- Service returns failure details without generating token.

4. Add login unknown-user test:

- User lookup returns null.
- Service returns auth failure result.

5. Add login bad-password test:

- User exists but password check fails.
- Service returns auth failure result.

6. Verify token service is called only on success paths.

## Verification Steps

1. Run focused tests:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo --filter "FullyQualifiedName~UserServiceTests"`
2. Ensure each negative-path test asserts both:

- Returned failure semantics.
- Absence of unintended side effects (for example, no token generation).

3. Run full suite.

## Completion Criteria

1. Duplicate-email and identity-failure registration cases are covered.
2. Unknown-user and bad-password login cases are covered.
3. No regressions in existing auth tests.
