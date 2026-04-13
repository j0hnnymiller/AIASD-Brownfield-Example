# PostHubAPI

The **PostHubAPI** is a blog API that provides complete CRUD (Create, Read, Update, Delete) functionalities for Posts and Comments, along with user registration capabilities.

## Technologies Used

- **C#**: Programming language used for API logic development.
- **ASP.NET Web API**: Framework used to create RESTful APIs on the .NET platform.
- **Entity Framework In Memory**: Object-Relational Mapping (ORM) tool that simplifies database access and manipulation.
- **AutoMapper**: Library simplifying object mapping in .NET applications.

## Features

- **CRUD for Posts**: Create, read, update, and delete blog posts.
- **CRUD for Comments**: Manage comments associated with each post.
- **User Registration**: Enable user registration and management to interact with the blog.

## Documentation

- [docs/posthubapi-architecture.md](docs/posthubapi-architecture.md) contains C4 context, container, and component diagrams for the current ASP.NET Core API. Provenance log: [ai-logs/2026/04/07/40697613-907e-4eb7-8cee-31463c338ddc/conversation.md](ai-logs/2026/04/07/40697613-907e-4eb7-8cee-31463c338ddc/conversation.md).
- [docs/developer-guide.md](docs/developer-guide.md) contains local setup, configuration, test workflow, and repository structure notes for contributors. Provenance log: [ai-logs/2026/04/07/24aba72b-f0e6-43b8-9fdf-d51df156fa31/conversation.md](ai-logs/2026/04/07/24aba72b-f0e6-43b8-9fdf-d51df156fa31/conversation.md).
- [.github/instructions/aspnetcore-webapi.instructions.md](.github/instructions/aspnetcore-webapi.instructions.md), [.github/instructions/entity-framework-core-identity.instructions.md](.github/instructions/entity-framework-core-identity.instructions.md), [.github/instructions/automapper.instructions.md](.github/instructions/automapper.instructions.md), [.github/instructions/jwt-bearer-auth.instructions.md](.github/instructions/jwt-bearer-auth.instructions.md), [.github/instructions/swagger-openapi.instructions.md](.github/instructions/swagger-openapi.instructions.md), and [.github/instructions/xunit.instructions.md](.github/instructions/xunit.instructions.md) define stack-specific coding guidance for this API. Provenance log: [ai-logs/2026/04/07/b883ead3-9823-4a1b-af57-79c22016fff3/conversation.md](ai-logs/2026/04/07/b883ead3-9823-4a1b-af57-79c22016fff3/conversation.md).

For local development setup and contributor workflow, start with [docs/developer-guide.md](docs/developer-guide.md).
