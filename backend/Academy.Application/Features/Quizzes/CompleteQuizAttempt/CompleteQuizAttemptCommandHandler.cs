using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Quizzes.CompleteQuizAttempt;

public class CompleteQuizAttemptCommandHandler : IRequestHandler<CompleteQuizAttemptCommand, QuizAttemptResultDto>
{
    private readonly IQuizAttemptRepository _attemptRepo;

    public CompleteQuizAttemptCommandHandler(IQuizAttemptRepository attemptRepo)
    {
        _attemptRepo = attemptRepo;
    }

    public async Task<QuizAttemptResultDto> Handle(CompleteQuizAttemptCommand request, CancellationToken cancellationToken)
    {
        var attempt = await _attemptRepo.GetByIdAsync(request.AttemptId);
        if (attempt == null || attempt.CompletedAt != null) throw new InvalidOperationException("Invalid attempt");

        attempt.CompletedAt = DateTime.UtcNow;
        attempt.CorrectAnswers = attempt.QuestionAttempts.Count(qa => qa.IsCorrect);
        
        if (attempt.TotalQuestions == 0) throw new InvalidOperationException("Cannot complete quiz with no questions");

        await _attemptRepo.UpdateAsync(attempt);

        return new QuizAttemptResultDto
        {
            QuizAttemptId = attempt.QuizAttemptId,
            CorrectAnswers = attempt.CorrectAnswers,
            TotalQuestions = attempt.TotalQuestions
        };
    }
}
