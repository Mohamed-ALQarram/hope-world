using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Auth.GetStudentsByClass;

public record GetStudentsByClassQuery(int ClassId) : IRequest<IEnumerable<StudentLookupDto>>;
