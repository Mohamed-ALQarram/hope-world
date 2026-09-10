namespace Academy.Domain.Entities;

public class QuizAttempt
{
    public int QuizAttemptId { get; set; }
    public int StudentId { get; set; }
    public int QuizId { get; set; }
    public int CorrectAnswers { get; set; }
    public int TotalQuestions { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public Student Student { get; set; } = null!;
    public Quiz Quiz { get; set; } = null!;
    public ICollection<QuestionAttempt> QuestionAttempts { get; set; } = new List<QuestionAttempt>();
}
