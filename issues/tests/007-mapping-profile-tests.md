# Work Item: Mapping Profile Tests (T7)

## Priority

Medium

## Goal

Add AutoMapper safety-net tests to detect profile drift for post/comment DTO mappings.

## Target Test File

- `PostHubAPI.Tests/Profiles/MappingProfileTests.cs`

## Implementation Guidance

1. Build mapper configuration that includes at least:

- `PostProfile`
- `CommentProfile`

2. Add configuration validity test:

- Call `AssertConfigurationIsValid()`.

3. Add mapping smoke tests for key flows:

- `CreatePostDto -> Post`
- `Post -> ReadPostDto`
- `CreateCommentDto -> Comment`
- `Comment -> ReadCommentDto`

4. Include assertions for representative field mappings (for example title/body, identifiers, foreign keys where applicable).
5. Keep tests focused on mapping contract, not service/controller behavior.

## Verification Steps

1. Run focused tests:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo --filter "FullyQualifiedName~MappingProfileTests"`
2. Confirm profile validation fails if a required map is intentionally removed, then restore and re-run.
3. Run full suite.

## Completion Criteria

1. AutoMapper profile validity is tested in CI.
2. Core post/comment DTO mapping flows have smoke coverage.
3. Mapping drift is detectable through failing tests.
