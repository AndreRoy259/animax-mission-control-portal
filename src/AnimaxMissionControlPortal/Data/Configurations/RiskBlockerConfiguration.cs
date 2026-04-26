using AnimaxMissionControlPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimaxMissionControlPortal.Data.Configurations;

public sealed class RiskBlockerConfiguration : IEntityTypeConfiguration<RiskBlocker>
{
    public void Configure(EntityTypeBuilder<RiskBlocker> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(20).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(20).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Author).HasMaxLength(120).IsRequired();
        builder.HasOne(x => x.Mission)
            .WithMany(x => x.RiskBlockers)
            .HasForeignKey(x => x.MissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
