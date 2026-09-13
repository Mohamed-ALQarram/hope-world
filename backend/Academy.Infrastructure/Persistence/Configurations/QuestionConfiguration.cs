using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Academy.Infrastructure.Persistence.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        // TPT Inheritance
        builder.UseTptMappingStrategy();
        builder.ToTable("Questions");

        builder.HasKey(q => q.QuestionId);
        builder.Property(q => q.QuestionText).IsRequired();

        builder.HasOne(q => q.Quiz)
               .WithMany(quiz => quiz.Questions)
               .HasForeignKey(q => q.QuizId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

public class ChooseQuestionConfiguration : IEntityTypeConfiguration<ChooseQuestion>
{
    public void Configure(EntityTypeBuilder<ChooseQuestion> builder)
    {
        builder.ToTable("ChooseQuestions");
        builder.Property(q => q.CorrectOption).IsRequired().HasMaxLength(500);

        builder.Property(q => q.Options)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>())
            .HasColumnType("nvarchar(max)");
    }
}

public class MatchingQuestionConfiguration : IEntityTypeConfiguration<MatchingQuestion>
{
    public void Configure(EntityTypeBuilder<MatchingQuestion> builder)
    {
        builder.ToTable("MatchingQuestions");

        builder.Property(q => q.Items)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>())
            .HasColumnType("nvarchar(max)");

        builder.Property(q => q.CorrectMatches)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions?)null) ?? new Dictionary<string, string>())
            .HasColumnType("nvarchar(max)");
    }
}

public class DragDropQuestionConfiguration : IEntityTypeConfiguration<DragDropQuestion>
{
    public void Configure(EntityTypeBuilder<DragDropQuestion> builder)
    {
        builder.ToTable("DragDropQuestions");

        builder.Property(q => q.Items)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>())
            .HasColumnType("nvarchar(max)");

        builder.Property(q => q.CorrectMatches)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions?)null) ?? new Dictionary<string, string>())
            .HasColumnType("nvarchar(max)");
    }
}

public class CompleteQuestionConfiguration : IEntityTypeConfiguration<CompleteQuestion>
{
    public void Configure(EntityTypeBuilder<CompleteQuestion> builder)
    {
        builder.ToTable("CompleteQuestions");
        builder.Property(q => q.CorrectAnswer).IsRequired().HasMaxLength(500);
    }
}
