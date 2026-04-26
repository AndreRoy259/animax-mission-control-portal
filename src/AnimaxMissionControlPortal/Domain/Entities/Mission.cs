using AnimaxMissionControlPortal.Domain.Enums;

namespace AnimaxMissionControlPortal.Domain.Entities;

public sealed class Mission
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string? Description { get; set; }
    public int DivisionId { get; set; }
    public Division Division { get; set; } = null!;
    public MissionStatus Status { get; set; }
    public Priority Priority { get; set; }
    public ClassificationLevel Classification { get; set; }
    public AlertLevel AlertLevel { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; } = "";
    public List<MissionUpdate> Updates { get; set; } = [];
    public List<RiskBlocker> RiskBlockers { get; set; } = [];

    public bool IsCritical => Priority == Priority.Critical || AlertLevel == AlertLevel.Critical;
    public bool IsBlocked => Status == MissionStatus.Blocked;
}
