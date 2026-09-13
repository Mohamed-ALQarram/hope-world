using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using Academy.Domain.Entities;
using MediatR;

namespace Academy.Application.Features.Quizzes.SubmitQuestionAnswer;

public class SubmitQuestionAnswerCommandHandler : IRequestHandler<SubmitQuestionAnswerCommand>
{
    private readonly IQuizAttemptRepository _attemptRepo;
    private readonly IQuestionRepository _questionRepo;

    public SubmitQuestionAnswerCommandHandler(IQuizAttemptRepository attemptRepo, IQuestionRepository questionRepo)
    {
        _attemptRepo = attemptRepo;
        _questionRepo = questionRepo;
    }

    public async Task Handle(SubmitQuestionAnswerCommand request, CancellationToken cancellationToken)
    {
        var attempt = await _attemptRepo.GetByIdAsync(request.AttemptId);
        if (attempt == null || attempt.CompletedAt != null) throw new InvalidOperationException("Invalid or completed attempt");

        var question = await _questionRepo.GetByIdAsync(request.AnswerDto.QuestionId);
        if (question == null || question.QuizId != attempt.QuizId) throw new InvalidOperationException("Invalid question");

        bool isCorrect = false;

        if (question is ChooseQuestion cq) isCorrect = cq.CorrectOption == request.AnswerDto.AnswerData;
        else if (question is CompleteQuestion cpq) isCorrect = cpq.CorrectAnswer.Equals(request.AnswerDto.AnswerData, StringComparison.OrdinalIgnoreCase);

        var qa = new QuestionAttempt
        {
            QuizAttemptId = request.AttemptId,
            QuestionId = request.AnswerDto.QuestionId,
            AnswerData = request.AnswerDto.AnswerData,
            IsCorrect = isCorrect,
            AnsweredAt = DateTime.UtcNow
        };

        attempt.QuestionAttempts.Add(qa);
        await _attemptRepo.UpdateAsync(attempt);
    }
}
