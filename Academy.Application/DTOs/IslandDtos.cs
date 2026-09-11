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
