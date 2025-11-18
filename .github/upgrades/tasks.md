# MAUI Samples .NET 9 Upgrade

## Overview

Bring the `Samples.sln` MAUI samples to a verified .NET 9 state: validate environment, run automated analysis, perform SDK-style / target and package upgrades, apply automated code fixes, run builds and automated tests, update CI/README, and finalize with commits and PR. Manual runtime UI validation (device/emulator) is excluded from automation tasks and should be performed separately by maintainers.

**Progress**: 4/6 tasks complete (67%) ![67%](https://progress-bar.xyz/67)

## Tasks

### [✓] TASK-001: Verify prerequisites (SDK and global.json compatibility) *(Completed: 2025-11-17 19:55)*
**References**: Plan §Preparation, Plan §Current state summary, .github/upgrades/assessment.md

- [✓] (1) Verify local environment has a .NET 9 SDK installed (or a compatible preview/build referenced by plan) per Plan §Preparation.
- [✓] (2) Verify `global.json` (if present) is compatible with .NET 9 requirements (report mismatches) per Plan §Preparation. (**Verify**)
- [✓] (3) Produce a short prerequisites report listing SDK version, `global.json` pinning, and any blockers to proceed (attach to assessment). (**Verify**)

### [✓] TASK-002: Run full solution analysis and enumerate automated fixes *(Completed: 2025-11-17 19:57)*
**References**: Plan §Discovery, .github/upgrades/assessment.md

- [✓] (1) Run the automated solution analysis tooling described in Plan §Discovery across `Samples.sln` to enumerate project types, non-SDK projects, API incompatibilities, and candidate automated fixes.
- [✓] (2) Produce an analysis report that lists: all projects (with project types), test projects, non-SDK projects (if any), package compatibility issues, and prioritized automated code changes (export to assessment). (**Verify**)
- [✓] (3) Record the list of test projects discovered (for TASK-004) in the analysis report. (**Verify**)

### [✓] TASK-003: Convert project files, update TargetFramework and NuGet packages, apply automated code fixes, restore *(Completed: 2025-11-17 20:03)*
**References**: Plan §Conversion & updates, Plan §Code fixes, Plan §Package updates, Plan §Breaking changes, .github/upgrades/assessment.md

- [✓] (1) Convert any non-SDK-style projects identified in Task-002 to SDK-style per Plan §Conversion & updates (apply only deterministic, reversible edits).  
- [✓] (2) Update TargetFramework(s) to `net9.0` for projects specified in Plan §Conversion & updates (reference the project list in analysis report rather than discovering).  
- [✓] (3) Update NuGet package references to the versions indicated in Plan §Package updates (batch update across projects as a single operation per strategy).  
- [✓] (4) Restore all dependencies and run an initial build to surface compilation errors.
- [✓] (5) Apply automated code fixes recommended by the analysis (API replacements, obsolete API updates) limited to changes that are deterministic and listed in Plan §Code fixes / analysis report.  
- [✓] (6) Rebuild solution; solution builds with 0 errors (**Verify**)

### [⊘] TASK-004: Run automated test suite and fix test regressions
**References**: Plan §Build & test, analysis report (Task-002)

- [⊘] (1) Run the discovered unit/integration test projects listed in the analysis report (from Task-002) per Plan §Build & test.
- [ ] (2) For any failing tests, apply deterministic code fixes (refer to Plan §Code fixes and assessment guidance) and re-run tests.  
- [ ] (3) All automated tests run and complete with 0 failures (**Verify**)

### [✓] TASK-005: Update CI configuration, `global.json` pinning (if needed), and repository docs *(Completed: 2025-11-17 20:07)*
**References**: Plan §Preparation, Plan §Finalize, Plan §Current state summary

- [✓] (1) Update CI workflow files (GitHub Actions / other CI) to use .NET 9 runner images and any MAUI build steps required per Plan §Preparation (update only files referenced in Plan).  
- [✓] (2) If `global.json` pinning requires change (as identified in Task-001), update `global.json` to the agreed SDK version per Plan §Preparation.  
- [✓] (3) Update `README` (Usage / Build instructions) with .NET 9 build hints and CI notes per Plan §Finalize.  
- [✓] (4) Validate that CI config files and `global.json` pass a dry-run (lint/syntax check) (**Verify**)

### [▶] TASK-006: Finalize changes — commit and open pull request
**References**: Plan §Finalize, Plan §Next immediate action

- [▶] (1) Commit all changes with an informative message: "Upgrade: migrate samples to .NET 9 — convert projects, update packages, apply automated fixes" (or per Plan §Finalize commit message guidance). (**Verify**)
- [▶] (2) Push commits and open a PR with the summary of changes, verification steps performed, and explicit manual runtime validation checklist for maintainers (device/emulator steps) per Plan §Finalize. (**Verify**)

Notes and exclusions:
- Manual runtime validation on emulators/devices (Android/iOS/Windows) is intentionally excluded from these tasks because it requires human interaction; include the manual checklist in the PR for reviewers as a non-automatable item.
- Do not include branch creation or switching operations in tasks (assumes correct working branch per Processing Flow).
- All large lists (projects, packages, breaking changes) are referenced from the analysis report and Plan sections; do not dynamically discover project lists during task execution.