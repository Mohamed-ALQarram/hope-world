using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Auth.RegisterStudent;

public record RegisterStudentCommand(RegisterStudentDto Dto) : IRequest<StudentAuthResponseDto>;
