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
name: xunit
description: Guidance for xUnit test design and maintenance in PostHubAPI.Tests
applyTo: "PostHubAPI.Tests/**/*.cs"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["xunit", "testing", "unit-tests", "aspnetcore"]
owner: "Development Team"
reviewedDate: "2026-04-07"
nextReview: "2026-07-07"
---

# xUnit Testing Instructions

## Overview

Apply these rules when creating or modifying tests in `PostHubAPI.Tests`.

## Core Rules

### 1. Keep Test Scope Focused

- Use unit tests for isolated business logic and configuration behavior.
- Use controller-focused tests for authorization and API boundary behavior.
- Keep each test centered on one behavior and one expectation pattern.

### 2. Keep Naming Explicit

- Use test names that describe scenario and expected result.
- Keep arrange/act/assert structure clear and easy to scan.
- Avoid ambiguous names that hide intent.

### 3. Test Security and Configuration Edges

- Cover JWT settings resolution failure and success paths.
- Cover protected endpoint authorization behavior.
- Keep regression tests for previously fixed auth and validation issues.

### 4. Keep Test Data Deterministic

- Use controlled test fixtures and deterministic timestamps where needed.
- Avoid shared mutable state between tests.
- Keep random values out of assertions unless explicitly bounded.

### 5. Keep Tests Fast and Reliable

- Avoid unnecessary I/O and network dependencies.
- Mock only what is needed to isolate the unit under test.
- Treat flaky tests as defects to fix immediately.

## Validation Checklist

- [ ] Tests have clear scenario-driven names.
- [ ] Auth and configuration edge cases are covered.
- [ ] Test setup and assertions are deterministic.
- [ ] Suite remains fast and stable.

## Summary

Prefer focused, deterministic xUnit coverage that protects API behavior, auth boundaries, and configuration safety.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-04-07
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/jwt-bearer-auth.instructions.md](.github/instructions/jwt-bearer-auth.instructions.md), [.github/instructions/evergreen-software-development.instructions.md](.github/instructions/evergreen-software-development.instructions.md)
