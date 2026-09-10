namespace Academy.Domain.Entities;

public class QuestionAttempt
{
    public int QuestionAttemptId { get; set; }
    public int QuizAttemptId { get; set; }
    public int QuestionId { get; set; }
    public string? AnswerData { get; set; }
    public bool IsCorrect { get; set; }
    public DateTime AnsweredAt { get; set; }

    public QuizAttempt QuizAttempt { get; set; } = null!;
    public Question Question { get; set; } = null!;
}
