using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Academy.Application.DTOs;
using Academy.Application.Features.Islands.CreateIsland;
using Academy.Application.Features.Islands.GetIslandHierarchy;
using Academy.Application.Features.Islands.GetIslands;
using Academy.Application.Features.Islands.GetStudentIslandProgress;
using Academy.Application.Features.Islands.UpdateStudentProgress;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IslandsController : ControllerBase
{
    private readonly IMediator _mediator;

    public IslandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetIslands()
    {
        var result = await _mediator.Send(new GetIslandsQuery());
        return Ok(result);
    }

    [HttpGet("hierarchy")]
    public async Task<IActionResult> GetHierarchy([FromQuery] int? islandId = null)
    {
        var result = await _mediator.Send(new GetIslandHierarchyQuery(islandId));
        return Ok(result);
    }

    [Authorize]
    [HttpGet("my-progress")]
    public async Task<IActionResult> GetMyProgress([FromQuery] int? islandId = null)
    {
        try
        {
            var studentId = GetStudentId();
            var result = await _mediator.Send(new GetStudentIslandProgressQuery(studentId, islandId));
            return Ok(result);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }

    [Authorize]
    [HttpPost("my-progress")]
    public async Task<IActionResult> UpdateMyProgress([FromBody] UpdateStudentProgressDto dto)
    {
        try
        {
            var studentId = GetStudentId();
            await _mediator.Send(new UpdateStudentProgressCommand(studentId, dto));
            return Ok(new { Message = "Student progress updated successfully" });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateIsland([FromBody] CreateIslandDto dto)
    {
        try
        {
            var id = await _mediator.Send(new CreateIslandCommand(dto.Name, dto.Description));
            return Ok(new { IslandId = id });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    private int GetStudentId()
    {
        var claimValue = User.FindFirstValue(ClaimTypes.NameIdentifier) 
                      ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);

        if (int.TryParse(claimValue, out var studentId))
        {
            return studentId;
        }

        throw new UnauthorizedAccessException("Invalid or missing Student ID in authentication token.");
    }
}
