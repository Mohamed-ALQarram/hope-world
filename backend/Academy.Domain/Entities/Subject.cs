namespace Academy.Domain.Entities;

public class Subject
{
    public int SubjectId { get; set; }
    public int? IslandId { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }

    public Island? Island { get; set; }
    public ICollection<Level> Levels { get; set; } = new List<Level>();
    public ICollection<StudentProgress> StudentProgresses { get; set; } = new List<StudentProgress>();
    public ICollection<ClassProgress> ClassProgresses { get; set; } = new List<ClassProgress>();
    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    public ICollection<Teach> Teaches { get; set; } = new List<Teach>();
}
