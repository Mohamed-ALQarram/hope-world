using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Auth.GetClasses;

public record GetClassesQuery : IRequest<IEnumerable<ClassLookupDto>>;
