---
ai_generated: true
model: "openai/gpt-5.3-codex@unknown"
operator: "johnmillerATcodemag-com"
chat_id: "create-evergreen-instructions-20260323"
prompt: |
  create an instruction file that contains the core principals for evergreen software development
started: "2026-03-23T01:00:00Z"
ended: "2026-03-23T01:15:00Z"
task_durations:
  - task: "requirements alignment"
    duration: "00:04:00"
  - task: "instruction authoring"
    duration: "00:08:00"
  - task: "traceability updates"
    duration: "00:03:00"
total_duration: "00:15:00"
ai_log: "ai-logs/2026/03/23/create-evergreen-instructions-20260323/conversation.md"
source: "github-copilot-chat"
name: evergreen-software-development
description: Core principles for building and maintaining evergreen software
applyTo: "**/*"
version: "1.0.0"
author: "johnmillerATcodemag-com"
tags: ["evergreen", "software-development", "architecture", "maintainability"]
owner: "Development Team"
reviewedDate: "2026-03-23"
nextReview: "2026-06-23"
---

# Evergreen Software Development Principles

## Overview

This instruction file defines core principles for building software that remains reliable, maintainable, and adaptable over time. Use these principles during planning, implementation, testing, and operational support.

## Core Principles

### 1. Design for Change

- Build small, cohesive modules with clear boundaries.
- Isolate business logic from framework, infrastructure, and UI concerns.
- Prefer explicit contracts (interfaces, schemas, API versions) at integration points.
- Avoid premature specialization that blocks future extension.

### 2. Preserve Simplicity

- Choose the simplest solution that fully satisfies current requirements.
- Minimize moving parts, dependencies, and hidden runtime behavior.
- Remove dead code, stale configuration, and obsolete feature flags promptly.
- Keep naming, folder structure, and architecture consistent.

### 3. Prioritize Readability and Intent

- Write code that explains why, not only how.
- Use clear domain language in symbols, comments, and commit messages.
- Keep functions and classes focused on one responsibility.
- Make side effects explicit and easy to trace.

### 4. Build with Defensive Quality

- Require automated tests at the right levels: unit, integration, and end-to-end.
- Protect critical paths with regression tests before refactoring.
- Enforce static analysis, linting, formatting, and CI quality gates.
- Treat reproducible builds and deterministic environments as mandatory.

### 5. Design for Operability

- Include structured logs, metrics, and tracing for critical workflows.
- Surface actionable errors with enough context to diagnose quickly.
- Define clear runbooks for deployment, rollback, and incident response.
- Prefer backward-compatible changes and controlled migrations.

### 6. Manage Dependencies Deliberately

- Prefer well-maintained, widely adopted dependencies.
- Pin versions where appropriate and review upgrades routinely.
- Remove unused packages and transitive risk where possible.
- Track security advisories and patch high-severity findings quickly.

### 7. Treat Data as a Long-Term Asset

- Model data with evolution in mind (versioning, migrations, compatibility).
- Validate inputs at boundaries and sanitize untrusted data.
- Make destructive operations explicit, reversible when possible, and audited.
- Document data ownership, retention, and lifecycle policies.

### 8. Optimize for Team Continuity

- Keep architecture decisions in lightweight ADRs.
- Document setup, development workflow, and troubleshooting steps.
- Standardize coding conventions and review expectations.
- Ensure handoffs are possible without tribal knowledge.

### 9. Use Security and Privacy by Default

- Apply least-privilege access and secure defaults everywhere.
- Keep secrets out of source and logs.
- Threat model sensitive workflows and external integrations.
- Include security checks in CI/CD, not as a late-stage activity.

### 10. Evolve Through Feedback

- Use production telemetry and user outcomes to guide improvements.
- Run retrospectives on incidents and defects; convert findings into guardrails.
- Track technical debt explicitly and pay it down in planned increments.
- Revisit architecture choices as context changes.

## Delivery Checklist

- [ ] Change is scoped to a clear objective.
- [ ] Design supports extension without major rewrites.
- [ ] Tests validate expected behavior and known edge cases.
- [ ] Logs and errors are actionable in production.
- [ ] Dependency and security implications were reviewed.
- [ ] Documentation and decision records are updated.
- [ ] Rollback or mitigation plan exists for deployment risk.

## Summary

Evergreen software is sustained by disciplined simplicity, modular design, defensive quality practices, and continuous learning. Apply these principles consistently to reduce fragility and keep the system adaptable as requirements and teams evolve.

---

**Document Version**: 1.0.0
**Last Updated**: 2026-03-23
**Maintainer**: Development Team
**Related Instructions**: [.github/instructions/instruction-files.instructions.md](.github/instructions/instruction-files.instructions.md), [.github/instructions/ai-assisted-output.instructions.md](.github/instructions/ai-assisted-output.instructions.md)
