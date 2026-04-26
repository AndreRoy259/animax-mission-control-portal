using AnimaxMissionControlPortal.Data.Seed;
using AnimaxMissionControlPortal.Domain.Enums;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Data;

public sealed class SeedDataTests
{
    [Fact]
    public void Seed_data_contains_required_counts_and_divisions()
    {
        AnimaxSeedData.Divisions.Should().HaveCount(7);
        AnimaxSeedData.Missions.Should().HaveCount(12);
        AnimaxSeedData.MissionUpdates.Should().HaveCount(10);
        AnimaxSeedData.RiskBlockers.Should().HaveCount(8);
        AnimaxSeedData.Divisions.Select(x => x.Code).Should().BeEquivalentTo(["CCCU", "FAAD", "PBRL", "HECH", "BOACT", "REMS", "FMRA"]);
    }

    [Fact]
    public void Seed_data_covers_all_reference_enums()
    {
        AnimaxSeedData.Missions.Select(x => x.Status).Should().Contain(Enum.GetValues<MissionStatus>());
        AnimaxSeedData.Missions.Select(x => x.Priority).Should().Contain(Enum.GetValues<Priority>());
        AnimaxSeedData.Missions.Select(x => x.Classification).Should().Contain(Enum.GetValues<ClassificationLevel>());
        AnimaxSeedData.Missions.Select(x => x.AlertLevel).Should().Contain(Enum.GetValues<AlertLevel>());
        AnimaxSeedData.RiskBlockers.Select(x => x.Status).Should().Contain(Enum.GetValues<RiskBlockerStatus>());
        AnimaxSeedData.RiskBlockers.Select(x => x.Type).Should().Contain(Enum.GetValues<RiskBlockerType>());
    }
}
