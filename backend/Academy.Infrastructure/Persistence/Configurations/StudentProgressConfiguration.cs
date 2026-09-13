using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Persistence.Configurations;

public class StudentProgressConfiguration : IEntityTypeConfiguration<StudentProgress>
{
    public void Configure(EntityTypeBuilder<StudentProgress> builder)
    {
        builder.HasKey(sp => sp.StudentProgressId);

        // StudentProgress tells the system where the individual student should continue.
        // Business rule: ONE StudentProgress record for Student + Subject
        builder.HasIndex(sp => new { sp.StudentId, sp.SubjectId }).IsUnique();

        builder.HasOne(sp => sp.Student)
               .WithMany(s => s.StudentProgresses)
               .HasForeignKey(sp => sp.StudentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sp => sp.Subject)
               .WithMany(s => s.StudentProgresses)
               .HasForeignKey(sp => sp.SubjectId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
