namespace Academy.Domain.Entities;

public class CompleteQuestion : Question
{
    public string CorrectAnswer { get; set; } = null!;
}
