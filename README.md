# Animax Mission Control Portal

Local-first Blazor MVP for a fictive Animax mission command portal. The app uses synthetic data only, stores local demo state in SQLite, and does not implement real authentication, RBAC, external APIs, notifications, SignalR, attachments, tenant isolation, or production security controls.

## Stack

- C# / .NET 10 / Blazor
- EF Core with SQLite
- Razor components
- Tailwind-oriented CSS entrypoint and Animax design tokens
- xUnit, FluentAssertions, and SQLite-backed service tests

## Commands

```bash
dotnet restore
dotnet build src/AnimaxMissionControlPortal/AnimaxMissionControlPortal.csproj
dotnet build tests/AnimaxMissionControlPortal.Tests/AnimaxMissionControlPortal.Tests.csproj
dotnet test tests/AnimaxMissionControlPortal.Tests/AnimaxMissionControlPortal.Tests.csproj
dotnet run --project src/AnimaxMissionControlPortal/AnimaxMissionControlPortal.csproj
```

The app creates `src/AnimaxMissionControlPortal/Data/animax-mission-control.db` automatically and seeds fictive demo records idempotently.

Environment caveat recorded during implementation: `dotnet build AnimaxMissionControlPortal.slnx` exited with code 1 and no diagnostics in this workspace, while both project-level builds and `dotnet sln AnimaxMissionControlPortal.slnx list` succeeded.

## Tailwind And CSS

The planned Tailwind entrypoint is `src/AnimaxMissionControlPortal/Styles/tailwind.css`, with tokens in `src/AnimaxMissionControlPortal/Styles/tokens.css` and compiled output served from `src/AnimaxMissionControlPortal/wwwroot/css/app.css`.

Indicative compile command:

```bash
npx @tailwindcss/cli -i ./src/AnimaxMissionControlPortal/Styles/tailwind.css -o ./src/AnimaxMissionControlPortal/wwwroot/css/app.css
```

The current MVP includes committed CSS output so the demo runs without requiring Node tooling.

## Demo Data

Seed data includes 7 divisions, 12 missions, 10 updates, and 8 risks/blockers. Required division codes are `CCCU`, `FAAD`, `PBRL`, `HECH`, `BOACT`, `REMS`, and `FMRA`.

Classification labels are informative demo labels only. They are not security controls.

## Routes

- `/` and `/dashboard`: Dashboard counts, Critical missions, Blocked missions, and open risks/blockers
- `/missions`: Mission List with status, priority, division, classification, and alert filters
- `/missions/create`: Create Mission form with French validation messages
- `/missions/{id:int}`: Mission Detail with status/priority edits, timeline updates, and risk/blocker panel
- `/divisions`: Division Directory with all seven seeded divisions and mission counts

## Demo Journey

Manual journey to validate after launch:

1. Open Dashboard and confirm totals, Critical missions, Blocked missions, and open risks/blockers are visible.
2. Switch persona between Mission Operator, Division Lead, and Executive Viewer.
3. Open Mission List and apply filters for status, priority, division, classification, and alert level.
4. Create a Mission with title, division, status, priority, classification, and alert level.
5. Open Mission Detail, add an Update, and add an Open Risk or Blocker.
6. Return to Dashboard and confirm counts refresh.

Implementation smoke validation confirmed all five MVP routes returned HTTP 200 locally. Service tests cover the create/update/add-update/add-risk behavior that backs the interactive journey. Expected local demo duration is under 5 minutes on a standard developer machine.

## Visual Assets

Visual assets are non-critical for this MVP. Future assets belong under `src/AnimaxMissionControlPortal/Assets/` and must stay fictive, local, and demo-safe.
