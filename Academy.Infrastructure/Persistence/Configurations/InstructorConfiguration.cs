using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Persistence.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(i => i.InstructorId);
        builder.Property(i => i.FullName).IsRequired().HasMaxLength(200);

        // 1 Instructor teaches 1 Subject
        builder.HasOne(i => i.Subject)
               .WithMany(s => s.Instructors)
               .HasForeignKey(i => i.SubjectId)
               .OnDelete(DeleteBehavior.Restrict);

        // Composite Unique constraint to allow composite foreign key in Teach table
        builder.HasIndex(i => new { i.InstructorId, i.SubjectId }).IsUnique();
    }
}
