using Academy.Application.Abstractions.Authentication;
using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, StudentAuthResponseDto>
{
    private readonly IStudentRepository _studentRepo;
    private readonly IClassRepository _classRepo;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(IStudentRepository studentRepo, IClassRepository classRepo, IJwtTokenGenerator jwtTokenGenerator)
    {
        _studentRepo = studentRepo;
        _classRepo = classRepo;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<StudentAuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepo.GetByIdAsync(request.Dto.StudentId);
        if (student == null || student.ClassId != request.Dto.ClassId)
        {
            throw new InvalidOperationException("Invalid student selection or student does not belong to the specified class.");
        }

        var studentClass = student.Class ?? await _classRepo.GetByIdAsync(student.ClassId);
        var className = studentClass?.ClassName ?? string.Empty;

        var token = _jwtTokenGenerator.GenerateToken(student, className);

        return new StudentAuthResponseDto
        {
            StudentId = student.StudentId,
            StudentName = student.StudentName,
            ClassId = student.ClassId,
            ClassName = className,
            Token = token
        };
    }
}
