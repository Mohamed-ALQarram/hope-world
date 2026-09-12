using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using Academy.Domain.Entities;
using MediatR;

namespace Academy.Application.Features.Islands.CreateIsland;

public record CreateIslandCommand(string Name, string? Description) : IRequest<int>;

public class CreateIslandCommandHandler : IRequestHandler<CreateIslandCommand, int>
{
    private readonly IIslandRepository _islandRepository;

    public CreateIslandCommandHandler(IIslandRepository islandRepository)
    {
        _islandRepository = islandRepository;
    }

    public async Task<int> Handle(CreateIslandCommand request, CancellationToken cancellationToken)
    {
        var island = new Island
        {
            Name = request.Name,
            Description = request.Description,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        await _islandRepository.AddAsync(island);
        return island.IslandId;
    }
}
