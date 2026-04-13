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
name: aspnetcore-webapi
description: Guidance for ASP.NET Core Web API controller and endpoint behavior in this repository
applyTo: "Controllers/**/*.cs"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["aspnetcore", "webapi", "controllers", "rest"]
owner: "Development Team"
reviewedDate: "2026-04-07"
nextReview: "2026-07-07"
---

# ASP.NET Core Web API Instructions

## Overview

Apply these rules when editing API endpoint code in `Controllers/`.

## Core Rules

### 1. Keep Controllers Thin

- Keep request validation, orchestration, and HTTP response concerns in controllers.
- Delegate business logic and persistence behavior to service interfaces.
- Avoid direct `DbContext` usage from controller actions.

### 2. Preserve Resource-Oriented HTTP Behavior

- Use clear route templates and stable resource naming.
- Return the most specific `ActionResult` status for each outcome.
- Keep action names and routes aligned with CRUD intent.

### 3. Enforce Authorization Boundaries

- Keep public endpoints explicit and minimal.
- Require `[Authorize]` on mutating operations unless public write access is intentional.
- Keep ownership checks in service logic and surface failures as standard API responses.

### 4. Keep DTO Contracts Stable

- Use DTO types for request and response payloads.
- Avoid exposing EF entities directly from API actions.
- Preserve backward compatibility for existing response shapes unless a contract change is requested.

### 5. Return Actionable Errors

- Translate expected service failures to consistent HTTP responses.
- Avoid leaking internal exception details in production responses.
- Keep model-validation failures and not-found responses explicit and predictable.

## Validation Checklist

- [ ] Controllers delegate business logic to services.
- [ ] Endpoint status codes match request outcomes.
- [ ] Authorization attributes and access boundaries remain correct.
- [ ] API actions use DTO contracts rather than entity types.

## Summary

Favor explicit HTTP behavior, thin controllers, and stable API contracts. Keep business logic in services and preserve clear authorization boundaries.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-04-07
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/csharp.instructions.md](.github/instructions/csharp.instructions.md), [.github/instructions/evergreen-software-development.instructions.md](.github/instructions/evergreen-software-development.instructions.md)
