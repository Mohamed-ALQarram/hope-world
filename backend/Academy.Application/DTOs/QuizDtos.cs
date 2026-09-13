namespace Academy.Application.DTOs;

public class QuizAttemptResultDto
{
    public int QuizAttemptId { get; set; }
    public int CorrectAnswers { get; set; }
    public int TotalQuestions { get; set; }
    public decimal ScorePercentage => TotalQuestions == 0 ? 0 : (decimal)CorrectAnswers / TotalQuestions * 100;
}

public class QuestionAnswerDto
{
    public int QuestionId { get; set; }
    public string AnswerData { get; set; } = null!;
}
