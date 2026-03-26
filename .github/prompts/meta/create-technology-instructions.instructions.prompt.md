---
name: create-technology-instructions
description: Create or update instruction files for the technologies actually used in this repository by inspecting the current project stack and writing matching .instructions.md files.
tags: ["instructions", "promptfile", "meta", "dotnet", "wpf"]
ai_generated: true
model: "openai/gpt-5.4@unknown"
operator: "johnmillerATcodemag-com"
chat_id: "create-technology-instructions-prompt-20260323"
prompt: |
  create a prompt file that creates instruction files for the technologies used in this project
started: "2026-03-23T12:54:52.2171424-07:00"
ended: "2026-03-23T12:55:04.7592410-07:00"
task_durations:
  - task: "prompt design"
    duration: "00:00:07"
  - task: "prompt authoring"
    duration: "00:00:08"
  - task: "traceability updates"
    duration: "00:00:05"
total_duration: "00:00:20"
ai_log: "ai-logs/2026/03/23/create-technology-instructions-prompt-20260323/conversation.md"
source: "github-copilot-chat"
owner: "Development Team"
version: "1.0.0"
prompt_metadata:
  id: create-technology-instructions
  title: Create Technology Instruction Files
  owner: johnmillerATcodemag-com
  version: 1.0.0
  output_path: .github/instructions/
  category: documentation
  output_format: markdown
---

# Create Technology Instruction Files

## Context

Inspect the current repository and create or update instruction files for the technologies that are actually in use.

Read the existing project files first so the instruction set matches the real stack rather than a generic template. Prioritize files such as the solution file, project file, README, app startup files, and any existing instruction files.

**CRITICAL**: All AI-generated artifacts MUST comply with `.github/instructions/ai-assisted-output.instructions.md`. Every generated instruction file MUST include full AI provenance metadata. If the output is a new AI-assisted artifact, also create the required chat log files under `ai-logs/` and add a README entry that links to the artifact and its conversation log.

## Objective

Produce a technology-specific instruction set that helps future edits stay aligned with the actual implementation choices in this repository.

## Workflow

1. Inspect the repository to identify the active technologies from source files and project metadata.
2. Build a minimal technology list based on what is actually present.
3. For each active technology, create or update one focused `.instructions.md` file in `.github/instructions/`.
4. Reuse existing instruction files when they already exist instead of creating duplicates.
5. Keep each instruction narrow, concrete, and repo-specific.
6. Create the matching `conversation.md` and `summary.md` files under `ai-logs/yyyy/mm/dd/<chat-id>/`.
7. Update `README.md` so the new instruction artifacts are discoverable.

## Technology Detection Rules

- Use the project file and solution file to determine the runtime and build stack.
- Use source file extensions and framework-specific declarations to determine language and UI technologies.
- Do not create instruction files for technologies that are not present.
- Do not create speculative files for testing, packaging, deployment, CI, or databases unless the repo actually contains them.

## Expected Output for This Repository

If the repository still matches the current calculator app, the expected technology instruction files are:

- `.github/instructions/dotnet.instructions.md`
- `.github/instructions/csharp.instructions.md`
- `.github/instructions/wpf.instructions.md`
- `.github/instructions/xaml.instructions.md`

If the stack changes later, adjust the output list to match the new reality.

## Deliverable

Generate or update the instruction files in `.github/instructions/` using this structure.

### Required AI Provenance Metadata (YAML Front Matter)

```yaml
ai_generated: true
model: "<provider>/<model-name>@<version>"
operator: "<operator-username>"
chat_id: "<chat-identifier>"
prompt: |
  <exact-prompt-text>
started: "<ISO8601-timestamp>"
ended: "<ISO8601-timestamp>"
task_durations:
  - task: "<task-name>"
    duration: "<hh:mm:ss>"
total_duration: "<hh:mm:ss>"
ai_log: "ai-logs/<yyyy>/<mm>/<dd>/<chat-id>/conversation.md"
source: "<creator-identifier>"
name: "<instruction-name>"
description: "<short purpose>"
applyTo: "<glob pattern>"
version: "1.0.0"
author: "<author>"
tags: ["<tag1>", "<tag2>"]
owner: "<owner>"
reviewedDate: "<yyyy-mm-dd>"
nextReview: "<yyyy-mm-dd>"
```

### Content Requirements

Each generated instruction file must:

- define the technology scope clearly in the title and overview
- include concise rules that reflect how that technology is used in this repo
- avoid boilerplate enterprise guidance that does not apply to the project
- include a validation checklist
- include a short summary and related instruction links

### Additional Required Outputs

- `ai-logs/yyyy/mm/dd/<chat-id>/conversation.md`
- `ai-logs/yyyy/mm/dd/<chat-id>/summary.md`
- `README.md` update with artifact and log links

## Quality Bar

- Prefer fewer, stronger instruction files over many overlapping ones.
- Map `applyTo` patterns to real file types in the repository.
- Keep wording imperative and reviewable.
- Preserve existing instruction files if they already satisfy the need.

## Validation Checklist

- [ ] The technology list came from actual repository files.
- [ ] No duplicate or speculative instruction files were created.
- [ ] Each instruction file has complete provenance metadata.
- [ ] `applyTo` patterns match real files in the repository.
- [ ] `conversation.md` and `summary.md` were created for the work burst.
- [ ] `README.md` was updated with artifact links.

## Output Format

Return a concise summary of:

- technologies detected
- instruction files created or updated
- ai-log path used
- README changes made
