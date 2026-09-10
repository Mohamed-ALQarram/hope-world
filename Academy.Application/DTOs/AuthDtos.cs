namespace Academy.Application.DTOs;

public class RegisterStudentDto
{
    public string ClassName { get; set; } = null!;
    public string StudentName { get; set; } = null!;
}

public class LoginRequestDto
{
    public int ClassId { get; set; }
    public int StudentId { get; set; }
}

public class StudentAuthResponseDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = null!;
    public int ClassId { get; set; }
    public string ClassName { get; set; } = null!;
    public string Token { get; set; } = null!;
}

public class ClassLookupDto
{
    public int ClassId { get; set; }
    public string ClassName { get; set; } = null!;
}

public class StudentLookupDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = null!;
}
