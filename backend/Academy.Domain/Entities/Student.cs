namespace Academy.Domain.Entities;

public class Student
{
    public int StudentId { get; set; }
    public int ClassId { get; set; }
    public string StudentName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    public Class Class { get; set; } = null!;
    public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
    public ICollection<StudentProgress> StudentProgresses { get; set; } = new List<StudentProgress>();
}
