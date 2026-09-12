using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Persistence.Configurations;

public class ClassProgressConfiguration : IEntityTypeConfiguration<ClassProgress>
{
    public void Configure(EntityTypeBuilder<ClassProgress> builder)
    {
        builder.HasKey(cp => cp.ClassProgressId);

        // Business rule: ONE ClassProgress record for Class + Subject
        builder.HasIndex(cp => new { cp.ClassId, cp.SubjectId }).IsUnique();

        builder.HasOne(cp => cp.Class)
               .WithMany(c => c.ClassProgresses)
               .HasForeignKey(cp => cp.ClassId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cp => cp.Subject)
               .WithMany(s => s.ClassProgresses)
               .HasForeignKey(cp => cp.SubjectId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
