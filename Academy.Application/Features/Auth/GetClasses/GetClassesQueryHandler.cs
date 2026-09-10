using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Auth.GetClasses;

public class GetClassesQueryHandler : IRequestHandler<GetClassesQuery, IEnumerable<ClassLookupDto>>
{
    private readonly IClassRepository _classRepo;

    public GetClassesQueryHandler(IClassRepository classRepo)
    {
        _classRepo = classRepo;
    }

    public async Task<IEnumerable<ClassLookupDto>> Handle(GetClassesQuery request, CancellationToken cancellationToken)
    {
        var classes = await _classRepo.GetAllAsync();
        return classes.Select(c => new ClassLookupDto
        {
            ClassId = c.ClassId,
            ClassName = c.ClassName
        });
    }
}
