using MediatR;

namespace Academy.Application.Features.Quizzes.StartQuizAttempt;

public record StartQuizAttemptCommand(int StudentId, int QuizId) : IRequest<int>;
