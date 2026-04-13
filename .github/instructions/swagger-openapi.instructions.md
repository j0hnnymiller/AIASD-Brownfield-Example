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
name: swagger-openapi
description: Guidance for Swagger and OpenAPI configuration in ASP.NET Core startup
applyTo: "Program.cs"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["swagger", "openapi", "aspnetcore", "documentation"]
owner: "Development Team"
reviewedDate: "2026-04-07"
nextReview: "2026-07-07"
---

# Swagger and OpenAPI Instructions

## Overview

Apply these rules when modifying Swagger/OpenAPI setup in application startup.

## Core Rules

### 1. Keep Swagger Development-Scoped by Default

- Enable Swagger middleware in development unless a deployment requirement says otherwise.
- Avoid exposing interactive API docs in production by default.
- Keep environment checks explicit and easy to audit.

### 2. Keep OpenAPI Configuration Consistent

- Register Swagger/OpenAPI services once in startup.
- Keep document metadata stable and meaningful.
- Ensure bearer-auth endpoints remain testable from Swagger when authentication is enabled.

### 3. Keep Security Scheme Definitions Accurate

- Document JWT bearer expectations in OpenAPI security configuration when needed.
- Keep scheme names and header conventions aligned with runtime auth behavior.
- Avoid stale security definitions that no longer match endpoint requirements.

### 4. Treat Swagger Changes as Developer Experience Changes

- Preserve discoverability of endpoints for local contributors.
- Keep docs behavior aligned with current route conventions.
- Validate that Swagger still boots under the development launch profile.

## Validation Checklist

- [ ] Swagger is enabled only in intended environments.
- [ ] OpenAPI registration and metadata remain coherent.
- [ ] Security scheme definitions match JWT behavior.
- [ ] Local developer Swagger workflow still works.

## Summary

Keep Swagger setup explicit, development-focused, and aligned with the running authentication and routing behavior.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-04-07
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/aspnetcore-webapi.instructions.md](.github/instructions/aspnetcore-webapi.instructions.md), [.github/instructions/jwt-bearer-auth.instructions.md](.github/instructions/jwt-bearer-auth.instructions.md)
