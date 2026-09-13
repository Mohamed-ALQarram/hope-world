using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface ISubjectRepository
{
    Task<Subject?> GetByIdAsync(int id);
    Task<IEnumerable<Subject>> GetAllAsync();
    Task AddAsync(Subject entity);
}
