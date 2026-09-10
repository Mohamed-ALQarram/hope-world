namespace Academy.Domain.Entities;

public class MatchingQuestion : Question
{
    public List<string> Items { get; set; } = new List<string>();
    // Dictionary mapping item to its correct match
    public Dictionary<string, string> CorrectMatches { get; set; } = new Dictionary<string, string>();
}
