using AnimaxMissionControlPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimaxMissionControlPortal.Data.Configurations;

public sealed class MissionConfiguration : IEntityTypeConfiguration<Mission>
{
    public void Configure(EntityTypeBuilder<Mission> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(180).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1200);
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(20).IsRequired();
        builder.Property(x => x.Priority).HasConversion<string>().HasMaxLength(20).IsRequired();
        builder.Property(x => x.Classification).HasConversion<string>().HasMaxLength(24).IsRequired();
        builder.Property(x => x.AlertLevel).HasConversion<string>().HasMaxLength(20).IsRequired();
        builder.Property(x => x.CreatedBy).HasMaxLength(120).IsRequired();
        builder.HasOne(x => x.Division)
            .WithMany(x => x.Missions)
            .HasForeignKey(x => x.DivisionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
