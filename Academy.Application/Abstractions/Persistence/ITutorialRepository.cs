using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface ITutorialRepository
{
    Task<Tutorial?> GetByIdAsync(int id);
    Task<IEnumerable<Tutorial>> GetByLevelIdAsync(int levelId);
    Task AddAsync(Tutorial entity);
    Task UpdateAsync(Tutorial entity);
}
