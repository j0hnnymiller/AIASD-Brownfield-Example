# Implementation Plan: Risk-and-Effort Prioritized

## Scope

This plan covers all currently open GitHub issues and sequences implementation by combined risk and effort.

## Priority Buckets

- P0: #3, #15
- P1: #1, #4, #13, #20
- P2: #2, #6, #10, #11, #12, #16, #17, #18
- P3: #7, #8, #9, #19

## Execution Principles

1. Fix security-critical items first.
2. Resolve runtime correctness issues before architecture refactors.
3. Bundle related changes to reduce regression risk.
4. Keep umbrella/tracking items (for example #9) out of active implementation unless they carry direct code work.
5. Handle duplicate scope before starting implementation work.

## Phase 0: Immediate Security Stabilization (P0)

### Objectives

- Eliminate active security exposure.

### Work Items

1. #3 JWT Secret Stored in Source-Controlled Settings
2. #15 Security: PostController mutation endpoints lack Authorize attribute

### Deliverables

- Secrets moved to secure configuration source.
- Post mutation endpoints protected with authorization.
- Verification for unauthenticated 401 and authenticated success paths.

### Exit Criteria

- Both issues closed.
- Security checks pass in CI.

## Phase 1: Runtime Correctness and Operational Reliability (P1)

### Objectives

- Remove immediate runtime/auth instability and persistence mismatch risk.

### Work Items

1. #1 JWT Configuration Key Mismatch
2. #13 Async correctness: Make UserController actions await service calls
3. #20 UserService builds JWT claims from nullable IdentityUser properties
4. #4 In-Memory Database Is Hardwired as Default

### Recommended Order

1. #1 and #20 together (auth correctness bundle)
2. #13 (controller correctness)
3. #4 (environment/provider behavior)

### Deliverables

- Auth config and claim generation are null-safe and consistent.
- Controller actions correctly await async service calls.
- Database provider strategy supports durable non-development environments.

### Exit Criteria

- Login/register flow validated end-to-end.
- No runtime task serialization issues.
- Environment-based DB behavior validated.

## Phase 2: Maintainability and Design Hardening (P2)

### Objectives

- Reduce technical debt and strengthen long-term maintainability.

### Work Items

1. #2 Legacy BCrypt package cleanup
2. #6 Edit Post DTO validation alignment
3. #16 and #17 DateTime.UtcNow migration (duplicate scope)
4. #18 Nullable reference type cleanup
5. #10 + #11 + #12 SOLID refactor set

### Recommended Order

1. #16 and #17: treat as one workstream, close one as duplicate after verification
2. #18 nullable cleanup
3. #2 dependency cleanup
4. #6 DTO validation consistency
5. #10 + #11 + #12 as one refactor epic

### Deliverables

- UTC timestamp consistency.
- Nullability warnings reduced and contracts clarified.
- Legacy dependency removed.
- Centralized exception handling and cleaner SOLID boundaries.

### Exit Criteria

- Build warning count reduced materially.
- Refactor work has regression tests for auth and API behavior.

## Phase 3: Low-Risk Polish and Developer Experience (P3)

### Objectives

- Finalize non-critical cleanup and operational quality-of-life improvements.

### Work Items

1. #7 Typo in public API method name
2. #8 README placeholder clone URL
3. #19 Swagger UI JWT authorize support
4. #9 SOLID umbrella issue closure once child issues are complete

### Deliverables

- Improved docs and naming quality.
- Swagger UI supports JWT auth for manual testing.
- Umbrella issue is closed with links to completed child work.

### Exit Criteria

- All P3 issues closed.
- #9 closed after #10/#11/#12/#13 completion confirmation.

## Suggested Milestone Breakdown

- Milestone A (Security and correctness): #3, #15, #1, #13, #20
- Milestone B (Durability and code health): #4, #16/#17, #18, #2, #6
- Milestone C (Architecture and polish): #10, #11, #12, #7, #8, #19, #9

## Suggested Parallelization

- Stream 1 (Security/Auth): #3, #15, #1, #20
- Stream 2 (Controller/API correctness): #13, #6, #12
- Stream 3 (Model/Data quality): #4, #16/#17, #18
- Stream 4 (Architecture/cleanup): #2, #10, #11, #7, #8, #19

## Review Cadence

- End of each phase: run build, smoke test auth endpoints, smoke test post/comment CRUD.
- End of milestone: update issue links, close completed issues, and adjust remaining priorities if new risk appears.
