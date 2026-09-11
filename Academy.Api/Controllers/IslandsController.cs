using Academy.Application.DTOs;
using Academy.Application.Features.Islands.CreateIsland;
using Academy.Application.Features.Islands.GetIslandHierarchy;
using Academy.Application.Features.Islands.GetIslands;
using MediatR;
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
}
