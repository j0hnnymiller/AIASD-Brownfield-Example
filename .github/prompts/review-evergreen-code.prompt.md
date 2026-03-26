---
name: review-evergreen-code
description: Review the repository against evergreen software development principles and report code that is brittle, tightly coupled, stale, or otherwise not evergreen.
temperature: 0.2
tags: ["review", "promptfile", "evergreen", "maintainability"]
ai_generated: true
model: "openai/gpt-5.4@unknown"
operator: "johnmillerATcodemag-com"
chat_id: "create-evergreen-review-prompt-20260324"
prompt: |
  create a prompt file that reviews the codebase and reports any code that is not evergreen
started: "2026-03-24T10:20:00Z"
ended: "2026-03-24T10:30:00Z"
task_durations:
  - task: "requirements alignment"
    duration: "00:02:00"
  - task: "prompt authoring"
    duration: "00:05:00"
  - task: "traceability updates"
    duration: "00:03:00"
total_duration: "00:10:00"
ai_log: "ai-logs/2026/03/24/create-evergreen-review-prompt-20260324/conversation.md"
source: "github-copilot-chat"
owner: "Development Team"
version: "1.0.0"
prompt_metadata:
  id: review-evergreen-code
  title: Review Evergreen Code
  owner: johnmillerATcodemag-com
  version: 1.0.0
  output_path: .github/prompts/review-evergreen-code.prompt.md
  category: review
  output_format: markdown
---

# Review Evergreen Code

## Context

Inspect the current repository and assess whether the implementation follows the evergreen software development principles defined in `.github/instructions/evergreen-software-development.instructions.md`.

Read the real code before judging it. Prioritize the solution file, project file, README, application startup files, UI definitions, and code-behind or domain logic files. Base the review on what is actually present rather than on generic architecture expectations.

**CRITICAL**: Treat this as a review task, not a refactor task. Report findings first. Do not change files unless the user explicitly asks for fixes after the review. If the review output itself becomes a new AI-assisted artifact, comply with `.github/instructions/ai-assisted-output.instructions.md`.

## Objective

Identify code, structure, or project decisions that reduce the repository's long-term maintainability, adaptability, testability, or operability.

## Evergreen Review Criteria

Evaluate the codebase against these evergreen concerns:

1. Design for change: tight coupling, mixed responsibilities, hardcoded assumptions, or framework-dependent business logic.
2. Simplicity: unnecessary complexity, duplicate logic, dead code, or confusing control flow.
3. Readability and intent: unclear naming, implicit side effects, difficult-to-follow event handling, or missing rationale in non-obvious code.
4. Defensive quality: missing validation, missing tests for risky logic, or behavior that is hard to verify safely.
5. Operability: weak error handling, poor diagnostics, or user-visible failures without actionable context.
6. Dependency and platform sustainability: outdated or brittle project configuration, hidden runtime assumptions, or avoidable platform lock-in.
7. Team continuity: missing documentation, knowledge trapped in code-behind, or structure that makes future extension harder than necessary.

## Workflow

1. Inspect the repository structure and identify the files that define application behavior.
2. Read `.github/instructions/evergreen-software-development.instructions.md` and use it as the evaluation baseline.
3. Review the implementation for concrete evergreen risks rather than style-only nits.
4. Group findings by severity and tie each finding to the violated evergreen principle.
5. Cite specific files and line numbers whenever possible.
6. If no material issues are found, state that explicitly and note any residual risks or testing gaps.

## Findings Requirements

For each finding, provide:

- severity: `high`, `medium`, or `low`
- file reference with line number
- the specific code or pattern that is not evergreen
- why it creates long-term maintenance or evolution risk
- the evergreen principle it violates
- a concrete remediation direction

Reject weak findings. Do not report purely subjective style preferences unless they create a clear maintenance risk.

## Deliverable

Return a concise review report with this structure:

### Findings

- `<severity>`: `<short title>`
  - File: `<path>:<line>`
  - Risk: `<why this is not evergreen>`
  - Principle: `<evergreen principle>`
  - Recommendation: `<pragmatic fix direction>`

### Open Questions or Assumptions

- `<question or assumption>`

### Residual Risks

- `<testing gap, operational gap, or documentation gap>`

If there are no findings, return:

- `No evergreen issues found.`
- `Residual risks:` followed by any remaining testing or documentation gaps.

## Quality Bar

- Focus on architectural and maintainability issues over formatting preferences.
- Prefer a small number of defensible findings over a long list of weak ones.
- Keep recommendations realistic for the repository's current size and technology stack.
- Use the existing calculator application context when judging proportionality.

## Validation Checklist

- [ ] The codebase was inspected before conclusions were drawn.
- [ ] Findings are tied to evergreen principles, not generic style guidance.
- [ ] Each finding cites a concrete file location.
- [ ] Findings are ordered by severity.
- [ ] The response makes clear whether no issues were found.

## Output Format

Return the review in Markdown with short sections and direct language.
