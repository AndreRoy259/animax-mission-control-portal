using AnimaxMissionControlPortal.Domain.Enums;

namespace AnimaxMissionControlPortal.Services;

public sealed record MissionInput(
    string? Title,
    string? Description,
    int DivisionId,
    MissionStatus Status,
    Priority Priority,
    ClassificationLevel Classification,
    AlertLevel AlertLevel,
    string? Author);

public sealed record MissionFilter(
    MissionStatus? Status = null,
    Priority? Priority = null,
    int? DivisionId = null,
    ClassificationLevel? Classification = null,
    AlertLevel? AlertLevel = null);

public sealed class MissionValidationResult
{
    private MissionValidationResult(bool isValid, string title, IReadOnlyList<string> errors)
    {
        IsValid = isValid;
        Title = title;
        Errors = errors;
    }

    public bool IsValid { get; }
    public string Title { get; }
    public IReadOnlyList<string> Errors { get; }

    public static MissionValidationResult Valid(string title) => new(true, title, []);
    public static MissionValidationResult Invalid(IEnumerable<string> errors) => new(false, "", errors.ToArray());
}
