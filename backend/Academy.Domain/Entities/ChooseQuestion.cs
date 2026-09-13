namespace Academy.Domain.Entities;

public class ChooseQuestion : Question
{
    public List<string> Options { get; set; } = new List<string>();
    public string CorrectOption { get; set; } = null!;
}
