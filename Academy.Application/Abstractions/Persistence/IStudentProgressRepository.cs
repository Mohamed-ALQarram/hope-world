using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface IStudentProgressRepository
{
    Task<StudentProgress?> GetByStudentAndSubjectAsync(int studentId, int subjectId);
    Task<IEnumerable<StudentProgress>> GetByStudentIdAsync(int studentId);
    Task<StudentProgress?> GetLatestProgressAsync(int studentId);
    Task AddAsync(StudentProgress entity);
    Task UpdateAsync(StudentProgress entity);
}
