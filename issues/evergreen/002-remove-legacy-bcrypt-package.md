# Issue: Legacy BCrypt Package Is Incompatible and Unused

## Severity

High

## Description

The project references `BCrypt.Net` version `0.1.0`, which is legacy and incompatible with current target expectations. Build currently reports compatibility warnings. A search indicates BCrypt is not used in the codebase.

## Proposed Updates

1. Remove the `BCrypt.Net` package reference from the project file.
2. If password hashing is required in future, use ASP.NET Identity hashing or a modern maintained package compatible with the current target framework.
3. Rebuild to confirm warning removal.

## Verification Steps

1. Remove package reference.
2. Run `dotnet restore`.
3. Run `dotnet build`.
4. Confirm legacy BCrypt compatibility warning is gone.
5. Smoke test register/login endpoints to verify no behavior regression.
