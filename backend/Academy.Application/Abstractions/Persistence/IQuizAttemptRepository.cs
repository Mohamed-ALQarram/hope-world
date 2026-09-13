using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface IQuizAttemptRepository
{
    Task<QuizAttempt?> GetByIdAsync(int id);
    Task AddAsync(QuizAttempt entity);
    Task UpdateAsync(QuizAttempt entity);
}
