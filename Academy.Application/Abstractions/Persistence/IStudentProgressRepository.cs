using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface IStudentProgressRepository
{
    Task<StudentProgress?> GetByStudentAndSubjectAsync(int studentId, int subjectId);
    Task AddAsync(StudentProgress entity);
    Task UpdateAsync(StudentProgress entity);
}
