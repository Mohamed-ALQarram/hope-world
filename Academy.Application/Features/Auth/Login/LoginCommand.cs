using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Auth.Login;

public record LoginCommand(LoginRequestDto Dto) : IRequest<StudentAuthResponseDto>;
