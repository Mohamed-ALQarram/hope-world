namespace Academy.Domain.Entities;

public class Island
{
    public int IslandId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
