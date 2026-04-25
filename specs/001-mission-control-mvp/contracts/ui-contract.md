# UI Contract: Animax Mission Control Portal MVP

The MVP is a local Blazor application with no external API contract. This document defines the user-facing route and component contracts that implementation must preserve.

## Global UI Contract

- UI labels are primarily French.
- Canonical domain terms remain in English: Mission, Dashboard, Division, Risk, Blocker, Update, Critical.
- Classification labels are informative only and must not imply access control or data protection.
- Demo Persona selection may influence labels, default author text, and visual accents, but must not restrict actions.
- All core flows must work without visual assets.

## Routes

### Dashboard

Route: `/` or `/dashboard`

Must display:

- Total mission count
- Critical mission count, where critical means `Priority == Critical` or `AlertLevel == Critical`
- Blocked mission count, where blocked means `Status == Blocked`
- Open risks/blockers count, where open means `RiskBlocker.Status == Open`
- Visible critical mission area or list
- Visible blocked mission area or list
- Active demo persona context

Must allow:

- Navigate to Mission List
- Navigate to Mission Detail for highlighted missions
- Change demo persona through `PersonaSwitcher`

### Mission List

Route: `/missions`

Must display:

- Mission cards or rows with title, division, status, priority, classification, alert level, and critical/blocked signals
- Filters for status, priority, division, classification, and alert level
- Empty state when no mission matches filters

Must allow:

- Navigate to Create Mission
- Navigate to Mission Detail
- Clear or change filters

### Create Mission

Route: `/missions/create`

Must display inputs for:

- Title
- Description
- Division
- Status
- Priority
- Classification
- Alert level

Must validate:

- Title is required after trimming.
- Division is required.
- Status is required.
- Priority is required.
- Classification is required.
- Alert level is required.
- Errors are readable and primarily French.

Must allow:

- Save valid mission and navigate to its detail or list location.
- Cancel back to Mission List.

### Mission Detail

Route: `/missions/{id:int}`

Must display:

- Mission title, description, division, status, priority, classification, alert level, created/updated dates, and demo author
- Updates timeline
- Risk/blocker panel with Open and Resolved states visible
- Classification disclaimer or nearby wording that avoids security claims

Must allow:

- Change mission status among Draft, Active, Blocked, Completed, Archived
- Change priority among Low, Medium, High, Critical
- Add MissionUpdate with content, author, and timestamp
- Add RiskBlocker with type Risk/Blocker, status Open/Resolved, description, author, and timestamp
- Navigate back to Dashboard or Mission List

### Division Directory

Route: `/divisions`

Must display:

- CCCU, FAAD, PBRL, HECH, BOACT, REMS, and FMRA
- Division name, operational domain, short description, and visual signal
- Mission count per division when available

Must allow:

- Navigate to filtered Mission List for a division if practical for MVP

## Reusable Component Contracts

- `MissionCard`: accepts a `Mission` view model and renders consistent summary metadata and critical/blocked signals.
- `MetricCard`: accepts label, value, tone/accent, and optional supporting text.
- `StatusBadge`: accepts `MissionStatus`.
- `PriorityBadge`: accepts `Priority`.
- `ClassificationBadge`: accepts `ClassificationLevel`.
- `AlertBadge`: accepts `AlertLevel`.
- `TimelineItem`: accepts update content, author, and created date.
- `RiskBlockerPanel`: accepts mission blockers/risks and exposes add behavior for mission detail.
- `DivisionPill`: accepts division code/name/visual signal.
- `PersonaSwitcher`: accepts/selects demo personas and raises selected persona changes without auth side effects.

## Non-Goals

- No real authentication UI.
- No role or permission lockouts.
- No external API calls.
- No realtime updates.
- No attachments.
- No advanced search.
