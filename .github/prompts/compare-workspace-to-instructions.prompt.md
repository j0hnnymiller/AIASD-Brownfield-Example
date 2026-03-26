---
name: compare-workspace-to-instructions
description: Compare the current repository implementation against the instruction files and report significant differences between the codebase and the documented rules.
temperature: 0.2
arguments:
  folder:
    type: string
    description: Optional repository-relative folder to focus the comparison on
tags: ["review", "promptfile", "instructions", "compliance", "analysis"]
ai_generated: true
model: "openai/gpt-5.4@unknown"
operator: "johnmillerATcodemag-com"
chat_id: "add-folder-parameter-to-compare-workspace-prompt-20260324"
prompt: |
  add a parameter to the prompt that focuses the comparison on a specific folder
started: "2026-03-24T12:14:38.4848302-07:00"
ended: "2026-03-24T12:14:38.4848302-07:00"
task_durations:
  - task: "prompt enhancement"
    duration: "00:04:00"
  - task: "traceability updates"
    duration: "00:02:00"
total_duration: "00:06:00"
ai_log: "ai-logs/2026/03/24/add-folder-parameter-to-compare-workspace-prompt-20260324/conversation.md"
source: "github-copilot-chat"
owner: "Development Team"
version: "1.1.0"
prompt_metadata:
  id: compare-workspace-to-instructions
  title: Compare Workspace To Instructions
  owner: johnmillerATcodemag-com
  version: 1.1.0
  output_path: .github/prompts/compare-workspace-to-instructions.prompt.md
  category: review
  output_format: markdown
---

# Compare Workspace To Instructions

## Context

Inspect the current repository and compare the implementation with the instruction files that apply to this workspace.

If `{{folder}}` is provided, focus the comparison on that repository-relative folder. In that mode, inspect only files inside the requested folder plus any directly related shared files, project files, or instruction files needed to evaluate that folder accurately. If `{{folder}}` is empty or omitted, compare the whole repository.

Read the real code and project files before reporting differences. Prioritize repository-wide instructions, technology-specific instruction files, prompt-file instructions, project files, application files, and supporting AI log artifacts when they are relevant to the documented rules.

Treat the instruction files as the expected behavior baseline, but do not assume the instructions themselves are correct. If an instruction file is malformed, contradictory, stale, or references missing artifacts, report that as a finding too.

**CRITICAL**: This is a review task. Do not change files. Report significant differences between the implementation and the instructions as they exist in the repository.

## Objective

Identify material mismatches between:

- the current implementation
- the documented instruction files
- the expected repository workflows implied by those instructions

When `{{folder}}` is provided, treat that folder as the primary comparison target and keep findings centered on that scope.

## Comparison Scope

When a folder is specified, evaluate these areas within that folder and any directly related shared artifacts.

Evaluate at least these areas when present:

1. Project and build workflow consistency
2. Source code alignment with language and framework instructions
3. UI and event wiring alignment with WPF and XAML instructions
4. Promptfile and instruction-file metadata compliance
5. AI provenance, ai-log, and README traceability requirements
6. Internal consistency across the instruction files themselves

## Workflow

1. Inspect the repository structure and determine whether the effective scope is `{{folder}}` or the full repository.
2. Read the relevant instruction files for the repository and technologies in use.
3. Compare the actual implementation and artifacts in scope against those instructions.
4. Report only significant differences, contradictions, or missing required elements.
5. Prefer concrete findings with file references over generic commentary.
6. If the implementation is aligned in an area, do not invent findings for it.

## Findings Requirements

For each finding, provide:

- severity: `high`, `medium`, or `low`
- file reference with line number
- the specific implementation or instruction difference
- why the difference matters
- whether the problem is in the implementation, the instructions, or both
- a pragmatic remediation direction

Do not report weak style-only observations unless they create a real maintenance, correctness, or compliance risk.

## Deliverable

Return a concise Markdown report with this structure:

If `{{folder}}` is provided, state the scoped folder near the top of the report.

### Findings

- `<severity>`: `<short title>`
  - File: `<path>:<line>`
  - Difference: `<implementation vs instruction mismatch>`
  - Impact: `<why it matters>`
  - Source Of Drift: `<implementation|instruction|both>`
  - Recommendation: `<pragmatic fix direction>`

### Open Questions or Assumptions

- `<question or assumption>`

### Residual Risks

- `<remaining uncertainty, testing gap, or validation gap>`

If no significant differences are found, return:

- `No significant instruction-to-implementation differences found.`
- `Residual risks:` followed by any remaining gaps.

## Quality Bar

- Focus on meaningful mismatches, not formatting trivia.
- Prefer a small number of defensible findings over a long list of weak ones.
- Distinguish clearly between broken implementation and broken instructions.
- Use the repository's current size and technology stack to judge proportionality.

## Validation Checklist

- [ ] The repository was inspected before conclusions were drawn.
- [ ] Relevant instruction files were read before comparison.
- [ ] Findings identify a concrete mismatch, not a generic suggestion.
- [ ] Each finding cites a specific file location.
- [ ] The report states whether the drift is in implementation, instructions, or both.

## Output Format

Return the review in Markdown with short sections and direct language.
