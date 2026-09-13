using Academy.Application.Abstractions.Authentication;
using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using Academy.Domain.Entities;
using MediatR;

namespace Academy.Application.Features.Auth.RegisterStudent;

public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, StudentAuthResponseDto>
{
    private readonly IClassRepository _classRepo;
    private readonly IStudentRepository _studentRepo;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterStudentCommandHandler(IClassRepository classRepo, IStudentRepository studentRepo, IJwtTokenGenerator jwtTokenGenerator)
    {
        _classRepo = classRepo;
        _studentRepo = studentRepo;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<StudentAuthResponseDto> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Dto.StudentName))
        {
            throw new ArgumentException("Student name is required.");
        }

        var nameParts = request.Dto.StudentName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (nameParts.Length != 3)
        {
            throw new ArgumentException("Student name must consist of exactly 3 names (e.g. First Second Third).");
        }

        if (string.IsNullOrWhiteSpace(request.Dto.ClassName))
        {
            throw new ArgumentException("Class name is required.");
        }

        var trimmedClassName = request.Dto.ClassName.Trim();
        var trimmedStudentName = string.Join(" ", nameParts);

        var existingClass = await _classRepo.GetByNameAsync(trimmedClassName);
        if (existingClass == null)
        {
            existingClass = new Class
            {
                ClassName = trimmedClassName,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
            await _classRepo.AddAsync(existingClass);
        }

        var existingStudent = await _studentRepo.GetByNameAndClassIdAsync(trimmedStudentName, existingClass.ClassId);
        if (existingStudent != null)
        {
            throw new InvalidOperationException("A student with this name is already registered in this class.");
        }

        var student = new Student
        {
            ClassId = existingClass.ClassId,
            StudentName = trimmedStudentName,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        await _studentRepo.AddAsync(student);

        var token = _jwtTokenGenerator.GenerateToken(student, existingClass.ClassName);

        return new StudentAuthResponseDto
        {
            StudentId = student.StudentId,
            StudentName = student.StudentName,
            ClassId = existingClass.ClassId,
            ClassName = existingClass.ClassName,
            Token = token
        };
    }
}
