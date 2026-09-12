using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Persistence.Repositories;

public class IslandRepository : IIslandRepository
{
    private readonly AcademyDbContext _context;

    public IslandRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<Island?> GetByIdAsync(int id)
    {
        return await _context.Islands.FindAsync(id);
    }

    public async Task<IEnumerable<Island>> GetAllAsync()
    {
        return await _context.Islands.ToListAsync();
    }

    public async Task<IEnumerable<Island>> GetHierarchyAsync()
    {
        return await _context.Islands
            .Include(i => i.Subjects)
                .ThenInclude(s => s.Levels)
                    .ThenInclude(l => l.Tutorials)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Island?> GetHierarchyByIdAsync(int id)
    {
        return await _context.Islands
            .Include(i => i.Subjects)
                .ThenInclude(s => s.Levels)
                    .ThenInclude(l => l.Tutorials)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.IslandId == id);
    }

    public async Task AddAsync(Island entity)
    {
        await _context.Islands.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Island entity)
    {
        _context.Islands.Update(entity);
        await _context.SaveChangesAsync();
    }
}
