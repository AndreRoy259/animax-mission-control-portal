using AnimaxMissionControlPortal.Data;
using AnimaxMissionControlPortal.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace AnimaxMissionControlPortal.Services;

public sealed class SeedService(AnimaxDbContext dbContext)
{
    public async Task EnsureSeededAsync(CancellationToken cancellationToken = default)
    {
        if (!await dbContext.Divisions.AnyAsync(cancellationToken))
        {
            dbContext.Divisions.AddRange(AnimaxSeedData.Divisions.Select(CloneDivision));
        }

        if (!await dbContext.Missions.AnyAsync(cancellationToken))
        {
            dbContext.Missions.AddRange(AnimaxSeedData.Missions.Select(CloneMission));
        }

        if (!await dbContext.MissionUpdates.AnyAsync(cancellationToken))
        {
            dbContext.MissionUpdates.AddRange(AnimaxSeedData.MissionUpdates.Select(CloneUpdate));
        }

        if (!await dbContext.RiskBlockers.AnyAsync(cancellationToken))
        {
            dbContext.RiskBlockers.AddRange(AnimaxSeedData.RiskBlockers.Select(CloneRisk));
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private static Domain.Entities.Division CloneDivision(Domain.Entities.Division source) => new()
    {
        Id = source.Id,
        Code = source.Code,
        Name = source.Name,
        OperationalDomain = source.OperationalDomain,
        Description = source.Description,
        VisualSignal = source.VisualSignal
    };

    private static Domain.Entities.Mission CloneMission(Domain.Entities.Mission source) => new()
    {
        Id = source.Id,
        Title = source.Title,
        Description = source.Description,
        DivisionId = source.DivisionId,
        Status = source.Status,
        Priority = source.Priority,
        Classification = source.Classification,
        AlertLevel = source.AlertLevel,
        CreatedAt = source.CreatedAt,
        UpdatedAt = source.UpdatedAt,
        CreatedBy = source.CreatedBy
    };

    private static Domain.Entities.MissionUpdate CloneUpdate(Domain.Entities.MissionUpdate source) => new()
    {
        Id = source.Id,
        MissionId = source.MissionId,
        Content = source.Content,
        Author = source.Author,
        CreatedAt = source.CreatedAt
    };

    private static Domain.Entities.RiskBlocker CloneRisk(Domain.Entities.RiskBlocker source) => new()
    {
        Id = source.Id,
        MissionId = source.MissionId,
        Type = source.Type,
        Status = source.Status,
        Description = source.Description,
        Author = source.Author,
        CreatedAt = source.CreatedAt,
        ResolvedAt = source.ResolvedAt
    };
}
