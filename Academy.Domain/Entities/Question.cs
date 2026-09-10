namespace Academy.Domain.Entities;

public abstract class Question
{
    public int QuestionId { get; set; }
    public int QuizId { get; set; }
    public string QuestionText { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public Quiz Quiz { get; set; } = null!;
    public ICollection<QuestionAttempt> QuestionAttempts { get; set; } = new List<QuestionAttempt>();
}
