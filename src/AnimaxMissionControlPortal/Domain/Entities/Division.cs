namespace AnimaxMissionControlPortal.Domain.Entities;

public sealed class Division
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string OperationalDomain { get; set; } = "";
    public string? Description { get; set; }
    public string VisualSignal { get; set; } = "";
    public List<Mission> Missions { get; set; } = [];
}
