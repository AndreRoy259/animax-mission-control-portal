# Implementation Plan: Animax Mission Control Portal MVP

**Branch**: `001-mission-control-mvp` | **Date**: 2026-04-25 | **Spec**: [spec.md](spec.md)
**Input**: Feature specification from `specs/001-mission-control-mvp/spec.md`

**Note**: This file is the `/speckit-plan` output for Phase 0 and Phase 1 planning. It stops before task generation and implementation.

## Summary

Build a local-first Blazor MVP for a fictive Animax mission command portal. The implementation will keep the existing app in `src/AnimaxMissionControlPortal`, add a simple Domain/Data/Services/Components/Pages/Styles/Assets separation, persist synthetic demo data in SQLite through EF Core, and use reusable Razor components plus Tailwind CSS/design tokens for a dark cyberpunk command-center UI. The MVP covers Dashboard, Mission List, Create Mission, Mission Detail, and Division Directory, with a Demo Persona Switcher that influences demo context only and never implements real authentication or RBAC.

## Technical Context

**Language/Version**: C# / .NET 10 (`net10.0` in `src/AnimaxMissionControlPortal/AnimaxMissionControlPortal.csproj`)  
**Primary Dependencies**: Blazor, EF Core, EF Core SQLite provider, EF Core tooling/design package, Tailwind CLI, reusable Razor components  
**Storage**: Local SQLite database with persistent synthetic demo seed data; last saved local change wins  
**Testing**: `dotnet test` with targeted service, domain, seed data, validation, and dashboard-count coverage  
**Target Platform**: Local developer machine, VS Code + WSL friendly  
**Project Type**: Blazor web application, local-first mono-user demo app  
**Performance Goals**: Responsive local demo journey under 5 minutes; no enterprise scale target  
**Constraints**: No real auth, no real RBAC, no external APIs, no SignalR/realtime, no advanced search, no attachments, no production-ready claims, no heavy UI framework  
**Scale/Scope**: 5 MVP routes, 7 divisions, 12 missions, 10 updates, 8 risks/blockers, complete coverage of statuses, priorities, classifications, and alert levels

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

- MVP demo path covers centralizing, prioritizing, and tracking inter-division missions: PASS. Planned routes support Dashboard -> Mission List -> Create Mission -> Mission Detail -> Add Update / Add Blocker -> Dashboard Refresh.
- Implementation remains local-first with SQLite and synthetic seed data: PASS. EF Core + SQLite is local only; seed data is explicitly fictive.
- No real auth, RBAC, tenant integration, external API, real notifications, or cloud dependency is introduced: PASS. DemoPersona is UI/demo state only.
- Structure keeps Domain, Data, Services, Components, Pages, Styles, Assets, and Tests clearly separated: PASS. The source structure below preserves that separation inside the existing Blazor app plus a test project.
- Validation and tests are targeted to the current MVP behavior: PASS. Planned validation is limited to required fields, trimmed titles, readable errors, and seed/service/dashboard rules.
- README impact is identified for build, run, test, structure, and demo-safe notes: PASS. README update is explicitly included in the implementation order.

No constitution violations are planned.

## Project Structure

### Documentation (this feature)

```text
specs/001-mission-control-mvp/
├── plan.md
├── research.md
├── data-model.md
├── quickstart.md
├── contracts/
│   └── ui-contract.md
└── tasks.md              # Created later by /speckit-tasks, not by this plan
```

### Source Code (repository root)

```text
src/
└── AnimaxMissionControlPortal/
    ├── Domain/
    │   ├── Enums/
    │   └── Entities/
    ├── Data/
    │   ├── AnimaxDbContext.cs
    │   ├── Configurations/
    │   ├── Seed/
    │   └── Migrations/
    ├── Services/
    │   ├── MissionService.cs
    │   ├── DivisionService.cs
    │   ├── DashboardService.cs
    │   ├── DemoPersonaService.cs
    │   └── SeedService.cs
    ├── Components/
    │   ├── Shared/
    │   │   ├── MissionCard.razor
    │   │   ├── MetricCard.razor
    │   │   ├── StatusBadge.razor
    │   │   ├── PriorityBadge.razor
    │   │   ├── ClassificationBadge.razor
    │   │   ├── AlertBadge.razor
    │   │   ├── TimelineItem.razor
    │   │   ├── RiskBlockerPanel.razor
    │   │   ├── DivisionPill.razor
    │   │   └── PersonaSwitcher.razor
    │   ├── Layout/
    │   └── Pages/
    │       ├── Dashboard.razor
    │       ├── Missions.razor
    │       ├── CreateMission.razor
    │       ├── MissionDetail.razor
    │       └── DivisionDirectory.razor
    ├── Styles/
    │   ├── tokens.css
    │   └── tailwind.css
    ├── Assets/
    │   └── README.md
    ├── wwwroot/
    ├── Program.cs
    └── AnimaxMissionControlPortal.csproj

tests/
└── AnimaxMissionControlPortal.Tests/
    ├── Domain/
    ├── Services/
    ├── Data/
    └── Components/
```

**Structure Decision**: Use the existing Blazor app at `src/AnimaxMissionControlPortal` as the application boundary. Keep domain entities/enums in `Domain`, EF Core persistence and seed logic in `Data`, application-facing operations in `Services`, reusable Razor UI in `Components/Shared`, route pages in `Components/Pages`, CSS/design tokens in `Styles`, future non-critical visual files in `Assets`, and targeted tests in `tests/AnimaxMissionControlPortal.Tests`.

## Route Plan

| Route | Page | Purpose |
|-------|------|---------|
| `/` or `/dashboard` | Dashboard | Global counts, critical missions, blocked missions, open risks/blockers, persona-aware demo context |
| `/missions` | Mission List | Mission portfolio with filters for status, priority, division, classification, and alert level |
| `/missions/create` | Create Mission | Required-field mission creation with readable validation errors |
| `/missions/{id:int}` | Mission Detail | Mission attributes, updates timeline, risk/blocker panel, status/priority edits, add update/blocker |
| `/divisions` | Division Directory | Lightweight reference for the 7 seeded fictive divisions |

## Component Plan

| Component | Responsibility |
|-----------|----------------|
| `MissionCard` | Reusable mission summary for dashboard and list, with critical/blocked visual emphasis |
| `MetricCard` | Dashboard metric display for totals, critical missions, blocked missions, open risks/blockers |
| `StatusBadge` | Visual mapping for Draft, Active, Blocked, Completed, Archived |
| `PriorityBadge` | Visual mapping for Low, Medium, High, Critical |
| `ClassificationBadge` | Visual mapping for Internal, Confidential, Classified, Blackfile plus non-security disclaimer context |
| `AlertBadge` | Visual mapping for Normal, Elevated, Critical |
| `TimelineItem` | Mission update timeline entry |
| `RiskBlockerPanel` | Open/resolved Risk and Blocker display and add form area |
| `DivisionPill` | Compact division code/name/color signal |
| `PersonaSwitcher` | Demo persona selector; stores local UI state only and does not enforce permissions |

## Domain and Data Plan

Enums:

- `MissionStatus`: Draft, Active, Blocked, Completed, Archived
- `Priority`: Low, Medium, High, Critical
- `ClassificationLevel`: Internal, Confidential, Classified, Blackfile
- `AlertLevel`: Normal, Elevated, Critical
- `RiskBlockerStatus`: Open, Resolved
- `RiskBlockerType`: Risk, Blocker

Entities:

- `Division`
- `Mission`
- `MissionUpdate`
- `RiskBlocker`
- `DemoPersona`

Persistence:

- Use `AnimaxDbContext` with `DbSet<Division>`, `DbSet<Mission>`, `DbSet<MissionUpdate>`, `DbSet<RiskBlocker>`, and optional persisted or in-memory `DemoPersona` records.
- Configure required fields and relationships with EF Core configuration classes or clear `OnModelCreating` mappings.
- Use SQLite database file under the app data path, for example `Data/animax-mission-control.db` or a configured local path documented in README.
- The MVP may use EF Core migrations to create/update the local SQLite database. If migrations are used, `dotnet ef database update --project src/AnimaxMissionControlPortal` assumes `dotnet-ef` is available in the WSL environment.
- `dotnet ef` is not a product requirement if implementation chooses automatic local database creation at startup, but the migrations path must stay documented and local-only.
- Apply seed data through `SeedService` or equivalent startup strategy that is idempotent and does not overwrite locally created missions.

Seed data requirements:

- 7 divisions: CCCU, FAAD, PBRL, HECH, BOACT, REMS, FMRA
- 12 missions
- 10 mission updates
- 8 risks/blockers
- Coverage of every mission status, priority, classification level, alert level, risk/blocker status, and risk/blocker type
- Synthetic names, descriptions, authors, and operational domains only

## Service Plan

| Service | Responsibility |
|---------|----------------|
| `MissionService` | CRUD-style mission operations, required-field validation, title trimming, status/priority updates, add update, add risk/blocker |
| `DivisionService` | Read seeded divisions and provide lookup values for forms/filters |
| `DashboardService` | Compute total missions, critical missions, blocked missions, open risks/blockers, and dashboard mission slices |
| `DemoPersonaService` | Track selected persona in local app state; expose current author/context labels without auth/RBAC |
| `SeedService` | Ensure idempotent synthetic seed data exists after database creation/migration |
| `AnimaxDbContext` | EF Core unit of persistence for local SQLite data |

## Validation Plan

- Mission title is required after `Trim()`.
- Division is required and must refer to a seeded division.
- Status, priority, classification, and alert level are required selections.
- Empty or whitespace-only titles are rejected with readable French messages.
- Validation messages must avoid security or production claims and remain demo-oriented.
- Create and edit flows use the same validation rules through service/domain validation to keep tests direct.

## UI and Styling Plan

- Use a simple Tailwind CLI workflow, not a heavy UI framework.
- Compile Tailwind from `src/AnimaxMissionControlPortal/Styles/tailwind.css` to a Blazor-served file such as `src/AnimaxMissionControlPortal/wwwroot/css/app.css`.
- Keep Animax design tokens in a lightweight CSS file, for example `src/AnimaxMissionControlPortal/Styles/tokens.css`.
- Tokens cover dark surfaces, text contrast, division signals, status colors, priority colors, classification colors, alert colors, focus states, and spacing.
- Do not introduce a heavy UI framework.
- Existing Bootstrap template artifacts may be removed or neutralized during shell cleanup only if they conflict with the Tailwind shell.
- Visual assets are non-critical and planned for a future wave under `Assets/`; the MVP must remain coherent without them.

## Test Plan

Targeted tests will cover:

- Required mission fields and title trimming.
- Dashboard counts for total, critical, blocked, and open risks/blockers.
- `RiskBlocker` Open vs Resolved inclusion rules.
- Seed data counts and reference coverage.
- Mission service create/update/add update/add risk-blocker behavior.
- Division service lookup behavior.
- Form validation behavior where practical with component tests or service-level validation.

Expected validation commands:

```bash
dotnet restore
dotnet build
dotnet test
dotnet ef --version         # validates dotnet-ef availability if migrations are used
dotnet ef database update --project src/AnimaxMissionControlPortal   # if migrations are used for local SQLite setup
dotnet run --project src/AnimaxMissionControlPortal
```

## Implementation Order

1. Clean and organize the existing Blazor shell.
2. Add Domain enums and entities.
3. Add EF Core + SQLite + `AnimaxDbContext`.
4. Add rich seed data.
5. Add services.
6. Add `PersonaSwitcher`.
7. Build Dashboard.
8. Build Mission List + filters.
9. Build Create Mission.
10. Build Mission Detail + updates + blockers.
11. Build Division Directory.
12. Apply Tailwind + Animax design tokens.
13. Add targeted tests.
14. Update README.
15. Prepare a future wave for visual assets.

## Complexity Tracking

No constitution violations or justified complexity exceptions.

## Phase 0 Output

Generated: [research.md](research.md)

## Phase 1 Output

Generated:

- [data-model.md](data-model.md)
- [contracts/ui-contract.md](contracts/ui-contract.md)
- [quickstart.md](quickstart.md)

## Post-Design Constitution Check

- Local-first SQLite persistence remains the only storage model: PASS.
- Demo data is synthetic and seed requirements are explicit: PASS.
- DemoPersona has no security effect and does not create auth/RBAC: PASS.
- No external API, SignalR, realtime, attachments, advanced search, multi-tenant, or production-ready requirement was added: PASS.
- Structure remains readable in VS Code + WSL: PASS.
- Tests and README updates are planned before implementation completion: PASS.
