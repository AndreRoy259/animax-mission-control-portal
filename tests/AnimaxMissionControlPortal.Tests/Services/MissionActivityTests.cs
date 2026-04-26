using AnimaxMissionControlPortal.Domain.Enums;
using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Services;

public sealed class MissionActivityTests
{
    [Fact]
    public async Task Updates_and_risk_blockers_reload_from_fresh_context()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;
        var service = new MissionService(context);

        await service.AddUpdateAsync(1, "  Update fraiche  ", "Tester");
        await service.AddRiskBlockerAsync(1, RiskBlockerType.Blocker, RiskBlockerStatus.Open, "  Blocage frais  ", "Tester");

        await using var freshContext = TestDb.CreateContext(connection);
        var reloaded = await new MissionService(freshContext).GetByIdAsync(1);

        reloaded!.Updates.Should().Contain(x => x.Content == "Update fraiche");
        reloaded.RiskBlockers.Should().Contain(x => x.Description == "Blocage frais" && x.Status == RiskBlockerStatus.Open);
    }
}
