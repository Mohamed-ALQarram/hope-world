using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Islands.GetIslands;

public record GetIslandsQuery : IRequest<IEnumerable<IslandDto>>;

public class GetIslandsQueryHandler : IRequestHandler<GetIslandsQuery, IEnumerable<IslandDto>>
{
    private readonly IIslandRepository _islandRepository;

    public GetIslandsQueryHandler(IIslandRepository islandRepository)
    {
        _islandRepository = islandRepository;
    }

    public async Task<IEnumerable<IslandDto>> Handle(GetIslandsQuery request, CancellationToken cancellationToken)
    {
        var islands = await _islandRepository.GetAllAsync();
        return islands.Select(i => new IslandDto(
            i.IslandId,
            i.Name,
            i.Description,
            i.IsActive,
            i.CreatedAt
        ));
    }
}
