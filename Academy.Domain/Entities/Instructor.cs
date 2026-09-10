namespace Academy.Domain.Entities;

public class Instructor
{
    public int InstructorId { get; set; }
    public int SubjectId { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    public Subject Subject { get; set; } = null!;
    public ICollection<Teach> Teaches { get; set; } = new List<Teach>();
}
