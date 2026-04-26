using AnimaxMissionControlPortal.Domain.Enums;
using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Services;

public sealed class MissionValidationTests
{
    [Fact]
    public async Task Validation_rejects_required_title_and_division()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;
        var service = new MissionService(context);

        var result = await service.ValidateAsync(new MissionInput("  ", null, 0, MissionStatus.Draft, Priority.Medium, ClassificationLevel.Internal, AlertLevel.Normal, null));

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain("Le titre de mission est obligatoire.");
        result.Errors.Should().Contain("La division assignee est obligatoire.");
    }

    [Fact]
    public async Task Validation_trims_title()
    {
        var (context, connection) = await TestDb.CreateSeededAsync();
        await using var _ = context;
        await using var __ = connection;
        var service = new MissionService(context);

        var result = await service.ValidateAsync(new MissionInput("  Mission nette  ", null, 1, MissionStatus.Active, Priority.High, ClassificationLevel.Internal, AlertLevel.Normal, "Tester"));

        result.IsValid.Should().BeTrue();
        result.Title.Should().Be("Mission nette");
    }
}
