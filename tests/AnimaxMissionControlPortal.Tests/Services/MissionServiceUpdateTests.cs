using AnimaxMissionControlPortal.Domain.Enums;
using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Services;

public sealed class MissionServiceUpdateTests
{
    [Fact]
    public async Task Status_and_priority_updates_are_persisted()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;
        var service = new MissionService(context);

        await service.UpdateStatusPriorityAsync(1, MissionStatus.Blocked, Priority.Low);

        var mission = await service.GetByIdAsync(1);
        mission!.Status.Should().Be(MissionStatus.Blocked);
        mission.Priority.Should().Be(Priority.Low);
    }
}
