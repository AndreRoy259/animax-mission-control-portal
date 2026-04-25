# Quickstart: Animax Mission Control Portal MVP

## Prerequisites

- .NET SDK compatible with `net10.0`
- VS Code + WSL or equivalent local shell
- SQLite support through EF Core packages added during implementation
- Tailwind CLI tooling added during implementation

If EF Core migrations are used, validate that `dotnet-ef` is available in WSL:

```bash
dotnet ef --version
```

If `dotnet ef` is not recognized, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If the command is still not recognized after installation, ensure the global tools path is available in the shell:

```bash
export PATH="$PATH:$HOME/.dotnet/tools"
```

## Restore

```bash
dotnet restore
```

## Build

```bash
dotnet build
```

## Database

The MVP may use EF Core migrations to create the local SQLite database. If the final implementation instead creates the database automatically at startup, `dotnet ef` is not required for normal demo use.

If migrations are used, create/update the local SQLite database with:

```bash
dotnet ef database update --project src/AnimaxMissionControlPortal
```

The database must remain local and contain synthetic data only. The seed strategy must insert:

- 7 divisions: CCCU, FAAD, PBRL, HECH, BOACT, REMS, FMRA
- 12 missions
- 10 updates
- 8 risks/blockers

No SQL Server, PostgreSQL, Docker, or external database service is expected for the MVP.

## Tailwind CSS

The preferred MVP styling path is simple Tailwind CLI compilation. Tailwind should compile a source CSS file into a static CSS file served by Blazor.

Expected files:

- Input: `src/AnimaxMissionControlPortal/Styles/tailwind.css`
- Output: `src/AnimaxMissionControlPortal/wwwroot/css/app.css`
- Design tokens: `src/AnimaxMissionControlPortal/Styles/tokens.css`

Indicative build command:

```bash
npx @tailwindcss/cli -i ./src/AnimaxMissionControlPortal/Styles/tailwind.css -o ./src/AnimaxMissionControlPortal/wwwroot/css/app.css
```

Indicative watch command:

```bash
npx @tailwindcss/cli -i ./src/AnimaxMissionControlPortal/Styles/tailwind.css -o ./src/AnimaxMissionControlPortal/wwwroot/css/app.css --watch
```

Tailwind must not introduce a heavy UI framework. Existing Bootstrap artifacts from the Blazor template may be removed or neutralized only if they interfere with the Tailwind shell.

## Test

```bash
dotnet test
```

Tests should target validation rules, dashboard counts, Open vs Resolved risk/blocker logic, seed data coverage, and main services.

## Run

```bash
dotnet run --project src/AnimaxMissionControlPortal
```

Open the local URL printed by `dotnet run`.

## Demo Journey

1. Open Dashboard.
2. Confirm totals, Critical missions, Blocked missions, and Open risks/blockers are visible.
3. Switch persona between Mission Operator, Division Lead, and Executive Viewer.
4. Open Mission List and apply filters for status, priority, division, classification, and alert level.
5. Create a Mission with title, division, status, priority, classification, and alert level.
6. Open Mission Detail.
7. Add an Update.
8. Add an Open Risk or Blocker.
9. Return to Dashboard and confirm counts refresh.

## Demo-Safe Notes

- All data must be fictive.
- No real authentication or RBAC is implemented.
- Persona switching is a visual/demo affordance only.
- Classification labels are not security controls.
- No external service, tenant, notification, SignalR, attachment, or advanced search dependency is expected.
- Visual assets are non-critical and planned for a future wave.
