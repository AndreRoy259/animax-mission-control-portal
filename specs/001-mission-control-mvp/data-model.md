# Data Model: Animax Mission Control Portal MVP

## Reference Enums

### MissionStatus

- Draft
- Active
- Blocked
- Completed
- Archived

### Priority

- Low
- Medium
- High
- Critical

### ClassificationLevel

- Internal
- Confidential
- Classified
- Blackfile

Classification is an informative demo label only. It is not a security control.

### AlertLevel

- Normal
- Elevated
- Critical

### RiskBlockerStatus

- Open
- Resolved

### RiskBlockerType

- Risk
- Blocker

## Entities

### Division

Represents a fictive Animax division available for mission assignment and filtering.

Fields:

- `Id`: integer primary key
- `Code`: required string, unique, examples: CCCU, FAAD, PBRL, HECH, BOACT, REMS, FMRA
- `Name`: required string
- `OperationalDomain`: required string, fictive
- `Description`: optional string
- `VisualSignal`: required string token or color key used by UI
- `Missions`: collection of assigned missions

Validation:

- `Code` is required and unique.
- `Name` is required.
- `OperationalDomain` is required.
- Seed data must include exactly the required seven division codes for MVP coverage.

Relationships:

- One `Division` has many `Mission` records.

### Mission

Represents an inter-division mission dossier.

Fields:

- `Id`: integer primary key
- `Title`: required string, stored trimmed
- `Description`: optional string
- `DivisionId`: required foreign key
- `Division`: required navigation property
- `Status`: required `MissionStatus`
- `Priority`: required `Priority`
- `Classification`: required `ClassificationLevel`
- `AlertLevel`: required `AlertLevel`
- `CreatedAt`: required date/time
- `UpdatedAt`: required date/time
- `CreatedBy`: required demo author string
- `Updates`: collection of `MissionUpdate`
- `RiskBlockers`: collection of `RiskBlocker`

Validation:

- `Title.Trim()` must not be empty.
- `DivisionId` must reference an existing seeded division.
- `Status`, `Priority`, `Classification`, and `AlertLevel` are required selections.
- Error messages must be readable and primarily French.

Derived UI rules:

- A mission is critical when `Priority == Critical` or `AlertLevel == Critical`.
- A mission is blocked when `Status == Blocked`.

State transitions:

- MVP allows direct status changes among Draft, Active, Blocked, Completed, and Archived.
- No approval workflow or transition guard is planned.
- Last saved local change wins.

### MissionUpdate

Represents a dated progress note for a mission.

Fields:

- `Id`: integer primary key
- `MissionId`: required foreign key
- `Mission`: required navigation property
- `Content`: required string
- `Author`: required demo author string
- `CreatedAt`: required date/time

Validation:

- `MissionId` must reference an existing mission.
- `Content.Trim()` must not be empty when added through the UI/service.
- `Author` comes from current demo persona context or a synthetic fallback.

Relationships:

- Many `MissionUpdate` records belong to one `Mission`.

### RiskBlocker

Represents a risk or blocker associated with a mission.

Fields:

- `Id`: integer primary key
- `MissionId`: required foreign key
- `Mission`: required navigation property
- `Type`: required `RiskBlockerType`
- `Status`: required `RiskBlockerStatus`
- `Description`: required string
- `Author`: required demo author string
- `CreatedAt`: required date/time
- `ResolvedAt`: optional date/time

Validation:

- `MissionId` must reference an existing mission.
- `Type` is required.
- `Status` is required.
- `Description.Trim()` must not be empty when added through the UI/service.
- `ResolvedAt` is set only when status is `Resolved`.

Dashboard rule:

- Only `RiskBlocker` records with `Status == Open` count toward open risks/blockers.
- `Resolved` records remain visible in mission detail history but do not count as open.

Relationships:

- Many `RiskBlocker` records belong to one `Mission`.

### DemoPersona

Represents a selectable demo persona, not an authenticated identity.

Fields:

- `Id`: integer primary key or stable key
- `Name`: required string, one of Mission Operator, Division Lead, Executive Viewer
- `NarrativeRole`: required string
- `DivisionContextCode`: optional division code
- `UiAccent`: optional token or color key
- `DefaultAuthorLabel`: required demo author label

Validation:

- Persona names are fixed demo values.
- Persona selection never hides, locks, or authorizes actions.

Persistence:

- Persona definitions may be seeded or static.
- Selected persona may live in scoped app state for the session; persistence is optional and must remain local only if added.

## Seed Coverage

Required seed counts:

- 7 `Division` records
- 12 `Mission` records
- 10 `MissionUpdate` records
- 8 `RiskBlocker` records

Required coverage:

- Every `MissionStatus`: Draft, Active, Blocked, Completed, Archived
- Every `Priority`: Low, Medium, High, Critical
- Every `ClassificationLevel`: Internal, Confidential, Classified, Blackfile
- Every `AlertLevel`: Normal, Elevated, Critical
- Every `RiskBlockerStatus`: Open, Resolved
- Every `RiskBlockerType`: Risk, Blocker

Seed data must be synthetic, branded as fictive, and must not include real personal data, secrets, tenants, endpoints, or operational identifiers.
