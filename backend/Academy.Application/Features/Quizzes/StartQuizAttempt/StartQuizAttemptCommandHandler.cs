using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using MediatR;

namespace Academy.Application.Features.Quizzes.StartQuizAttempt;

public class StartQuizAttemptCommandHandler : IRequestHandler<StartQuizAttemptCommand, int>
{
    private readonly IQuizAttemptRepository _attemptRepo;
    private readonly IQuestionRepository _questionRepo;

    public StartQuizAttemptCommandHandler(IQuizAttemptRepository attemptRepo, IQuestionRepository questionRepo)
    {
        _attemptRepo = attemptRepo;
        _questionRepo = questionRepo;
    }

    public async Task<int> Handle(StartQuizAttemptCommand request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepo.GetByQuizIdAsync(request.QuizId);
        
        var attempt = new QuizAttempt
        {
            StudentId = request.StudentId,
            QuizId = request.QuizId,
            TotalQuestions = questions.Count(),
            StartedAt = DateTime.UtcNow,
            CorrectAnswers = 0
        };

        await _attemptRepo.AddAsync(attempt);
        return attempt.QuizAttemptId;
    }
}
