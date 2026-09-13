using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Persistence.Configurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.HasKey(q => q.QuizId);
        builder.Property(q => q.Title).IsRequired().HasMaxLength(200);

        builder.HasOne(q => q.Tutorial)
               .WithMany(t => t.Quizzes)
               .HasForeignKey(q => q.TutorialId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
