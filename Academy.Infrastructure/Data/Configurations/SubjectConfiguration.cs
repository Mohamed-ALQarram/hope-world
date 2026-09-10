using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(s => s.SubjectId);
        builder.Property(s => s.Code).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
    }
}
