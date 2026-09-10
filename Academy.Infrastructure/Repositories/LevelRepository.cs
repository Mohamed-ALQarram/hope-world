using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class LevelRepository : ILevelRepository
{
    private readonly AcademyDbContext _context;

    public LevelRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<Level?> GetByIdAsync(int id)
    {
        return await _context.Levels.FindAsync(id);
    }

    public async Task<IEnumerable<Level>> GetBySubjectIdAsync(int subjectId)
    {
        return await _context.Levels.Where(l => l.SubjectId == subjectId).ToListAsync();
    }

    public async Task AddAsync(Level entity)
    {
        await _context.Levels.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Level entity)
    {
        _context.Levels.Update(entity);
        await _context.SaveChangesAsync();
    }
}
