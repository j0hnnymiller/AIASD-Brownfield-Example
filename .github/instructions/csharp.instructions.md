---
ai_generated: true
model: "openai/gpt-5.4@unknown"
operator: "johnmillerATcodemag-com"
chat_id: "create-technology-instructions-20260323"
prompt: |
  create instruction files for the technologies used in this project
started: "2026-03-23T12:45:37.8199608-07:00"
ended: "2026-03-23T12:46:27.4628188-07:00"
task_durations:
  - task: "technology review"
    duration: "00:00:15"
  - task: "instruction authoring"
    duration: "00:00:25"
  - task: "traceability updates"
    duration: "00:00:10"
total_duration: "00:00:50"
ai_log: "ai-logs/2026/03/23/create-technology-instructions-20260323/conversation.md"
source: "github-copilot-chat"
name: csharp
description: Guidance for C# application logic in this .NET 8 WPF calculator project
applyTo: "**/*.cs"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["csharp", "dotnet", "calculator", "desktop"]
owner: "Development Team"
reviewedDate: "2026-03-23"
nextReview: "2026-06-23"
---

# C# Instructions

## Overview

Apply these rules when editing C# source files in this repository.

## Core Rules

### 1. Keep Logic Direct and Readable

- Prefer straightforward methods over abstraction layers.
- Use descriptive member names that reflect calculator behavior.
- Keep mutable state limited to the UI state the app actually needs.

### 2. Treat Parsing and Formatting Explicitly

- Parse numeric input with `CultureInfo.InvariantCulture`.
- Format calculator output deterministically.
- Validate user-visible math operations before updating the display.

### 3. Keep Non-UI Logic Predictable

- Prefer pure helper methods for calculations and numeric conversions.
- Keep UI event handlers thin when logic starts to grow.
- If repeated logic emerges, extract it into private helper methods before introducing new types.

### 4. Respect Nullable and Error Boundaries

- Keep nullable annotations accurate.
- Fail with clear messages for invalid math states such as divide-by-zero or undefined trigonometric input.
- Catch exceptions at the UI boundary when the app needs to show a user-facing error.

### 5. Use WPF Event Patterns Correctly

- Preserve standard WPF handler signatures for button and window events.
- Avoid `async void` unless the method is an actual event handler and asynchronous behavior is required.
- Keep code-behind aligned with the control names and event hooks defined in XAML.

## Validation Checklist

- [ ] Method and field names reflect calculator intent.
- [ ] Numeric parsing and formatting stay culture-safe.
- [ ] Error handling remains user-visible and deterministic.
- [ ] Event handlers stay small enough to understand quickly.

## Summary

Favor clear, small C# code that keeps calculator state easy to reason about. Separate reusable math behavior from UI plumbing when complexity starts to grow.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-03-23
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/dotnet.instructions.md](.github/instructions/dotnet.instructions.md), [.github/instructions/evergreen-software-development.instructions.md](.github/instructions/evergreen-software-development.instructions.md)
