using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class InstructorRepository : IInstructorRepository
{
    private readonly AcademyDbContext _context;

    public InstructorRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<Instructor?> GetByIdAsync(int id)
    {
        return await _context.Instructors.FindAsync(id);
    }

    public async Task<IEnumerable<Instructor>> GetAllAsync()
    {
        return await _context.Instructors.ToListAsync();
    }

    public async Task AddAsync(Instructor entity)
    {
        await _context.Instructors.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Instructor entity)
    {
        _context.Instructors.Update(entity);
        await _context.SaveChangesAsync();
    }
}
