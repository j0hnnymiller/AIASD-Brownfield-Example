# Work Item: Post Controller Behavior Tests (T3)

## Priority

Medium

## Goal

Add controller behavior tests for HTTP status-code translation and contract-level responses.

## Target Test File

- `PostHubAPI.Tests/Controllers/PostControllerTests.cs`

## Implementation Guidance

1. Create tests with mocked `IPostService` and `IMapper` only.
2. Cover `GetAllPosts`:

- Service returns list -> controller returns `200 OK` with payload.

3. Cover `GetPostById`:

- Existing id -> `200 OK`.
- Service throws `NotFoundException` -> `404 Not Found`.

4. Cover `EditPost`:

- Invalid model state -> `400 Bad Request`.
- Valid request and service success -> expected success response (`200` or `204` based on implementation).
- Service throws `NotFoundException` -> `404 Not Found`.

5. Cover `DeletePost`:

- Success path returns expected success response.
- Not-found path returns `404 Not Found`.

6. Assert result types and status codes explicitly (`OkObjectResult`, `BadRequestObjectResult`, `NotFoundObjectResult`, `NoContentResult`, etc.).

## Verification Steps

1. Run focused tests:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo --filter "FullyQualifiedName~PostControllerTests"`
2. Confirm model-state invalid test fails before implementation and passes after implementation.
3. Run existing controller auth tests to ensure no regression:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo --filter "FullyQualifiedName~PostControllerAuthorizationTests"`
4. Run full suite.

## Completion Criteria

1. Core post controller actions have explicit success and failure-path assertions.
2. Status-code contracts are locked down by tests.
3. Existing controller tests remain green.
