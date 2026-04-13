# Work Item: Post Service Tests (T1)

## Priority

High

## Goal

Add deterministic unit tests for `PostService` CRUD behavior, including not-found paths.

## Target Test File

- `PostHubAPI.Tests/Services/PostServiceTests.cs`

## Implementation Guidance

1. Build a shared test setup helper in the test class that creates:

- In-memory `ApplicationDbContext` with a unique database name per test.
- AutoMapper configured with `PostProfile` and `CommentProfile`.

2. Cover `GetAllPosts`:

- Returns empty list when no posts exist.
- Returns projected DTO list when posts exist.

3. Cover `GetPostById`:

- Returns expected post when id exists.
- Throws `NotFoundException` when id does not exist.

4. Cover `CreatePost`:

- Persists post.
- Returns mapped `ReadPostDto` with expected field values.

5. Cover `EditPost`:

- Updates title/body/updated timestamp when id exists.
- Throws `NotFoundException` when id does not exist.

6. Cover `DeletePost`:

- Removes record when id exists.
- Throws `NotFoundException` when id does not exist.

7. Assert side effects directly against the context after each mutation.

## Verification Steps

1. Run focused tests:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo --filter "FullyQualifiedName~PostServiceTests"`
2. Confirm all test cases pass in isolation.
3. Run the full suite:
   `dotnet test PostHubAPI.Tests/PostHubAPI.Tests.csproj --nologo`
4. Confirm no order dependency by running focused tests again.

## Completion Criteria

1. Success and not-found branches are covered for all CRUD operations.
2. Tests are deterministic and do not share state across test methods.
3. Full test suite remains green.
