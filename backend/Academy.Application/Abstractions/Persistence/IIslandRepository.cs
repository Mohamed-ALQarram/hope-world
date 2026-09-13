using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface IIslandRepository
{
    Task<Island?> GetByIdAsync(int id);
    Task<IEnumerable<Island>> GetAllAsync();
    Task<IEnumerable<Island>> GetHierarchyAsync();
    Task<Island?> GetHierarchyByIdAsync(int id);
    Task AddAsync(Island entity);
    Task UpdateAsync(Island entity);
}
