# Upgrade Samples.sln → .NET 10.0 (Preview) — Tasks

## Overview

Upgrade the `Samples.sln` MAUI sample solution from .NET 9 → .NET 10.0 (Preview). Tasks apply the Bottom-Up (dependency-first) batching rules: prerequisites first, then a single batched Tier-1 upgrade (all leaf/sample projects), followed by testing/stabilization and CI finalization. Tasks are automatable, bounded, and reference the Plan and Assessment for details.

**Progress**: 0/5 tasks complete (0%) ![0%](https://progress-bar.xyz/0)

## Tasks

### [▶] TASK-001: Verify SDK and prepare global.json (prerequisites)
**References**: Plan §1 (Executive Summary), Plan §2.3 (Parallel vs Sequential), Plan §9 (Source Control Strategy), Assessment (see .github/upgrades/assessment.md)

- [ ] (1) Verify .NET 10 Preview SDK required by Plan is installed on the executor environment (Plan §0/Preparation).  
- [ ] (2) If the repository pins SDK via `global.json`, update or create `global.json` to pin the required .NET 10 Preview SDK version per Plan §1 and §2.3 (do not switch branches in this task).  
- [ ] (3) Run `dotnet --list-sdks` and confirm listed SDK includes the pinned preview version (**Verify**).  
- [ ] (4) If `global.json` was created or modified, commit the change with message: "TASK-001: Pin .NET 10 Preview SDK in global.json" and verify the commit exists in local history (**Verify**).

---

### [ ] TASK-002: Batch Tier 1 — Add `net10.0-windows`, update packages, restore, build & fix compilation (all leaf/sample projects)
**References**: Plan §2 (Migration Strategy — Bottom-Up), Plan §3.1 (Project list/topology), Plan §4 (Project-by-Project Migration Plans), Plan §5 (Package Update Reference), Plan §6 (Breaking Changes Catalog)

- [ ] (1) Update `TargetFrameworks` in all Tier 1 projects listed in Plan §3.1 to include `net10.0-windows` while preserving existing `net9.0` targets; follow example in Plan §4 (do not dynamically discover projects; use project list in Plan §3.1)  
- [ ] (2) Update `Microsoft.Extensions.Logging.Debug` to `10.0.0` across Tier 1 projects per Plan §5 (batch update all references as one operation).  
- [ ] (3) Run `dotnet restore` for the solution and verify all projects restore successfully (**Verify**).  
- [ ] (4) Build the solution (`dotnet build -c Release`) targeting the new TFMs (ensure build includes `net10.0-windows` where added) and capture compilation errors.  
- [ ] (5) Apply deterministic automated code fixes described in Plan §4 and Plan §6 (Breaking Changes Catalog) to address compile-time errors; make discrete changes only as specified by deterministic fixes.  
- [ ] (6) Rebuild the solution and verify it completes with 0 errors (**Verify**).  
- [ ] (7) Commit the project and package changes with message: "TASK-002: Add net10.0-windows targets; update Microsoft.Extensions.Logging.Debug → 10.0.0 (Tier 1)" and verify the commit exists (**Verify**).

---

### [ ] TASK-003: Run per-project/unit tests and stabilize (Phase 2)
**References**: Plan §7 (Testing and Validation Strategy), Plan §4 (Per-project migration steps), Assessment test listings in .github/upgrades/assessment.md

- [ ] (1) For projects that include unit or integration tests (see Plan §4 and Assessment), run tests for those projects (`dotnet test` for test projects) after TASK-002 changes.  
- [ ] (2) If tests fail, apply deterministic fixes referenced in Plan §6 (Breaking Changes Catalog) and test-specific guidance in Plan §7.1 (one targeted fix pass).  
- [ ] (3) Re-run the failing tests once after fixes and verify all tests pass with 0 failures (**Verify**).  
- [ ] (4) If tests still fail after one targeted fix and re-run, collect test logs and create an issue for maintainers with failure details and captured logs (do NOT loop indefinitely) (**Verify**: issue created with logs).  
- [ ] (5) Commit test-related fixes with message: "TASK-003: Fix test regressions after Tier 1 upgrade" (only if code changes were applied) and verify commit exists (**Verify**).

---

### [ ] TASK-004: Update CI, run pipeline validation, and bound CI remediation
**References**: Plan §1 (Target State), Plan §7.3 (Comprehensive Validation), Plan §9 (Source Control Strategy)

- [ ] (1) Update CI pipeline definitions to use the pinned .NET 10 Preview SDK images as specified in Plan §1 and Plan §9 (modify pipeline YAML/configs).  
- [ ] (2) Run a CI dry-run or pipeline validation job (as configured in repository CI). Capture CI logs and status.  
- [ ] (3) If CI fails due to configuration or environment issues, apply one targeted configuration fix per Plan §9 (example: update image tag, restore steps, or caching config) and record the change.  
- [ ] (4) Re-run the pipeline once to validate the fix and verify CI job succeeds (**Verify**).  
- [ ] (5) If CI still fails after the single remediation pass, collect CI logs and create an issue/PR for maintainers with logs and remediation attempts (do NOT retry indefinitely) (**Verify**: issue/PR exists with CI logs).  
- [ ] (6) Commit CI configuration changes with message: "TASK-004: CI update — use .NET 10 Preview image and pipeline adjustments" and verify commit exists (**Verify**).

---

### [ ] TASK-005: Finalize, verify cross-project build & create PR
**References**: Plan §7 (Validation Strategy), Plan §9 (Source Control Strategy), Plan §11 (Success Criteria)

- [ ] (1) Run a final solution-level build and the pooled test suite described in Plan §7.1 to verify cross-project integration (verify builds and tests that are automated) (**Verify**: solution builds with 0 errors; automated tests pass).  
- [ ] (2) Prepare PR content: summary of changes, verification checklist (automated build/test results), and manual runtime validation steps for maintainers (per Plan §7.3).  
- [ ] (3) Create a PR from the current branch with the prepared PR description (include links to logs and verification artifacts) and verify the PR was created (**Verify**).  
- [ ] (4) Tag or note any remaining manual runtime checks for maintainers in the PR (explicitly mark these as manual and excluded from automation).  

--- 

Generation checklist (applied):
- Strategy batching rules applied: prerequisites separated; Tier-1 projects batched together; package updates batched; compilation fixes combined with build; testing and CI separated and bounded.  
- Large lists referenced (Plan §3.1, §5); no dynamic discovery steps.  
- Non-automatable/manual runtime verification excluded from automated tasks and explicitly marked for maintainers in TASK-005.