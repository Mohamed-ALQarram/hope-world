using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(int id);
    Task<Student?> GetByNameAndClassIdAsync(string studentName, int classId);
    Task<IEnumerable<Student>> GetByClassIdAsync(int classId);
    Task AddAsync(Student entity);
    Task UpdateAsync(Student entity);
}
