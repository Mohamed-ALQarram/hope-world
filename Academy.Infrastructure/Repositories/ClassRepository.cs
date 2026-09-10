using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class ClassRepository : IClassRepository
{
    private readonly AcademyDbContext _context;

    public ClassRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<Class?> GetByIdAsync(int id)
    {
        return await _context.Classes.FindAsync(id);
    }

    public async Task<Class?> GetByNameAsync(string className)
    {
        return await _context.Classes.FirstOrDefaultAsync(c => c.ClassName.ToLower() == className.ToLower());
    }

    public async Task<IEnumerable<Class>> GetAllAsync()
    {
        return await _context.Classes.ToListAsync();
    }

    public async Task AddAsync(Class entity)
    {
        await _context.Classes.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Class entity)
    {
        _context.Classes.Update(entity);
        await _context.SaveChangesAsync();
    }
}
