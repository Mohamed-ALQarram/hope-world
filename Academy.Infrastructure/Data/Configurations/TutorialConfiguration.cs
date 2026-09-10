using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Data.Configurations;

public class TutorialConfiguration : IEntityTypeConfiguration<Tutorial>
{
    public void Configure(EntityTypeBuilder<Tutorial> builder)
    {
        builder.HasKey(t => t.TutorialId);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
        builder.Property(t => t.VideoUrl).HasMaxLength(500);
        builder.Property(t => t.PhotoUrl).HasMaxLength(500);
        builder.Property(t => t.AudioUrl).HasMaxLength(500);

        builder.HasOne(t => t.Level)
               .WithMany(l => l.Tutorials)
               .HasForeignKey(t => t.LevelId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
