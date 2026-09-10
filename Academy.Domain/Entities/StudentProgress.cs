namespace Academy.Domain.Entities;

public class StudentProgress
{
    public int StudentProgressId { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public int? CurrentLevelId { get; set; }
    public int? CurrentTutorialId { get; set; }
    public int? CurrentQuizId { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Student Student { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
}
