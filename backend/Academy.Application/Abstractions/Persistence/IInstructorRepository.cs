using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface IInstructorRepository
{
    Task<Instructor?> GetByIdAsync(int id);
    Task AddAsync(Instructor entity);
    Task UpdateAsync(Instructor entity);
}
