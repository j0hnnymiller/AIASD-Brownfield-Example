# Issue: Typo in Public API Method Name

## Severity

Low

## Description

A public service method is named `CreateNewCommnentAsync` (typo), and the typo propagates through interface, implementation, and call sites. This reduces readability and maintainability.

## Proposed Updates

1. Rename method to `CreateNewCommentAsync` everywhere.
2. Rebuild and run endpoint tests.
3. If external consumers depend on the typoed name, provide a temporary compatibility path.

## Verification Steps

1. Rename symbol in interface, implementation, and controller usage.
2. Run `dotnet build`.
3. Exercise comment creation endpoint and confirm success.
4. Search for old name and confirm no remaining references.
