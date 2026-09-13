using Academy.Domain.Entities;

namespace Academy.Application.Abstractions.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Student student, string className);
}
