using Academy.Application.DTOs;
using Academy.Application.Features.Auth.GetClasses;
using Academy.Application.Features.Auth.GetStudentsByClass;
using Academy.Application.Features.Auth.Login;
using Academy.Application.Features.Auth.RegisterStudent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterStudentDto dto)
    {
        try
        {
            var response = await _mediator.Send(new RegisterStudentCommand(dto));
            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }

    [HttpGet("classes")]
    public async Task<IActionResult> GetClasses()
    {
        try
        {
            var classes = await _mediator.Send(new GetClassesQuery());
            return Ok(classes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }

    [HttpGet("classes/{classId}/students")]
    public async Task<IActionResult> GetStudentsByClass(int classId)
    {
        try
        {
            var students = await _mediator.Send(new GetStudentsByClassQuery(classId));
            return Ok(students);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        try
        {
            var response = await _mediator.Send(new LoginCommand(dto));
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }
}
