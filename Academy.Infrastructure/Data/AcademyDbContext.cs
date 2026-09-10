using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Academy.Infrastructure.Data;

public class AcademyDbContext : DbContext
{
    public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options) { }

    public DbSet<Class> Classes { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Instructor> Instructors { get; set; } = null!;
    public DbSet<Subject> Subjects { get; set; } = null!;
    public DbSet<Level> Levels { get; set; } = null!;
    public DbSet<Tutorial> Tutorials { get; set; } = null!;
    public DbSet<Quiz> Quizzes { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<ChooseQuestion> ChooseQuestions { get; set; } = null!;
    public DbSet<MatchingQuestion> MatchingQuestions { get; set; } = null!;
    public DbSet<DragDropQuestion> DragDropQuestions { get; set; } = null!;
    public DbSet<CompleteQuestion> CompleteQuestions { get; set; } = null!;
    public DbSet<QuizAttempt> QuizAttempts { get; set; } = null!;
    public DbSet<QuestionAttempt> QuestionAttempts { get; set; } = null!;
    public DbSet<StudentProgress> StudentProgresses { get; set; } = null!;
    public DbSet<ClassProgress> ClassProgresses { get; set; } = null!;
    public DbSet<Teach> Teaches { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
