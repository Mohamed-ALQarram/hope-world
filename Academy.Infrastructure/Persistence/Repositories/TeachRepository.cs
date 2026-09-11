using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Persistence.Repositories;

public class TeachRepository : ITeachRepository
{
    private readonly AcademyDbContext _context;

    public TeachRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Teach>> GetByInstructorIdAsync(int instructorId)
    {
        return await _context.Teaches.Where(t => t.InstructorId == instructorId).ToListAsync();
    }

    public async Task<Teach?> GetByClassAndSubjectAsync(int classId, int subjectId)
    {
        return await _context.Teaches
            .FirstOrDefaultAsync(t => t.ClassId == classId && t.SubjectId == subjectId);
    }

    public async Task AddAsync(Teach entity)
    {
        await _context.Teaches.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Teach entity)
    {
        _context.Teaches.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
