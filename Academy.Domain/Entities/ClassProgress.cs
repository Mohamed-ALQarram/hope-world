namespace Academy.Domain.Entities;

public class ClassProgress
{
    public int ClassProgressId { get; set; }
    public int ClassId { get; set; }
    public int SubjectId { get; set; }
    public int LevelId { get; set; }
    public int Score { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Class Class { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
}
