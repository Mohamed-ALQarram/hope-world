using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Data.Configurations;

public class QuestionAttemptConfiguration : IEntityTypeConfiguration<QuestionAttempt>
{
    public void Configure(EntityTypeBuilder<QuestionAttempt> builder)
    {
        builder.HasKey(qa => qa.QuestionAttemptId);
        builder.Property(qa => qa.AnswerData).HasMaxLength(4000);

        builder.HasOne(qa => qa.QuizAttempt)
               .WithMany(q => q.QuestionAttempts)
               .HasForeignKey(qa => qa.QuizAttemptId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(qa => qa.Question)
               .WithMany(q => q.QuestionAttempts)
               .HasForeignKey(qa => qa.QuestionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
