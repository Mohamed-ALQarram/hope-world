using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Islands.GetIslandHierarchy;

public record GetIslandHierarchyQuery(int? IslandId = null) : IRequest<IEnumerable<IslandHierarchyDto>>;

public class GetIslandHierarchyQueryHandler : IRequestHandler<GetIslandHierarchyQuery, IEnumerable<IslandHierarchyDto>>
{
    private readonly IIslandRepository _islandRepository;

    public GetIslandHierarchyQueryHandler(IIslandRepository islandRepository)
    {
        _islandRepository = islandRepository;
    }

    public async Task<IEnumerable<IslandHierarchyDto>> Handle(GetIslandHierarchyQuery request, CancellationToken cancellationToken)
    {
        var islands = request.IslandId.HasValue
            ? (await _islandRepository.GetHierarchyByIdAsync(request.IslandId.Value) is { } island ? new[] { island } : Array.Empty<Academy.Domain.Entities.Island>())
            : await _islandRepository.GetHierarchyAsync();

        return islands.Select(island => new IslandHierarchyDto(
            island.IslandId,
            island.Name,
            island.Description,
            island.IsActive,
            island.Subjects.Select(subject => new SubjectInIslandDto(
                subject.SubjectId,
                subject.Code,
                subject.Name,
                subject.IsActive,
                subject.Levels.Select(level => new LevelInSubjectDto(
                    level.LevelId,
                    level.LevelNumber,
                    level.IsActive,
                    level.Tutorials.Select(tutorial => new TutorialInLevelDto(
                        tutorial.TutorialId,
                        tutorial.Title,
                        tutorial.Description,
                        tutorial.VideoUrl,
                        tutorial.PhotoUrl,
                        tutorial.AudioUrl,
                        tutorial.IsActive
                    )).ToList()
                )).ToList()
            )).ToList()
        ));
    }
}
