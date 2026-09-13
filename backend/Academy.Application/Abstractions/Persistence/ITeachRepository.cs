using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface ITeachRepository
{
    Task<IEnumerable<Teach>> GetByInstructorIdAsync(int instructorId);
    Task AddAsync(Teach entity);
}
