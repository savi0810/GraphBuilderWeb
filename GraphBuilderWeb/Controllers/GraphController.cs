using GraphBuilderShared.Models;
using GraphBuilderWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GraphBuilderWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GraphController : ControllerBase
{
    private readonly IGraphCalculationService _calculationService;
    private readonly IFunctionParserService _parserService;

    public GraphController(
        IGraphCalculationService calculationService,
        IFunctionParserService parserService)
    {
        _calculationService = calculationService;
        _parserService = parserService;
    }

    [HttpPost("calculate")]
    public async Task<ActionResult<List<PointDTO>>> Calculate([FromBody] GraphRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Function))
                return BadRequest(new { error = "Function is required" });

            var validationResult = await _parserService.ValidateExpressionAsync(request.Function);
            if (!validationResult.IsValid)
                return BadRequest(new { error = validationResult.ErrorMessage });

            if (Math.Abs(request.ToX - request.FromX) < 0.0001)
            {
                request.FromX -= 5;
                request.ToX += 5;
            }
            var points = await _calculationService.CalculateFunctionAsync(
                request.Function,
                request.FromX,
                request.ToX,
                request.PointsCount);

            return Ok(points);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpPost("validate")]
    public async Task<ActionResult<ValidationResult>> Validate([FromBody] string request)
    {
        try
        {
            var result = await _parserService.ValidateExpressionAsync(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}

