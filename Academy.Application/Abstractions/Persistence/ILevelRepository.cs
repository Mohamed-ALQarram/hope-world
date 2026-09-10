using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface ILevelRepository
{
    Task<Level?> GetByIdAsync(int id);
    Task<IEnumerable<Level>> GetBySubjectIdAsync(int subjectId);
    Task AddAsync(Level entity);
}
