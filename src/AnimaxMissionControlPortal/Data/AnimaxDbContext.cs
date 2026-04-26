using AnimaxMissionControlPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimaxMissionControlPortal.Data;

public sealed class AnimaxDbContext(DbContextOptions<AnimaxDbContext> options) : DbContext(options)
{
    public DbSet<Division> Divisions => Set<Division>();
    public DbSet<Mission> Missions => Set<Mission>();
    public DbSet<MissionUpdate> MissionUpdates => Set<MissionUpdate>();
    public DbSet<RiskBlocker> RiskBlockers => Set<RiskBlocker>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimaxDbContext).Assembly);
    }
}
