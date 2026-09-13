using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.StudentId);
        builder.Property(s => s.StudentName).IsRequired().HasMaxLength(200);

        builder.HasOne(s => s.Class)
               .WithMany(c => c.Students)
               .HasForeignKey(s => s.ClassId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
