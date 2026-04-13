---
ai_generated: true
model: "openai/gpt-5.3-codex@unknown"
operator: "johnmillerATcodemag-com"
chat_id: "b883ead3-9823-4a1b-af57-79c22016fff3"
prompt: |
  create instruction files for the tech stack in the #file:developer-guide.md
started: "2026-04-07T15:10:00-07:00"
ended: "2026-04-07T15:21:00-07:00"
task_durations:
  - task: "stack analysis"
    duration: "00:03:00"
  - task: "instruction authoring"
    duration: "00:07:00"
  - task: "traceability updates"
    duration: "00:01:00"
total_duration: "00:11:00"
ai_log: "ai-logs/2026/04/07/b883ead3-9823-4a1b-af57-79c22016fff3/conversation.md"
source: "github-copilot-chat"
name: entity-framework-core-identity
description: Guidance for EF Core and ASP.NET Core Identity persistence configuration and usage
applyTo: "Data/**/*.cs"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["efcore", "identity", "database", "persistence"]
owner: "Development Team"
reviewedDate: "2026-04-07"
nextReview: "2026-07-07"
---

# Entity Framework Core and Identity Instructions

## Overview

Apply these rules when editing persistence code, model relationships, and Identity-backed data behavior.

## Core Rules

### 1. Keep `ApplicationDbContext` as the Persistence Boundary

- Define entity sets and relationship mapping in `ApplicationDbContext`.
- Keep relationship behavior explicit (delete behavior, required fields, keys).
- Avoid hidden conventions for critical data integrity rules.

### 2. Preserve Identity Integration

- Keep Identity user behavior compatible with `User` model expectations.
- Do not bypass `UserManager` workflows for password or identity-sensitive operations.
- Keep Identity and domain data concerns separated at service boundaries.

### 3. Protect Relational Compatibility

- Treat development in-memory behavior as a local convenience, not production truth.
- Avoid query patterns that only work in-memory but fail on relational providers.
- Keep data access patterns deterministic and testable.

### 4. Keep Entity Changes Backward Aware

- Make additive schema and model changes by default.
- Review cascade delete and required/optional relationship impacts before modifying mappings.
- Ensure new fields have clear initialization and validation behavior.

### 5. Keep Data Access in Services

- Perform query and mutation logic in service implementations, not controllers.
- Use async EF patterns for I/O operations.
- Keep transaction or unit-of-work expectations clear when multiple entities are updated.

## Validation Checklist

- [ ] DbContext mapping rules remain explicit and intentional.
- [ ] Identity-sensitive flows still route through Identity abstractions.
- [ ] Data access code stays in services, not endpoint handlers.
- [ ] Persistence behavior remains compatible with relational providers.

## Summary

Keep persistence predictable, relationally safe, and aligned with Identity workflows. Centralize data mapping in `ApplicationDbContext` and data operations in services.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-04-07
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/csharp.instructions.md](.github/instructions/csharp.instructions.md), [.github/instructions/evergreen-software-development.instructions.md](.github/instructions/evergreen-software-development.instructions.md)
