using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface IQuestionRepository
{
    Task<Question?> GetByIdAsync(int id);
    Task<IEnumerable<Question>> GetByQuizIdAsync(int quizId);
    Task AddAsync(Question entity);
}
