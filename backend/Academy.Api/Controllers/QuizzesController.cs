using Academy.Application.DTOs;
using Academy.Application.Features.Quizzes.CompleteQuizAttempt;
using Academy.Application.Features.Quizzes.StartQuizAttempt;
using Academy.Application.Features.Quizzes.SubmitQuestionAnswer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizzesController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuizzesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{quizId}/attempts")]
    public async Task<IActionResult> StartAttempt(int quizId, [FromQuery] int studentId)
    {
        try
        {
            var attemptId = await _mediator.Send(new StartQuizAttemptCommand(studentId, quizId));
            return Ok(new { AttemptId = attemptId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPost("attempts/{attemptId}/answers")]
    public async Task<IActionResult> SubmitAnswer(int attemptId, [FromBody] QuestionAnswerDto dto)
    {
        try
        {
            await _mediator.Send(new SubmitQuestionAnswerCommand(attemptId, dto));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPost("attempts/{attemptId}/complete")]
    public async Task<IActionResult> CompleteAttempt(int attemptId)
    {
        try
        {
            var result = await _mediator.Send(new CompleteQuizAttemptCommand(attemptId));
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}
