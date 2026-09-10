using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class SubjectRepository : ISubjectRepository
{
    private readonly AcademyDbContext _context;

    public SubjectRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<Subject?> GetByIdAsync(int id)
    {
        return await _context.Subjects.FindAsync(id);
    }

    public async Task<IEnumerable<Subject>> GetAllAsync()
    {
        return await _context.Subjects.ToListAsync();
    }

    public async Task AddAsync(Subject entity)
    {
        await _context.Subjects.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Subject entity)
    {
        _context.Subjects.Update(entity);
        await _context.SaveChangesAsync();
    }
}
