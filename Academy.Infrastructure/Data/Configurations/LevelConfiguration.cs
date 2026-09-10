using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Data.Configurations;

public class LevelConfiguration : IEntityTypeConfiguration<Level>
{
    public void Configure(EntityTypeBuilder<Level> builder)
    {
        builder.HasKey(l => l.LevelId);

        builder.HasOne(l => l.Subject)
               .WithMany(s => s.Levels)
               .HasForeignKey(l => l.SubjectId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
