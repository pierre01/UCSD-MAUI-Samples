# Upgrade Plan: MAUI Samples repository

## Goal
Bring the solution to a verified, maintainable .NET 9 MAUI state and produce a reproducible upgrade plan for any further modernization (Azure, packaging, CI, platform-specific fixes).

## Current state summary
- Repository: UCSD-MAUI-Samples
- Solution: `Samples.sln`
- MAUI projects target `.NET 9` (net9.0-android; net9.0-ios; net9.0-maccatalyst; windows on Windows hosts)
- Example project: `MauiControls` (already SDK-style)

## Risks / Constraints
- Platform-specific code (Android/iOS/Windows) may require per-platform fixes.
- CI and global.json SDK pinning may block builds if not aligned with local SDKs.

## Plan — High level tasks
1. Discovery
   - Run full solution analysis to enumerate issues and API incompatibilities.
   - Identify test projects.
2. Preparation
   - Validate .NET SDK installation and `global.json` compatibility for net9.0.
   - Create a new git branch for the upgrade work.
3. Conversion & updates
   - Convert any non-SDK-style projects (if found) to SDK-style.
   - Update NuGet packages to versions compatible with net9.0 (Microsoft.Maui.* packages already present at 9.x).
4. Code fixes
   - Apply automated fixes suggested by analysis (API replacements, obsolete APIs).
   - Manually address platform-specific issues (Android manifest, iOS entitlements, Windows min version).
5. Build & test
   - Build projects in topological order.
   - Run unit and integration tests; fix failing tests.
6. Validation
   - Validate sample runtime on representative platforms (Android emulator, iOS simulator on macOS, Windows where available).
   - Update README and CI accordingly.
7. Finalize
   - Commit changes, create PR with summary and instructions for reviewers.

## Next immediate action (recommended)
- Run automated analysis for the whole solution to produce detailed tasks and actionable items.

