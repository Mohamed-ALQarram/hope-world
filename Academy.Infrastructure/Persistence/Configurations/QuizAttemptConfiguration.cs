using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Persistence.Configurations;

public class QuizAttemptConfiguration : IEntityTypeConfiguration<QuizAttempt>
{
    public void Configure(EntityTypeBuilder<QuizAttempt> builder)
    {
        builder.HasKey(qa => qa.QuizAttemptId);

        // Do NOT make StudentId + QuizId unique as students can repeat quizzes.
        // builder.HasIndex(qa => new { qa.StudentId, qa.QuizId }).IsUnique(); // <-- Omitted on purpose

        builder.HasOne(qa => qa.Student)
               .WithMany(s => s.QuizAttempts)
               .HasForeignKey(qa => qa.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(qa => qa.Quiz)
               .WithMany(q => q.QuizAttempts)
               .HasForeignKey(qa => qa.QuizId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
