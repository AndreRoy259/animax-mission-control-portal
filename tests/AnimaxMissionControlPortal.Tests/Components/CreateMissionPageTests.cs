using AnimaxMissionControlPortal.Domain.Enums;
using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Components;

public sealed class CreateMissionPageTests
{
    [Fact]
    public async Task Create_page_validation_rules_are_service_backed()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;
        var service = new MissionService(context);

        var result = await service.ValidateAsync(new MissionInput("", "", 0, MissionStatus.Draft, Priority.Low, ClassificationLevel.Internal, AlertLevel.Normal, null));

        result.IsValid.Should().BeFalse();
        result.Errors.Should().OnlyContain(x => x.Contains("obligatoire"));
    }
}
