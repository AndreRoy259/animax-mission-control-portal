# Tasks: Animax Mission Control Portal MVP

**Input**: Design documents from `/home/pajar/projects/animax-mission-control-portal/specs/001-mission-control-mvp/`
**Prerequisites**: plan.md, spec.md, research.md, data-model.md, contracts/ui-contract.md, quickstart.md
**Artifact Note**: This `tasks.md` is the generated post-plan task artifact for `001-mission-control-mvp`; `plan.md` remains the earlier planning artifact.
**Tests**: Targeted tests are included because the implementation plan requires service, domain, seed data, validation, and dashboard-count coverage.
**Organization**: Tasks are grouped by user story so each story can be implemented and tested independently after the shared foundation.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel because it touches different files and has no dependency on incomplete tasks
- **[Story]**: User story label for story phases only
- Each task includes an exact file path

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Prepare the existing Blazor app, test project, package references, and styling pipeline.

- [X] T001 Update `src/AnimaxMissionControlPortal/AnimaxMissionControlPortal.csproj` with EF Core SQLite/design/tooling package references and Tailwind-friendly static asset settings
- [X] T002 Create `tests/AnimaxMissionControlPortal.Tests/AnimaxMissionControlPortal.Tests.csproj` with xUnit, FluentAssertions, EF Core SQLite, and project reference to `src/AnimaxMissionControlPortal/AnimaxMissionControlPortal.csproj`
- [X] T003 Validate/update existing `AnimaxMissionControlPortal.slnx` to include `src/AnimaxMissionControlPortal/AnimaxMissionControlPortal.csproj` and `tests/AnimaxMissionControlPortal.Tests/AnimaxMissionControlPortal.Tests.csproj`
- [X] T004 [P] Create folder placeholders or README files for `src/AnimaxMissionControlPortal/Domain/`, `src/AnimaxMissionControlPortal/Data/`, `src/AnimaxMissionControlPortal/Services/`, `src/AnimaxMissionControlPortal/Components/Shared/`, `src/AnimaxMissionControlPortal/Styles/`, and `src/AnimaxMissionControlPortal/Assets/README.md`
- [X] T005 [P] Create Tailwind entrypoint and Animax token files in `src/AnimaxMissionControlPortal/Styles/tailwind.css` and `src/AnimaxMissionControlPortal/Styles/tokens.css`
- [X] T006 [P] Create Tailwind output directory and compiled CSS placeholder in `src/AnimaxMissionControlPortal/wwwroot/css/app.css`
- [X] T007 Remove or replace stock Blazor sample navigation entries in `src/AnimaxMissionControlPortal/Components/Layout/NavMenu.razor`

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Build shared domain, persistence, seed, app services, and layout infrastructure that all stories depend on.

**CRITICAL**: No user story work can begin until this phase is complete.

- [X] T008 [P] Create mission enum types in `src/AnimaxMissionControlPortal/Domain/Enums/MissionStatus.cs`, `src/AnimaxMissionControlPortal/Domain/Enums/Priority.cs`, `src/AnimaxMissionControlPortal/Domain/Enums/ClassificationLevel.cs`, `src/AnimaxMissionControlPortal/Domain/Enums/AlertLevel.cs`, `src/AnimaxMissionControlPortal/Domain/Enums/RiskBlockerStatus.cs`, and `src/AnimaxMissionControlPortal/Domain/Enums/RiskBlockerType.cs`
- [X] T009 [P] Create `Division` entity in `src/AnimaxMissionControlPortal/Domain/Entities/Division.cs`
- [X] T010 [P] Create `Mission` entity in `src/AnimaxMissionControlPortal/Domain/Entities/Mission.cs`
- [X] T011 [P] Create `MissionUpdate` entity in `src/AnimaxMissionControlPortal/Domain/Entities/MissionUpdate.cs`
- [X] T012 [P] Create `RiskBlocker` entity in `src/AnimaxMissionControlPortal/Domain/Entities/RiskBlocker.cs`
- [X] T013 [P] Create `DemoPersona` model in `src/AnimaxMissionControlPortal/Domain/Entities/DemoPersona.cs`
- [X] T014 Create EF Core context in `src/AnimaxMissionControlPortal/Data/AnimaxDbContext.cs`
- [X] T015 [P] Create EF Core entity configurations in `src/AnimaxMissionControlPortal/Data/Configurations/DivisionConfiguration.cs`, `src/AnimaxMissionControlPortal/Data/Configurations/MissionConfiguration.cs`, `src/AnimaxMissionControlPortal/Data/Configurations/MissionUpdateConfiguration.cs`, and `src/AnimaxMissionControlPortal/Data/Configurations/RiskBlockerConfiguration.cs`
- [X] T016 Create deterministic synthetic seed definitions in `src/AnimaxMissionControlPortal/Data/Seed/AnimaxSeedData.cs`
- [X] T017 Create idempotent seed service in `src/AnimaxMissionControlPortal/Services/SeedService.cs`
- [X] T018 [P] Create demo persona service as in-memory/scoped UI demo state by default, with no DemoPersona persistence table unless explicitly justified later, in `src/AnimaxMissionControlPortal/Services/DemoPersonaService.cs`
- [X] T019 Create division service in `src/AnimaxMissionControlPortal/Services/DivisionService.cs`
- [X] T020 Create mission validation result types in `src/AnimaxMissionControlPortal/Services/MissionValidationResult.cs`
- [X] T021 Create mission service with create, read, update status/priority, add update, add risk/blocker, and filter operations in `src/AnimaxMissionControlPortal/Services/MissionService.cs`
- [X] T022 Create dashboard service for total, critical, blocked, and open risk/blocker counts in `src/AnimaxMissionControlPortal/Services/DashboardService.cs`
- [X] T023 Configure SQLite DbContext, scoped services, database creation/migration, and idempotent seed execution in `src/AnimaxMissionControlPortal/Program.cs`
- [X] T024 [P] Create shared badge components in `src/AnimaxMissionControlPortal/Components/Shared/StatusBadge.razor`, `src/AnimaxMissionControlPortal/Components/Shared/PriorityBadge.razor`, `src/AnimaxMissionControlPortal/Components/Shared/ClassificationBadge.razor`, and `src/AnimaxMissionControlPortal/Components/Shared/AlertBadge.razor`
- [X] T025 [P] Create shared display components in `src/AnimaxMissionControlPortal/Components/Shared/MetricCard.razor`, `src/AnimaxMissionControlPortal/Components/Shared/DivisionPill.razor`, `src/AnimaxMissionControlPortal/Components/Shared/MissionCard.razor`, and `src/AnimaxMissionControlPortal/Components/Shared/TimelineItem.razor`
- [X] T026 Create persona switcher component in `src/AnimaxMissionControlPortal/Components/Shared/PersonaSwitcher.razor`
- [X] T027 Update application imports and shell references in `src/AnimaxMissionControlPortal/Components/_Imports.razor`, `src/AnimaxMissionControlPortal/Components/App.razor`, and `src/AnimaxMissionControlPortal/Components/Layout/MainLayout.razor`
- [X] T028 [P] Add seed coverage tests for required counts and enum coverage in `tests/AnimaxMissionControlPortal.Tests/Data/SeedDataTests.cs`
- [X] T029 [P] Add mission validation tests for required fields and title trimming in `tests/AnimaxMissionControlPortal.Tests/Services/MissionValidationTests.cs`
- [X] T030 [P] Add dashboard count tests for critical, blocked, and open risk/blocker rules in `tests/AnimaxMissionControlPortal.Tests/Services/DashboardServiceTests.cs`

**Checkpoint**: Foundation ready. User story implementation can now begin in priority order or parallel by story.

---

## Phase 3: User Story 1 - Creer et assigner une mission (Priority: P1) MVP

**Goal**: A Mission Operator can create a valid mission assigned to a seeded division and see it reflected in mission views and dashboard-critical indicators.

**Independent Test**: Select Mission Operator, create a mission with title, division, status, priority, classification, and alert level, then verify it appears in Mission List, Mission Detail, and dashboard critical indicators when applicable.

### Tests for User Story 1

- [X] T031 [P] [US1] Add mission creation persistence tests in `tests/AnimaxMissionControlPortal.Tests/Services/MissionServiceCreateTests.cs`
- [X] T032 [P] [US1] Add create mission form validation tests in `tests/AnimaxMissionControlPortal.Tests/Components/CreateMissionPageTests.cs`

### Implementation for User Story 1

- [X] T033 [US1] Implement create mission route and French validation messages in `src/AnimaxMissionControlPortal/Components/Pages/CreateMission.razor`
- [X] T034 [US1] Implement mission list baseline route with newly created mission visibility in `src/AnimaxMissionControlPortal/Components/Pages/Missions.razor`
- [X] T035 [US1] Implement mission detail baseline route for created mission attributes in `src/AnimaxMissionControlPortal/Components/Pages/MissionDetail.razor`
- [X] T036 [US1] Implement dashboard baseline route with total and critical mission indicators in `src/AnimaxMissionControlPortal/Components/Pages/Dashboard.razor`
- [X] T037 [US1] Wire mission creation navigation links in `src/AnimaxMissionControlPortal/Components/Layout/NavMenu.razor`
- [X] T038 [US1] Remove stock sample pages or routes from `src/AnimaxMissionControlPortal/Components/Pages/Counter.razor`, `src/AnimaxMissionControlPortal/Components/Pages/Weather.razor`, and `src/AnimaxMissionControlPortal/Components/Pages/Home.razor`

**Checkpoint**: User Story 1 is fully functional and independently testable.

---

## Phase 4: User Story 2 - Piloter une mission divisionnelle (Priority: P2)

**Goal**: A Division Lead can change mission status and priority, add updates, add risks/blockers, and have open blockers reflected in detail and dashboard counts.

**Independent Test**: Select Division Lead, open a mission, change status to Blocked, change priority, add an Update, add an Open Blocker, and verify the detail page, mission list, and dashboard counts update.

### Tests for User Story 2

- [X] T039 [P] [US2] Add status and priority update tests in `tests/AnimaxMissionControlPortal.Tests/Services/MissionServiceUpdateTests.cs`
- [X] T040 [P] [US2] Add mission update and risk/blocker service tests, including SQLite reload coverage proving created `MissionUpdate` and `RiskBlocker` records are read correctly after a fresh DbContext/service instance, in `tests/AnimaxMissionControlPortal.Tests/Services/MissionActivityTests.cs`
- [X] T041 [P] [US2] Add open versus resolved risk/blocker dashboard tests in `tests/AnimaxMissionControlPortal.Tests/Services/RiskBlockerDashboardTests.cs`

### Implementation for User Story 2

- [X] T042 [US2] Extend mission detail route with editable status and priority controls in `src/AnimaxMissionControlPortal/Components/Pages/MissionDetail.razor`
- [X] T043 [US2] Create risk/blocker panel with add form and Open/Resolved display in `src/AnimaxMissionControlPortal/Components/Shared/RiskBlockerPanel.razor`
- [X] T044 [US2] Extend mission detail route with update timeline and add update form in `src/AnimaxMissionControlPortal/Components/Pages/MissionDetail.razor`
- [X] T045 [US2] Extend mission list cards to reflect changed status and priority in `src/AnimaxMissionControlPortal/Components/Shared/MissionCard.razor`
- [X] T046 [US2] Extend dashboard blocked and open risk/blocker sections in `src/AnimaxMissionControlPortal/Components/Pages/Dashboard.razor`

**Checkpoint**: User Stories 1 and 2 both work independently.

---

## Phase 5: User Story 3 - Superviser les missions critiques (Priority: P3)

**Goal**: An Executive Viewer can quickly inspect global indicators, critical/blocked missions, and open a critical mission detail without any real permission behavior.

**Independent Test**: Select Executive Viewer, view the dashboard, identify total, Critical, Blocked, and open risk/blocker indicators, then open a highlighted Critical or Blocked mission detail.

### Tests for User Story 3

- [X] T047 [P] [US3] Add executive dashboard slice tests in `tests/AnimaxMissionControlPortal.Tests/Services/ExecutiveDashboardTests.cs`
- [X] T048 [P] [US3] Add demo persona service tests proving no permission restriction behavior in `tests/AnimaxMissionControlPortal.Tests/Services/DemoPersonaServiceTests.cs`

### Implementation for User Story 3

- [X] T049 [US3] Extend dashboard route with critical mission and blocked mission sections in `src/AnimaxMissionControlPortal/Components/Pages/Dashboard.razor`
- [X] T050 [US3] Integrate persona switcher into dashboard and layout context in `src/AnimaxMissionControlPortal/Components/Shared/PersonaSwitcher.razor` and `src/AnimaxMissionControlPortal/Components/Layout/MainLayout.razor`
- [X] T051 [US3] Add classification disclaimer text near mission classification displays in `src/AnimaxMissionControlPortal/Components/Shared/ClassificationBadge.razor` and `src/AnimaxMissionControlPortal/Components/Pages/MissionDetail.razor`
- [X] T052 [US3] Ensure dashboard mission cards navigate to mission detail pages in `src/AnimaxMissionControlPortal/Components/Pages/Dashboard.razor`

**Checkpoint**: User Stories 1, 2, and 3 are independently functional.

---

## Phase 6: User Story 4 - Explorer et filtrer le portefeuille de missions (Priority: P4)

**Goal**: A demo user can filter missions by status, priority, division, classification, and alert level, and browse the seven seeded divisions.

**Independent Test**: Apply each mission filter against seeded data, verify only matching missions appear, clear filters, verify an empty state for unmatched filters, then open the division directory and confirm all seven divisions are listed.

### Tests for User Story 4

- [X] T053 [P] [US4] Add mission filter service tests in `tests/AnimaxMissionControlPortal.Tests/Services/MissionFilterTests.cs`
- [X] T054 [P] [US4] Add division lookup tests in `tests/AnimaxMissionControlPortal.Tests/Services/DivisionServiceTests.cs`

### Implementation for User Story 4

- [X] T055 [US4] Extend mission list route with status, priority, division, classification, and alert level filters in `src/AnimaxMissionControlPortal/Components/Pages/Missions.razor`
- [X] T056 [US4] Add clear-filter and no-result empty states in `src/AnimaxMissionControlPortal/Components/Pages/Missions.razor`
- [X] T057 [US4] Implement division directory route with seven seeded division records and mission counts in `src/AnimaxMissionControlPortal/Components/Pages/DivisionDirectory.razor`
- [X] T058 [US4] Add division directory navigation and optional division-filter links in `src/AnimaxMissionControlPortal/Components/Layout/NavMenu.razor` and `src/AnimaxMissionControlPortal/Components/Pages/DivisionDirectory.razor`

**Checkpoint**: All MVP user stories are independently functional.

---

## Phase 7: Polish & Cross-Cutting Concerns

**Purpose**: Finish demo-ready styling, local documentation, verification, and guardrails across all stories.

- [X] T059 [P] Apply dark cyberpunk command-center layout styling in `src/AnimaxMissionControlPortal/Styles/tokens.css`, `src/AnimaxMissionControlPortal/Styles/tailwind.css`, and `src/AnimaxMissionControlPortal/wwwroot/css/app.css`
- [X] T060 [P] Update README with restore, build, test, Tailwind, SQLite, run, and demo-safe notes in `README.md`
- [X] T061 [P] Document non-critical visual asset guidance in `src/AnimaxMissionControlPortal/Assets/README.md`
- [X] T062 Verify French UI labels and canonical English terms across `src/AnimaxMissionControlPortal/Components/Pages/` and `src/AnimaxMissionControlPortal/Components/Shared/`
- [X] T063 Verify no real auth, RBAC, external API, notification, SignalR, attachment, multi-tenant, secret, or production-security claim was introduced in `src/AnimaxMissionControlPortal/`
- [X] T064 Run quickstart validation commands and record any environment-specific caveats in `README.md`
- [X] T065 Manually validate the full demo journey Dashboard -> Mission List -> Create Mission -> Mission Detail -> Add Update / Add Blocker -> Dashboard Refresh, confirm it completes in under 5 minutes with seeded data, and document the result or caveats in `README.md`
- [X] T066 Complete a lightweight manual UI/demo-ready checklist covering the 5 MVP routes visible and navigable, Critical and Blocked states visually distinct, main Dashboard counters visible, primary labels in French with canonical English domain terms preserved, usable layout at standard desktop width, no blocking visual assets, and no real security claims tied to classifications; record findings or caveats in `README.md`

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies; can start immediately.
- **Foundational (Phase 2)**: Depends on Phase 1; blocks every user story.
- **User Story 1 (Phase 3)**: Depends on Phase 2; delivers the MVP creation path.
- **User Story 2 (Phase 4)**: Depends on Phase 2 and benefits from US1 pages, but service behavior remains independently testable.
- **User Story 3 (Phase 5)**: Depends on Phase 2 and dashboard baseline; can be validated with seeded data.
- **User Story 4 (Phase 6)**: Depends on Phase 2 and mission list baseline; can be validated with seeded data.
- **Polish (Phase 7)**: Depends on the desired user stories being complete.

### User Story Dependencies

- **US1 (P1)**: Start after foundation; no dependency on other stories.
- **US2 (P2)**: Start after foundation; integrates into mission detail/list/dashboard surfaces introduced by US1.
- **US3 (P3)**: Start after foundation; uses dashboard and mission detail data from foundation/US1.
- **US4 (P4)**: Start after foundation; uses mission and division services from foundation.

### Within Each User Story

- Tests come before implementation and should fail before implementation.
- Shared entities and services come from Phase 2 before route pages.
- Services should be completed before page integration.
- Each story reaches a checkpoint before moving to lower-priority stories.

## Parallel Opportunities

- Setup tasks T004, T005, and T006 can run in parallel.
- Entity and enum tasks T008 through T013 can run in parallel.
- Shared component tasks T024 and T025 can run in parallel after domain types exist.
- Foundational tests T028 through T030 can run in parallel after services are sketched.
- Story test tasks within each user story can run in parallel.
- After Phase 2, US1, US2, US3, and US4 can be staffed in parallel if page file edits are coordinated.
- Polish tasks T059, T060, and T061 can run in parallel.
- Manual validation tasks T065 and T066 run after the routes, styling, data, and README baseline are complete.

## Parallel Examples

### User Story 1

```bash
Task: "T031 [P] [US1] Add mission creation persistence tests in tests/AnimaxMissionControlPortal.Tests/Services/MissionServiceCreateTests.cs"
Task: "T032 [P] [US1] Add create mission form validation tests in tests/AnimaxMissionControlPortal.Tests/Components/CreateMissionPageTests.cs"
```

### User Story 2

```bash
Task: "T039 [P] [US2] Add status and priority update tests in tests/AnimaxMissionControlPortal.Tests/Services/MissionServiceUpdateTests.cs"
Task: "T040 [P] [US2] Add mission update and risk/blocker service tests in tests/AnimaxMissionControlPortal.Tests/Services/MissionActivityTests.cs"
Task: "T041 [P] [US2] Add open versus resolved risk/blocker dashboard tests in tests/AnimaxMissionControlPortal.Tests/Services/RiskBlockerDashboardTests.cs"
```

### User Story 3

```bash
Task: "T047 [P] [US3] Add executive dashboard slice tests in tests/AnimaxMissionControlPortal.Tests/Services/ExecutiveDashboardTests.cs"
Task: "T048 [P] [US3] Add demo persona service tests proving no permission restriction behavior in tests/AnimaxMissionControlPortal.Tests/Services/DemoPersonaServiceTests.cs"
```

### User Story 4

```bash
Task: "T053 [P] [US4] Add mission filter service tests in tests/AnimaxMissionControlPortal.Tests/Services/MissionFilterTests.cs"
Task: "T054 [P] [US4] Add division lookup tests in tests/AnimaxMissionControlPortal.Tests/Services/DivisionServiceTests.cs"
```

## Implementation Strategy

### MVP First (User Story 1 Only)

1. Complete Phase 1 setup.
2. Complete Phase 2 foundation.
3. Complete Phase 3 User Story 1.
4. Stop and validate mission creation independently with `dotnet test` and the create mission demo path.

### Incremental Delivery

1. Add US1 for mission creation and central visibility.
2. Add US2 for operational updates, status/priority changes, and blockers.
3. Add US3 for executive dashboard supervision and persona context.
4. Add US4 for mission filtering and division directory browsing.
5. Finish polish, documentation, and quickstart validation.

### Validation Commands

```bash
dotnet restore
dotnet build
dotnet test
dotnet ef --version
dotnet ef database update --project src/AnimaxMissionControlPortal
dotnet run --project src/AnimaxMissionControlPortal
```
