using Academy.Application.Abstractions.Authentication;
using Academy.Application.Abstractions.Persistence;
using Academy.Infrastructure.Authentication;
using Academy.Infrastructure.Data;
using Academy.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Academy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AcademyDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IIslandRepository, IslandRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<ILevelRepository, LevelRepository>();
        services.AddScoped<ITutorialRepository, TutorialRepository>();
        services.AddScoped<IQuizRepository, QuizRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuizAttemptRepository, QuizAttemptRepository>();
        services.AddScoped<IStudentProgressRepository, StudentProgressRepository>();
        services.AddScoped<IClassProgressRepository, ClassProgressRepository>();
        services.AddScoped<ITeachRepository, TeachRepository>();

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
