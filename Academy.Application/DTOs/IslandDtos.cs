namespace Academy.Application.DTOs;

public record IslandDto(
    int IslandId,
    string Name,
    string? Description,
    bool IsActive,
    DateTime CreatedAt
);

public record CreateIslandDto(
    string Name,
    string? Description
);

public record IslandHierarchyDto(
    int IslandId,
    string Name,
    string? Description,
    bool IsActive,
    List<SubjectInIslandDto> Subjects
);

public record SubjectInIslandDto(
    int SubjectId,
    string Code,
    string Name,
    bool IsActive,
    List<LevelInSubjectDto> Levels
);

public record LevelInSubjectDto(
    int LevelId,
    int LevelNumber,
    bool IsActive,
    List<TutorialInLevelDto> Tutorials
);

public record TutorialInLevelDto(
    int TutorialId,
    string Title,
    string? Description,
    string? VideoUrl,
    string? PhotoUrl,
    string? AudioUrl,
    bool IsActive
);

public record StudentHeaderDto(
    int StudentId,
    string StudentName,
    string ClassName
);

public record QuickLaunchDto(
    int SubjectId,
    string SubjectName,
    int LevelId,
    int LevelNumber,
    int? TutorialId,
    string? TutorialTitle,
    int? QuizId
);

public record LevelProgressDto(
    int LevelId,
    int LevelNumber,
    bool IsActive,
    string Status,
    int ProgressPercentage,
    List<TutorialInLevelDto> Tutorials
);

public record SubjectProgressDto(
    int SubjectId,
    string Code,
    string Name,
    bool IsActive,
    int? CurrentLevelId,
    int? CurrentTutorialId,
    int? CurrentQuizId,
    int ProgressPercentage,
    List<LevelProgressDto> Levels
);

public record IslandWithStudentProgressDto(
    int IslandId,
    string Name,
    string? Description,
    bool IsActive,
    int ProgressPercentage,
    List<SubjectProgressDto> Subjects
);

public record StudentIslandProgressResponseDto(
    StudentHeaderDto Student,
    QuickLaunchDto? QuickLaunch,
    List<IslandWithStudentProgressDto> Islands
);

public record UpdateStudentProgressDto(
    int SubjectId,
    int? LevelId,
    int? TutorialId,
    int? QuizId
);
