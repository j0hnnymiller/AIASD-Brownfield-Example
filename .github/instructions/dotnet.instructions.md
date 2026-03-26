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
name: dotnet
description: Guidance for maintaining the .NET 8 SDK-style WPF project in this repository
applyTo: "**/*.csproj"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["dotnet", "net8", "msbuild", "wpf"]
owner: "Development Team"
reviewedDate: "2026-03-23"
nextReview: "2026-06-23"
---

# .NET Project Instructions

## Overview

Apply these rules when changing the SDK-style project configuration for this calculator application.

## Core Rules

### 1. Preserve the Desktop App Target

- Keep `TargetFramework` on `net8.0-windows` unless the user explicitly requests a framework migration.
- Keep `OutputType` as `WinExe` for the desktop UI entry point.
- Keep `UseWPF` enabled.

### 2. Keep the Project File Minimal

- Prefer the default SDK behavior over verbose `ItemGroup` declarations.
- Add properties only when they change behavior in a necessary, reviewable way.
- Do not add custom build steps, analyzers, or package references without a concrete need.

### 3. Prefer Platform APIs Before Adding Dependencies

- Use the .NET Base Class Library before introducing NuGet packages.
- If a new package is required, choose a stable package, pin the version, and explain why the framework APIs are insufficient.
- Avoid dependencies that add application hosting, DI, or MVVM infrastructure unless the project scope actually requires them.

### 4. Keep Build and Run Workflow Stable

- Ensure `dotnet build` works from the repo root.
- Ensure `dotnet run --project Calculator.csproj` remains the primary local run command.
- Treat warnings caused by project-file changes as regressions to fix, not noise to ignore.

### 5. Maintain Solution Consistency

- If new projects are added, keep the solution file aligned with the project layout.
- Do not rename the existing project or root namespace without explicit user direction.
- Prefer additive, low-risk project changes over structural churn.

## Validation Checklist

- [ ] `TargetFramework`, `OutputType`, and `UseWPF` still match a WPF desktop app.
- [ ] The project file stays SDK-style and easy to review.
- [ ] New dependencies are justified and versioned.
- [ ] Root-level `dotnet build` and project-level `dotnet run` still make sense.

## Summary

Optimize for a small, stable .NET 8 desktop application. Keep the project file lean, preserve the WPF runtime settings, and avoid unnecessary build complexity.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-03-23
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/evergreen-software-development.instructions.md](.github/instructions/evergreen-software-development.instructions.md), [.github/instructions/ai-assisted-output.instructions.md](.github/instructions/ai-assisted-output.instructions.md)
