using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Services;

public sealed class DivisionServiceTests
{
    [Fact]
    public async Task Division_lookup_returns_all_seeded_divisions_with_counts()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;

        var divisions = await new DivisionService(context).GetAllAsync();

        divisions.Should().HaveCount(7);
        divisions.Select(x => x.Code).Should().Contain(["CCCU", "FAAD", "PBRL", "HECH", "BOACT", "REMS", "FMRA"]);
        divisions.Should().OnlyContain(x => x.Missions.Count >= 1);
    }
}
