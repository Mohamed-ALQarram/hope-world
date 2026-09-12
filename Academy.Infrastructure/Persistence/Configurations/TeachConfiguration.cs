using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Persistence.Configurations;

public class TeachConfiguration : IEntityTypeConfiguration<Teach>
{
    public void Configure(EntityTypeBuilder<Teach> builder)
    {
        builder.HasKey(t => t.TeachId);

        // A Class + Subject cannot have more than one Instructor
        builder.HasIndex(t => new { t.ClassId, t.SubjectId }).IsUnique();

        builder.HasOne(t => t.Class)
               .WithMany(c => c.Teaches)
               .HasForeignKey(t => t.ClassId)
               .OnDelete(DeleteBehavior.Cascade);

        // To ensure the SubjectId matches the Instructor's SubjectId, use composite foreign key
        builder.HasOne(t => t.Instructor)
               .WithMany(i => i.Teaches)
               .HasForeignKey(t => new { t.InstructorId, t.SubjectId })
               .HasPrincipalKey(i => new { i.InstructorId, i.SubjectId })
               .OnDelete(DeleteBehavior.Restrict);

        // Map the Subject navigation
        builder.HasOne(t => t.Subject)
               .WithMany(s => s.Teaches)
               .HasForeignKey(t => t.SubjectId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
