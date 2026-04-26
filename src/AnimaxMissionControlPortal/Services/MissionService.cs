using AnimaxMissionControlPortal.Data;
using AnimaxMissionControlPortal.Domain.Entities;
using AnimaxMissionControlPortal.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AnimaxMissionControlPortal.Services;

public sealed class MissionService(AnimaxDbContext dbContext)
{
    public async Task<List<Mission>> GetMissionsAsync(MissionFilter? filter = null, CancellationToken cancellationToken = default)
    {
        var query = dbContext.Missions.AsNoTracking().Include(x => x.Division).Include(x => x.RiskBlockers).AsQueryable();

        if (filter is not null)
        {
            if (filter.Status is { } status) query = query.Where(x => x.Status == status);
            if (filter.Priority is { } priority) query = query.Where(x => x.Priority == priority);
            if (filter.DivisionId is { } divisionId) query = query.Where(x => x.DivisionId == divisionId);
            if (filter.Classification is { } classification) query = query.Where(x => x.Classification == classification);
            if (filter.AlertLevel is { } alertLevel) query = query.Where(x => x.AlertLevel == alertLevel);
        }

        return await query.OrderByDescending(x => x.UpdatedAt).ThenBy(x => x.Title).ToListAsync(cancellationToken);
    }

    public Task<Mission?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        dbContext.Missions
            .AsNoTracking()
            .Include(x => x.Division)
            .Include(x => x.Updates.OrderByDescending(update => update.CreatedAt))
            .Include(x => x.RiskBlockers.OrderByDescending(risk => risk.CreatedAt))
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<Mission> CreateAsync(MissionInput input, CancellationToken cancellationToken = default)
    {
        var validation = await ValidateAsync(input, cancellationToken);
        if (!validation.IsValid)
        {
            throw new InvalidOperationException(string.Join(" ", validation.Errors));
        }

        var now = DateTime.UtcNow;
        var mission = new Mission
        {
            Title = validation.Title,
            Description = string.IsNullOrWhiteSpace(input.Description) ? null : input.Description.Trim(),
            DivisionId = input.DivisionId,
            Status = input.Status,
            Priority = input.Priority,
            Classification = input.Classification,
            AlertLevel = input.AlertLevel,
            CreatedAt = now,
            UpdatedAt = now,
            CreatedBy = string.IsNullOrWhiteSpace(input.Author) ? "Mission Operator" : input.Author.Trim()
        };

        dbContext.Missions.Add(mission);
        await dbContext.SaveChangesAsync(cancellationToken);
        return mission;
    }

    public async Task<MissionValidationResult> ValidateAsync(MissionInput input, CancellationToken cancellationToken = default)
    {
        var errors = new List<string>();
        var title = input.Title?.Trim() ?? "";
        if (title.Length == 0)
        {
            errors.Add("Le titre de mission est obligatoire.");
        }

        if (!await dbContext.Divisions.AnyAsync(x => x.Id == input.DivisionId, cancellationToken))
        {
            errors.Add("La division assignee est obligatoire.");
        }

        return errors.Count == 0 ? MissionValidationResult.Valid(title) : MissionValidationResult.Invalid(errors);
    }

    public async Task UpdateStatusPriorityAsync(int missionId, MissionStatus status, Priority priority, CancellationToken cancellationToken = default)
    {
        var mission = await dbContext.Missions.FindAsync([missionId], cancellationToken) ?? throw new InvalidOperationException("Mission introuvable.");
        mission.Status = status;
        mission.Priority = priority;
        mission.UpdatedAt = DateTime.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<MissionUpdate> AddUpdateAsync(int missionId, string? content, string? author, CancellationToken cancellationToken = default)
    {
        var text = content?.Trim() ?? "";
        if (text.Length == 0)
        {
            throw new InvalidOperationException("Le contenu de la mise a jour est obligatoire.");
        }

        await EnsureMissionExistsAsync(missionId, cancellationToken);
        var update = new MissionUpdate
        {
            MissionId = missionId,
            Content = text,
            Author = string.IsNullOrWhiteSpace(author) ? "Division Lead" : author.Trim(),
            CreatedAt = DateTime.UtcNow
        };
        dbContext.MissionUpdates.Add(update);
        await TouchMissionAsync(missionId, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return update;
    }

    public async Task<RiskBlocker> AddRiskBlockerAsync(int missionId, RiskBlockerType type, RiskBlockerStatus status, string? description, string? author, CancellationToken cancellationToken = default)
    {
        var text = description?.Trim() ?? "";
        if (text.Length == 0)
        {
            throw new InvalidOperationException("La description du risque ou bloqueur est obligatoire.");
        }

        await EnsureMissionExistsAsync(missionId, cancellationToken);
        var risk = new RiskBlocker
        {
            MissionId = missionId,
            Type = type,
            Status = status,
            Description = text,
            Author = string.IsNullOrWhiteSpace(author) ? "Division Lead" : author.Trim(),
            CreatedAt = DateTime.UtcNow,
            ResolvedAt = status == RiskBlockerStatus.Resolved ? DateTime.UtcNow : null
        };
        dbContext.RiskBlockers.Add(risk);
        await TouchMissionAsync(missionId, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return risk;
    }

    private async Task EnsureMissionExistsAsync(int missionId, CancellationToken cancellationToken)
    {
        if (!await dbContext.Missions.AnyAsync(x => x.Id == missionId, cancellationToken))
        {
            throw new InvalidOperationException("Mission introuvable.");
        }
    }

    private async Task TouchMissionAsync(int missionId, CancellationToken cancellationToken)
    {
        var mission = await dbContext.Missions.FindAsync([missionId], cancellationToken);
        if (mission is not null)
        {
            mission.UpdatedAt = DateTime.UtcNow;
        }
    }
}
