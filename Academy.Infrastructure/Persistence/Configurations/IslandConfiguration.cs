using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Persistence.Configurations;

public class IslandConfiguration : IEntityTypeConfiguration<Island>
{
    public void Configure(EntityTypeBuilder<Island> builder)
    {
        builder.HasKey(i => i.IslandId);
        builder.Property(i => i.Name).IsRequired().HasMaxLength(150);
        builder.Property(i => i.Description).HasMaxLength(500);

        builder.HasMany(i => i.Subjects)
               .WithOne(s => s.Island)
               .HasForeignKey(s => s.IslandId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
