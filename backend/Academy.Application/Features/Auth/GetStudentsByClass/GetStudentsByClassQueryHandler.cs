using Academy.Application.Abstractions.Persistence;
using Academy.Application.DTOs;
using MediatR;

namespace Academy.Application.Features.Auth.GetStudentsByClass;

public class GetStudentsByClassQueryHandler : IRequestHandler<GetStudentsByClassQuery, IEnumerable<StudentLookupDto>>
{
    private readonly IStudentRepository _studentRepo;

    public GetStudentsByClassQueryHandler(IStudentRepository studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public async Task<IEnumerable<StudentLookupDto>> Handle(GetStudentsByClassQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentRepo.GetByClassIdAsync(request.ClassId);
        return students.Select(s => new StudentLookupDto
        {
            StudentId = s.StudentId,
            StudentName = s.StudentName
        });
    }
}
