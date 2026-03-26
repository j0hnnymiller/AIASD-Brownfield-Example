# Issue: JWT RequireHttpsMetadata Is Disabled

## Severity

Medium

## Description

JWT bearer configuration sets `RequireHttpsMetadata = false`. This weakens secure-by-default behavior and can accidentally carry into non-development environments.

## Proposed Updates

1. Enable `RequireHttpsMetadata` by default.
2. Gate any local-development exception behind explicit environment checks.
3. Document expected behavior by environment.

## Verification Steps

1. Set secure default in JWT bearer config.
2. Run local development scenario and confirm expected behavior.
3. Run non-development scenario and confirm HTTPS metadata enforcement.
4. Validate authorized endpoint access still works under HTTPS.
