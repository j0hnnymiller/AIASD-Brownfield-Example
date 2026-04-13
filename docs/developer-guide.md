---
ai_generated: true
model: "openai/gpt-5.4@unknown"
operator: "johnmillerATcodemag-com"
chat_id: "24aba72b-f0e6-43b8-9fdf-d51df156fa31"
prompt: |
  create a developers guide for this project. move any redundant content from the readme file
started: "2026-04-07T14:02:30.0000000-07:00"
ended: "2026-04-07T14:11:55.7209411-07:00"
task_durations:
  - task: "repository analysis"
    duration: "00:04:00"
  - task: "guide authoring"
    duration: "00:03:30"
  - task: "traceability updates"
    duration: "00:01:55"
total_duration: "00:09:25"
ai_log: "ai-logs/2026/04/07/24aba72b-f0e6-43b8-9fdf-d51df156fa31/conversation.md"
source: "github-copilot-chat"
---

# PostHubAPI Developer Guide

## Purpose

This guide is for contributors working on the API itself. It covers local setup, configuration, runtime behavior, test commands, and the current project layout. For system-level design context, see [docs/posthubapi-architecture.md](docs/posthubapi-architecture.md).

## Stack Summary

- ASP.NET Core 8 Web API
- Entity Framework Core with ASP.NET Core Identity
- AutoMapper for DTO mapping
- JWT bearer authentication
- Swagger in development
- xUnit for automated tests

## Repository Layout

| Path                        | Responsibility                                                                         |
| --------------------------- | -------------------------------------------------------------------------------------- |
| `Program.cs`                | Application composition, dependency injection, authentication, and middleware pipeline |
| `Controllers/`              | HTTP endpoints for users, posts, and comments                                          |
| `Services/Implementations/` | Business logic used by controllers                                                     |
| `Services/Interfaces/`      | Service contracts                                                                      |
| `Data/`                     | EF Core `ApplicationDbContext` and persistence configuration                           |
| `Models/`                   | Entity types persisted by EF Core and Identity                                         |
| `Dtos/`                     | Request and response contracts for the API surface                                     |
| `Profiles/`                 | AutoMapper profiles mapping entities and DTOs                                          |
| `Configuration/`            | Configuration helpers such as JWT settings resolution                                  |
| `PostHubAPI.Tests/`         | xUnit coverage for configuration, controllers, and services                            |
| `docs/`                     | Long-lived project documentation                                                       |
| `issues/evergreen/`         | Tracked engineering follow-up items and technical debt notes                           |

## Prerequisites

- .NET 8 SDK
- A local secret store or environment-variable workflow for JWT configuration
- An IDE or editor with ASP.NET Core support such as Visual Studio or VS Code

## Local Configuration

### JWT Settings

The application requires these configuration values:

- `JWT:ValidIssuer`
- `JWT:ValidAudience`
- `JWT:Secret`

`ValidIssuer` and `ValidAudience` are already present in [appsettings.json](../appsettings.json). `JWT:Secret` must be provided outside source control. If it is missing, `JwtSettingsResolver` throws during startup.

Recommended development setup:

```powershell
dotnet user-secrets init --project .\PostHubAPI.csproj
dotnet user-secrets set "JWT:Secret" "replace-with-a-long-random-secret" --project .\PostHubAPI.csproj
```

Alternative:

```powershell
$env:JWT__Secret = "replace-with-a-long-random-secret"
```

Do not store signing secrets in tracked configuration files.

### Database Behavior By Environment

- `Development` uses the EF Core in-memory provider named `PostHubApi.db`.
- Non-development environments use SQLite via `ConnectionStrings:DefaultConnection`.

This means local development has minimal setup, but it also means development behavior does not fully match relational database semantics.

## Running The API

Restore dependencies:

```powershell
dotnet restore
```

Run the API with the local HTTPS launch profile:

```powershell
dotnet run --launch-profile https
```

Default development URLs from [Properties/launchSettings.json](../Properties/launchSettings.json):

- `https://localhost:7151`
- `http://localhost:5045`

Swagger UI is enabled only in development and opens at `/swagger`.

## Authentication And Endpoint Shape

- `UserController` exposes public `Register` and `Login` endpoints.
- `PostController` allows public reads and requires authorization for create, edit, and delete operations.
- `CommentController` requires authorization for all actions.

JWT bearer auth is configured in `Program.cs`. In development, `RequireHttpsMetadata` is disabled. In non-development environments, it remains enabled.

## Test Workflow

Run the focused test project from the repository root:

```powershell
dotnet test .\PostHubAPI.Tests\PostHubAPI.Tests.csproj --no-restore
```

Current test coverage is organized around:

- `Configuration/` for JWT settings resolution
- `Controllers/` for authorization and user API behavior
- `Services/` for token generation and business logic

## Implementation Notes

- Controllers are intentionally thin and delegate to service interfaces.
- Token creation is isolated behind `ITokenService` with `JwtTokenService` as the default implementation.
- DTO mapping lives in AutoMapper profiles rather than controllers or entity classes.
- `ApplicationDbContext` hosts both blog entities and ASP.NET Core Identity entities.
- Posts own comments through a cascade delete relationship configured in `ApplicationDbContext`.

## Documentation And Follow-Up

- Architecture reference: [docs/posthubapi-architecture.md](docs/posthubapi-architecture.md)
- Tracked engineering follow-ups: [issues/evergreen/README.md](../issues/evergreen/README.md)

When adding long-lived documentation, prefer `docs/` and add a link from the README so contributors can find it without scanning the tree.
