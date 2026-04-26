using AnimaxMissionControlPortal.Domain.Enums;
using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Services;

public sealed class RiskBlockerDashboardTests
{
    [Fact]
    public async Task Dashboard_counts_only_open_risks_and_blockers()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;
        var missionService = new MissionService(context);

        await missionService.AddRiskBlockerAsync(1, RiskBlockerType.Risk, RiskBlockerStatus.Resolved, "Resolved demo", "Tester");
        await missionService.AddRiskBlockerAsync(1, RiskBlockerType.Risk, RiskBlockerStatus.Open, "Open demo", "Tester");

        var snapshot = await new DashboardService(context).GetSnapshotAsync();
        snapshot.OpenRiskBlockers.Should().Be(7);
    }
}
