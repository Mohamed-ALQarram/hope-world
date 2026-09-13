using Academy.Application.Abstractions.Persistence;
using Academy.Domain.Entities;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Persistence.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly AcademyDbContext _context;

    public QuestionRepository(AcademyDbContext context)
    {
        _context = context;
    }

    public async Task<Question?> GetByIdAsync(int id)
    {
        return await _context.Questions.FindAsync(id);
    }

    public async Task<IEnumerable<Question>> GetByQuizIdAsync(int quizId)
    {
        return await _context.Questions.Where(q => q.QuizId == quizId).ToListAsync();
    }

    public async Task AddAsync(Question entity)
    {
        await _context.Questions.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Question entity)
    {
        _context.Questions.Update(entity);
        await _context.SaveChangesAsync();
    }
}
