# Issue: JWT Configuration Key Mismatch

## Severity

High

## Description

Token generation and token validation use different configuration keys.

- Token generation uses `JWT:Issuer` and `JWT:Audience`.
- Token validation uses `JWT:ValidIssuer` and `JWT:ValidAudience`.
- Current configuration defines `ValidIssuer` and `ValidAudience`, not `Issuer` and `Audience`.

This mismatch creates authentication fragility and environment drift risk.

## Proposed Updates

1. Standardize on one key naming pattern for issuer and audience.
2. Update token generation to read the same keys used by token validation.
3. Add startup configuration validation for required JWT settings.
4. Document expected JWT keys in project documentation.

## Verification Steps

1. Align key names in code and configuration.
2. Run `dotnet build`.
3. Start API with `dotnet run`.
4. Register or login to get a JWT.
5. Call an authorized endpoint with that JWT.
6. Confirm success response (no `401`).
7. Remove issuer config and verify startup fails with a clear error.
