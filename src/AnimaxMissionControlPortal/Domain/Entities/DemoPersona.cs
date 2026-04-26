namespace AnimaxMissionControlPortal.Domain.Entities;

public sealed class DemoPersona
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string NarrativeRole { get; set; } = "";
    public string? DivisionContextCode { get; set; }
    public string? UiAccent { get; set; }
    public string DefaultAuthorLabel { get; set; } = "";
}
