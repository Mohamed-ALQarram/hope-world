namespace Academy.Domain.Entities;

public class Teach
{
    public int TeachId { get; set; }
    public int InstructorId { get; set; }
    public int SubjectId { get; set; }
    public int ClassId { get; set; }

    public Instructor Instructor { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
    public Class Class { get; set; } = null!;
}
