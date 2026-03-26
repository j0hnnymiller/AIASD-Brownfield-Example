# Issue: In-Memory Database Is Hardwired as Default

## Severity

Medium

## Description

The API is configured to always use `UseInMemoryDatabase`. This is useful for demos/tests but not durable for production-like operation, and it hides persistence/migration issues.

## Proposed Updates

1. Make database provider environment-driven.
2. Keep in-memory provider for development/tests only.
3. Use a durable provider for non-development environments.
4. Add setup documentation for provider selection and connection configuration.

## Verification Steps

1. Implement environment-based provider selection.
2. Run in Development and confirm in-memory provider is used.
3. Run in non-Development and confirm durable provider is used.
4. Create data, restart app, verify data persists in durable environment.
5. Run CRUD endpoint smoke tests across both configurations.
