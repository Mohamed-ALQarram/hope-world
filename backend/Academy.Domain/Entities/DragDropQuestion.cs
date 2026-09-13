namespace Academy.Domain.Entities;

public class DragDropQuestion : Question
{
    public List<string> Items { get; set; } = new List<string>();
    public Dictionary<string, string> CorrectMatches { get; set; } = new Dictionary<string, string>();
}
