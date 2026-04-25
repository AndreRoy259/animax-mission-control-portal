# Animax Mission Control Portal

Animax Mission Control Portal is a fictive, demo-safe internal web app for
Animax Global Corporation(TM). The MVP demonstrates a Spec-Driven + Codex
workflow through a credible Blazor application for centralizing, prioritizing,
and tracking inter-division missions.

## Target Stack

- C# / .NET / Blazor
- EF Core with SQLite
- Tailwind CSS
- Reusable Razor components
- Local-first execution with synthetic seed data

## Commands

```bash
dotnet build src/AnimaxMissionControlPortal/AnimaxMissionControlPortal.csproj
dotnet run --project src/AnimaxMissionControlPortal/AnimaxMissionControlPortal.csproj
dotnet test
```

`dotnet test` requires a test project to be present. Until then, use `dotnet
build` as the executable validation gate.

## MVP Scope

The planned MVP includes:

- Dashboard
- Mission List
- Create Mission
- Mission Detail
- Division Directory
- Lightweight Demo Persona Switcher
- Synthetic seed data for missions, divisions, and personas

The MVP does not include real authentication, RBAC, approval workflows, external
APIs, real notifications, multi-tenant behavior, real-time synchronization,
attachments, or production-ready enterprise workflow behavior.

## Solution Structure

```text
src/
└── AnimaxMissionControlPortal/
    ├── Domain/
    ├── Data/
    ├── Services/
    ├── Components/
    ├── Components/Pages/
    ├── Styles/
    ├── Assets/
    └── wwwroot/

tests/
└── AnimaxMissionControlPortal.Tests/
```

## Technical Assumptions

- The app runs completely locally.
- SQLite is the default persistence store.
- All data is synthetic and safe for demos.
- Demo persona switching is simulated and visual only.
- Classification labels are presentation metadata, not security controls.
- Visual Animax assets can be generated later and are not required for core behavior.

## Key Decisions

- Keep the MVP simple and readable in VS Code + WSL.
- Prefer Blazor and Razor components over a heavy UI framework.
- Use EF Core directly for MVP data access unless a concrete duplication problem appears.
- Add targeted tests around domain behavior, seed data, services, and critical UI workflows.
- Update this README when build, run, test, structure, or demo-safe assumptions change.
