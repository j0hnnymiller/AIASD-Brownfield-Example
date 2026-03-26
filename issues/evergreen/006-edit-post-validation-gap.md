# Issue: Edit Post DTO Validation Gap

## Severity

Medium

## Description

Edit payload fields for post updates have no data annotations, while controller logic relies on model validation checks. This causes inconsistent data constraints between create and edit operations.

## Proposed Updates

1. Add explicit validation rules to edit DTO fields.
2. Align constraints with create DTO unless intentionally supporting partial updates.
3. If partial updates are intended, switch to PATCH semantics and define nullable validation rules clearly.
4. Add tests for invalid and valid edit payloads.

## Verification Steps

1. Apply validation strategy for edit requests.
2. Run `dotnet build`.
3. Send invalid edit payloads and verify `400 Bad Request`.
4. Send valid edit payload and verify success.
5. Confirm create/edit constraints are consistent with intended API behavior.
