using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly AcademyDbContext _context;

    public QuizRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<Quiz?> GetByIdAsync(int id)
    {
        return await _context.Quizzes.FindAsync(id);
    }

    public async Task<IEnumerable<Quiz>> GetByTutorialIdAsync(int tutorialId)
    {
        return await _context.Quizzes.Where(q => q.TutorialId == tutorialId).ToListAsync();
    }

    public async Task AddAsync(Quiz entity)
    {
        await _context.Quizzes.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Quiz entity)
    {
        _context.Quizzes.Update(entity);
        await _context.SaveChangesAsync();
    }
}
