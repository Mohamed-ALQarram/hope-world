using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AcademyDbContext _context;

    public StudentRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.Include(s => s.Class).FirstOrDefaultAsync(s => s.StudentId == id);
    }

    public async Task<Student?> GetByNameAndClassIdAsync(string studentName, int classId)
    {
        return await _context.Students.Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.ClassId == classId && s.StudentName.ToLower() == studentName.ToLower());
    }

    public async Task<IEnumerable<Student>> GetByClassIdAsync(int classId)
    {
        return await _context.Students.Where(s => s.ClassId == classId).ToListAsync();
    }

    public async Task AddAsync(Student entity)
    {
        await _context.Students.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student entity)
    {
        _context.Students.Update(entity);
        await _context.SaveChangesAsync();
    }
}
