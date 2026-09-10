using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Quizzes.CompleteQuizAttempt;

public record CompleteQuizAttemptCommand(int AttemptId) : IRequest<QuizAttemptResultDto>;
