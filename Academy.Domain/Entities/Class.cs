namespace Academy.Domain.Entities;

public class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<ClassProgress> ClassProgresses { get; set; } = new List<ClassProgress>();
    public ICollection<Teach> Teaches { get; set; } = new List<Teach>();
}
