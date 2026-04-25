<!--
Sync Impact Report
Version change: template -> 1.0.0
Modified principles:
- Template placeholders -> I. MVP Demo Journey First
- Template placeholders -> II. Local-First Demo-Safe Operation
- Template placeholders -> III. Clear Blazor Modularity
- Template placeholders -> IV. Seeded Data and Targeted Validation
- Template placeholders -> V. Small, Testable, Documented Steps
Added sections:
- MVP Scope and Technology Constraints
- Delivery Workflow and Documentation
Removed sections:
- Placeholder section headings and sample comments from the template
Templates requiring updates:
- ✅ .specify/templates/plan-template.md
- ✅ .specify/templates/spec-template.md
- ✅ .specify/templates/tasks-template.md
- ✅ .specify/templates/checklist-template.md
- ✅ .specify/extensions/git/commands/*.md
- ✅ README.md
Follow-up TODOs: None
-->
# Animax Mission Control Portal Constitution

## Core Principles

### I. MVP Demo Journey First

Every feature MUST preserve a complete demo path for centralizing, prioritizing,
and tracking inter-division missions in the Animax Mission Control Portal. The
MVP favors credible, working Blazor screens over enterprise completeness: a
Dashboard, Mission List, Create Mission, Mission Detail, and Division Directory
form the core experience. Work outside that path MUST be deferred unless it
unblocks the demo workflow.

Rationale: The project exists to demonstrate Spec-Driven development with Codex
through a believable internal app, not to simulate a full enterprise platform.

### II. Local-First Demo-Safe Operation

The application MUST run completely on a developer machine with synthetic data,
SQLite storage, and no required network service. The codebase MUST NOT contain
hardcoded secrets, real personal data, tenant integrations, cloud dependencies,
real notifications, real authentication, real RBAC, or production security
claims. Classification labels and persona switching are visual demo affordances
only and MUST NOT be represented as security controls.

Rationale: The portal is fictive and demo-safe; its behavior must be easy to run
and inspect without creating operational or data-handling risk.

### III. Clear Blazor Modularity

Implementation MUST keep a simple, readable separation between Domain, Data,
Services, reusable Razor Components, Pages, Styles, Assets, and Tests. C# naming
and folder conventions MUST remain consistent across the solution. Razor
components MUST be reused where they simplify repeated UI patterns, and new
abstractions MUST be justified by current duplication or clarity needs.

Rationale: The app is intended to be understandable in VS Code and WSL by
someone reviewing the Spec Kit workflow and the resulting code side by side.

### IV. Seeded Data and Targeted Validation

Demo seed data is mandatory for mission, division, and persona workflows. Data
MUST be synthetic, recognizable as fictive, and sufficient to exercise priority,
status, division, and mission-detail views. User input MUST receive minimal
useful validation that prevents broken demo states without introducing complex
business rules.

Rationale: A local demo needs meaningful data immediately, while the MVP must
avoid inventing approval engines or enterprise policy logic.

### V. Small, Testable, Documented Steps

Work MUST progress in small increments that can be built, run, tested, and
reviewed independently. Tests MUST be targeted to domain behavior, data seeding,
service logic, and critical UI workflows when those areas change. The README
MUST stay executable with build, run, test commands, solution structure,
technical assumptions, demo-safe notes, and known visual asset timing.

Rationale: The project is a demonstration of disciplined Spec-Driven + Codex
delivery; each increment must be easy to validate without over-engineering.

## MVP Scope and Technology Constraints

The target stack is C#/.NET, Blazor, EF Core, SQLite, Tailwind CSS, reusable
Razor components, and local-first execution. Visual assets for Animax branding
MAY be generated later and MUST NOT be required for core functionality.

The MVP MUST include the following pages or equivalent routes:

- Dashboard
- Mission List
- Create Mission
- Mission Detail
- Division Directory

The MVP MUST include a lightweight Demo Persona Switcher. Simulated persona or
auth state MAY influence visible labels, filters, and demo context, but MUST NOT
be implemented as real authentication or authorization.

The following are out of scope unless this constitution is amended:

- Real authentication or RBAC
- Complex approval workflows
- External APIs or tenant integrations
- Real notifications
- Multi-tenant architecture
- Real-time synchronization
- Attachments
- Advanced enterprise workflow engines
- Production-ready claims
- Heavy UI frameworks without documented justification
- Distributed architecture or required cloud services

## Delivery Workflow and Documentation

Specifications, plans, and tasks MUST keep the MVP local-first and demo-safe.
Plans MUST document the chosen C#/.NET, Blazor, EF Core, SQLite, Tailwind CSS,
and test approach before implementation begins. Tasks MUST be organized into
small, independently validatable slices and MUST include seed data and README
updates when behavior changes.

Generated documentation MUST include:

- Build, run, and test commands
- Technical assumptions and key decisions
- Demo-safe constraints and synthetic data notes
- Solution structure
- The planned point at which Animax visual assets are introduced

Implementation MUST avoid dead code, broad speculative abstractions, and
unvalidated requirements. Dependencies MUST stay lightweight; any new dependency
must have an immediate MVP purpose and a simpler alternative considered.

## Governance

This constitution supersedes conflicting project guidance for the Animax Mission
Control Portal. Amendments MUST be made through a documented Spec Kit update
that records the version change, affected principles or sections, and required
template or documentation synchronization.

Versioning follows semantic governance:

- MAJOR: Removes or redefines a core principle or expands the project beyond
  local-first demo-safe MVP assumptions.
- MINOR: Adds a principle, mandatory section, technology constraint, or material
  delivery rule.
- PATCH: Clarifies wording, fixes errors, or tightens guidance without changing
  obligations.

Compliance review is required at specification, plan, task, and implementation
checkpoints. Any violation MUST be recorded with its rationale and a simpler
alternative that was rejected. Unjustified scope expansion, real integrations,
secret handling, or production-ready claims MUST block acceptance until removed
or the constitution is amended.

**Version**: 1.0.0 | **Ratified**: 2026-04-25 | **Last Amended**: 2026-04-25
