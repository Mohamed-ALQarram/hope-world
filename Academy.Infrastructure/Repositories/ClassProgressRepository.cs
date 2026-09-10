using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class ClassProgressRepository : IClassProgressRepository
{
    private readonly AcademyDbContext _context;

    public ClassProgressRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<ClassProgress?> GetByClassAndSubjectAsync(int classId, int subjectId)
    {
        return await _context.ClassProgresses
            .FirstOrDefaultAsync(cp => cp.ClassId == classId && cp.SubjectId == subjectId);
    }

    public async Task<IEnumerable<ClassProgress>> GetByClassIdAsync(int classId)
    {
        return await _context.ClassProgresses.Where(cp => cp.ClassId == classId).ToListAsync();
    }

    public async Task AddAsync(ClassProgress entity)
    {
        await _context.ClassProgresses.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ClassProgress entity)
    {
        _context.ClassProgresses.Update(entity);
        await _context.SaveChangesAsync();
    }
}
