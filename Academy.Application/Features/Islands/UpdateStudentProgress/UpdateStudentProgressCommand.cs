using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using Academy.Domain.Entities;
using MediatR;

namespace Academy.Application.Features.Islands.UpdateStudentProgress;

public record UpdateStudentProgressCommand(int StudentId, UpdateStudentProgressDto Dto) : IRequest<bool>;

public class UpdateStudentProgressCommandHandler : IRequestHandler<UpdateStudentProgressCommand, bool>
{
    private readonly IStudentProgressRepository _studentProgressRepository;

    public UpdateStudentProgressCommandHandler(IStudentProgressRepository studentProgressRepository)
    {
        _studentProgressRepository = studentProgressRepository;
    }

    public async Task<bool> Handle(UpdateStudentProgressCommand request, CancellationToken cancellationToken)
    {
        var existing = await _studentProgressRepository.GetByStudentAndSubjectAsync(request.StudentId, request.Dto.SubjectId);

        if (existing == null)
        {
            var newProgress = new StudentProgress
            {
                StudentId = request.StudentId,
                SubjectId = request.Dto.SubjectId,
                CurrentLevelId = request.Dto.LevelId,
                CurrentTutorialId = request.Dto.TutorialId,
                CurrentQuizId = request.Dto.QuizId,
                UpdatedAt = DateTime.UtcNow
            };

            await _studentProgressRepository.AddAsync(newProgress);
        }
        else
        {
            if (request.Dto.LevelId.HasValue)
            {
                existing.CurrentLevelId = request.Dto.LevelId.Value;
            }

            if (request.Dto.TutorialId.HasValue)
            {
                existing.CurrentTutorialId = request.Dto.TutorialId.Value;
            }

            if (request.Dto.QuizId.HasValue)
            {
                existing.CurrentQuizId = request.Dto.QuizId.Value;
            }

            existing.UpdatedAt = DateTime.UtcNow;

            await _studentProgressRepository.UpdateAsync(existing);
        }

        return true;
    }
}
