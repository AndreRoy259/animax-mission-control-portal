using AnimaxMissionControlPortal.Domain.Entities;

namespace AnimaxMissionControlPortal.Services;

public sealed class DemoPersonaService
{
    public IReadOnlyList<DemoPersona> Personas { get; } =
    [
        new() { Id = "operator", Name = "Mission Operator", NarrativeRole = "Creation et coordination des missions", UiAccent = "cyan", DefaultAuthorLabel = "Mission Operator" },
        new() { Id = "division-lead", Name = "Division Lead", NarrativeRole = "Pilotage divisionnel et suivi des bloqueurs", DivisionContextCode = "HECH", UiAccent = "amber", DefaultAuthorLabel = "Division Lead" },
        new() { Id = "executive", Name = "Executive Viewer", NarrativeRole = "Supervision globale sans restriction d'acces", UiAccent = "rose", DefaultAuthorLabel = "Executive Viewer" }
    ];

    public DemoPersona Current { get; private set; }
    public event Action? Changed;

    public DemoPersonaService()
    {
        Current = Personas[0];
    }

    public void Select(string? personaId)
    {
        var selected = Personas.FirstOrDefault(x => x.Id == personaId) ?? Personas[0];
        if (selected.Id == Current.Id)
        {
            return;
        }

        Current = selected;
        Changed?.Invoke();
    }

    public string CurrentAuthor => Current.DefaultAuthorLabel;
    public bool CanPerformAnyDemoAction() => true;
}
