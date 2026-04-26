using AnimaxMissionControlPortal.Domain.Enums;

namespace AnimaxMissionControlPortal.Domain.Entities;

public sealed class RiskBlocker
{
    public int Id { get; set; }
    public int MissionId { get; set; }
    public Mission Mission { get; set; } = null!;
    public RiskBlockerType Type { get; set; }
    public RiskBlockerStatus Status { get; set; }
    public string Description { get; set; } = "";
    public string Author { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
}
