using AnimaxMissionControlPortal.Services;
using FluentAssertions;

namespace AnimaxMissionControlPortal.Tests.Services;

public sealed class DemoPersonaServiceTests
{
    [Fact]
    public void Persona_switching_does_not_restrict_demo_actions()
    {
        var service = new DemoPersonaService();

        foreach (var persona in service.Personas)
        {
            service.Select(persona.Id);
            service.CanPerformAnyDemoAction().Should().BeTrue();
        }
    }
}
