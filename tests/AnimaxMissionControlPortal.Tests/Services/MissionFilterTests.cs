using AnimaxMissionControlPortal.Domain.Enums;
using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Services;

public sealed class MissionFilterTests
{
    [Fact]
    public async Task Filters_apply_status_priority_division_classification_and_alert()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;
        var service = new MissionService(context);

        var filtered = await service.GetMissionsAsync(new MissionFilter(MissionStatus.Active, Priority.Critical, 1, ClassificationLevel.Confidential, AlertLevel.Critical));

        filtered.Should().ContainSingle();
        filtered[0].Title.Should().Be("Synchroniser le tableau de crise Animax");
    }
}
