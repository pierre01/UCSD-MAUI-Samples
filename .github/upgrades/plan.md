# Upgrade Plan: Samples.sln → .NET 10.0 (Preview)

## 1. Executive Summary

- Scenario: Upgrade the MAUI samples solution `Samples.sln` from .NET 9 to .NET 10.0 (Preview). The upgrade will multi-target where appropriate (retain existing net9.0 targets and add `net10.0-windows` for projects that require Windows support).
- Scope: 18 MAUI sample projects under the solution (see Project list in §Detailed Dependency Analysis). All projects were analyzed; none were flagged as non-SDK. Many projects require a package update and a TargetFramework addition.
- Target State: All projects target their `Proposed Target Framework` from assessment (add `net10.0-windows` where recommended) and update NuGet packages per assessment (notably `Microsoft.Extensions.Logging.Debug` → `10.0.0`). CI and `global.json` will be updated to reference the required .NET 10 SDK (preview).
- Selected Strategy: Bottom-Up (dependency-first). Rationale: solution contains many independent sample projects and must preserve stability; bottom-up minimizes risk by upgrading leaf projects first to provide a stable foundation for any dependants.
- Complexity Assessment: Medium — many projects but each is small sample app; risk comes from updating to a preview SDK and package alignment across many projects.
- Critical Issues: .NET 10 is Preview (SDK required); `Microsoft.Extensions.Logging.Debug` must be updated to 10.0.0 across many projects; projects must add `net10.0-windows` multi-target to ensure Windows builds on .NET 10.
- Recommended Approach: Incremental Bottom-Up upgrade, batching all leaf projects into Phase 1 (assessment shows no internal project references), then tests and CI updates as final phases.

---

## 2. Migration Strategy

### 2.1 Approach Selection
- Chosen Strategy: Bottom-Up
- Strategy Rationale: Analysis shows the solution contains many self-contained MAUI sample projects. Bottom-Up reduces risk and isolates issues to the projects that change first. It also aligns with the existing upgrade workflow and staging in `tasks.md`.
- Strategy-Specific Considerations: Multi-project tiering, batch package updates per tier, run tier-scoped builds and tests before progressing.

### 2.2 Dependency-Based Ordering
- Ordering rule followed: leaf projects (no internal project references) first, then any projects that depend on them. Assessment and topological ordering indicate the projects are independent sample projects; therefore they are all Tier 1 (leaf) candidates.
- Critical paths: None across internal projects (no circular dependencies reported in assessment). External NuGet packages (Tier 0) must be updated in concert with tier changes.

### 2.3 Parallel vs Sequential Execution
- Since Tier 1 contains multiple independent projects, they can be upgraded in parallel by the team. However package updates and CI/global.json changes should be coordinated.
- Testing and stabilization are done per-tier; after Tier 1 completes, run cross-project integration checks and tests before finalizing CI and PR.

---

## 3. Detailed Dependency Analysis

### 3.1 Dependency Graph Summary
Topology (leaf-to-root order returned by analysis):
- D:\Dev\MAUI\UCSD\Samples\MauiBiometrics\MauiBiometrics.csproj
- D:\Dev\MAUI\UCSD\Samples\MAUICommunications\MAUICommunications.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiCamera\MauiCamera.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiLocalization\MauiLocalization.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiAnimations\MauiAnimations.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiMedia\MauiMedia.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiDeviceOutput\MauiDeviceOutput.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiGeoLocation\MauiGeoLocation.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiNavigation\MauiNavigation.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiSensors\MauiSensors.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiDevices\MauiDevices.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiStorage\MauiStorage.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiMvvm\MauiMvvm.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiLayouts\MauiLayouts.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiGraphics\MauiGraphics.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiDataBinding\MauiDataBinding.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiCollections\MauiCollections.csproj
- D:\Dev\MAUI\UCSD\Samples\MauiControls\MauiControls.csproj

All projects were treated as Tier 1 (leaf) because the analysis did not report internal project references between sample projects.

### 3.2 Project Groupings
- Phase 0 (Preparation): SDK validation, global.json review, CI dry-run
- Phase 1 (Foundation / Leaf projects): All sample projects listed above
- Phase 2 (Tests & Integration): Unit and integration tests discovered in assessment (run after Phase 1)
- Phase 3 (Finalize): CI updates, docs, commit and PR

---

## 4. Project-by-Project Migration Plans

Notes: Each project in Phase 1 follows the same batched migration flow: Preparation → Update TargetFramework → Update packages → Build → Apply deterministic code fixes → Run unit tests (if present) → Stabilize.

Tier Metadata (Phase 1)
- Tier number and name: Tier 1 — Leaf sample projects
- Projects included: (list below)
- Dependencies on previous tiers: Tier 0 (NuGet packages)
- Estimated complexity: Low–Medium per project (samples with small LOC)

Tier 1 Projects (each follow the same steps):

- `MauiBiometrics` (D:\Dev\MAUI\UCSD\Samples\MauiBiometrics\MauiBiometrics.csproj)
  - Current Targets: net9.0-android;net9.0-ios;net9.0-maccatalyst;net9.0-windows10.0.19041.0
  - Proposed: add `net10.0-windows` (multi-target), retain existing net9.0 targets
  - Packages to update (per assessment): `Microsoft.Extensions.Logging.Debug` 9.0.9 → 10.0.0
  - Migration steps: see general steps below

- `MAUICommunications` (D:\Dev\MAUI\UCSD\Samples\MAUICommunications\MAUICommunications.csproj)
  - Current Targets: (same pattern)
  - Proposed: add `net10.0-windows`
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.5 → 10.0.0

- `MauiCamera` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.5 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiLocalization` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.0 & 9.0.5 → 10.0.0 (multiple references)
  - Proposed: add `net10.0-windows`

- `MauiAnimations` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.9 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiMedia` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.5 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiDeviceOutput` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.5 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiGeoLocation` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.5 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiNavigation` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.5 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiSensors` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.9 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiDevices` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.5 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiStorage` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.9 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiMvvm` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.9 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiLayouts` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.5 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiGraphics` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.9 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiDataBinding` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.5 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiCollections` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.5 → 10.0.0
  - Proposed: add `net10.0-windows`

- `MauiControls` …
  - Packages: `Microsoft.Extensions.Logging.Debug` 9.0.9 → 10.0.0
  - Proposed: add `net10.0-windows`


General Migration Steps (applies to each project in Phase 1):
1. Preparation
   - Ensure working branch is `upgrade-to-NET10` (create from `development` and push a backup branch if needed).  NOTE: Planner will not perform the switch; executor must ensure branch is created before changes.
   - Ensure .NET 10 (Preview) SDK is installed and `global.json` updated if pinning is used (Plan §Preparation).

2. Update project files
   - Open `*.csproj` and add `net10.0-windows` to `TargetFrameworks` (multi-target) preserving existing net9.0 entries. Example: `<TargetFrameworks>net9.0-android;net9.0-ios;net9.0-maccatalyst;net9.0-windows10.0.19041.0;net10.0-windows</TargetFrameworks>`

3. Package updates (batched per tier)
   - Update `Microsoft.Extensions.Logging.Debug` to `10.0.0` for all projects that reference it (see §5 Package Update Reference).
   - Restore packages and run `dotnet restore` for solution.

4. Build
   - Perform `dotnet build -c Release` for each targeted runtime (Windows target is critical to validate the new net10.0 target). Address compile-time errors.

5. Deterministic code fixes
   - Apply only deterministic, automated fixes suggested by analysis (API replacements, obsolete APIs). Document any manual fixes required.

6. Tests
   - Run unit/integration tests associated with these projects (Phase 2) and fix regressions.

7. Stabilize
   - Fix remaining warnings or build issues, record lessons learned.

Validation checklist (per project)
- [ ] `TargetFrameworks` updated
- [ ] All package references updated per Tier 1 package updates
- [ ] `dotnet restore` succeeds
- [ ] Project builds for `net9.0` and `net10.0-windows` where applicable
- [ ] Unit tests pass (if present)
- [ ] No new security vulnerabilities introduced

---

## 5. Package Update Reference

Tier 1 Package Updates (applies to all Phase 1 projects above)
- `Microsoft.Extensions.Logging.Debug`: versions found in assessment → `10.0.0`
  - `MauiBiometrics`: 9.0.9 → 10.0.0
  - `MAUICommunications`: 9.0.5 → 10.0.0
  - `MauiCamera`: 9.0.5 → 10.0.0
  - `MauiLocalization`: 9.0.0 / 9.0.5 → 10.0.0
  - `MauiAnimations`: 9.0.9 → 10.0.0
  - `MauiMedia`: 9.0.5 → 10.0.0
  - `MauiDeviceOutput`: 9.0.5 → 10.0.0
  - `MauiGeoLocation`: 9.0.5 → 10.0.0
  - `MauiNavigation`: 9.0.5 → 10.0.0
  - `MauiSensors`: 9.0.9 → 10.0.0
  - `MauiDevices`: 9.0.5 → 10.0.0
  - `MauiStorage`: 9.0.9 → 10.0.0
  - `MauiMvvm`: 9.0.9 → 10.0.0
  - `MauiLayouts`: 9.0.5 → 10.0.0
  - `MauiGraphics`: 9.0.9 → 10.0.0
  - `MauiDataBinding`: 9.0.5 → 10.0.0
  - `MauiCollections`: 9.0.5 → 10.0.0
  - `MauiControls`: 9.0.9 → 10.0.0

Reason: assessment recommended replacing older `Microsoft.Extensions.Logging.Debug` references with the 10.0.0 package to be compatible with the .NET 10 preview runtime.

---

## 6. Breaking Changes Catalog (Expected)
- `Microsoft.Extensions.*` packages may introduce API surface changes in major versions. Expect to address any obsolete or renamed APIs at compile-time. Anticipate minor code adjustments around logging factory creation and provider registration.
- Adding `net10.0-windows` multi-target may expose Windows-specific API availability changes. Validate any Windows-specific code paths (app shell, handlers) when building for `net10.0-windows`.
- .NET 10 is Preview: toolchain and package behavior may change; CI and developers must use Preview SDK version pinned in `global.json`.

Notes: Specific breaking changes will be discovered during compilation. Document and triage them per project.

---

## 7. Testing and Validation Strategy

### 7.1 Phase-by-Phase Testing
- Phase 1: Per-project build for `net9.0` and `net10.0-windows`, run unit tests attached to those projects. Integration smoke tests across projects that share runtime behaviors.
- Phase 2: Run pooled test suite (all unit/integration tests). Fix regressions.
- Phase 3: CI pipeline run (dry-run then full run) to validate builds and publish steps.

### 7.2 Smoke Tests (after each project or batch)
- Build succeeds for all target TFMs
- Application boots on Windows target (headless verification: launch and exit)
- No failing unit tests

### 7.3 Comprehensive Validation
- All automated tests pass
- CI runs successfully on .NET 10 preview images
- Manual runtime validation checklist (device/emulator) included in PR for maintainers

---

## 8. Timeline and Effort Estimates

Assumptions: one experienced developer per project; deterministic automated fixes available for majority of errors.

| Phase | Scope | Estimated Time |
|---|---:|---:|
| Phase 0 | SDK & CI prep, global.json | 2-4 hours |
| Phase 1 | 18 projects (parallelizable) — per project: update TFMs, package update, build, fixes | 2–4 hours each; with parallel work 2–3 days total |
| Phase 2 | Tests and regression fixes | 1–2 days |
| Phase 3 | CI and docs, finalize PR | 4–8 hours |
| Total | End-to-end | 4–7 working days (with 1–2 engineers) |

Include contingency buffer for preview SDK quirks.

---

## 9. Source Control Strategy

- Upgrade branch: `upgrade-to-NET10` (create from `development`).
- Branching: one branch for entire upgrade; consider feature sub-branches for large fixes if needed.
- Commit strategy: batch commits per phase with clear messages. Example commit message: "upgrade: add net10.0-windows target; update Microsoft.Extensions.Logging.Debug → 10.0.0 (Phase 1)".
- Rollback: If severe issues found, revert `upgrade-to-NET10` branch to `development` and open an incident PR.

---

## 10. Risk Management

High-risk items:
- Using .NET 10 Preview (SDK/tooling instability) — Mitigation: pin SDK in `global.json`, run CI on preview images, keep backups and feature branches.
- Package major-version upgrades — Mitigation: run automated tests, stagger package updates, and document changes.

Contingency plans:
- If compilation fails with large unknown breakages, revert branch and pause; escalate to maintainers.
- If package compatibility is worse than expected, consider stepping back to .NET 9 for that project and flagging it for later attention.

---

## 11. Success Criteria

- All projects updated to include `net10.0-windows` where recommended and still compile for existing net9.0 targets.
- All package updates from assessment applied.
- All unit and integration tests pass (or failures triaged and accepted with mitigation).
- CI runs succeed on pinned .NET 10 SDK image.
- PR created with verification steps and manual runtime validation checklist.

---

## 12. Next Immediate Actions (for executor)
1. Ensure working directory is clean (no pending changes).
2. Create and switch to branch `upgrade-to-NET10` from `development`.
3. Update `global.json` (if present) to pin required .NET 10 Preview SDK (use the SDK version recommended/installed).
4. Batch-update `Microsoft.Extensions.Logging.Debug` to `10.0.0` in all Phase 1 projects.
5. Add `net10.0-windows` to `TargetFrameworks` in each project file that assessment recommended.
6. Run `dotnet restore`, `dotnet build`, and follow the Validation checklist per project.
7. Run tests and fix deterministic regressions.
8. Update CI to use .NET 10 preview images and run a full CI validation.
9. Commit changes and open PR with verification notes and manual runtime validation checklist.

---

Appendix: Assessment references stored in `.github/upgrades/assessment.md`. If additional package details or compatibility notes are required, consult the assessment file used to build this plan.
