# Work Item: Comment Service Tests (T2)

## Priority

High

## Goal

Add service-level tests for `CommentService` covering create/read/update/delete and parent-post validation.

## Target Test File

- `PostHubAPI.Tests/Services/CommentServiceTests.cs`

## Implementation Guidance

1. Reuse deterministic setup pattern:

- Unique in-memory database per test.
- AutoMapper configured with `CommentProfile` and `PostProfile`.

2. Cover read paths:

- Get comments for an existing post returns mapped DTOs.
- Get by id returns mapped DTO for existing comment.
- Nonexistent comment id throws `NotFoundException`.

3. Cover create paths:

- Creating comment for existing post persists and returns expected DTO.
- Creating comment for nonexistent post throws `NotFoundException`.

4. Cover edit paths:

- Existing comment updates fields and persists changes.
- Nonexistent comment id throws `NotFoundException`.

5. Cover delete paths:

- Existing comment is removed.
- Nonexistent comment id throws `NotFoundException`.

6. Validate persistence side effects and parent/child relationship correctness.

## Verification Steps

1. Run focused tests:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo --filter "FullyQualifiedName~CommentServiceTests"`
2. Verify expected exception assertions for all failure-path tests.
3. Run full suite:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo`

## Completion Criteria

1. CRUD and post-not-found behavior are fully covered.
2. Tests assert both return values and DB side effects.
3. Full suite stays green.
