# Issue: JWT Secret Stored in Source-Controlled Settings

## Severity

High

## Description

A live JWT signing secret is present in tracked configuration. Keeping secrets in source control increases leakage risk and complicates secure rotation.

## Proposed Updates

1. Remove live secret values from tracked settings files.
2. Use secure sources for secrets (environment variables or user secrets for local development).
3. Add startup guardrails that fail clearly when required secrets are missing.
4. Document secure secret setup and rotation steps.

## Verification Steps

1. Move JWT secret to secure configuration source.
2. Ensure tracked settings no longer contain live secret values.
3. Run `dotnet run` with secure secret configured and confirm startup succeeds.
4. Run without secret and confirm startup fails with clear guidance.
5. Execute auth flow and verify token issuance and validation still work.
