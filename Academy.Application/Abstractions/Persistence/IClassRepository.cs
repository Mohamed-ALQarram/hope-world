using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface IClassRepository
{
    Task<Class?> GetByIdAsync(int id);
    Task<Class?> GetByNameAsync(string className);
    Task<IEnumerable<Class>> GetAllAsync();
    Task AddAsync(Class entity);
    Task UpdateAsync(Class entity);
}
