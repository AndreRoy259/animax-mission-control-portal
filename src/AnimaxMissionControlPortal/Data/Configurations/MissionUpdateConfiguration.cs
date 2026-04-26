using AnimaxMissionControlPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimaxMissionControlPortal.Data.Configurations;

public sealed class MissionUpdateConfiguration : IEntityTypeConfiguration<MissionUpdate>
{
    public void Configure(EntityTypeBuilder<MissionUpdate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Content).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Author).HasMaxLength(120).IsRequired();
        builder.HasOne(x => x.Mission)
            .WithMany(x => x.Updates)
            .HasForeignKey(x => x.MissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
