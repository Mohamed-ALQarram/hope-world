using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Repositories;

public class QuizAttemptRepository : IQuizAttemptRepository
{
    private readonly AcademyDbContext _context;

    public QuizAttemptRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<QuizAttempt?> GetByIdAsync(int id)
    {
        return await _context.QuizAttempts
            .Include(qa => qa.QuestionAttempts)
            .FirstOrDefaultAsync(qa => qa.QuizAttemptId == id);
    }

    public async Task<IEnumerable<QuizAttempt>> GetByStudentIdAsync(int studentId)
    {
        return await _context.QuizAttempts.Where(qa => qa.StudentId == studentId).ToListAsync();
    }

    public async Task AddAsync(QuizAttempt entity)
    {
        await _context.QuizAttempts.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(QuizAttempt entity)
    {
        _context.QuizAttempts.Update(entity);
        await _context.SaveChangesAsync();
    }
}
