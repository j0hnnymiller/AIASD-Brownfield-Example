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
name: wpf
description: Guidance for WPF application structure and code-behind behavior in this project
applyTo: "**/*.xaml.cs"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["wpf", "desktop", "code-behind", "windows"]
owner: "Development Team"
reviewedDate: "2026-03-23"
nextReview: "2026-06-23"
---

# WPF Instructions

## Overview

Apply these rules when editing WPF-specific application code such as window code-behind and app startup code.

## Core Rules

### 1. Keep UI Structure and Behavior in Sync

- Keep code-behind consistent with the control names, `Tag` values, and event handlers declared in XAML.
- Update both the XAML and the corresponding C# handler wiring when renaming controls or events.
- Do not leave dead handlers or unused named controls behind.

### 2. Favor Simple WPF Patterns

- For a small calculator, code-behind is acceptable when it stays easy to follow.
- Do not introduce MVVM, commands, or dependency injection unless the user explicitly asks for architectural expansion.
- Keep startup flow simple through `App.xaml` and `MainWindow`.

### 3. Protect the User Interaction Loop

- Keep the display state, pending operator state, and memory state internally consistent after each action.
- Reset entry flags deliberately so repeated button presses behave predictably.
- Show meaningful status text when actions succeed or fail.

### 4. Keep WPF-Specific Behavior Intentional

- Use `MessageBox` or status text only for user-facing conditions that need immediate feedback.
- Prefer built-in WPF controls and layout containers before adding custom controls.
- Preserve window sizing constraints and startup behavior unless the user asks for a UX change.

## Validation Checklist

- [ ] XAML event hookups and code-behind methods still match.
- [ ] Calculator state transitions remain predictable after each button click.
- [ ] WPF-specific changes stay proportionate to the app’s size.
- [ ] Startup and main-window behavior remain intact.

## Summary

Use WPF as a lightweight desktop UI layer. Keep code-behind synchronized with XAML, preserve predictable button behavior, and avoid heavyweight patterns unless the project scope changes.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-03-23
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/csharp.instructions.md](.github/instructions/csharp.instructions.md), [.github/instructions/xaml.instructions.md](.github/instructions/xaml.instructions.md)
