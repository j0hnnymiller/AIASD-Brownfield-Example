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
name: automapper
description: Guidance for AutoMapper profile design and DTO mapping in this repository
applyTo: "Profiles/**/*.cs"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["automapper", "dto", "mapping", "profiles"]
owner: "Development Team"
reviewedDate: "2026-04-07"
nextReview: "2026-07-07"
---

# AutoMapper Instructions

## Overview

Apply these rules when editing mapping profiles and DTO conversion behavior.

## Core Rules

### 1. Keep Mapping Definitions in Profiles

- Define mapping rules in `Profiles/` classes.
- Keep controller and service code free of ad-hoc property mapping.
- Add or update profile registrations through startup configuration only when needed.

### 2. Preserve API Contract Intent

- Map only fields intended for the API contract.
- Avoid exposing sensitive internal fields through DTO mappings.
- Keep read/write DTO responsibilities explicit.

### 3. Favor Explicit Rules for Non-Trivial Cases

- Use explicit member mapping when names or semantics differ.
- Add value transformations in profiles only when they are deterministic and contract-safe.
- Avoid hidden behavior that makes mapping results hard to predict.

### 4. Keep Mapping Changes Testable

- Update tests or add coverage when mapping behavior changes.
- Validate that required DTO fields remain populated after mapping updates.
- Treat contract-impacting mapping changes as breaking unless intentionally versioned.

## Validation Checklist

- [ ] All mapping behavior lives in profile classes.
- [ ] DTO mappings do not leak internal or sensitive fields.
- [ ] Non-trivial mappings use explicit configuration.
- [ ] Mapping changes are covered by relevant tests.

## Summary

Use AutoMapper profiles as the single source of DTO mapping behavior. Keep mappings explicit, contract-safe, and test-backed.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-04-07
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/aspnetcore-webapi.instructions.md](.github/instructions/aspnetcore-webapi.instructions.md), [.github/instructions/csharp.instructions.md](.github/instructions/csharp.instructions.md)
