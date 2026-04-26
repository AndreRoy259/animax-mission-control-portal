using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Services;

public sealed class ExecutiveDashboardTests
{
    [Fact]
    public async Task Dashboard_exposes_critical_and_blocked_slices()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;

        var snapshot = await new DashboardService(context).GetSnapshotAsync();

        snapshot.CriticalMissionSlice.Should().NotBeEmpty();
        snapshot.BlockedMissionSlice.Should().OnlyContain(x => x.IsBlocked);
    }
}
