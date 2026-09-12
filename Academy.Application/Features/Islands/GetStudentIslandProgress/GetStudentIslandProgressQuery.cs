using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using Academy.Domain.Entities;
using MediatR;

namespace Academy.Application.Features.Islands.GetStudentIslandProgress;

public record GetStudentIslandProgressQuery(int StudentId, int? IslandId = null) : IRequest<StudentIslandProgressResponseDto>;

public class GetStudentIslandProgressQueryHandler : IRequestHandler<GetStudentIslandProgressQuery, StudentIslandProgressResponseDto>
{
    private readonly IIslandRepository _islandRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IStudentProgressRepository _studentProgressRepository;

    public GetStudentIslandProgressQueryHandler(
        IIslandRepository islandRepository,
        IStudentRepository studentRepository,
        IStudentProgressRepository studentProgressRepository)
    {
        _islandRepository = islandRepository;
        _studentRepository = studentRepository;
        _studentProgressRepository = studentProgressRepository;
    }

    public async Task<StudentIslandProgressResponseDto> Handle(GetStudentIslandProgressQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.StudentId);
        if (student == null)
        {
            throw new KeyNotFoundException($"Student with ID {request.StudentId} was not found.");
        }

        var islands = request.IslandId.HasValue
            ? (await _islandRepository.GetHierarchyByIdAsync(request.IslandId.Value) is { } singleIsland ? new[] { singleIsland } : Array.Empty<Island>())
            : await _islandRepository.GetHierarchyAsync();

        var studentProgresses = (await _studentProgressRepository.GetByStudentIdAsync(request.StudentId))
            .ToDictionary(sp => sp.SubjectId);

        QuickLaunchDto? quickLaunch = null;
        var latestProgress = await _studentProgressRepository.GetLatestProgressAsync(request.StudentId);

        if (latestProgress != null)
        {
            var matchedIsland = islands.FirstOrDefault(i => i.Subjects.Any(s => s.SubjectId == latestProgress.SubjectId));
            var matchedSubject = matchedIsland?.Subjects.FirstOrDefault(s => s.SubjectId == latestProgress.SubjectId);
            var matchedLevel = matchedSubject?.Levels.FirstOrDefault(l => l.LevelId == latestProgress.CurrentLevelId);
            var matchedTutorial = matchedLevel?.Tutorials.FirstOrDefault(t => t.TutorialId == latestProgress.CurrentTutorialId);

            if (matchedSubject != null && matchedLevel != null)
            {
                quickLaunch = new QuickLaunchDto(
                    matchedSubject.SubjectId,
                    matchedSubject.Name,
                    matchedLevel.LevelId,
                    matchedLevel.LevelNumber,
                    matchedTutorial?.TutorialId,
                    matchedTutorial?.Title,
                    latestProgress.CurrentQuizId
                );
            }
        }

        var islandDtos = new List<IslandWithStudentProgressDto>();

        foreach (var island in islands)
        {
            var subjectDtos = new List<SubjectProgressDto>();
            int totalIslandLevels = 0;
            int completedIslandLevels = 0;

            foreach (var subject in island.Subjects)
            {
                studentProgresses.TryGetValue(subject.SubjectId, out var sp);
                var orderedLevels = subject.Levels.OrderBy(l => l.LevelNumber).ToList();

                var levelDtos = new List<LevelProgressDto>();
                int subjectLevelCount = orderedLevels.Count;
                int subjectCompletedLevels = 0;

                int currentLevelNumber = 1;
                if (sp?.CurrentLevelId != null)
                {
                    var activeLevel = orderedLevels.FirstOrDefault(l => l.LevelId == sp.CurrentLevelId);
                    if (activeLevel != null)
                    {
                        currentLevelNumber = activeLevel.LevelNumber;
                    }
                }

                foreach (var level in orderedLevels)
                {
                    totalIslandLevels++;
                    string status;
                    int levelProgressPct;

                    if (level.LevelNumber < currentLevelNumber)
                    {
                        status = "Completed";
                        levelProgressPct = 100;
                        subjectCompletedLevels++;
                        completedIslandLevels++;
                    }
                    else if (level.LevelNumber == currentLevelNumber)
                    {
                        status = "Current";
                        levelProgressPct = 50;
                    }
                    else
                    {
                        status = "Locked";
                        levelProgressPct = 0;
                    }

                    var tutorialDtos = level.Tutorials.Select(t => new TutorialInLevelDto(
                        t.TutorialId,
                        t.Title,
                        t.Description,
                        t.VideoUrl,
                        t.PhotoUrl,
                        t.AudioUrl,
                        t.IsActive
                    )).ToList();

                    levelDtos.Add(new LevelProgressDto(
                        level.LevelId,
                        level.LevelNumber,
                        level.IsActive,
                        status,
                        levelProgressPct,
                        tutorialDtos
                    ));
                }

                if (quickLaunch == null && orderedLevels.Count > 0)
                {
                    var firstLevel = orderedLevels.First();
                    var firstTutorial = firstLevel.Tutorials.FirstOrDefault();
                    quickLaunch = new QuickLaunchDto(
                        subject.SubjectId,
                        subject.Name,
                        firstLevel.LevelId,
                        firstLevel.LevelNumber,
                        firstTutorial?.TutorialId,
                        firstTutorial?.Title,
                        null
                    );
                }

                int subjectPct = subjectLevelCount > 0 ? (subjectCompletedLevels * 100) / subjectLevelCount : 0;

                subjectDtos.Add(new SubjectProgressDto(
                    subject.SubjectId,
                    subject.Code,
                    subject.Name,
                    subject.IsActive,
                    sp?.CurrentLevelId ?? orderedLevels.FirstOrDefault()?.LevelId,
                    sp?.CurrentTutorialId ?? orderedLevels.FirstOrDefault()?.Tutorials.FirstOrDefault()?.TutorialId,
                    sp?.CurrentQuizId,
                    subjectPct,
                    levelDtos
                ));
            }

            int islandPct = totalIslandLevels > 0 ? (completedIslandLevels * 100) / totalIslandLevels : 0;

            islandDtos.Add(new IslandWithStudentProgressDto(
                island.IslandId,
                island.Name,
                island.Description,
                island.IsActive,
                islandPct,
                subjectDtos
            ));
        }

        var headerDto = new StudentHeaderDto(
            student.StudentId,
            student.StudentName,
            student.Class?.ClassName ?? "Unassigned"
        );

        return new StudentIslandProgressResponseDto(
            headerDto,
            quickLaunch,
            islandDtos
        );
    }
}
