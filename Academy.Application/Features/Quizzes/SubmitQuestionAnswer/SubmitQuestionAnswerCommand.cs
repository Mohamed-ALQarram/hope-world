using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Quizzes.SubmitQuestionAnswer;

public record SubmitQuestionAnswerCommand(int AttemptId, QuestionAnswerDto AnswerDto) : IRequest;
