namespace Academy.Domain.Entities;

public class Tutorial
{
    public int TutorialId { get; set; }
    public int LevelId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }
    public string? PhotoUrl { get; set; }
    public string? AudioUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public Level Level { get; set; } = null!;
    public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
