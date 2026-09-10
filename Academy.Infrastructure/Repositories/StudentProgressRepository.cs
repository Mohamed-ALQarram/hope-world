using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class StudentProgressRepository : IStudentProgressRepository
{
    private readonly AcademyDbContext _context;

    public StudentProgressRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<StudentProgress?> GetByStudentAndSubjectAsync(int studentId, int subjectId)
    {
        return await _context.StudentProgresses
            .FirstOrDefaultAsync(sp => sp.StudentId == studentId && sp.SubjectId == subjectId);
    }

    public async Task<IEnumerable<StudentProgress>> GetByStudentIdAsync(int studentId)
    {
        return await _context.StudentProgresses.Where(sp => sp.StudentId == studentId).ToListAsync();
    }

    public async Task AddAsync(StudentProgress entity)
    {
        await _context.StudentProgresses.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(StudentProgress entity)
    {
        _context.StudentProgresses.Update(entity);
        await _context.SaveChangesAsync();
    }
}
