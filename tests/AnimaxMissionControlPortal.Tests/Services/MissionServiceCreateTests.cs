using AnimaxMissionControlPortal.Domain.Enums;
using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Services;

public sealed class MissionServiceCreateTests
{
    [Fact]
    public async Task Create_persists_trimmed_mission()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;
        var service = new MissionService(context);

        var mission = await service.CreateAsync(new MissionInput("  Nouvelle cible  ", "Demo", 1, MissionStatus.Active, Priority.Critical, ClassificationLevel.Internal, AlertLevel.Critical, "Tester"));

        var reloaded = await service.GetByIdAsync(mission.Id);
        reloaded.Should().NotBeNull();
        reloaded!.Title.Should().Be("Nouvelle cible");
        reloaded.Division.Code.Should().Be("CCCU");
    }
}
