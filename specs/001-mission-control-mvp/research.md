# Phase 0 Research: Animax Mission Control Portal MVP

## Decision: Keep one Blazor app with simple internal folders

**Rationale**: The constitution requires readability in VS Code + WSL and the existing project already contains `src/AnimaxMissionControlPortal`. A single app with `Domain`, `Data`, `Services`, `Components`, `Pages`, `Styles`, `Assets`, and a separate targeted test project is enough for the MVP without introducing project-boundary overhead.

**Alternatives considered**: Multiple class-library projects for Domain/Data/Services were rejected for this MVP because they add ceremony without improving the local demo journey. A feature-sliced architecture was rejected because the spec explicitly asks for the named simple layers.

## Decision: Use EF Core with SQLite local file persistence

**Rationale**: The clarified spec requires persistence across browser refresh and application restart. EF Core SQLite fits the .NET/Blazor stack, supports migrations if needed, works locally without an external service, and keeps the data model testable. If migrations are used, `dotnet ef database update --project src/AnimaxMissionControlPortal` is the documented path and assumes `dotnet-ef` is installed in WSL. If the final implementation creates the SQLite database automatically at startup, `dotnet ef` remains optional for normal demo use.

**Alternatives considered**: In-memory storage was rejected because it cannot survive app restart. Browser local storage was rejected because mission updates and blocker relationships are better represented relationally. SQL Server or PostgreSQL were rejected because they introduce external service dependencies.

## Decision: Seed through an idempotent `SeedService`

**Rationale**: The seed set is demo-critical but local users may create additional missions. An idempotent service can insert missing reference/demo records on startup or after migration without overwriting user-created local data.

**Alternatives considered**: Static `HasData` seeding was considered, but richer related data and idempotent non-destructive behavior are easier to reason about in a dedicated seed service. Manual seed scripts were rejected because the app should run cleanly with standard local commands.

## Decision: Keep DemoPersona as UI/demo context only

**Rationale**: The spec and constitution forbid real auth and RBAC. `DemoPersonaService` will track selected persona state and provide labels/default authors/accent values while leaving all actions available.

**Alternatives considered**: ASP.NET Core Identity, authorization policies, and claims were rejected because they would incorrectly imply real permissions and expand scope beyond the demo.

## Decision: Use service-level validation for required mission fields

**Rationale**: Required fields and whitespace title trimming are business rules shared by create/edit UI and tests. Keeping validation in `MissionService` or a small validation helper makes form behavior testable without relying solely on Razor component tests.

**Alternatives considered**: UI-only validation was rejected because it is easier to bypass and harder to test as business behavior. A full validation framework was rejected as unnecessary for the limited MVP rules.

## Decision: Use Tailwind CLI plus Animax CSS tokens, no heavy UI framework

**Rationale**: Tailwind is explicitly requested for UI, and the simplest MVP path is Tailwind CLI compiling `src/AnimaxMissionControlPortal/Styles/tailwind.css` into `src/AnimaxMissionControlPortal/wwwroot/css/app.css`. Animax tokens remain in a lightweight CSS file such as `Styles/tokens.css` to keep status, priority, classification, alert, spacing, and focus states consistent. The component list is small enough for direct Razor components.

**Alternatives considered**: Bootstrap-only styling was rejected because the brief asks for Tailwind and Animax design tokens. Heavy component suites were rejected by constraint and would slow the MVP. Existing Bootstrap template artifacts may be removed or neutralized only when they interfere with the Tailwind shell.

## Decision: Define UI route contracts instead of external API contracts

**Rationale**: The app does not expose public APIs or external interfaces. The useful contract for planning is the route/page contract: route paths, page responsibilities, critical inputs, and expected outputs.

**Alternatives considered**: REST/OpenAPI contracts were rejected because adding an API would violate the local Blazor MVP scope and create an unneeded integration surface.

## Decision: Use targeted tests for domain/service/data behavior

**Rationale**: The highest-risk MVP behavior is validation, seed coverage, dashboard counts, Open vs Resolved blocker logic, and main services. Focused tests provide confidence without trying to create a production-grade test suite.

**Alternatives considered**: Broad end-to-end automation was deferred because the MVP is local/demo-oriented and the implementation has not yet introduced a browser test stack. No tests was rejected by the constitution.
