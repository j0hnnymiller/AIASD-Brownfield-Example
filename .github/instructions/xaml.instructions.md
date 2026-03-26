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
name: xaml
description: Guidance for XAML layout and control declarations in this WPF calculator project
applyTo: "**/*.xaml"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["xaml", "wpf", "layout", "ui"]
owner: "Development Team"
reviewedDate: "2026-03-23"
nextReview: "2026-06-23"
---

# XAML Instructions

## Overview

Apply these rules when editing XAML files in this repository.

## Core Rules

### 1. Keep Layout Declarative

- Put layout, sizing, spacing, and control composition in XAML.
- Keep calculation logic out of XAML.
- Use the smallest layout container that expresses the intended structure clearly.

### 2. Optimize for the Existing Calculator UI

- Preserve the right-aligned numeric display and compact calculator grid layout.
- Keep button content, `Tag` values, and click handlers aligned with the intended operation.
- Maintain minimum window sizes and margins so the calculator remains usable on smaller displays.

### 3. Name Only What Code Needs

- Add `x:Name` only for controls accessed from code-behind.
- Avoid unnecessary named borders, panels, or placeholder elements.
- Remove stale names when a control no longer participates in code-behind logic.

### 4. Prefer Consistency Over Decoration

- Keep font sizes, margins, and alignment consistent across related buttons.
- Reuse simple structure before introducing styles or templates.
- Extract shared resources only when duplication becomes meaningful.

### 5. Keep App Wiring Stable

- Preserve the `x:Class` declarations.
- Keep `StartupUri` accurate in `App.xaml`.
- Ensure any renamed controls or handlers are updated in the matching C# file.

## Validation Checklist

- [ ] Layout remains readable and usable at the current window constraints.
- [ ] Control names and handler references match code-behind.
- [ ] UI consistency is preserved across rows and button groups.
- [ ] XAML stays focused on presentation and wiring, not calculation logic.

## Summary

Use XAML to express a clean, stable calculator UI. Keep layout declarative, names intentional, and event wiring synchronized with the WPF code-behind.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-03-23
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/wpf.instructions.md](.github/instructions/wpf.instructions.md), [.github/instructions/evergreen-software-development.instructions.md](.github/instructions/evergreen-software-development.instructions.md)
