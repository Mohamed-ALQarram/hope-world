namespace Academy.Domain.Entities;

public class Level
{
    public int LevelId { get; set; }
    public int SubjectId { get; set; }
    public int LevelNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    public Subject Subject { get; set; } = null!;
    public ICollection<Tutorial> Tutorials { get; set; } = new List<Tutorial>();
}
