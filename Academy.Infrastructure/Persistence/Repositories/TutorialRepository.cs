using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Persistence.Repositories;

public class TutorialRepository : ITutorialRepository
{
    private readonly AcademyDbContext _context;

    public TutorialRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<Tutorial?> GetByIdAsync(int id)
    {
        return await _context.Tutorials.FindAsync(id);
    }

    public async Task<IEnumerable<Tutorial>> GetByLevelIdAsync(int levelId)
    {
        return await _context.Tutorials.Where(t => t.LevelId == levelId).ToListAsync();
    }

    public async Task AddAsync(Tutorial entity)
    {
        await _context.Tutorials.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tutorial entity)
    {
        _context.Tutorials.Update(entity);
        await _context.SaveChangesAsync();
    }
}
