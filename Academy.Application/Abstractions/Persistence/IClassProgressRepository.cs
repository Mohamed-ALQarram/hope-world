using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface IClassProgressRepository
{
    Task<ClassProgress?> GetByClassAndSubjectAsync(int classId, int subjectId);
    Task AddAsync(ClassProgress entity);
    Task UpdateAsync(ClassProgress entity);
}
