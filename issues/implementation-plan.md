# Implementation Plan: Risk-and-Effort Prioritized

## Test Expansion Plan (April 2026)

### Goal

Close the highest-value test coverage gaps identified in controllers, services, mapping, and startup behavior.

### Current Status

- Completed: Comment controller authorization and success-path integration tests.
- In Progress: Planning remaining recommended tests.

### Priority Sequence

- T0 (Done): Comment controller integration tests (`CommentControllerAuthorizationTests`).
- T1: Post service unit tests (`PostServiceTests`).
- T2: Comment service unit tests (`CommentServiceTests`).
- T3: Post controller behavior tests (`PostControllerTests`).
- T4: User service negative-path tests (`UserServiceTests` expansion).
- T5: JWT token service guardrail tests (`JwtTokenServiceTests` expansion).
- T6: Startup/configuration behavior tests (`ProgramConfigurationTests`).
- T7: AutoMapper profile tests (`MappingProfileTests`).

### Test Work Item Files

- [issues/tests/001-post-service-tests.md](tests/001-post-service-tests.md)
- [issues/tests/002-comment-service-tests.md](tests/002-comment-service-tests.md)
- [issues/tests/003-post-controller-tests.md](tests/003-post-controller-tests.md)
- [issues/tests/004-user-service-negative-path-tests.md](tests/004-user-service-negative-path-tests.md)
- [issues/tests/005-jwt-token-service-guardrail-tests.md](tests/005-jwt-token-service-guardrail-tests.md)
- [issues/tests/006-program-configuration-tests.md](tests/006-program-configuration-tests.md)
- [issues/tests/007-mapping-profile-tests.md](tests/007-mapping-profile-tests.md)

### Work Packages

#### WP1: Services Coverage (T1, T2)

Objectives:

- Validate success and failure branches in post/comment services.
- Lock down `NotFoundException` behavior and persistence side effects.

Tasks:

1. Add `PostServiceTests` for get all/get by id/create/edit/delete.
2. Add `CommentServiceTests` for get/create/edit/delete plus post-not-found flow.
3. Use deterministic in-memory EF setup and AutoMapper profiles.

Exit Criteria:

- All service CRUD branches covered for success and not-found paths.
- New tests pass reliably in isolated and full-suite runs.

#### WP2: Controller Behavior Coverage (T3)

Objectives:

- Validate HTTP status codes beyond auth-only checks.
- Verify model-state and not-found translations to API responses.

Tasks:

1. Add `PostControllerTests` for `GetAllPosts`, `GetPostById`, `EditPost`, `DeletePost`.
2. Assert `400` for invalid model state and `404` for service not-found.
3. Keep controllers thin by stubbing service contracts.

Exit Criteria:

- Core post controller action outcomes have explicit tests.
- Regression confidence for status-code contracts is improved.

#### WP3: Auth and Startup Guardrails (T4, T5, T6)

Objectives:

- Protect auth failure paths and startup configuration behavior.

Tasks:

1. Expand `UserServiceTests` with duplicate-email, identity-failure, unknown-user, bad-password cases.
2. Expand `JwtTokenServiceTests` with null-user and missing-claim-field checks.
3. Add `ProgramConfigurationTests` for JWT config requirements and environment-specific DB provider behavior.

Exit Criteria:

- Critical authentication edge cases are covered.
- Startup fails fast with missing required JWT settings.

#### WP4: Mapping Safety Net (T7)

Objectives:

- Detect DTO/entity mapping drift quickly.

Tasks:

1. Add `MappingProfileTests` to assert AutoMapper configuration validity.
2. Add smoke mapping assertions for post and comment DTO flows.

Exit Criteria:

- Mapper configuration checks run in CI and fail on misconfiguration.

### Execution Order and Parallelization

- Sprint A: WP1 (services) + WP4 (mapping).
- Sprint B: WP2 (controllers).
- Sprint C: WP3 (auth/startup guardrails).

Parallel Streams:

- Stream 1: Service tests (WP1).
- Stream 2: Controller tests (WP2).
- Stream 3: Auth/startup and mapping tests (WP3, WP4).

### Definition of Done

1. All new test files compile and pass locally with `dotnet test`.
2. No existing tests regress.
3. New tests are deterministic and do not depend on execution order.
4. Added tests cover both happy path and failure path per targeted area.
5. Coverage trend improves in previously low-coverage files.

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
