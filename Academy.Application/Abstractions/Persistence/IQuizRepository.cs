using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Persistence;

public interface IQuizRepository
{
    Task<Quiz?> GetByIdAsync(int id);
    Task<IEnumerable<Quiz>> GetByTutorialIdAsync(int tutorialId);
    Task AddAsync(Quiz entity);
}
