using AnimaxMissionControlPortal.Data;
using AnimaxMissionControlPortal.Domain.Entities;
using AnimaxMissionControlPortal.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AnimaxMissionControlPortal.Services;

public sealed record DashboardSnapshot(
    int TotalMissions,
    int CriticalMissions,
    int BlockedMissions,
    int OpenRiskBlockers,
    IReadOnlyList<Mission> CriticalMissionSlice,
    IReadOnlyList<Mission> BlockedMissionSlice);

public sealed class DashboardService(AnimaxDbContext dbContext)
{
    public async Task<DashboardSnapshot> GetSnapshotAsync(CancellationToken cancellationToken = default)
    {
        var missions = await dbContext.Missions
            .AsNoTracking()
            .Include(x => x.Division)
            .Include(x => x.RiskBlockers)
            .OrderByDescending(x => x.UpdatedAt)
            .ToListAsync(cancellationToken);

        var critical = missions.Where(x => x.Priority == Priority.Critical || x.AlertLevel == AlertLevel.Critical).ToList();
        var blocked = missions.Where(x => x.Status == MissionStatus.Blocked).ToList();

        return new DashboardSnapshot(
            missions.Count,
            critical.Count,
            blocked.Count,
            missions.SelectMany(x => x.RiskBlockers).Count(x => x.Status == RiskBlockerStatus.Open),
            critical.Take(4).ToList(),
            blocked.Take(4).ToList());
    }
}
