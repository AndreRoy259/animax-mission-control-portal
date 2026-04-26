using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Services;

public sealed class DashboardServiceTests
{
    [Fact]
    public async Task Snapshot_counts_critical_blocked_and_open_risks()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;

        var snapshot = await new DashboardService(context).GetSnapshotAsync();

        snapshot.TotalMissions.Should().Be(12);
        snapshot.CriticalMissions.Should().Be(4);
        snapshot.BlockedMissions.Should().Be(2);
        snapshot.OpenRiskBlockers.Should().Be(6);
    }
}
