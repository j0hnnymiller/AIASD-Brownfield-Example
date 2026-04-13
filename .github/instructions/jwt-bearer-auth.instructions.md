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
name: jwt-bearer-auth
description: Guidance for JWT bearer authentication configuration and token handling
applyTo: "Configuration/**/*.cs"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["jwt", "authentication", "authorization", "security"]
owner: "Development Team"
reviewedDate: "2026-04-07"
nextReview: "2026-07-07"
---

# JWT Bearer Authentication Instructions

## Overview

Apply these rules when changing JWT settings resolution, token validation, and auth pipeline behavior.

## Core Rules

### 1. Keep Secrets Out of Source Control

- Do not commit `JWT:Secret` values in tracked config files.
- Resolve secrets from secure external configuration providers.
- Fail fast on startup when required JWT settings are missing.

### 2. Preserve Token Validation Strictness

- Keep issuer, audience, signature, and lifetime validation enabled.
- Keep HTTPS metadata required outside development environments.
- Avoid relaxing validation flags unless explicitly required and documented.

### 3. Keep Settings Resolution Centralized

- Use `JwtSettingsResolver` or equivalent centralized configuration access.
- Keep JWT option names consistent (`JWT:ValidIssuer`, `JWT:ValidAudience`, `JWT:Secret`).
- Avoid scattered configuration key lookups across unrelated classes.

### 4. Keep Token Creation and Validation Separated

- Generate tokens through the token service abstraction.
- Keep validation settings in startup/auth configuration.
- Keep claim naming and semantics stable for existing consumers.

### 5. Audit Auth-Sensitive Changes with Tests

- Add or update tests for settings resolution and auth behavior changes.
- Verify unauthorized and forbidden flows remain correct on protected endpoints.
- Treat auth configuration regressions as high severity.

## Validation Checklist

- [ ] JWT secrets remain external to source control.
- [ ] Token validation strictness has not been unintentionally reduced.
- [ ] JWT settings access remains centralized.
- [ ] Auth changes include test updates where relevant.

## Summary

Keep JWT configuration secure, centralized, and strict by default. Preserve endpoint protection and token semantics through explicit tests and configuration rules.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-04-07
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/aspnetcore-webapi.instructions.md](.github/instructions/aspnetcore-webapi.instructions.md), [.github/instructions/evergreen-software-development.instructions.md](.github/instructions/evergreen-software-development.instructions.md)
